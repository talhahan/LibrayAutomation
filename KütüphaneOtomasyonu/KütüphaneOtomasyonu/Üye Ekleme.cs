using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KütüphaneOtomasyonu
{
    public partial class Üye_Ekleme : Form
    {
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-FCJSJPA\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");

        public Üye_Ekleme()
        {
            InitializeComponent();
        }

        private async void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Style = ProgressBarStyle.Blocks; // Progres barı blok stiline ayarla
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100;

                baglantı.Open();

                SqlCommand komut = new SqlCommand("insert into uyekaydı (tc,adsoyad,yas,cinsiyet,telefon,adres,email) values(@tc,@adsoyad,@yas,@cinsiyet,@telefon,@adres,@email)", baglantı);

                komut.Parameters.AddWithValue("@tc", txtTc.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtAd.Text);
                komut.Parameters.AddWithValue("@yas", txtYas.Text); komut.Parameters.AddWithValue("@cinsiyet", mboxCinsiyet.Text); komut.Parameters.AddWithValue("@telefon", txtboxTelefon.Text); komut.Parameters.AddWithValue("@adres", txtAdres.Text); komut.Parameters.AddWithValue("@email", txtMail.Text);
                // Diğer parametreler...

                // Asenkron olarak işlemi gerçekleştir
                await Task.Delay(1000); // Gerçek işlem süresi yerine geçici olarak 1 saniyelik bir gecikme kullanıldı (Gerçek işlem süresi bu değil)
                await komut.ExecuteNonQueryAsync();

                // Progres barı tamamen doldur
                for (int i = 0; i <= 100; i++)
                {
                    progressBar1.Value = i;
                    await Task.Delay(50); // İstediğiniz hızda güncelleme yapmak için bu gecikmeyi ayarlayabilirsiniz
                }

                MessageBox.Show("Tebrikler!! Üye kaydı yapıldı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglantı.Close();
            }
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Eğer bir işlem yapılacaksa buraya yazabilirsiniz
        }

        private void Üye_Ekleme_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemler buraya yazılabilir
        }
    }
}
