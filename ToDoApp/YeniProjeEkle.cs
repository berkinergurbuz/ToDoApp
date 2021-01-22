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

namespace ToDoApp
{
    public partial class YeniProjeEkle : MetroFramework.Forms.MetroForm
    {
        public YeniProjeEkle()
        {
            InitializeComponent();
        }
        public string kartId;
        public string conString = "Data Source=.\\SQLEXPRESS;Initial Catalog=todoproje;Integrated Security=True";
        private void btn_kaydet1_Click(object sender, EventArgs e)
        {
            
            if (txt_projeAdi.Text == "")
            {                            
                MessageBox.Show("Lütfen Proje Adını Yazınız");
            }
            else if (txt_isAciklama.Text == "")
            {                
                MessageBox.Show("Lütfen Proje Açıklamasını Yazınız");
            }
            else if (txt_not.Text == "")
            {               
                MessageBox.Show("Lütfen Proje Notunu Yazınız");
            }
            else if (txt_teknikUzman.Text == "")
            {                
                MessageBox.Show("Lütfen Teknik Uzman Adını Yazınız");
            }
            else
            {                
                tlp_istakibi.Enabled = true;
                btn_kaydet2.Enabled = true;
                txt_isAciklama.Enabled = false;
                txt_not.Enabled = false;
                txt_teknikUzman.Enabled = false;
                txt_projeAdi.Enabled = false;
                
                Random rastgele = new Random();
                int sayi = rastgele.Next(100);
                DateTime bugun = DateTime.Now;
                DateTime sonuc = bugun.AddDays(sayi);

                metroDateTime2.Value = sonuc;
                metroDateTime3.Value = sonuc;
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                SqlCommand komut = new SqlCommand("insert into tbl_proje(proje_adi,proje_uzman,proje_tarih,proje_tarihTahmin,proje_isAciklama,proje_not) values(@proje_adi,@proje_uzman,@proje_tarih,@proje_tarihTahmin,@proje_isAciklama,@proje_not)", con);
                komut.Parameters.AddWithValue("@proje_adi", txt_projeAdi.Text);
                komut.Parameters.AddWithValue("@proje_uzman", txt_teknikUzman.Text);
                komut.Parameters.AddWithValue("@proje_tarih", metroDateTime1.Text);
                komut.Parameters.AddWithValue("@proje_tarihTahmin", metroDateTime2.Text);
                komut.Parameters.AddWithValue("@proje_isAciklama", txt_isAciklama.Text);
                komut.Parameters.AddWithValue("@proje_not", txt_not.Text);
                komut.ExecuteNonQuery();
                con.Close();

                con.Open();
                string giris = "SELECT TOP 1 kartNo_id FROM tbl_proje ORDER BY kartNo_id DESC";
                SqlCommand komut2 = new SqlCommand(giris, con);
                SqlDataAdapter d = new SqlDataAdapter(komut2);
                SqlDataReader r = komut2.ExecuteReader();
                if (r.Read())
                {
                    kartId = r["kartNo_id"].ToString();                  
                }
                 txt_kartNo.Text = kartId;
                con.Close();
                        
            }


        }

