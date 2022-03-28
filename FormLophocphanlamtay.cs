using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Timkiemlophocphan
{
    public partial class Form1 : Form
    {
        public static string un;
        public string username;
        public string alias;
        public static Form1 me;
        String str = @"Data Source=DESKTOP-J79GQJ1\SQLEXPRESS;Initial Catalog=QLSVtrang;Integrated Security=True";
        SqlConnection con = null;

        string suffer = @"USE QLSVtrang; SELECT DISTINCT @X FROM (SELECT E.bachoc,E.tenkh,E.tenng,E.tenct,E.namvao,E.malophoc,E.tenmon FROM (SELECT D.*,MH.tenmon FROM MONHOC AS MH 
RIGHT JOIN (SELECT C.*,LHP.malophp,LHP.mamon FROM  LOPHOCPHAN AS LHP RIGHT JOIN (SELECT B.*, LH.malophoc,LH.namvao  FROM LOPHOC AS LH RIGHT JOIN (SELECT A.*,NG.tenng
FROM NGANH AS NG RIGHT JOIN (SELECT CT.*,K.tenkh FROM KHOA AS K RIGHT JOIN CHUONGTRINH AS CT ON CT.makh=K.makh) AS A ON A.mang=NG.mang) AS B on B.mact=LH.mact) AS C
ON C.malophoc=LHP.malophoc) AS D ON D.mamon=MH.mamon) AS E) as I WHERE @X IS NOT NULL";
        String[] tenbien = { "bachoc", "tenkh", "tenng", "tenct", "namvao", "malophoc", "tenmon" };
        List<String> dieukien = new List<String>();




        public Form1()
        {


            InitializeComponent();

        }

      
        public void comboBox3_DropDown(object sender, EventArgs e)
        {
            comboBox3.Items.Clear(); 
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmd1= new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = suffer.Replace("@X",tenbien[0]);
            SqlDataReader dr1=cmd1.ExecuteReader();
            while (dr1.Read())
            { comboBox3.Items.Add(dr1.GetString(0)); }
            dr1.Close();
            


        }

        public void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dieukien.Add(comboBox3.SelectedItem.ToString());
            comboBox4.Items.Clear();
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandText = suffer.Replace("@X", tenbien[1])
                +" AND "+tenbien[0]+"=N'"+comboBox3.SelectedItem.ToString()+"'";
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            { comboBox4.Items.Add(dr2.GetString(0)); }
            dr2.Close();
            
        }

       public void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            dieukien.Add(comboBox4.SelectedItem.ToString());
            comboBox5.Items.Clear();
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con;
            cmd3.CommandText = suffer.Replace("@X", tenbien[2]) 
                + " AND " + tenbien[0] + "=N'" + comboBox3.SelectedItem.ToString() + "'" 
                + " AND " + tenbien[1] + "=N'" + comboBox4.SelectedItem.ToString() + "'";
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            { comboBox5.Items.Add(dr3.GetString(0)); }
            dr3.Close();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            dieukien.Add(comboBox5.SelectedItem.ToString());
            comboBox6.Items.Clear();
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = con;
            cmd4.CommandText = suffer.Replace("@X", tenbien[3]) 
                + " AND " + tenbien[0] + "=N'" + comboBox3.SelectedItem.ToString() + "'" 
                + " AND " + tenbien[1] + "=N'" + comboBox4.SelectedItem.ToString() + "'"
                + " AND " + tenbien[2] + "=N'" + comboBox5.SelectedItem.ToString()+"'";
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            { comboBox6.Items.Add(dr4.GetString(0)); }
            dr4.Close();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            dieukien.Add(comboBox6.SelectedItem.ToString());
            comboBox7.Items.Clear();
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmd5 = new SqlCommand();
            cmd5.Connection = con;
            cmd5.CommandText = suffer.Replace("@X", tenbien[4])
                + " AND " + tenbien[0]  + "=N'" + comboBox3.SelectedItem.ToString() + "'" 
                + " AND " + tenbien[1] + "=N'"+ comboBox4.SelectedItem.ToString() + "'"
                + " AND " + tenbien[2] + "=N'" + comboBox5.SelectedItem.ToString()+ "'"
                + " AND " + tenbien[3] + "=N'" + comboBox6.SelectedItem.ToString() + "'";
            SqlDataReader dr5 = cmd5.ExecuteReader();
            while (dr5.Read())
            { comboBox7.Items.Add(dr5.GetInt32(0)); }
            dr5.Close();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            dieukien.Add(comboBox7.SelectedItem.ToString());
            comboBox8.Items.Clear();
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmd6 = new SqlCommand();
            cmd6.Connection = con;
            cmd6.CommandText = suffer.Replace("@X", tenbien[5])
                + " AND " + tenbien[0] + "=N'" + comboBox3.SelectedItem.ToString() + "'"
                + " AND " + tenbien[1] + "=N'" + comboBox4.SelectedItem.ToString() + "'"
                + " AND " + tenbien[2] + "=N'" + comboBox5.SelectedItem.ToString() + "'"
                + " AND " + tenbien[3] + "=N'" + comboBox6.SelectedItem.ToString() + "'"
                + " AND " + tenbien[4] + "=N'" + comboBox7.SelectedItem.ToString() + "'";
            SqlDataReader dr6 = cmd6.ExecuteReader();
            while (dr6.Read())
            { comboBox8.Items.Add(dr6.GetString(0)); }
            dr6.Close();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            dieukien.Add(comboBox8.SelectedItem.ToString());
            comboBox9.Items.Clear();
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmd7 = new SqlCommand();
            cmd7.Connection = con;
            cmd7.CommandText = suffer.Replace("@X", tenbien[6])
                + " AND " + tenbien[0] + "=N'" + comboBox3.SelectedItem.ToString() + "'"
                + " AND " + tenbien[1] + "=N'" + comboBox4.SelectedItem.ToString() + "'"
                + " AND " + tenbien[2] + "=N'" + comboBox5.SelectedItem.ToString() + "'"
                + " AND " + tenbien[3] + "=N'" + comboBox6.SelectedItem.ToString() + "'"
                + " AND " + tenbien[4] + "=N'" + comboBox7.SelectedItem.ToString() + "'"
                + " AND " + tenbien[4] + "=N'" + comboBox7.SelectedItem.ToString() + "'";
            SqlDataReader dr7 = cmd7.ExecuteReader();
            while (dr7.Read())
            { comboBox9.Items.Add(dr7.GetString(0)); }
            dr7.Close();
        }
        public void khoacontrol()
        {
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;
            comboBox7.Enabled = false;
            comboBox8.Enabled = false;
            comboBox9.Enabled = false;

        }
        public void mocontrol()
        { comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            comboBox5.Enabled = true;
            comboBox6.Enabled = true;
            comboBox7.Enabled = true; 
            comboBox8.Enabled = true;
            comboBox9.Enabled = true;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text.Trim() !=null)
            {
                khoacontrol();
                textBox2.Enabled = false;
                textBox1.Focus();
            }
            else
            {
                mocontrol();
                textBox2.Enabled=true    ;
            }
        }
   

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (textBox2.Text.Trim() != null)
            {
                khoacontrol();
                textBox1.Enabled = false;
                textBox2.Focus();
            }
            else
            {
                mocontrol();
                textBox1.Enabled = true;
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Enabled=true)
            { Form2 f2 = new Form2();
                f2.Show();
            }
        }
    }
    }

