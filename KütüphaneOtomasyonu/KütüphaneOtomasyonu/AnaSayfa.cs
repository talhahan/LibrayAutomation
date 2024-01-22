using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KütüphaneOtomasyonu
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

          

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Üye_Ekleme ekleme = new Üye_Ekleme();

            ekleme.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ÜyeListeleme listele = new ÜyeListeleme();

            listele.Show();

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            kitapListeleme liste = new kitapListeleme();

            liste.ShowDialog();
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {


        }

        private void button6_Click(object sender, EventArgs e)
        {
            kitapeklefrm kitapekle = new kitapeklefrm();

            kitapekle.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KitapVermeİslemi ktp = new KitapVermeİslemi();

            ktp.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EmanetKitapListele lst = new EmanetKitapListele();

            lst.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmanetKitapİade iade = new EmanetKitapİade();

            iade.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Sıralama srl = new Sıralama();

            srl.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
