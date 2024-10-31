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
using System.Data.SqlClient;

namespace personel_kayit_programi
{
    public partial class Frmgiris : Form
    {
        public Frmgiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=RASIT\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand giris = new SqlCommand("select * from tbl_yonetici where kullaniciad=@p1 and sifre=@p2",baglanti);
            giris.Parameters.AddWithValue("@p1", TxtKullanici.Text);
            giris.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader g = giris.ExecuteReader();
            if (g.Read())
            {
                FrmAnaForm frm = new FrmAnaForm();
                frm.Show();
                this.Hide();
            }
            else
            {
                TxtKullanici.Text = "";
                TxtSifre.Text = "";
                TxtKullanici.Focus();
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre!");
                
            }
            baglanti.Close();
        }
    }
}
