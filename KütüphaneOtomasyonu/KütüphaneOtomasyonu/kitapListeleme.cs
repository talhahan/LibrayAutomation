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
    public partial class kitapListeleme : Form
    {
        public kitapListeleme()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-FCJSJPA\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");

        private void btnEkle_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-FCJSJPA\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True"))
            {
                connection.Open();

                SqlCommand komut = new SqlCommand("update kitap set barkodno=@barkodno,kitapadi=@kitapadi,yazari=@yazari,yayinevi=@yayinevi,sayfasayisi=@sayfasayisi,türü=@türü,stoksayisi=@stoksayisi,rafno=@rafno,aciklama=@aciklama where barkodno=@barkodno", connection);

                komut.Parameters.AddWithValue("@barkodno", txtBarkodNo.Text);
                komut.Parameters.AddWithValue("@kitapadi", txtKitapAdı.Text);
                komut.Parameters.AddWithValue("@yazari", txtYazar.Text);
                komut.Parameters.AddWithValue("@yayinevi", txtYayınevi.Text);
                komut.Parameters.AddWithValue("@sayfasayisi", txtSayfa.Text);
                komut.Parameters.AddWithValue("@türü", cmboxTür.Text);
                komut.Parameters.AddWithValue("@stoksayisi", txtStok.Text);
                komut.Parameters.AddWithValue("@rafno", txtRaf.Text);
                komut.Parameters.AddWithValue("@aciklama", txtAciklama.Text);



                try
                {
                    // ExecuteNonQuery() metoduyla güncelleme işlemi gerçekleştirilir
                    int affectedRows = komut.ExecuteNonQuery();

                    // Güncelleme başarılıysa
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Üye bilgileri güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme başarısız oldu veya herhangi bir değişiklik yapılmadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }

            dataset.Tables["kitap"].Clear();

            kitapListele();

            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        DataSet dataset = new DataSet();
        private void kitapListele()
        {
            baglantı.Open();



            SqlDataAdapter adrt = new SqlDataAdapter("select*from kitap", baglantı);

            adrt.Fill(dataset, "kitap");

            dataGridView1.DataSource = dataset.Tables["kitap"];

            baglantı.Close();






        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();

            SqlCommand komut = new SqlCommand("delete from kitap where barkodno=@barkodno", baglantı);
            komut.Parameters.AddWithValue("@barkodno", dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString());
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kayıt başarıyla silindi.");
            dataset.Tables["kitap"].Clear();
            kitapListele();



            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = " ";

                }
            }

        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBarkodNo.Text = dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString();
        }


        private void textBoxAra_TextChanged(object sender, EventArgs e)
        {
            dataset.Tables["kitap"].Clear();

            baglantı.Open();

            SqlDataAdapter adrt = new SqlDataAdapter("select * from kitap where barkodno like '%" + textBoxAra.Text + "%'", baglantı);

            adrt.Fill(dataset, "kitap");

            dataGridView1.DataSource = dataset.Tables["kitap"];

            baglantı.Close(); 
        }

        private void kitapListeleme_Load(object sender, EventArgs e)
        {
            kitapListele();
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBarkodNo_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-FCJSJPA\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("select * from kitap where barkodno like '%" + txtBarkodNo.Text + "%'", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    txtKitapAdı.Text = reader["kitapadi"].ToString();
                    txtYazar.Text = reader["yazari"].ToString();
                    txtYayınevi.Text = reader["yayinevi"].ToString();
                    txtSayfa.Text = reader["sayfasayisi"].ToString();
                    cmboxTür.Text = reader["türü"].ToString();
                    txtStok.Text = reader["stoksayisi"].ToString();
                    txtRaf.Text = reader["rafno"].ToString();
                    txtAciklama.Text = reader["aciklama"].ToString();
                }
            } // using bloğu bittiğinde bağlantı otomatik olarak 
        }
    }
}
