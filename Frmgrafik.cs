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
    public partial class Frmgrafik : Form
    {
        public Frmgrafik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=RASIT\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
        private void Frmgrafik_Load(object sender, EventArgs e)
        {
            //Şehir Grafiği
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("select persehir,count(*) from tbl_personel group by persehir", baglanti);
            SqlDataReader g1 = komutg1.ExecuteReader();
            while (g1.Read())
            {
                chart1.Series["sehirler"].Points.AddXY(g1[0], g1[1]);

            }
            baglanti.Close();

            //Meslek-Maaş Ortalaması Grafiği
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("select permeslek,avg(permaaş) from tbl_personel group by permeslek", baglanti);
            SqlDataReader g2 = komutg2.ExecuteReader();
            while (g2.Read())
            {
                chart2.Series["meslek-maas"].Points.AddXY(g2[0], g2[1]);
            }

        }
    }
}
