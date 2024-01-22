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
    public partial class KitapVermeİslemi : Form
    {
        public KitapVermeİslemi()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-FCJSJPA\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglantı.Open();

            SqlCommand komut = new SqlCommand("insert into sepett(barkodno,kitapadi,yazari,yayinevi,sayfasayisi,kitapsayisi,teslimtarihi,iadetarihi) values(@barkodno,@kitapadi,@yazari,@yayinevi,@sayfasayisi,@kitapsayisi,@teslimtarihi,@iadetarihi)", baglantı);
            string kitapAdi = !string.IsNullOrEmpty(txtKitapAdi.Text) ? txtKitapAdi.Text : "Bilgi Yok";
            komut.Parameters.AddWithValue("@kitapadi", kitapAdi);
            komut.Parameters.AddWithValue("@barkodno", txtBarkod.Text);
            komut.Parameters.AddWithValue("@yazari", txtYazar.Text);
            komut.Parameters.AddWithValue("@yayinevi", txtYayinEvi.Text);
            komut.Parameters.AddWithValue("@sayfasayisi", txtSayfa.Text);
            komut.Parameters.AddWithValue("@kitapsayisi", txtKitapSayisi.Text);
            komut.Parameters.AddWithValue("@teslimtarihi", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@iadetarihi", dateTimePicker2.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kitaplar sepete eklendi", "Ekleme İşlemi");
            daset.Tables["sepett"].Clear();
            sepetlistele();
            lblKitapSayi.Text = "";
            kitapsayisi();
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    if (item != txtKitapSayisi)
                    {
                        item.Text = "";
                    }
                }
            }








        }
        DataSet daset = new DataSet();

        private void sepetlistele()
        {
            baglantı.Open();
            SqlDataAdapter adrt = new SqlDataAdapter("select*from sepett", baglantı);
            adrt.Fill(daset, "sepett");
            dataGridView1.DataSource = daset.Tables["sepett"];
            baglantı.Close();
        }


        private void KitapVermeİslemi_Load(object sender, EventArgs e)
        {
            sepetlistele();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {
            baglantı.Open();

            SqlCommand komut = new SqlCommand("select * from uyekaydı where tc like '" + txtTc.Text + "'", baglantı);

            SqlDataReader read = komut.ExecuteReader();

            while (read.Read())
            {
                txtAd.Text = read["adsoyad"].ToString();
                txtYas.Text = read["yas"].ToString();
                txtTelefon.Text = read["telefon"].ToString();

            }

            baglantı.Close();

            baglantı.Open();

            SqlCommand komut2 = new SqlCommand("select sum(kitapsayisi) from emanetkitap", baglantı);

            lblKayıtlıKitap.Text = komut2.ExecuteScalar().ToString();

            baglantı.Close();

            if (txtTc.Text == "")
            {

                foreach (Control item in groupBox1.Controls)
                {
                    if (item is TextBox)
                    {

                        item.Text = "";
                        lblKayıtlıKitap.Text = "";

                    }
                }
            }
        }
        private void kitapsayisi()
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("select sum(kitapsayisi) from sepett ", baglantı);
            lblKitapSayi.Text = komut.ExecuteScalar().ToString();
            baglantı.Close();

        }

        private void txtBarkod_TextChanged(object sender, EventArgs e)
        {
            baglantı.Open();

            SqlCommand komut = new SqlCommand("select *from kitap where barkodno like '" + txtBarkod.Text + "'", baglantı);

            SqlDataReader read = komut.ExecuteReader();

            while (read.Read())
            {

                txtKitapAdi.Text = read["kitapadi"].ToString();
                txtYazar.Text = read["yazari"].ToString();
                txtYayinEvi.Text = read["yayinevi"].ToString();
                txtSayfa.Text = read["sayfasayisi"].ToString();


            }

            baglantı.Close();

            if (txtBarkod.Text == "")
            {
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != txtKitapSayisi)
                        {
                            item.Text = "";

                        }
                    }
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult diyolog;

            diyolog = MessageBox.Show("Kayıt silinsinmi ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (diyolog == DialogResult.Yes)
            {
                baglantı.Open();

                SqlCommand komut = new SqlCommand("delete from sepett where barkodno='" + dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString() + "'", baglantı);

                komut.ExecuteNonQuery();

                baglantı.Close();

                MessageBox.Show("Silme işlemi yapıldı.", "Silme İşlemi");

                daset.Tables["sepett"].Clear();

                sepetlistele();

                lblKitapSayi.Text = "";
                kitapsayisi();
            }


        }

        private void btnTeslimEt_Click(object sender, EventArgs e)
        {
            if (lblKitapSayi.Text != "")
            {


                if (txtTc.Text != "" && txtAd.Text != "" && txtYas.Text != "" && txtTelefon.Text != "")
                {


                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        baglantı.Open();






                        SqlCommand komut = new SqlCommand("insert into emanetkitap(tc,adsoyad,yas,telefon,barkodno,kitapadi,yazari,yayinevi,sayfasayisi,kitapsayisi,teslimtarihi,iadetarihi) values(@tc,@adsoyad,@yas,@telefon,@barkodno,@kitapadi,@yazari,@yayinevi,@sayfasayisi,@kitapsayisi,@teslimtarihi,@iadetarihi)", baglantı);

                        komut.Parameters.AddWithValue("@tc", txtTc.Text);
                        komut.Parameters.AddWithValue("@adsoyad", txtAd.Text);
                        komut.Parameters.AddWithValue("@yas", txtYas.Text);
                        komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                        komut.Parameters.AddWithValue("barkodno", dataGridView1.Rows[i].Cells["barkodno"].Value.ToString());
                        komut.Parameters.AddWithValue("kitapadi", dataGridView1.Rows[i].Cells["kitapadi"].Value.ToString());
                        komut.Parameters.AddWithValue("yazari", dataGridView1.Rows[i].Cells["yazari"].Value.ToString());
                        komut.Parameters.AddWithValue("yayinevi", dataGridView1.Rows[i].Cells["yayinevi"].Value.ToString());
                        komut.Parameters.AddWithValue("sayfasayisi", dataGridView1.Rows[i].Cells["sayfasayisi"].Value.ToString());
                        komut.Parameters.AddWithValue("kitapsayisi", int.Parse(dataGridView1.Rows[i].Cells["kitapsayisi"].Value.ToString()));
                        komut.Parameters.AddWithValue("teslimtarihi", dataGridView1.Rows[i].Cells["teslimtarihi"].Value.ToString());
                        komut.Parameters.AddWithValue("iadetarihi", dataGridView1.Rows[i].Cells["iadetarihi"].Value.ToString());
                        komut.ExecuteNonQuery();

                        SqlCommand komut3 = new SqlCommand("update kitap set stoksayisi = stoksayisi-'" + int.Parse(dataGridView1.Rows[i].Cells["kitapsayisi"].Value.ToString()) + "'where barkodno='" + dataGridView1.Rows[i].Cells["barkodno"].Value.ToString() + "'", baglantı);

                        baglantı.Close();





                    }


                    baglantı.Open();
                    SqlCommand komut4 = new SqlCommand("delete from sepett", baglantı);
                    komut4.ExecuteNonQuery();
                    baglantı.Close();
                    MessageBox.Show("Kitaplar emanet edildi", "Bilgi");
                    daset.Tables["sepett"].Clear();
                    sepetlistele();
                    txtTc.Text = "";
                    lblKitapSayi.Text = "";
                    kitapsayisi();
                    lblKayıtlıKitap.Text = "";




                    lblKitapSayi.Text = "";
                    kitapsayisi();
                }

                else
                {
                    MessageBox.Show("Önce üye ismi seçmeniz gerekir !!!", "Uyarı");
                }

            }
            else
            {
                MessageBox.Show("Emanet kitap saysı 3 ten fazla olamaz", "Uyarı");

            }

        }










    }
}
    