        private void btn_kaydet2_Click(object sender, EventArgs e)
        {
            if (txt_yapilacakIs1.Text != "" && txt_aciklama1.Text != "" && cb_durum1.Text != "")
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                SqlCommand komut = new SqlCommand("insert into tbl_task(task_fk_kartNo,task_yapilacakIs,task_aciklama,task_durum) values(@task_fk_kartNo,@task_yapilacakIs,@task_aciklama,@task_durum)", con);
                komut.Parameters.AddWithValue("@task_fk_kartNo", txt_kartNo.Text);
                komut.Parameters.AddWithValue("@task_yapilacakIs", txt_yapilacakIs1.Text);
                komut.Parameters.AddWithValue("@task_aciklama", txt_aciklama1.Text);
                komut.Parameters.AddWithValue("@task_durum", cb_durum1.Text);              
                komut.ExecuteNonQuery();
                con.Close();
            }
            if (txt_yapilacakIs2.Text != "" && txt_aciklama2.Text != "" && cb_durum2.Text != "")
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                SqlCommand komut = new SqlCommand("insert into tbl_task(task_fk_kartNo,task_yapilacakIs,task_aciklama,task_durum) values(@task_fk_kartNo,@task_yapilacakIs,@task_aciklama,@task_durum)", con);
                komut.Parameters.AddWithValue("@task_fk_kartNo", txt_kartNo.Text);
                komut.Parameters.AddWithValue("@task_yapilacakIs", txt_yapilacakIs2.Text);
                komut.Parameters.AddWithValue("@task_aciklama", txt_aciklama2.Text);
                komut.Parameters.AddWithValue("@task_durum", cb_durum2.Text);
                komut.ExecuteNonQuery();
                con.Close();
            }
            if (txt_yapilacakIs3.Text != "" && txt_aciklama3.Text != "" && cb_durum3.Text != "")
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                SqlCommand komut = new SqlCommand("insert into tbl_task(task_fk_kartNo,task_yapilacakIs,task_aciklama,task_durum) values(@task_fk_kartNo,@task_yapilacakIs,@task_aciklama,@task_durum)", con);
                komut.Parameters.AddWithValue("@task_fk_kartNo", txt_kartNo.Text);
                komut.Parameters.AddWithValue("@task_yapilacakIs", txt_yapilacakIs3.Text);
                komut.Parameters.AddWithValue("@task_aciklama", txt_aciklama3.Text);
                komut.Parameters.AddWithValue("@task_durum", cb_durum3.Text);
                komut.ExecuteNonQuery();
                con.Close();
            }
            if (txt_yapilacakIs4.Text != "" && txt_aciklama4.Text != "" && cb_durum4.Text != "")
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                SqlCommand komut = new SqlCommand("insert into tbl_task(task_fk_kartNo,task_yapilacakIs,task_aciklama,task_durum) values(@task_fk_kartNo,@task_yapilacakIs,@task_aciklama,@task_durum)", con);
                komut.Parameters.AddWithValue("@task_fk_kartNo", txt_kartNo.Text);
                komut.Parameters.AddWithValue("@task_yapilacakIs", txt_yapilacakIs4.Text);
                komut.Parameters.AddWithValue("@task_aciklama", txt_aciklama4.Text);
                komut.Parameters.AddWithValue("@task_durum", cb_durum4.Text);
                komut.ExecuteNonQuery();
                con.Close();
            }
            if (txt_yapilacakIs5.Text != "" && txt_aciklama5.Text != "" && cb_durum5.Text != "")
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                SqlCommand komut = new SqlCommand("insert into tbl_task(task_fk_kartNo,task_yapilacakIs,task_aciklama,task_durum) values(@task_fk_kartNo,@task_yapilacakIs,@task_aciklama,@task_durum)", con);
                komut.Parameters.AddWithValue("@task_fk_kartNo", txt_kartNo.Text);
                komut.Parameters.AddWithValue("@task_yapilacakIs", txt_yapilacakIs5.Text);
                komut.Parameters.AddWithValue("@task_aciklama", txt_aciklama5.Text);
                komut.Parameters.AddWithValue("@task_durum", cb_durum5.Text);
                komut.ExecuteNonQuery();
                con.Close();
            }
            if (txt_yapilacakIs6.Text != "" && txt_aciklama6.Text != "" && cb_durum6.Text != "")
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                SqlCommand komut = new SqlCommand("insert into tbl_task(task_fk_kartNo,task_yapilacakIs,task_aciklama,task_durum) values(@task_fk_kartNo,@task_yapilacakIs,@task_aciklama,@task_durum)", con);
                komut.Parameters.AddWithValue("@task_fk_kartNo", txt_kartNo.Text);
                komut.Parameters.AddWithValue("@task_yapilacakIs", txt_yapilacakIs6.Text);
                komut.Parameters.AddWithValue("@task_aciklama", txt_aciklama6.Text);
                komut.Parameters.AddWithValue("@task_durum", cb_durum6.Text);
                komut.ExecuteNonQuery();
                con.Close();
            }

            Projeler pr = new Projeler();
            pr.Show();
            this.Close();

        }

        private void btn_geri_Click(object sender, EventArgs e)
        {
            Main ma = new Main();
            ma.Show();
            this.Close();
        }
    }
}
