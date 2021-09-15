using System;
using System.Collections.Generic;
using System.Text;

namespace proba0
{
    public class Spoon
    {
        private Diner owner;
        public Spoon(Diner d) { owner = d; }
        public Diner getOwner() { return owner; }
        public void setOwner(Diner d) { owner = d; }
        public void use()
        {
            Console.WriteLine("%s has eaten!", owner.getName());
        }
    }
}
