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
using System.Drawing;


namespace Wpf_2
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {
            InitializeComponent();
            
            afas.FontSize = 10;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            MessageBox.Show(menuItem.Header.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

           
        }

        private void afas_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void rtbEditor_SelectionChanged(object sender,RoutedEventArgs e)
        {
            
        }

        private void afas_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = afas.Selection.GetPropertyValue(Inline.FontWeightProperty);
            
        }
    }
}
