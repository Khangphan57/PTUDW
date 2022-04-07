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
public bool KTThongTin()
        {
            if(mact.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mact.Focus();
                return false;
            }
            if (tenct.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Tenct.Focus();
                return false;
            }
            if (bachoc.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Bachoc.Focus();
                return false;
            }
           if (makh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Makh.Focus();
                return false;
            }
           if (mang.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mang.Focus();
                return false;
            }
            if (tongsohk.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Tongsohk.Focus();
                return false;
            } 
            return true;
        }
         private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc muốn thoát?","Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if(dg == DialogResult.OK)
            {
                Application.Exit();
            }
        }    
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KTThongTin2())
            {
                try
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();
 
                    cmd.CommandText = "SP_ThemChuongTrinh";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@mact", SqlDbType.NVarChar).Value = mact.Text;
                    cmd.Parameters.Add("@tenct", SqlDbType.NVarChar).Value = tenct.Text;
                    cmd.Parameters.Add("@bachoc", SqlDbType.NVarChar).Value = bachoc.Text;
                    cmd.Parameters.Add("@mang", SqlDbType.NVarChar).Value = mang.Text;
                    cmd.Parameters.Add("@makh", SqlDbType.NVarChar).Value = makh.Text;
                    cmd.Parameters.Add("@tongsohk", SqlDbType.NVarChar).Value = tongsohk.Text;  
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    LayDSHS();
                    Reset();
                    MessageBox.Show("Đã thêm mới chương trình thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
