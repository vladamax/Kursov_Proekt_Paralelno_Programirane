using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace proba0
{
    /// <summary>
    /// Interaction logic for Win3.xaml
    /// </summary>
    public partial class Win3 : Window
    {
        public Win3()
        {
            InitializeComponent();
        }

        private async Task PrepareTheCoffee()
        {
            lblResult.Content = "Preparing the coffee...";
            await Task.Delay(1000);
            lblResult.Content = "Cofee has been prepared.";
        }

        private async void NoDeadLock(object sender, RoutedEventArgs e)
        {
            await PrepareTheCoffee();

            await Task.Delay(1000);

            lblResult.Content = "Please take your coffee :)";
        }

        private void DeadLock(object sender, RoutedEventArgs e)
        {
            // Deadlock

            var task = PrepareTheCoffee();
            task.Wait();

            lblResult.Content = "Please take your coffee :)";
        }
    }
}
