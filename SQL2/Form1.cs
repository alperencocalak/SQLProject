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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-9OVK0ID;Initial Catalog=SatisVT;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void BtnKategori_Click(object sender, EventArgs e)
        {
            FrmKategoriler fr = new FrmKategoriler();
            fr.Show();
        }

        private void BtnMusteri_Click(object sender, EventArgs e)
        {
            FrmMusteri fr2 = new FrmMusteri();
            fr2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("execute test4", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select KATEGORIAD,COUNT(*) FROM TBLKATEGORI INNER JOIN TBLURUNLER ON TBLKATEGORI.KATEGORIID=TBLURUNLER.KATEGORI GROUP BY KATEGORIAD", baglanti);
            SqlDataReader dr = komut2.ExecuteReader();
            while(dr.Read())
            {
                chart1.Series["Kategoriler"].Points.AddXY(dr[0], dr[1]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select MUSTERISEHIR,COUNT(*) FROM TBLMUSTERI GROUP BY MUSTERISEHIR", baglanti);
            SqlDataReader dr2 = komut3.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Şehirler"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
