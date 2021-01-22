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
    public partial class Güncelle : MetroFramework.Forms.MetroForm
    {
        public Güncelle()
        {
            InitializeComponent();
        }

        public string conString = "Data Source=.\\SQLEXPRESS;Initial Catalog=todoproje;Integrated Security=True";
        DataSet daset = new DataSet();

        private void btn_geri_Click(object sender, EventArgs e)
        {
            Projeler pr = new Projeler();
            pr.Show();
            this.Close();
        }

        private void btn_guncelle1_Click(object sender, EventArgs e)
        {
            if (txt_GprojeAdi.Text == "")
            {              
                MessageBox.Show("Lütfen Proje Adını Yazınız");
            }
            else if (txt_GisAciklama.Text == "")
            {
                MessageBox.Show("Lütfen Proje Açıklamasını Yazınız");
            }
            else if (txt_Gnot.Text == "")
            {
                MessageBox.Show("Lütfen Proje Notunu Yazınız");
            }
            else if (txt_GteknikUzman.Text == "")
            {
                MessageBox.Show("Lütfen Teknik Uzman Adını Yazınız");
            }
            else
            {
                tlp_Gistakibi.Enabled = true;
                btn_guncelle2.Enabled = true;
                txt_GisAciklama.Enabled = false;
                txt_Gnot.Enabled = false;
                txt_GteknikUzman.Enabled = false;
                txt_GprojeAdi.Enabled = false;
              
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                SqlCommand komut = new SqlCommand("update tbl_proje set proje_adi = @proje_adi, proje_uzman = @proje_uzman, proje_tarih = @proje_tarih, proje_tarihTahmin = @proje_tarihTahmin, proje_isAciklama = @proje_isAciklama, proje_not = @proje_not where kartNo_id='" + Convert.ToInt32(txt_GkartNo.Text) + "'", con);
                komut.Parameters.AddWithValue("@proje_adi", txt_GprojeAdi.Text);
                komut.Parameters.AddWithValue("@proje_uzman", txt_GteknikUzman.Text);
                komut.Parameters.AddWithValue("@proje_tarih", metroDateTime1.Text);
                komut.Parameters.AddWithValue("@proje_tarihTahmin", metroDateTime2.Text);
                komut.Parameters.AddWithValue("@proje_isAciklama", txt_GisAciklama.Text);
                komut.Parameters.AddWithValue("@proje_not", txt_Gnot.Text);
                komut.ExecuteNonQuery();
                con.Close();
              
            }
        }

        private void Güncelle_Load(object sender, EventArgs e)
        {
            txt_GkartNo.Text = Projeler.aktifId;
            Doldur();
        }

        private void Doldur()
        {
            int a;
            a = Convert.ToInt32(txt_GkartNo.Text);
            SqlConnection d = new SqlConnection(conString);
            d.Open();
            SqlCommand komut = new SqlCommand("select *from tbl_proje  where kartNo_id='" + a + "'", d);
            SqlDataReader read = komut.ExecuteReader();


            if (read.Read())
            {
                txt_GprojeAdi.Text = read["proje_adi"].ToString();
                txt_GteknikUzman.Text = read["proje_uzman"].ToString();
                metroDateTime1.Text = read["proje_tarih"].ToString();
                metroDateTime2.Text = read["proje_tarihTahmin"].ToString();
                txt_GisAciklama.Text = read["proje_isAciklama"].ToString();
                txt_Gnot.Text = read["proje_not"].ToString();
            }

            d.Close();
            d.Open();
            SqlCommand komut2 = new SqlCommand("select *from tbl_task  where task_fk_kartNo='" + a + "'", d);
            SqlDataReader read2 = komut2.ExecuteReader();
            int c = 0;
            while (read2.Read())
            {               
                if (c==0)
                {
                    txt_GyapilacakIs1.Text = read2["task_yapilacakIs"].ToString();
                    txt_Gaciklama1.Text = read2["task_aciklama"].ToString();
                    cb_Gdurum1.Text = read2["task_durum"].ToString();
                    c++;
                }
                else if (c == 1)
                {
                    txt_GyapilacakIs2.Text = read2["task_yapilacakIs"].ToString();
                    txt_Gaciklama2.Text = read2["task_aciklama"].ToString();
                    cb_Gdurum2.Text = read2["task_durum"].ToString();
                    c++;
                }
                else if (c == 2)
                {
                    txt_GyapilacakIs3.Text = read2["task_yapilacakIs"].ToString();
                    txt_Gaciklama3.Text = read2["task_aciklama"].ToString();
                    cb_Gdurum3.Text = read2["task_durum"].ToString();
                    c++;
                }
                else if (c == 3)
                {
                    txt_GyapilacakIs4.Text = read2["task_yapilacakIs"].ToString();
                    txt_Gaciklama4.Text = read2["task_aciklama"].ToString();
                    cb_Gdurum4.Text = read2["task_durum"].ToString();
                    c++;
                }
                else if (c == 4)
                {
                    txt_GyapilacakIs5.Text = read2["task_yapilacakIs"].ToString();
                    txt_Gaciklama5.Text = read2["task_aciklama"].ToString();
                    cb_Gdurum5.Text = read2["task_durum"].ToString();
                    c++;
                }
                else if (c == 5)
                {
                    txt_GyapilacakIs6.Text = read2["task_yapilacakIs"].ToString();
                    txt_Gaciklama6.Text = read2["task_aciklama"].ToString();
                    cb_Gdurum6.Text = read2["task_durum"].ToString();
                    c++;
                }

            }
            d.Close();
            metroDateTime3.Value = metroDateTime2.Value ;

        }

        private void btn_guncelle2_Click(object sender, EventArgs e)
        {
            SqlConnection d = new SqlConnection(conString);
            d.Open();
            SqlCommand komut2 = new SqlCommand("delete from tbl_task where task_fk_kartNo='" + Convert.ToInt32(txt_GkartNo.Text) + "'", d);
            komut2.ExecuteNonQuery();
            d.Close();
            if (daset.Tables["tbl_task"] != null)
            {
                daset.Tables["tbl_task"].Clear();
            }
            

            if (txt_GyapilacakIs1.Text != "" && txt_Gaciklama1.Text != "" && cb_Gdurum1.Text != "")
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                SqlCommand komut = new SqlCommand("insert into tbl_task(task_fk_kartNo,task_yapilacakIs,task_aciklama,task_durum) values(@task_fk_kartNo,@task_yapilacakIs,@task_aciklama,@task_durum)", con);
                komut.Parameters.AddWithValue("@task_fk_kartNo", txt_GkartNo.Text);
                komut.Parameters.AddWithValue("@task_yapilacakIs", txt_GyapilacakIs1.Text);
                komut.Parameters.AddWithValue("@task_aciklama", txt_Gaciklama1.Text);
                komut.Parameters.AddWithValue("@task_durum", cb_Gdurum1.Text);
                komut.ExecuteNonQuery();
                con.Close();
            }
            if (txt_GyapilacakIs2.Text != "" && txt_Gaciklama2.Text != "" && cb_Gdurum2.Text != "")
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                SqlCommand komut = new SqlCommand("insert into tbl_task(task_fk_kartNo,task_yapilacakIs,task_aciklama,task_durum) values(@task_fk_kartNo,@task_yapilacakIs,@task_aciklama,@task_durum)", con);
                komut.Parameters.AddWithValue("@task_fk_kartNo", txt_GkartNo.Text);
                komut.Parameters.AddWithValue("@task_yapilacakIs", txt_GyapilacakIs2.Text);
                komut.Parameters.AddWithValue("@task_aciklama", txt_Gaciklama2.Text);
                komut.Parameters.AddWithValue("@task_durum", cb_Gdurum2.Text);
                komut.ExecuteNonQuery();
                con.Close();
            }
            if (txt_GyapilacakIs3.Text != "" && txt_Gaciklama3.Text != "" && cb_Gdurum3.Text != "")
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                SqlCommand komut = new SqlCommand("insert into tbl_task(task_fk_kartNo,task_yapilacakIs,task_aciklama,task_durum) values(@task_fk_kartNo,@task_yapilacakIs,@task_aciklama,@task_durum)", con);
                komut.Parameters.AddWithValue("@task_fk_kartNo", txt_GkartNo.Text);
                komut.Parameters.AddWithValue("@task_yapilacakIs", txt_GyapilacakIs3.Text);
                komut.Parameters.AddWithValue("@task_aciklama", txt_Gaciklama3.Text);
                komut.Parameters.AddWithValue("@task_durum", cb_Gdurum3.Text);
                komut.ExecuteNonQuery();
                con.Close();
            }
            if (txt_GyapilacakIs4.Text != "" && txt_Gaciklama4.Text != "" && cb_Gdurum4.Text != "")
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                SqlCommand komut = new SqlCommand("insert into tbl_task(task_fk_kartNo,task_yapilacakIs,task_aciklama,task_durum) values(@task_fk_kartNo,@task_yapilacakIs,@task_aciklama,@task_durum)", con);
                komut.Parameters.AddWithValue("@task_fk_kartNo", txt_GkartNo.Text);
                komut.Parameters.AddWithValue("@task_yapilacakIs", txt_GyapilacakIs4.Text);
                komut.Parameters.AddWithValue("@task_aciklama", txt_Gaciklama4.Text);
                komut.Parameters.AddWithValue("@task_durum", cb_Gdurum4.Text);
                komut.ExecuteNonQuery();
                con.Close();
            }
            if (txt_GyapilacakIs5.Text != "" && txt_Gaciklama5.Text != "" && cb_Gdurum5.Text != "")
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                SqlCommand komut = new SqlCommand("insert into tbl_task(task_fk_kartNo,task_yapilacakIs,task_aciklama,task_durum) values(@task_fk_kartNo,@task_yapilacakIs,@task_aciklama,@task_durum)", con);
                komut.Parameters.AddWithValue("@task_fk_kartNo", txt_GkartNo.Text);
                komut.Parameters.AddWithValue("@task_yapilacakIs", txt_GyapilacakIs5.Text);
                komut.Parameters.AddWithValue("@task_aciklama", txt_Gaciklama5.Text);
                komut.Parameters.AddWithValue("@task_durum", cb_Gdurum5.Text);
                komut.ExecuteNonQuery();
                con.Close();
            }
            if (txt_GyapilacakIs6.Text != "" && txt_Gaciklama6.Text != "" && cb_Gdurum6.Text != "")
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                SqlCommand komut = new SqlCommand("insert into tbl_task(task_fk_kartNo,task_yapilacakIs,task_aciklama,task_durum) values(@task_fk_kartNo,@task_yapilacakIs,@task_aciklama,@task_durum)", con);
                komut.Parameters.AddWithValue("@task_fk_kartNo", txt_GkartNo.Text);
                komut.Parameters.AddWithValue("@task_yapilacakIs", txt_GyapilacakIs6.Text);
                komut.Parameters.AddWithValue("@task_aciklama", txt_Gaciklama6.Text);
                komut.Parameters.AddWithValue("@task_durum", cb_Gdurum6.Text);
                komut.ExecuteNonQuery();
                con.Close();
            }

            Projeler pr = new Projeler();
            pr.Show();
            this.Close();
        }
    }
}
