using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


namespace AraSınavÖdevi
{
    public partial class güncelle : Form
    {
 
        public güncelle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=hastaKayitlari.accdb;");
        OleDbCommand komut = new OleDbCommand();
        DataTable tablo=new DataTable();
        DataSet ds = new DataSet();
        string hastaCinsiyet;
        

        private void button1_Click(object sender, EventArgs e)
        {
            anaMenü anaProgram = new anaMenü();
            this.Hide();
            anaProgram.Show();
        }

        private void verileriGoster_Load(object sender, EventArgs e)
        {   baglanti.Open();

            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From hastalar", baglanti);
            adtr.Fill(ds, "hastalar");
           
            
            dataGridView1.DataSource = ds.Tables["hastalar"];
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int cevap;
            cevap = Convert.ToInt32(MessageBox.Show("Çıkmak İstiyor Musunuz?", "Çıkış", MessageBoxButtons.YesNo));
            if (cevap == 6)//6 evet döndürür
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                hastaCinsiyet = "E";

            }
            else
            {
                hastaCinsiyet = "K";

            }

            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "UPDATE hastalar SET hastaAd='" + textBox2.Text + "',hastaSoyad='" + textBox3.Text + "',hastaTelefon='" + textBox4.Text + "',hastaCinsiyet='" + hastaCinsiyet + "' WHERE hastaTc='" + textBox1.Text + "'";
            int sonuc = komut.ExecuteNonQuery();
      
            MessageBox.Show("Kayıt Güncellendi");
            komut.Dispose();
            baglanti.Close();



            baglanti.Open();
            DataSet dtst = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From hastalar ", baglanti);
            adtr.Fill(dtst, "hastalar");
            dataGridView1.DataSource = dtst.Tables["hastalar"];
            adtr.Dispose();
            baglanti.Close();
           
            //baglanti.Open();
            //OleDbCommand komut = new OleDbCommand();
            //komut.Connection = baglanti;
            
            //komut.CommandText = "UPDATE hastalar SET hastaAd='" + textBox2.Text + "',hastaSoyad='" + textBox3.Text + "',hastaTel='" + textBox4.Text + "' WHERE hastaTc='"+textBox1.Text+"'";
            //int sonuc = komut.ExecuteNonQuery();
            //komut.Dispose();
            //baglanti.Close();

            //if (radioButton1.Checked == true)
            //{
            //    hastaCinsiyet = "E";
            //    komut.CommandText = "UPDATE hastalar SET hastaCinsiyeti='" + hastaCinsiyet + "'WHERE hastaTc='"+textBox1.Text+"'";
            //}
            //else
            //{
            //    hastaCinsiyet = "K";
            //    komut.CommandText = "UPDATE hastalar SET hastaCinsiyeti='" + hastaCinsiyet + "' WHERE hastaTc='" + textBox1.Text + "'";
            //}

            //int sonuc = komut.ExecuteNonQuery();
            //if (sonuc==1)
            //{
            //    MessageBox.Show("Kayıt Güncellendi");
            //}
           
            
            //komut.Dispose();
            //baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "E")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = false;
            }

        }
    }
}
