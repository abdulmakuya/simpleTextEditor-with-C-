using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_text_editor
{
    public partial class Form1 : Form
    {
        string fn = "";//file name variable

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //set default font to the text
            richTextBox1.Font = new Font("Arial", 12, FontStyle.Regular);

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                //Choose file to open
                openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                openFileDialog1.Multiselect = false;
                openFileDialog1.ShowDialog();

                fn = openFileDialog1.FileName;

                richTextBox1.Text = readText(fn);

            }
            catch (FileNotFoundException ex) { }

        }

        private string readText(string fn)
        {
            //read file content and place it in the RichTextBox
            string content = null;
            if (fn != null)
            {
                FileStream fs = new FileStream(fn, FileMode.Open, FileAccess.Read);
                StreamReader fr = new StreamReader(fs);

                content = fr.ReadToEnd();
                fs.Close();
            }
            return content;
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            //open font dialog box
            fontDialog1.ShowDialog();

            //Textbox doesnot contain fields SelectionFont or SelecetionColor
            richTextBox1.SelectionFont = fontDialog1.Font;
            richTextBox1.SelectionColor = fontDialog1.Color;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            //Open color dialog box
            colorDialog1.ShowDialog();
            richTextBox1.SelectionColor = colorDialog1.Color;
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //save to existing file
            if (fn != "")
                richTextBox1.SaveFile(fn, RichTextBoxStreamType.PlainText);
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //resize the controls when the form resizes
            richTextBox1.Width = this.Width - 60;
            richTextBox1.Height = this.Height - 100;
        }
                
    }
}