using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace proba0
{
    public class Diner
    {
        private String name;
        private bool isHungry = true;

        public Diner(String n) { name = n; }
        public String getName() { return name; }
        public bool IsHungry() { return isHungry; }

        public async Task eatWithLiveLock(Spoon spoon, Diner spouse)
        {
            while (isHungry)
            {

                // Don't have the spoon, so wait patiently for spouse.
                if (spoon.getOwner() != this)
                {
                    try { Thread.Sleep(1); }
                    catch (Exception e) { continue; }
                    continue;
                }

                // If spouse is hungry, insist upon passing the spoon.
                if (spouse.IsHungry())
                {
                    Win2.convLock.Add(name + ": You eat first my darling " +
                         spouse.getName() + "!");
                    spoon.setOwner(spouse);
                    continue;
                }

                // Spouse wasn't hungry, so finally eat
                spoon.use();
                isHungry = false;
                Win2.convLock.Add(name + " I am stuffed , my darling " + spouse.getName() + "!");
                spoon.setOwner(spouse);
            }
        }



        public async Task eatWith(Spoon spoon, Diner spouse)
        {
             int counter = 0;

            while (isHungry)
            {

                // Don't have the spoon, so wait patiently for spouse.
                if (spoon.getOwner() != this)
                {
                    try { Thread.Sleep(1); }
                    catch (Exception e) { continue; }
                    continue;
                }

                // If spouse is hungry, insist upon passing the spoon.
                if (spouse.IsHungry() && counter<1)
                {
                    Win2.convNoLock.Add(name + ": You eat first my darling " +
                         spouse.getName() + "!");
                    spoon.setOwner(spouse);
                    counter++;
                    continue;
                }

                // Spouse wasn't hungry, so finally eat
                spoon.use();
                isHungry = false;
                Win2.convNoLock.Add(name + " I am stuffed , my darling " + spouse.getName() + "!");
                spoon.setOwner(spouse);
            }
        }


    }
}
