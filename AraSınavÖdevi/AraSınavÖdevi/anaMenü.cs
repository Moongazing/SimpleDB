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
    public partial class anaMenü : Form
    {
        public anaMenü()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=hastaKayitlari.accdb");
        OleDbCommand komut = new OleDbCommand();
        DataTable tablo = new DataTable();
        DataSet ds = new DataSet();
        string hastaTc;
        string hastaAd;
        string hastaSoyad;
        string hastaTelefon;
        string hastaCinsiyet;
        string silinecek;
        DateTime tarih;
        public void kayıtEkleme()
        {


            if (textBox1.TextLength == 11)//tc uzunluğu 11 olmalı
            {
                if (Convert.ToInt64(textBox1.Text) % 2 == 0)//tc çift olmalı
                {
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "SELECT count(*) FROM hastalar WHERE hastaTc='" + hastaTc + "'";// aynı pk var mı kontrol
                    int sonuc = Convert.ToInt32(komut.ExecuteScalar());
                    if (sonuc > 0)
                    {
                        MessageBox.Show("Kayıt Zaten Var ");
                    }
                    else
                    {
                        komut.CommandText = "INSERT INTO hastalar (hastaTc,hastaAd,hastaSoyad,hastaTelefon,hastaCinsiyet,kayıtTarih) VALUES('" + hastaTc + "','" + hastaAd + "','" + hastaSoyad + "','" + hastaTelefon + "','" + hastaCinsiyet + "','" + tarih + "')";
                        komut.ExecuteNonQuery();
                        komut.Dispose();
                        baglanti.Close();
                        MessageBox.Show("Kayıt Tamamlandı.");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";


                        if (radioButton1.Checked == true)
                        {
                            radioButton1.Checked = false;
                        }
                        else
                        {
                            radioButton2.Checked = false;
                        }


                    }
                }
                else
                    MessageBox.Show("T.C. Yanlış");//tc çift bitmeli
            }
            else
                MessageBox.Show("T.C. Kimlik Numaranız 11 Haneli Olmalı.");
        
        }
        public void kayitSilme()
    {

        silinecek = textBox5.Text;
        baglanti.Open();
        komut.Connection = baglanti;
        komut.CommandText = "DELETE FROM hastalar Where hastaTc='" + silinecek + "'";
        int sonuc = komut.ExecuteNonQuery();//sayi döndür kayıt var mı yok mu
        komut.Dispose();
        baglanti.Close();
        if (sonuc == 0)
        {
            MessageBox.Show("Silinecek Kayıt Bulunamadı");
            textBox1.Focus();
            textBox1.SelectAll();
        }
        else
            MessageBox.Show(sonuc + "adet kayıt silindi");

    
    
    }
        public void dataGridGüncelle()
        {
            baglanti.Open();
            DataSet dtst = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From hastalar ", baglanti);
            adtr.Fill(dtst, "hastalar");
            dataGridView1.DataSource = dtst.Tables["hastalar"];
            adtr.Dispose();
            baglanti.Close();
        
        
        }
           
    
        private void button1_Click(object sender, EventArgs e)
        {//kayıt ekleme
            tarih = dateTimePicker1.Value;
            
           hastaTc = textBox1.Text;
           hastaAd = textBox2.Text;
           hastaSoyad = textBox3.Text;
           hastaTelefon = textBox4.Text;
           hastaCinsiyet = " ";
            if (radioButton1.Checked == true) hastaCinsiyet = "E";
            if (radioButton2.Checked == true) hastaCinsiyet = "K";
            kayıtEkleme();
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kayitSilme();
            dataGridGüncelle();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            /* int getir = Convert.ToInt32(textBox5.Text);
             baglanti.Open();
             OleDbCommand komut = new OleDbCommand();
             komut.Connection=baglanti;
             komut.CommandText = "SELECT hastaTc,hastaAd,hastaSoyad,hastaTel,hastaCinsiyet,hastaSıra from hastalar where hastaSıra=" + getir + "";
             OleDbDataReader dr = komut.ExecuteReader();
             if (dr.Read())
             {
                 textBox1.Text = dr["hastaTc"].ToString();
                 textBox2.Text = dr["hastaAd"].ToString();
                 textBox3.Text = dr["hastaSoyad"].ToString();
                 textBox4.Text = dr["hastaTel"].ToString();
                 if (dr["hastaCinsiyet"].ToString()=="E")
                 {
                     radioButton1.Checked = true;
                 }
                 else
                 {
                
                     radioButton2.Checked = true;
                 }

                 baglanti.Close();
              
            
             }*/
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            güncelle verileriGoster = new güncelle();
            this.Hide();
            verileriGoster.Show();
        }

        private void anaMenü_Load(object sender, EventArgs e)
        {


            dataGridGüncelle();
          
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // string cins = "";
            //string tck = (dataGridView1.CurrentRow.Cells[0].Value);
           

        }

        private void button3_0Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int cevap;
            cevap = Convert.ToInt32(MessageBox.Show("Çıkmak İstiyor Musunuz?", "Çıkış", MessageBoxButtons.YesNo));
            if (cevap == 6)//6 evet döndürür
            {
                Application.Exit();
            }
        }

        private void kayıtSilmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            textBox5.Visible = true;
            button2.Visible = true;
           // kayıtSilmeToolStripMenuItem.Name=""
        }

        private void dataGridGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
           
           
            
        }

        private void güncellemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            güncelle verileriGoster = new güncelle();
            this.Hide();
            verileriGoster.Show();
        }

   

        private void kayıtlarıGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kayıtlarıListele kayitlariListele = new kayıtlarıListele();
            this.Hide();
            kayitlariListele.Show();
        }

        private void tarihArasıSorgulamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tarihlerArasıSorgu tarihA = new tarihlerArasıSorgu();
            this.Hide();
            tarihA.Show();
        }

        private void tümVerileriSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "DELETE * FROM hastalar";
            int sonuc = komut.ExecuteNonQuery();
            MessageBox.Show(+sonuc+" "+"Adet Veri Silindi");
            baglanti.Close();
            dataGridGüncelle();
            
            

        }

    }
}
