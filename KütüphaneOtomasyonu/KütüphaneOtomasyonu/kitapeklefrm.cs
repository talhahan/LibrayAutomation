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
    public partial class kitapeklefrm : Form
    {
        public kitapeklefrm()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-FCJSJPA\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");

        private void kitapeklefrm_Load(object sender, EventArgs e)
        {

        }



        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglantı.Open();

            SqlCommand komut = new SqlCommand("insert into kitap (barkodno,kitapadi,yazari,yayinevi,sayfasayisi,türü,stoksayisi,rafno,aciklama,kayittarihi) values(@barkodno,@kitapadi,@yazari,@yayinevi,@sayfasayisi,@türü,@stoksayisi,@rafno,@aciklama,@kayittarihi)", baglantı);




            komut.Parameters.AddWithValue("@barkodno", txtBarkodNo.Text);
            komut.Parameters.AddWithValue("@kitapadi", txtKitapAdı.Text);
            komut.Parameters.AddWithValue("@yazari", txtYazar.Text);
            komut.Parameters.AddWithValue("@yayinevi", txtYayınevi.Text);
            komut.Parameters.AddWithValue("@sayfasayisi", txtSayfa.Text);
            komut.Parameters.AddWithValue("@türü", cmboxTür.Text);
            komut.Parameters.AddWithValue("@stoksayisi", txtStok.Text);
            komut.Parameters.AddWithValue("@rafno", txtRaf.Text);
            komut.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
            komut.Parameters.AddWithValue("@kayittarihi", DateTime.Now.ToShortDateString());
            komut.ExecuteNonQuery();
            MessageBox.Show("Tebrikler!!!Kitap kaydı yapıldı.");

            foreach (Control item in Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
            }

        }
    }
}
