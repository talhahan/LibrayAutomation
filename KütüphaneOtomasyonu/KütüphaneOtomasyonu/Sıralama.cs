using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KütüphaneOtomasyonu
{
    public partial class Sıralama : Form
    {
        public Sıralama()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-FCJSJPA\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");

        DataSet daset = new DataSet();
        private void Sıralama_Load(object sender, EventArgs e)
        {
            baglantı.Open();

            SqlDataAdapter adrt = new SqlDataAdapter("select * from kitap order by sayfasayisi ", baglantı);

            adrt.Fill(daset, "kitap");

            dataGridView1.DataSource = daset.Tables["kitap"];

            baglantı.Close();
        }
    }
}
