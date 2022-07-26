using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using swinAdventure;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GUIbase gU;
        public MainWindow()
        {
            InitializeComponent();
            gU = new GUIbase();
            Console.Text = gU.Output;
        }

        private void EnterClick(object sender, RoutedEventArgs e)
        {
            Console.Text = "\n" + gU.Inputcommand(commandBox.Text);
            commandBox.Clear();
            if (Console.Text == "\nbye!")
            {
                App.Current.Shutdown();
            }
        }
        private void TextChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
