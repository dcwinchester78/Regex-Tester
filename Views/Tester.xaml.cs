using RegexTesterUI.ViewModels;
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
using System.Windows.Shapes;
using RegexTesterUI.Data;
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.Win32;
using System.IO;


namespace RegexTesterUI.Views
{
    /// <summary>
    /// Interaction logic for Tester.xaml
    /// </summary>
    public partial class Tester : Window
    {
        TesterViewModel tvm;

        public Tester()
        {
            InitializeComponent();
            tvm = new TesterViewModel(Factory.GetRegex());
            DataContext = tvm;
        }

       //Close application
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #region Load_Data

        //Load data from local machine
        private void LoadFileData_Click(object sender, RoutedEventArgs e)
        {
            IData data = Factory.GetData();        
            tvm.LoadData(data.DataFromSource(), data.Path);
        }
   
        //Load data via http request
        private void LoadWebData_Click(object sender, RoutedEventArgs e)
        {
            IData data;
            string text = txtAddress.Text.ToLower();
            if (!String.IsNullOrWhiteSpace(text) && text.StartsWith("http"))
            {
                data = Factory.GetData(text);               
                tvm.LoadData(data.DataFromSource(), data.Path);
            }           
        }

        #endregion

        #region Clear_Textboxes

        private void ClearMultipleRegexPattern_Click(object sender, RoutedEventArgs e)
        {
            txtMultipleRegexPattern.Text = "";
            txtMultipleRegexPattern.Focus();
        }

        private void ClearSingleRegPattern_Click(object sender, RoutedEventArgs e)
        {
            txtSingleRegPattern.Text = "";
            txtSingleRegPattern.Focus();
        }

        private void ClearSingleContent_Click(object sender, RoutedEventArgs e)
        {
            txtSingleContent.Text = "";
            txtSingleContent.Focus();
        }

        private void ClearAddress_Click(object sender, RoutedEventArgs e)
        {
            txtAddress.Text = "";
            txtAddress.Focus();
        }

        #endregion

    }
}
