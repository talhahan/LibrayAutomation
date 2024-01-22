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
    public partial class ÜyeListeleme : Form
    {
        public ÜyeListeleme()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-FCJSJPA\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");



        private void txtTc_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-FCJSJPA\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("select * from uyekaydı where tc like '%" + txtTc.Text + "%'", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    txtAd.Text = reader["adsoyad"].ToString();
                    txtAdres.Text = reader["adres"].ToString();
                    txtboxTelefon.Text = reader["telefon"].ToString();
                    txtMail.Text = reader["email"].ToString();
                    mboxCinsiyet.Text = reader["cinsiyet"].ToString();
                    txtYas.Text = reader["yas"].ToString();
                }
            } // using bloğu bittiğinde bağlantı otomatik olarak kapanır
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTc.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
        }

        DataSet dataset = new DataSet();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataset.Tables["uyekaydı"].Clear();

            baglantı.Open();

            SqlDataAdapter adrt = new SqlDataAdapter("select * from uyekaydı where tc like '%" + textBox1.Text + "%'", baglantı);

            adrt.Fill(dataset, "uyekaydı");

            dataGridView1.DataSource = dataset.Tables["uyekaydı"];

            baglantı.Close();

        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglantı.Open();

            SqlCommand komut = new SqlCommand("delete from uyekaydı where tc=@tc", baglantı);
            komut.Parameters.AddWithValue("@tc", dataGridView1.CurrentRow.Cells["tc"].Value.ToString());
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kayıt başarıyla silindi.");
            dataset.Tables["uyekaydı"].Clear();
            uyeListele();

            

            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = " ";

                }
            }

            
        }

        private void ÜyeListeleme_Load(object sender, EventArgs e)
        {
            uyeListele();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {


            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-FCJSJPA\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True"))
            {
                connection.Open();

                SqlCommand komut = new SqlCommand("Update uyekaydı set adsoyad=@adsoyad, yas=@yas, cinsiyet=@cinsiyet, telefon=@telefon, adres=@adres, email=@email where tc=@tc", connection);

                komut.Parameters.AddWithValue("@tc", txtTc.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtAd.Text);
                komut.Parameters.AddWithValue("@yas", txtYas.Text);
                komut.Parameters.AddWithValue("@cinsiyet", mboxCinsiyet.Text);
                komut.Parameters.AddWithValue("@telefon", txtboxTelefon.Text);
                komut.Parameters.AddWithValue("@adres", txtAdres.Text);
                komut.Parameters.AddWithValue("@email", txtMail.Text);

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

            dataset.Tables["uyekaydı"].Clear();
            uyeListele();

            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }
        private void uyeListele()
        {
            baglantı.Open();



            SqlDataAdapter adrt = new SqlDataAdapter("select*from uyekaydı", baglantı);

            adrt.Fill(dataset, "uyekaydı");

            dataGridView1.DataSource = dataset.Tables["uyekaydı"];

            baglantı.Close();


            



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
    

        
        

