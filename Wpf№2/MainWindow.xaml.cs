using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;


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
            items.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            items1.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            MessageBox.Show("Привет");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }

        private void afas_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void afas_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = afas.Selection.GetPropertyValue(Inline.FontWeightProperty);

            bolt.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = afas.Selection.GetPropertyValue(Inline.FontStyleProperty);
            italic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = afas.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            underliune.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = afas.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            items.SelectedItem = temp;
            temp = afas.Selection.GetPropertyValue(Inline.FontSizeProperty);
            items1.Text = temp.ToString();

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (items.SelectedItem != null)
                afas.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, items.SelectedItem);

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            afas.Selection.ApplyPropertyValue(Inline.FontSizeProperty, items1.SelectedItem);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
                TextRange range = new TextRange(afas.Document.ContentStart, afas.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Rtf);
            }
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                TextRange range = new TextRange(afas.Document.ContentStart, afas.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
            }
        }
        
        
    }
}
