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
    public partial class GirisEkranı : Form
    {
        public GirisEkranı()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-FCJSJPA\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            string kulanıcıadı = textBox1.Text; // Kullanıcı adı TextBox'ından veriyi al
            string sifre = textBox2.Text; // Şifre TextBox'ından veriyi al

            // SQL sorgusu ile kullanıcı adı ve şifre kontrolü
            string query = "SELECT COUNT(*) FROM Yönetici WHERE kulanıcıadı = @kulanıcıadı AND sifre = @sifre";
            using (SqlCommand command = new SqlCommand(query, baglantı))
            {
                command.Parameters.AddWithValue("@kulanıcıadı", kulanıcıadı);
                command.Parameters.AddWithValue("@sifre", sifre);

                baglantı.Open();
                int result = (int)command.ExecuteScalar(); // Sorgudan dönen sonucu al

                if (result > 0) // Eğer kullanıcı adı ve şifre doğru ise
                {
                    MessageBox.Show("Giriş Başarılı!");
                    // Burada ana uygulama formunu açabilirsiniz
                    // Örnek olarak:
                    AnaSayfa anaEkran = new AnaSayfa();
                    anaEkran.Show();
                    this.Hide(); // Giriş ekranını gizle
                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre!");
                }
            }
            baglantı.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void GirisEkranı_Load(object sender, EventArgs e)
        {

        }
    }
}
