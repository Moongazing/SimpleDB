using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AraSınavÖdevi
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi="admin";
            string sifre="123";
            if (kullaniciAdi=="admin"&& sifre=="123")
            {
                
                anaMenü anaProgram = new anaMenü();
                this.Hide();
                anaProgram.Show();
               
            }
            
            else
            {
                MessageBox.Show("Kullanıcı Adı Veya Şifre Yanlış");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                checkBox1.Text = "Parolayı Gizle";
                
                textBox2.PasswordChar = '\0';
            }
            else
            {
                checkBox1.Text = "Parolayı Göster";
                textBox2.PasswordChar = '*';
            }
        }
    }
}
