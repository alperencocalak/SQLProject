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
    public partial class FrmMusteri : Form
    {
        public FrmMusteri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-9OVK0ID;Initial Catalog=SatisVT;Integrated Security=True");

        void Listele()
        {
            SqlCommand komut = new SqlCommand("Select * from TBLMUSTERI", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from TBLMUSTERI where MUSTERIAD=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbSehir.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtBakiye.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

        }

        private void FrmMusteri_Load_1(object sender, EventArgs e)
        {
            Listele();

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select * from TBLSEHIR", baglanti);
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                cmbSehir.Items.Add(dr["sehir"]);
            }
            baglanti.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("insert into TBLMUSTERI (MUSTERIAD,MUSTERISOYAD,MUSTERISEHIR,MUSTERIBAKIYE) VALUES (@P1,@P2,@P3,@P4)", baglanti);
            komut3.Parameters.AddWithValue("@P1", txtAd.Text);
            komut3.Parameters.AddWithValue("@P2", txtSoyad.Text);
            komut3.Parameters.AddWithValue("@P3", cmbSehir.Text);
            komut3.Parameters.AddWithValue("@P4", decimal.Parse(txtBakiye.Text));
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Sisteme Kaydedildi.");
            Listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Delete from TBLMUSTERI where MUSTERIID=@P1", baglanti);
            komut2.Parameters.AddWithValue("@P1", txtID.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Sistemden Silindi.");
            Listele();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update TBLMUSTERI set MUSTERIAD=@p1,MUSTERISOYAD=@p2,MUSTERISEHIR=@p3,MUSTERIBAKIYE=@p4 where MUSTERIID=@p5",baglanti);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtBakiye.Text));
            komut.Parameters.AddWithValue("@p5", txtID.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Güncellendi.");
            Listele();

        }
    }
}
