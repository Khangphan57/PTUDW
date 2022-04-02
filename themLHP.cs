using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QLLHP
{
    public partial class themLHP : Form
    {
        SqlConnection sc = new SqlConnection("data source =LAPTOP-CG9B8T7E\\SQLEXPRESS; initial catalog =QLSV; User ID =sa; Password =nhom5");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        SqlDataReader sdr;
        DataSet ds = new DataSet();
        public void chendulieu(string hedt, string khoa, string nganh, string ct, string nam, string lop)
        {
            textBox1.Text = hedt;
            textBox2.Text = khoa;
            textBox3.Text = nganh;
            textBox4.Text = ct;
            textBox5.Text = nam;
            textBox6.Text = lop;
        }
        public themLHP(string ct)
        {

            InitializeComponent();
            sc.Open();
            cmd = new SqlCommand("select mh.tenmon, gv.tengv from ((CHUONGTRINHMONHOC ctmh join CHUONGTRINH ct on ctmh.mact=ct.mact) join MONHOC mh on mh.mamon=ctmh.mamon) Join (GIAOVIENMONHOC gvmh join GIAOVIEN gv on gvmh.magv = gv.magv) on gvmh.mamon = ctmh.mamon where tenct=N'" + ct + "'", sc);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                string mh = sdr.GetString(0).Trim();
                string gv = sdr.GetString(1).Trim();
                if (cbb_mh.Items.Contains(mh) == false)
                { cbb_mh.Items.Add(mh); }
                if (cbb_gv.Items.Contains(gv) == false)
                { cbb_gv.Items.Add(gv); }

            }
            
            sc.Close();
            if (cbb_mh.Items.Count > 0)
            {
                cbb_mh.SelectedIndex = 0;
            }
            sc.Open();
            cmd = new SqlCommand("select maloaihp from LOAIHP", sc);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                string loaihp = sdr.GetString(0);
                cbb_loaihp.Items.Add(loaihp);
            }
            sc.Close();


        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sc.Open();
            cmd = new SqlCommand(" select mamon from MONHOC where tenmon=N'" + cbb_mh.SelectedItem + "'", sc);
            sdr = cmd.ExecuteReader();
            sdr.Read();
            tb_mmon.Text = sdr.GetString(0);
            sc.Close();

            sc.Open();
            cbb_gv.Items.Clear();
            cbb_sohk.Items.Clear();
            cmd = new SqlCommand(" select  gv.tengv, sohk from ((CHUONGTRINHMONHOC ctmh join CHUONGTRINH ct on ctmh.mact=ct.mact) " +
                "join MONHOC mh on mh.mamon=ctmh.mamon) Join (GIAOVIENMONHOC gvmh join GIAOVIEN gv on gvmh.magv = gv.magv) " +
                "on gvmh.mamon = ctmh.mamon where tenmon = N'"+ cbb_mh.SelectedItem+ "'", sc);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                string khoa = sdr.GetString(0).Trim();
                int sohk = sdr.GetInt32(1);
                cbb_gv.Items.Add(khoa);
                if (cbb_sohk.Items.Contains(sohk) == false)
                {
                    cbb_sohk.Items.Add(sohk);
                    for (int i = sohk + 1; i < 7; i++)
                    {
                        cbb_sohk.Items.Add(i);
                    }
                }

            }
            sdr.Close();
            sc.Close();
            if (cbb_mh.Items.Count > 0)
            { cbb_gv.SelectedIndex = 0; }
        }

        private void cbb_gv_SelectedIndexChanged(object sender, EventArgs e)
        {
            sc.Open();
            cmd = new SqlCommand(" select magv from GIAOVIEN where tengv=N'" + cbb_gv.SelectedItem + "'", sc);
            sdr = cmd.ExecuteReader();
            sdr.Read();
            tb_magv.Text = sdr.GetString(0);
            sc.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (tb_mmon.Text != "" && tb_magv.Text != "" && cbb_loaihp.SelectedItem.ToString() !="" && cbb_sohk.SelectedItem.ToString() !="" )
            {
                sc.Open();
                cmd = new SqlCommand("select  count(malophp) as dem  from LOPHOCPHAN lhp join MONHOC mh ON mh.mamon=lhp.mamon where lhp.mamon='" + tb_mmon.Text + "' group by lhp.mamon", sc);
                sdr = cmd.ExecuteReader();
                sdr.Read();
                int dem = sdr.GetInt32(0) + 1;
                string malhp = taoma(cbb_mh.SelectedItem.ToString())+ dem.ToString();
                cmd = new SqlCommand("INSERT into LOPHOCPHAN(malophp,malophoc,sohk,mamon,magv,maloaihp) values (@malophp, @malophoc, @sohk, @mamon,@magv,@maloaihp)", sc);
                sc.Close();
                sc.Open();
                cmd.Parameters.AddWithValue("@malophp", malhp );
                cmd.Parameters.AddWithValue("@malophoc", textBox6.Text );
                cmd.Parameters.AddWithValue("@sohk", cbb_sohk.SelectedItem);
                cmd.Parameters.AddWithValue("@mamon", tb_mmon.Text);
                cmd.Parameters.AddWithValue("@magv", tb_magv.Text);
                cmd.Parameters.AddWithValue("@maloaihp", cbb_loaihp.SelectedItem);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công. Nhấp vào Bảng DSLHP để tải lại");
                sc.Close();
                
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin   ");
            }
        }
        public static string taoma(string input)
        {
            string a = "";
            int i = 0;
            a += input[0];
            for (i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == ' ' || input[i] == '\t' ||
                    input[i] == '\n')
                {
                    a += input[i + 1];
                }
            }
            return a;
        }
    }
}
