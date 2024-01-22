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
    public partial class EmanetKitapListele : Form
    {
        public EmanetKitapListele()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-FCJSJPA\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");

        DataSet daset = new DataSet();
        

        private void EmanetKitapListle()
        {
            baglantı.Open();

            SqlDataAdapter adrt = new SqlDataAdapter("select * from emanetkitap",baglantı);

            adrt.Fill(daset, "emanetkitap");

            dataGridView1.DataSource = daset.Tables["emanetkitap"];

            baglantı.Close();


        }
        private void EmanetKitapListele_Load(object sender, EventArgs e)
        {
            EmanetKitapListle();


            comboBox1.SelectedIndex = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            daset.Tables["emanetkitap"].Clear();

            if (comboBox1.SelectedIndex==0)
            {

                EmanetKitapListle();
            }

            else if (comboBox1.SelectedIndex == 1)
            {
                baglantı.Open();

                SqlDataAdapter adrt = new SqlDataAdapter("select*from emanetkitap where '"+DateTime.Now.ToShortDateString()+"'>iadetarihi",baglantı);


                adrt.Fill(daset, "emanetkitap");

                dataGridView1.DataSource = daset.Tables["emanetkitap"];

                baglantı.Close();


            }

            else if (comboBox1.SelectedIndex == 2)
            {
                baglantı.Open();

                SqlDataAdapter adrt = new SqlDataAdapter("select*from emanetkitap where '" + DateTime.Now.ToShortDateString() + "'<=iadetarihi", baglantı);


                adrt.Fill(daset, "emanetkitap");

                dataGridView1.DataSource = daset.Tables["emanetkitap"];

                baglantı.Close();


            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // Eğer seçili satır varsa
            {
                DialogResult dialogResult = MessageBox.Show("Seçili kaydı silmek istediğinizden emin misiniz?", "Kayıt Silme", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string selectedTC = dataGridView1.SelectedRows[0].Cells["tc"].Value.ToString(); // "TCKN" yerine ilgili TC kolon adını kullanın

                    // Silme işlemi için SQL sorgusu
                    string deleteQuery = "DELETE FROM emanetkitap WHERE  tc= @tc"; // "TCKN" yerine ilgili TC kolon adını kullanın
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, baglantı))
                    {
                        cmd.Parameters.AddWithValue("@tc", selectedTC);
                        baglantı.Open();
                        cmd.ExecuteNonQuery();
                        baglantı.Close();
                    }

                    MessageBox.Show("Kayıt başarıyla silindi.");

                    // DataGridView'deki güncel veriyi yeniden yükle
                    daset.Tables["emanetkitap"].Clear();
                    EmanetKitapListle(); // Yeniden veri yükleme işlemi
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir kayıt seçin.");
            }
        }
    }
}
