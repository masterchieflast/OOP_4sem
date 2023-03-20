using System.Windows;
using System.Windows.Input;

namespace Lab07
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var binding = new CommandBinding(Commands.Visible);
            binding.Executed += CommandBinding_Executed;

            CommandBindings.Add(binding);
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            grid4.Visibility = grid4.Visibility == Visibility.Collapsed ?
                Visibility.Visible : Visibility.Collapsed;
        }


        private void Button_MouseDown(object sender, RoutedEventArgs e)
        {
            biba.Text += "sender: " + sender + "\n";
            biba.Text += "source: " + e.Source + "\n";
        }

        private void Button_PreviewMouseDown(object sender, RoutedEventArgs e)
        {
            boba.Text += "sender: " + sender + "\n";
            boba.Text += "source: " + e.Source + "\n";
        }


        private void Button_MouseDown1(object sender, RoutedEventArgs e)
        {
            text.Text += "sender: " + sender + "\n";
            text.Text += "source: " + e.Source + "\n";
        }
    }
}
