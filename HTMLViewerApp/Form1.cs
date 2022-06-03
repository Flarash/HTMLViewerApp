using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTMLViewerApp
{
    public partial class Form1 : Form
    {

        private static OpenFileDialog filePicker;
        private Dictionary<String, String> filesSelected = new Dictionary<String, String>();

        public Form1()
        {
            InitializeComponent();
            filePicker = new FilePickerConstructor().getFilePicker();
            listBox1.SelectionMode = SelectionMode.One;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(filePicker.ShowDialog() == DialogResult.OK)
            {
                try 
                {
                    var filePath = filePicker.FileName;

                    if (!filePath.EndsWith(".html") && !filePath.EndsWith("\\"))
                    {
                        MessageBox.Show($"Not a valid format. Please select an HTML file.\nDetails: {filePath}");
                    }

                    AddFileToListBox(filePath);
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string s = listBox1.SelectedItem.ToString().Split().First();
            s = s.Remove(0, 1);
            s = s.Remove(s.Length - 1, 1);
            webBrowser1.Navigate(filesSelected.ElementAt(Int32.Parse(s)-1).Key);
        }

        private void AddFileToListBox(string filePath)
        {
            if (filesSelected.ContainsKey(filePath))
            {
                MessageBox.Show($"File already imported.\nDetails: {filePath}");
                return;
            }

            try
            {
                filesSelected[filePath] = Path.GetFileName(filePath);

                listBox1.BeginUpdate();
                listBox1.Items.Add("(" + filesSelected.Count + ") " + Path.GetFileName(filePath) + " [" + filePath + "]");

                listBox1.EndUpdate();
                listBox1.SetSelected(listBox1.Items.Count-1, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception Details: {ex}");
                return;
            }
        }
    }
}
