using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQL2
{
    public partial class FrmKategoriler : Form
    {
        public FrmKategoriler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-9OVK0ID;Initial Catalog=SatisVT;Integrated Security=True");
        //Data Source = DESKTOP - 9OVK0ID;Initial Catalog = SatisVT; Integrated Security = True
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from TBLKATEGORI", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into TBLKATEGORI (KATEGORIAD) values (@p1)", baglanti);
            komut2.Parameters.AddWithValue("@p1", txtKategoriAd.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori Kaydetme İşlemi Başarıyla Gerçekleşti");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKategoriID.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKategoriAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("delete from TBLKATEGORI where KATEGORIID=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", txtKategoriID.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori Silme İşlemi Başarıyla Gerçekleşti");
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("update TBLKATEGORI set KATEGORIAD=@p1 where KATEGORIID=@p2", baglanti);
            komut4.Parameters.AddWithValue("@p1", txtKategoriAd.Text);
            komut4.Parameters.AddWithValue("@p2", txtKategoriID.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori Güncelleme İşlemi Başarıyla Gerçekleşti");
        }
    }
}
