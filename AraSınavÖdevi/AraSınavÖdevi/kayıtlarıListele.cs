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
    public partial class kayıtlarıListele : Form
    {
        public kayıtlarıListele()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=hastaKayitlari.accdb");
        OleDbCommand komut = new OleDbCommand();
        DataTable tablo = new DataTable();
        DataSet ds = new DataSet();
        


        public void kayitListele()
        {

            listView1.Items.Clear();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM hastalar";
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["hastaTc"].ToString());
                item.SubItems.Add(dr["hastaAd"].ToString());
                item.SubItems.Add(dr["hastaSoyad"].ToString());
                item.SubItems.Add(dr["hastaTelefon"].ToString());
                item.SubItems.Add(dr["hastaCinsiyet"].ToString());
                item.SubItems.Add(dr["kayıtTarih"].ToString());
                listView1.Items.Add(item);
            }
            baglanti.Close();
        
        }

        private void kayıtlarıListele_Load(object sender, EventArgs e)
        {
            kayitListele();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            anaMenü anaProgram = new anaMenü();
            this.Hide();
            anaProgram.Show();
        }
    }
}
