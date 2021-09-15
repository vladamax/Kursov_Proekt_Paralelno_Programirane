using Microsoft.Build.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
    public partial class Win2 : INotifyPropertyChanged
    {
        public static List<string> convLock = new List<string>();
        public static List<string> convNoLock = new List<string>();


        public Win2()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            convNoLock.Clear();

            Diner husband = new Diner("Bob");
            Diner wife = new Diner("Alice");

            Spoon s = new Spoon(husband);


            Task t1 = Task.Factory.StartNew(() => husband.eatWith(s, wife));

            Task t2 = Task.Factory.StartNew(() => wife.eatWith(s, husband));

            await Task.Delay(150);

            lista.ItemsSource = convNoLock;
        }


        private async void Button_Click_LiveLock(object sender, RoutedEventArgs e)
        {

            lista.ItemsSource = null;
            convLock.Clear();

            Diner husband = new Diner("Bob");
            Diner wife = new Diner("Alice");

            Spoon s = new Spoon(husband);


            Task t1 = Task.Factory.StartNew(() => husband.eatWithLiveLock(s, wife));

            Task t2 = Task.Factory.StartNew(() => wife.eatWithLiveLock(s, husband));

            MessageBox.Show("This is a livelock !");

            await Task.Delay(150);

            lista.ItemsSource = convLock;
        }


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}