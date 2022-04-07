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
            if(txtMaGV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên giáo viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTen.Focus();
                return false;
            }
            if (TenGV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên giáo viên ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return false;
            }
            if (Email.Text == "")
            {
                MessageBox.Show("Vui lòng nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return false;
            }
           if (MaKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã khoa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return false;
            }
           if (lathinhgiang.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thỉnh giảng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
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
            if (KTThongTin())
            {
                try
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();
 
                    cmd.CommandText = "SP_ThemGiaoVien";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MaGV", SqlDbType.NVarChar).Value = MaGV.Text;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email.Text;
                    cmd.Parameters.Add("@TenGV", SqlDbType.NVarChar).Value = TenGV.Text;
                    cmd.Parameters.Add("@MaKH", SqlDbType.NVarChar).Value = MaKH.Text;
                    cmd.Parameters.Add("@lathinhgiang", SqlDbType.NVarChar).Value = lathinhgiang.Text;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    LayDSHS();
                    Reset();
                    MessageBox.Show("Đã thêm mới giáo viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
