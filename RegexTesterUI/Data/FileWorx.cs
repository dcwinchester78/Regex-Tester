using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace RegexTesterUI.Data
{
    public class FileWorx : IData
    {
        public string Path { get; set; }

        public FileWorx()
        {
            
        }

        public string DataFromSource()
        {
            var openFileDialog = new OpenFileDialog();

            try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    if (openFileDialog.FileName != "")
                    {
                        Path = openFileDialog.FileName;

                        string readText = File.ReadAllText(openFileDialog.FileName);

                     //MessageBox.Show(readText);
                        return readText;


                    }
                }
            }
            catch(FileLoadException ex)
            {

            }
            

            return "File not found";
        }
    }
}
