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
    public partial class tarihlerArasıSorgu : Form
    {
        public tarihlerArasıSorgu()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=hastaKayitlari.accdb");
        OleDbCommand komut = new OleDbCommand();
        DataTable tablo = new DataTable();



        public void listle()
        {

            tablo.Clear();//Kayıtlar karışmamalı 
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("SELECT * FROM hastalar WHERE kayıtTarih BETWEEN tarih1 and tarih2", baglanti);
            adtr.SelectCommand.Parameters.AddWithValue("tarih1", dateTimePicker1.Value.ToShortDateString());
            adtr.SelectCommand.Parameters.AddWithValue("tarih2", dateTimePicker2.Value.ToShortDateString());
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        
        }
        private void button2_Click(object sender, EventArgs e)
        {
            anaMenü anaProgram = new anaMenü();
            this.Hide();
            anaProgram.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listle();
            baglanti.Open();
            DataSet dtst = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From hastalar ", baglanti);
            adtr.Fill(dtst, "hastalar");
            dataGridView1.DataSource = dtst.Tables["hastalar"];
            adtr.Dispose();
            baglanti.Close();
           

        }
    }
}
