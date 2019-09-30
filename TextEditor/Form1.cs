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

namespace TextEditor
{
    public partial class Form1 : Form
    {
        string FileName;
        string PrevText;
        public Form1()
        {
            InitializeComponent();
            FileName = "new";
            PrevText = richTextBox1.Text;
            this.Text = "Text Editor (new)";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                if (PrevText != richTextBox1.Text)
                {
                    if (MessageBox.Show("Would you like to save the file now?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (FileName != "new")
                        {
                            File.WriteAllText(FileName, richTextBox1.Text);
                            richTextBox1.Clear();
                        }
                        else
                        {
                            SaveFileDialog SaveFile = new SaveFileDialog();
                            SaveFile.Filter = "Text Files | *.txt";
                            SaveFile.Title = "Save a file...";
                            if (SaveFile.ShowDialog() == DialogResult.OK)
                            {
                                File.WriteAllText(SaveFile.FileName, richTextBox1.Text);
                            }
                            richTextBox1.Clear();
                        }
                    }
                    else
                    {
                        richTextBox1.Clear();
                    }
                }
                else
                {
                    richTextBox1.Clear();
                }
            }
            else
                richTextBox1.Clear();
            FileName = "new";
            this.Text = "Text Editor (new)";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PrevText != richTextBox1.Text)
            {
                if (MessageBox.Show("Would you like to save the file now?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (FileName != "new")
                    {
                        File.WriteAllText(FileName, richTextBox1.Text);
                    }
                    else
                    {
                        SaveFileDialog SaveFile = new SaveFileDialog();
                        SaveFile.Filter = "Text Files | *.txt";
                        SaveFile.Title = "Save a file...";
                        if (SaveFile.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllText(SaveFile.FileName, richTextBox1.Text);
                        }
                    }
                }
            }
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PrevText != richTextBox1.Text)
            {
                if (richTextBox1.Text.Length > 0)
                {
                    if (MessageBox.Show("Would you like to save the file now?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (FileName != "new")
                        {
                            File.WriteAllText(FileName, richTextBox1.Text);
                            richTextBox1.Clear();
                            OpenFileDialog OpenFile = new OpenFileDialog();
                            OpenFile.Filter = "Text Files | *.txt";
                            OpenFile.Title = "Open a file...";
                            if (OpenFile.ShowDialog() == DialogResult.OK)
                            {
                                FileName = OpenFile.FileName;
                                StreamReader SR = new StreamReader(OpenFile.FileName);
                                richTextBox1.Text = SR.ReadToEnd();
                                SR.Close();
                            }
                        }
                        else
                        {
                            SaveFileDialog SaveFile = new SaveFileDialog();
                            SaveFile.Filter = "Text Files | *.txt";
                            SaveFile.Title = "Save a file...";
                            if (SaveFile.ShowDialog() == DialogResult.OK)
                            {
                                File.WriteAllText(SaveFile.FileName, richTextBox1.Text);
                            }
                            richTextBox1.Clear();
                            OpenFileDialog OpenFile = new OpenFileDialog();
                            OpenFile.Filter = "Text Files | *.txt";
                            OpenFile.Title = "Open a file...";
                            if (OpenFile.ShowDialog() == DialogResult.OK)
                            {
                                FileName = OpenFile.FileName;
                                StreamReader SR = new StreamReader(OpenFile.FileName);
                                richTextBox1.Text = SR.ReadToEnd();
                                SR.Close();
                            }
                        }
                    }
                    else
                    {
                        richTextBox1.Clear();
                        OpenFileDialog OpenFile = new OpenFileDialog();
                        OpenFile.Filter = "Text Files | *.txt";
                        OpenFile.Title = "Open a file...";
                        if (OpenFile.ShowDialog() == DialogResult.OK)
                        {
                            FileName = OpenFile.FileName;
                            StreamReader SR = new StreamReader(OpenFile.FileName);
                            richTextBox1.Text = SR.ReadToEnd();
                            SR.Close();
                        }
                    }
                    PrevText = richTextBox1.Text;
                }
                else
                {
                    OpenFileDialog OpenFile = new OpenFileDialog();
                    OpenFile.Filter = "Text Files | *.txt";
                    OpenFile.Title = "Open a file...";
                    if (OpenFile.ShowDialog() == DialogResult.OK)
                    {
                        FileName = OpenFile.FileName;
                        StreamReader SR = new StreamReader(OpenFile.FileName);
                        richTextBox1.Text = SR.ReadToEnd();
                        SR.Close();
                    }
                    PrevText = richTextBox1.Text;
                }
            }
            else
            {
                OpenFileDialog OpenFile = new OpenFileDialog();
                OpenFile.Filter = "Text Files | *.txt";
                OpenFile.Title = "Open a file...";
                if (OpenFile.ShowDialog() == DialogResult.OK)
                {
                    FileName = OpenFile.FileName;
                    StreamReader SR = new StreamReader(OpenFile.FileName);
                    richTextBox1.Text = SR.ReadToEnd();
                    SR.Close();
                }
                PrevText = richTextBox1.Text;
            }
            this.Text = "Text Editor (" + FileName + ")";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileName == "new")
            {
                SaveFileDialog SaveFile = new SaveFileDialog();
                SaveFile.Filter = "Text Files | *.txt";
                SaveFile.Title = "Save a file...";
                if (SaveFile.ShowDialog() == DialogResult.OK)
                {
                    FileName = SaveFile.FileName;
                    StreamWriter SW = new StreamWriter(SaveFile.FileName);
                    SW.Write(richTextBox1.Text);
                    SW.Close();
                }
            }
            else
            {
                StreamWriter SW = new StreamWriter(FileName);
                SW.Write(richTextBox1.Text);
                SW.Close();
            }
            PrevText = richTextBox1.Text;
            this.Text = "Text Editor (" + FileName + ")";
        }
        private void SaveAstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.Filter = "Text Files | *.txt";
            SaveFile.Title = "Save a file...";
            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                FileName = SaveFile.FileName;
                StreamWriter SW = new StreamWriter(SaveFile.FileName);
                SW.Write(richTextBox1.Text);
                SW.Close();
            }
            PrevText = richTextBox1.Text;
            this.Text = "Text Editor (" + FileName + ")";
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog FontD = new FontDialog();
            FontD.Font = new Font(richTextBox1.Font, FontStyle.Regular);
            if (FontD.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = FontD.Font;
            }
        }

        private void ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog ColorD = new ColorDialog();
            ColorD.Color = richTextBox1.ForeColor;
            if (ColorD.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = ColorD.Color;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("    This program is made by group 6\n\n     In Adv. Computer Programming\n\n               Naresuan University.", "About...", MessageBoxButtons.OK);
        }
    }
}
