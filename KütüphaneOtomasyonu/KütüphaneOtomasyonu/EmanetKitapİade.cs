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
    public partial class EmanetKitapİade : Form
    {
        public EmanetKitapİade()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-FCJSJPA\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        DataSet daset = new DataSet();
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void EmanetKitapListlee()
        {
            baglantı.Open();

            SqlDataAdapter adrt = new SqlDataAdapter("select * from emanetkitap", baglantı);

            adrt.Fill(daset, "emanetkitap");

            dataGridView1.DataSource = daset.Tables["emanetkitap"];

            baglantı.Close();


        }
        private void EmanetKitapİade_Load(object sender, EventArgs e)
        {
            EmanetKitapListlee();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            daset.Tables["emanetkitap"].Clear();

            baglantı.Open();

            SqlDataAdapter adrt = new SqlDataAdapter("select * from  emanetkitap  where  tc  like '%"+ txtTcAra.Text +"%'",baglantı);
            adrt.Fill(daset, "emanetkitap");
            baglantı.Close();
            if (txtTcAra.Text=="")
            {
                daset.Tables["emanetkitap"].Clear();
                EmanetKitapListlee();
            }
        }

        private void txtBarkod_TextChanged(object sender, EventArgs e)
        {

            daset.Tables["emanetkitap"].Clear();

            baglantı.Open();

            SqlDataAdapter adrt = new SqlDataAdapter("select*from emanetkitap where barkodno like '%" + txtBarkod.Text + "%'", baglantı);
            adrt.Fill(daset, "emanetkitap");
            baglantı.Close();
            if (txtBarkod.Text == "")
            {
                daset.Tables["emanetkitap"].Clear();
                EmanetKitapListlee();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            baglantı.Open();
            
            SqlCommand komut = new SqlCommand("delete from emanetkitap where @tc=tc and @barkodno=barkodno",baglantı);
            komut.Parameters.AddWithValue("@tc",dataGridView1.CurrentRow.Cells["tc"].Value.ToString());
            komut.Parameters.AddWithValue("@barkodno", dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString());
            komut.ExecuteNonQuery();
            SqlCommand komut2 = new SqlCommand("update kitap set stoksayisi=stoksayisi+ '"+dataGridView1.CurrentRow.Cells["kitapsayisi"].Value.ToString()+"' where @barkodno=barkodno",baglantı);
            komut2.Parameters.AddWithValue("@barkodno", dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString());
            komut2.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kitap teslim alındı!!!","Bilgi");


            daset.Tables["emanetkitap"].Clear();
            EmanetKitapListlee();
        }
    }
}
