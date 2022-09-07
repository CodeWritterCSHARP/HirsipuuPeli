using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hirsipuu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string sana = "";
        string newsana = "";
        string[] filepath = {
            $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\1.png",
            $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\2.png",
            $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\3.png",
            $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\4.png",
            $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\5.png"
        };
        List<char> aakkoset = new List<char>();

        int counter = -1;

        CheckBox ck;

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.ToLower();
            sana = textBox1.Text;
            newsana = textBox2.Text;

            if(counter > 3) MessageBox.Show("Sinä hävitset, yritä vielä kerran");
            if (string.IsNullOrEmpty(sana)) MessageBox.Show("Rivi ei voi olla tyhjää");
            else
            {
                if (sana == newsana && !string.IsNullOrEmpty(sana)) MessageBox.Show("Voito!!!");
                else
                {
                    if(aakkoset.Count == 0)
                    {
                        bool checker = false;
                        for (int i = 0; i < textBox1.Text.Length; i++)
                        {
                            if (char.IsDigit(textBox1.Text[i]))
                            {
                                MessageBox.Show("Ei voi olla numeroita");
                                checker = true;
                                break;
                            }
                        }
                        if(checker == false)
                        {
                            for (int i = 0; i < textBox1.Text.Length; i++)
                            {
                                aakkoset.Add(textBox1.Text[i]);
                            }
                        }
                    }
                    if (aakkoset.Count != 0)
                    {
                        int k = 0;
                        foreach (var item in this.Controls.OfType<CheckBox>())
                        {
                            if(k > 1)
                            {
                                MessageBox.Show("Valitse yksi kirjain");
                                break;
                            }
                            if(item.Checked == true)
                            {
                                ck = item;
                                k++;
                            }
                        }
                        if (k <= 1)
                        {
                            if(k == 0) MessageBox.Show("Valitse yksi kirjain");
                            else
                            {
                                textBox1.ReadOnly = true;
                                if (aakkoset.Contains(Convert.ToChar(ck.Text.ToLower())))
                                {
                                    string btwsana = "";
                                    for (int i = 0; i < textBox1.Text.Length; i++)
                                    {
                                        if (textBox1.Text[i] == Convert.ToChar(ck.Text.ToLower())) { btwsana += textBox1.Text[i]; }
                                        else btwsana += "_";
                                    }
                                    if (string.IsNullOrEmpty(newsana)) { newsana = btwsana; }
                                    else
                                    {
                                        string bs = "";
                                        for (int i = 0; i < btwsana.Length; i++)
                                        {
                                            if (btwsana[i] != '_') bs += btwsana[i];
                                            else bs += newsana[i];
                                        }
                                        newsana = bs;
                                    }
                                    textBox2.Text = newsana;
                                    label3.Text += ck.Text + Environment.NewLine;
                                    ck.Checked = false;
                                    ck.Enabled = false;
                                }
                                else
                                {
                                    label3.Text += ck.Text + Environment.NewLine;
                                    ck.Checked = false;
                                    ck.Enabled = false;
                                    counter ++;
                                    this.pictureBox1.Image = Image.FromFile(filepath[counter]);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
