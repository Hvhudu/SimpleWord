using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Menu
{
    public partial class Form1 : Form
    {
        Color c;
        public Form1()
        {
            this.Size = this.MaximumSize = this.MinimumSize;
            InitializeComponent();
            c = this.BackColor;
            menuStripRu.Visible = false;
            but_leng.Text = "English";
            size.Value = (decimal)richTextBox1.Font.Size;
            string path = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem it = (ToolStripMenuItem)sender;
            if (it.Checked == true) BackColor = Color.Red;
            else BackColor = c;
        }

       
        private void but_leng_Click(object sender, EventArgs e)
        {
            if(but_leng.Text.CompareTo("English")==0)
            {
                but_leng.Text = "Русский";
                menuStripRu.Visible = true;
                menuStripEn.Visible = false;
                this.MainMenuStrip = menuStripRu;
            }
            else
            {
                but_leng.Text = "English";
                menuStripRu.Visible = false;
                menuStripEn.Visible = true;
                this.MainMenuStrip = menuStripEn;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files (.txt)| *.txt| All Files(*.*)" +
                                    "|*.*";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName == "") return;
                else
                {
                    string temp = openFileDialog1.FileName;
                    using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                    {
                        richTextBox1.Text = sr.ReadToEnd();
                    }

                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string temp = openFileDialog1.FileName;
                //openFileDialog1.CheckPathExists()
                if (saveFileDialog1.FileName == "") return;
                else
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                    {
                        sw.Write(richTextBox1.Text);
                    }
                }
                if (saveFileDialog1.FileName == temp)
                {
                    using (StreamWriter sw = new StreamWriter(temp))
                    {
                        sw.Write(richTextBox1.Text);
                    }
                }
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowHelp = false;
            fontDialog1.Font = richTextBox1.SelectionFont;
            if(fontDialog1.ShowDialog()==DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = richTextBox1.SelectionColor;
            if(cd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = cd.Color;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Size_ValueChanged(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily,
                                         (float)size.Value,
                                         richTextBox1.Font.Style,
                                         GraphicsUnit.Point);
        }

        private void Bolt_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Bold == true)
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont,
                                                  FontStyle.Regular);
            else richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont,
                                                  FontStyle.Bold);
        }

        private void Italic_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Italic == true)
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont,
                                                  FontStyle.Regular);
            else richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont,
                                                  FontStyle.Italic);
        }

        private void Underline_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Underline == true)
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont,
                                                  FontStyle.Regular);
            else richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont,
                                                  FontStyle.Underline);
        }

        private void clear_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
    }
}
