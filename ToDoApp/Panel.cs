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
    public partial class Panel : MetroFramework.Forms.MetroForm
    {
        public Panel()
        {
            InitializeComponent();
        }
        public string conString = "Data Source=.\\SQLEXPRESS;Initial Catalog=todoproje;Integrated Security=True";
        
        public string str1, str2, str3, str4, str5, x;

        private void btn_3_Click(object sender, EventArgs e)
        {                  
            if (dtg_research.Rows.Count != 1)
            {
                x = dtg_research.CurrentRow.Cells["task_id"].Value.ToString();
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlCommand komut = new SqlCommand("update tbl_task set task_durum = @task_durum where task_id='" + x + "'", con);
                komut.Parameters.AddWithValue("@task_durum", str3);
                komut.ExecuteNonQuery();
                con.Close();
                Listele();
            }                 
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            if ( dtg_InProgress.Rows.Count != 1)
            {
                x = dtg_InProgress.CurrentRow.Cells["task_id"].Value.ToString();
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlCommand komut = new SqlCommand("update tbl_task set task_durum = @task_durum where task_id='" + x + "'", con);
                komut.Parameters.AddWithValue("@task_durum", str2);
                komut.ExecuteNonQuery();
                con.Close();
                Listele();
            }
            
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            if (dtg_InProgress.Rows.Count != 1)
            {
                x = dtg_InProgress.CurrentRow.Cells["task_id"].Value.ToString();
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlCommand komut = new SqlCommand("update tbl_task set task_durum = @task_durum where task_id='" + x + "'", con);
                komut.Parameters.AddWithValue("@task_durum", str4);
                komut.ExecuteNonQuery();
                con.Close();
                Listele();
            }           
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            if (dtg_Check.Rows.Count != 1)
            {
                x = dtg_Check.CurrentRow.Cells["task_id"].Value.ToString();
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlCommand komut = new SqlCommand("update tbl_task set task_durum = @task_durum where task_id='" + x + "'", con);
                komut.Parameters.AddWithValue("@task_durum", str3);
                komut.ExecuteNonQuery();
                con.Close();
                Listele();
            }
               
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            if (dtg_Check.Rows.Count != 1)
            {
                x = dtg_Check.CurrentRow.Cells["task_id"].Value.ToString();
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlCommand komut = new SqlCommand("update tbl_task set task_durum = @task_durum where task_id='" + x + "'", con);
                komut.Parameters.AddWithValue("@task_durum", str5);
                komut.ExecuteNonQuery();
                con.Close();
                Listele();
            }
          
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            if (dtg_Done.Rows.Count != 1)
            {
                x = dtg_Done.CurrentRow.Cells["task_id"].Value.ToString();
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlCommand komut = new SqlCommand("update tbl_task set task_durum = @task_durum where task_id='" + x + "'", con);
                komut.Parameters.AddWithValue("@task_durum", str4);
                komut.ExecuteNonQuery();
                con.Close();
                Listele();
            }
            
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            if (dtg_research.Rows.Count != 1)
            {
                x = dtg_research.CurrentRow.Cells["task_id"].Value.ToString();
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlCommand komut = new SqlCommand("update tbl_task set task_durum = @task_durum where task_id='" + x + "'", con);
                komut.Parameters.AddWithValue("@task_durum", str1);
                komut.ExecuteNonQuery();
                con.Close();
                Listele();
            }
            

        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            if (dtg_todo.Rows.Count != 1)
            {
                x = dtg_todo.CurrentRow.Cells["task_id"].Value.ToString();
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlCommand komut = new SqlCommand("update tbl_task set task_durum = @task_durum where task_id='" + x + "'", con);
                komut.Parameters.AddWithValue("@task_durum", str2);
                komut.ExecuteNonQuery();
                con.Close();
                Listele();
            }
            
        }

        private void btn_geri_Click(object sender, EventArgs e)
        {
            Projeler pr = new Projeler();
            pr.Show();
            this.Close();
        }

        private void Panel_Load(object sender, EventArgs e)
        {           
            str1 = "ToDo";
            str2 = "Research";
            str3 = "InProgres";
            str4 = "Check";
            str5 = "Done";

            lbl_aktifproje.Text = Projeler.aktifId;
            Listele();

        }

        private void Listele()
        {
            DataSet daset = new DataSet();
            DataSet daset2 = new DataSet();
            DataSet daset3 = new DataSet();
            DataSet daset4 = new DataSet();
            DataSet daset5 = new DataSet();
            SqlConnection con = new SqlConnection(conString);

            con.Open();
            SqlDataAdapter adtr1 = new SqlDataAdapter("SELECT * from tbl_task where task_fk_kartNo='" + lbl_aktifproje.Text + "' AND task_durum='" + str1 + "' ", con);
            adtr1.Fill(daset, "tbl_task");
            dtg_todo.DataSource = daset.Tables["tbl_task"];
            con.Close();
            dtg_todo.Columns[0].DisplayIndex = 3;
            dtg_todo.Columns[1].Visible = false;
            dtg_todo.Columns[3].Visible = false;
            dtg_todo.Columns[4].Visible = false;

            con.Open();
            SqlDataAdapter adtr2 = new SqlDataAdapter("SELECT * from tbl_task where task_fk_kartNo='" + lbl_aktifproje.Text + "' AND task_durum='" + str2 + "' ", con);
            adtr2.Fill(daset2, "tbl_task");
            dtg_research.DataSource = daset2.Tables["tbl_task"];
            con.Close();
            dtg_research.Columns[0].DisplayIndex = 3;
            dtg_research.Columns[1].Visible = false;
            dtg_research.Columns[3].Visible = false;
            dtg_research.Columns[4].Visible = false;

            con.Open();
            SqlDataAdapter adtr3 = new SqlDataAdapter("SELECT * from tbl_task where task_fk_kartNo='" + lbl_aktifproje.Text + "' AND task_durum='" + str3 + "' ", con);
            adtr3.Fill(daset3, "tbl_task");
            dtg_InProgress.DataSource = daset3.Tables["tbl_task"];
            con.Close();
            dtg_InProgress.Columns[0].DisplayIndex = 3;
            dtg_InProgress.Columns[1].Visible = false;
            dtg_InProgress.Columns[3].Visible = false;
            dtg_InProgress.Columns[4].Visible = false;

            con.Open();
            SqlDataAdapter adtr4 = new SqlDataAdapter("SELECT * from tbl_task where task_fk_kartNo='" + lbl_aktifproje.Text + "' AND task_durum='" + str4 + "' ", con);
            adtr4.Fill(daset4, "tbl_task");
            dtg_Check.DataSource = daset4.Tables["tbl_task"];
            con.Close();
            dtg_Check.Columns[0].DisplayIndex = 3;
            dtg_Check.Columns[1].Visible = false;
            dtg_Check.Columns[3].Visible = false;
            dtg_Check.Columns[4].Visible = false;
            con.Open();

            SqlDataAdapter adtr5 = new SqlDataAdapter("SELECT * from tbl_task where task_fk_kartNo='" + lbl_aktifproje.Text + "' AND task_durum='" + str5 + "' ", con);
            adtr5.Fill(daset5, "tbl_task");
            dtg_Done.DataSource = daset5.Tables["tbl_task"];
            con.Close();
            dtg_Done.Columns[0].DisplayIndex = 3;
            dtg_Done.Columns[1].Visible = false;
            dtg_Done.Columns[3].Visible = false;
            dtg_Done.Columns[4].Visible = false;

        }

        /*rivate void Temizle()
        {
            dtg_todo.DataSource = null;
            dtg_todo.Rows.Clear();
            dtg_todo.Refresh();
            dtg_research.DataSource = null;
            dtg_research.Rows.Clear();
            dtg_research.Refresh();
            dtg_InProgress.DataSource = null;
            dtg_InProgress.Rows.Clear();
            dtg_InProgress.Refresh();
            dtg_Check.DataSource = null;
            dtg_Check.Rows.Clear();
            dtg_Check.Refresh();
            dtg_Done.DataSource = null;
            dtg_Done.Rows.Clear();
            dtg_Done.Refresh();
        }*/

    }
}
