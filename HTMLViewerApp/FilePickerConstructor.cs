using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTMLViewerApp
{
    class FilePickerConstructor 
    {
        private OpenFileDialog openFileDialog;

        public FilePickerConstructor() 
        {
            openFileDialog = new OpenFileDialog() 
            {
                FileName = "Select Folder or File",
                Filter = "HTML files (*.html)|*.html",
                Title = "Open HTML File"
            };

        }

        public OpenFileDialog getFilePicker()
        {
            return this.openFileDialog;
        }
    }
}
