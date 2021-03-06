using System.Windows;
using System.Windows.Controls;

namespace Ch08Ex01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = "Clicked!";
            Button newButton = new Button();
            newButton.Content = "New Button!";
            newButton.Margin = new Thickness(10, 10, 200, 200);
            newButton.Click += NewButton_Click;
            ((Grid)((Button)sender).Parent).Children.Add(newButton);
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = "Clicked!!";
        }
    }
}
