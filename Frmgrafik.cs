using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
            // --- Şehir-Personel Sayısı Grafiği ---
            try
            {
                baglanti.Open();
                // SQL metni yerine Stored Procedure adını çağırıyoruz.
                SqlCommand komutg1 = new SqlCommand("sp_GrafikSehirPersonelSayisi", baglanti);
                komutg1.CommandType = CommandType.StoredProcedure; // Komut tipini belirtiyoruz.
                SqlDataReader dr1 = komutg1.ExecuteReader();
                while (dr1.Read())
                {
                    // Stored procedure'den gelen verileri grafiğe ekliyoruz.
                    chart1.Series["sehirler"].Points.AddXY(dr1[0], dr1[1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Şehir grafiği yüklenirken hata oluştu: " + ex.Message);
            }
            finally
            {
                // Bağlantıyı her zaman kapatıyoruz.
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
            }

            // --- Meslek-Maaş Ortalaması Grafiği ---
            try
            {
                baglanti.Open();
                // SQL metni yerine Stored Procedure adını çağırıyoruz.
                SqlCommand komutg2 = new SqlCommand("sp_GrafikMeslekOrtalamaMaas", baglanti);
                komutg2.CommandType = CommandType.StoredProcedure; // Komut tipini belirtiyoruz.
                SqlDataReader dr2 = komutg2.ExecuteReader();
                while (dr2.Read())
                {
                    // Stored procedure'den gelen verileri grafiğe ekliyoruz.
                    chart2.Series["meslek-maas"].Points.AddXY(dr2[0], dr2[1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Meslek-Maaş grafiği yüklenirken hata oluştu: " + ex.Message);
            }
            finally
            {
                // Bağlantıyı her zaman kapatıyoruz.
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
            }
        }
    }
}
