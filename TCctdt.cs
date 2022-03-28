using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections;

namespace QLLHP
{
    public partial class TCctdt : Form
    { 
        SqlConnection sc = new SqlConnection("data source =LAPTOP-CG9B8T7E\\SQLEXPRESS; initial catalog =QLSV; User ID =sa; Password =nhom5");


        public TCctdt()
        {
            InitializeComponent();
            //SqlConnection sc = new SqlConnection("data source =LAPTOP-CG9B8T7E\\SQLEXPRESS; initial catalog =QLSV; User ID =sa; Password =nhom5");
            sc.Open();
            SqlCommand cmd = new SqlCommand(
                " select  distinct ct.bachoc, kh.tenkh , ng.tenng , tenct from (CHUONGTRINH ct join KHOA kh ON ct.makh=kh.makh )  Join NGANH ng ON ng.mang=ct.mang ", sc);

            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                string bachoc = sdr.GetString(0).Trim();
                string khoa = sdr.GetString(1).Trim();
                string nganh = sdr.GetString(2).Trim();
                string ct = sdr.GetString(3).Trim();
                if (comboBox1.Items.Contains(bachoc) == false)
                { comboBox1.Items.Add(bachoc); }
               
                if (comboBox2.Items.Contains(khoa) == false)
                { comboBox2.Items.Add(khoa); }
                
                if (comboBox3.Items.Contains(nganh) == false)
                { comboBox3.Items.Add(nganh); }

                if (comboBox4.Items.Contains(ct) == false)
                { comboBox4.Items.Add(ct); }
                
            }

            sc.Close();
            comboBox1.SelectedIndex = 0;

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {

            }
            else
            {
                
                ctdt f = new ctdt(comboBox4.SelectedItem.ToString());
                f.chendulieu(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString(), comboBox4.SelectedItem.ToString());

                f.Show();
            } 
                
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            sc.Open(); 
            comboBox2.Items.Clear();
                SqlCommand cmd = new SqlCommand(
                "select  distinct  kh.tenkh from CHUONGTRINH ct join KHOA kh ON ct.makh=kh.makh where bachoc=N'" + comboBox1.SelectedItem + "'", sc);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {  
                    string khoa = sdr.GetString(0).Trim();
                
                    comboBox2.Items.Add(khoa);
                  }
            sdr.Close();
            sc.Close();
            comboBox2.SelectedIndex = 0;

        }



        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
            {
            
            sc.Open();
            comboBox3.Items.Clear();
            SqlCommand cmd = new SqlCommand(
                "select  distinct  ng.tenng  from (CHUONGTRINH ct join KHOA kh ON ct.makh=kh.makh )  Join NGANH ng ON ng.mang=ct.mang where tenkh=N'" + comboBox2.SelectedItem + "'", sc);
            SqlDataReader sdr1 = cmd.ExecuteReader();
            while (sdr1.Read())
            {
                string nganh = sdr1.GetString(0).Trim();
                comboBox3.Items.Add(nganh);
            }
            sdr1.Close();
            sc.Close();
            comboBox3.SelectedIndex = 0;

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            sc.Open();
            comboBox4.Items.Clear();
            SqlCommand cmd = new SqlCommand(
                " select  distinct  ct.tenct  from (CHUONGTRINH ct join KHOA kh ON ct.makh=kh.makh )  Join NGANH ng ON ng.mang=ct.mang where tenng = N'" + comboBox3.SelectedItem + "'", sc);
            SqlDataReader sdr2 = cmd.ExecuteReader();
            while (sdr2.Read())
            {
                string ct = sdr2.GetString(0).Trim();
                comboBox4.Items.Add(ct);
            }
            sdr2.Close();
            sc.Close();
            comboBox4.SelectedIndex = 0;
        }

    }
}
