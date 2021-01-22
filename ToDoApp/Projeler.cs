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
    public partial class Projeler : MetroFramework.Forms.MetroForm
    {
        public Projeler()
        {
            InitializeComponent();
        }

        public string conString = "Data Source=.\\SQLEXPRESS;Initial Catalog=todoproje;Integrated Security=True";
        
        DataSet daset = new DataSet();
        static public string aktifId;
        private void Projeler_Load(object sender, EventArgs e)
        {
            Guncelle();
            //con.Open(); 
            //string giris = "SELECT proje_adi from tbl_proje ";
            //SqlCommand komut = new SqlCommand(giris, con);


            //SqlDataAdapter d = new SqlDataAdapter(komut);
            //SqlDataReader r = komut.ExecuteReader();

            //while (r.Read()) 
            //{
            //    ToDo.Items.Add(r["proje_adi"]);
            //}
            //con.Close(); 
        }

        private void Guncelle()
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from tbl_proje", con);
            adtr.Fill(daset, "tbl_proje");
            metroGrid1.DataSource = daset.Tables["tbl_proje"];
            con.Close();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            string b = metroGrid1.CurrentRow.Cells["kartNo_id"].Value.ToString();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand komut2 = new SqlCommand("delete from tbl_task where task_fk_kartNo='" + b + "'", con);
            komut2.ExecuteNonQuery();
            con.Close();
            con.Open();
            SqlCommand komut = new SqlCommand("delete from tbl_proje where kartNo_id='" + metroGrid1.CurrentRow.Cells["kartNo_id"].Value.ToString() + "'", con);
            komut.ExecuteNonQuery();
            con.Close();
            daset.Tables["tbl_proje"].Clear();
            
            
            daset.Tables["tbl_proje"].Clear();
            if (daset.Tables["tbl_task"] != null)
            {
                daset.Tables["tbl_task"].Clear();
            }
            

            Guncelle();
            MessageBox.Show("Proje panelden silindi.");
            
        }

        private void btn_geridon_Click(object sender, EventArgs e)
        {
            Main ma = new Main();
            ma.Show();
            this.Close();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            aktifId = metroGrid1.CurrentRow.Cells["kartNo_id"].Value.ToString();
            Güncelle gn = new Güncelle();
            gn.Show();
            this.Close();
        }

        private void btn_ac_Click(object sender, EventArgs e)
        {
            aktifId = metroGrid1.CurrentRow.Cells["kartNo_id"].Value.ToString();
            Panel pn = new Panel();
            pn.Show();
            this.Close();
        }
    }
}
