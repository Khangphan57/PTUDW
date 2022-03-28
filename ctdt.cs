using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLLHP
{
    public partial class ctdt : Form
    {
        SqlConnection sc = new SqlConnection("data source =LAPTOP-CG9B8T7E\\SQLEXPRESS; initial catalog =QLSV; User ID =sa; Password =nhom5");
        //ArrayList mahp = new ArrayList();
        //ArrayList mon = new ArrayList();
        //ArrayList sotc = new ArrayList();
        //ArrayList dstq = new ArrayList();
        //ArrayList dsmt = new ArrayList();
        //ArrayList khoa = new ArrayList();
        //ArrayList gv = new ArrayList(); 
        //ArrayList sohk = new ArrayList();

        public void chendulieu(string hedt, string khoa, string nganh, string ct)
        {
            textBox1.Text = hedt;
            textBox2.Text = khoa;
            textBox3.Text = nganh;
            textBox4.Text = ct;
        }
        public  ctdt(string ct)
        {
           
            InitializeComponent();
            sc.Open();
            SqlCommand cmd = new SqlCommand(
   "select malophp, mh.tenmon, mh.sotc, mh.dsmontienquyet, mh.dsmontruoc, kh.tenkh, gv.tengv, sohk, lh.mact, ct.tenct, lh.malophoc " +
   "from((LOPHOCPHAN lhp join MONHOC mh ON lhp.mamon = mh.mamon) Join(GIAOVIEN gv  join KHOA kh ON gv.makh = kh.makh) ON lhp.magv = gv.magv) " +
   "join(LOPHOC lh   Join CHUONGTRINH ct ON lh.mact = ct.mact) ON lhp.malophoc = lh.malophoc where ct.tenct=N'" + ct +"'", sc);
            SqlDataReader sdr = cmd.ExecuteReader();
            int i = 0;
            while (sdr.Read())
            {
                
                i = i + 1;
                string stt = i.ToString();
                string mahp = sdr.GetString(0).Trim();
                string mon = sdr.GetString(1).Trim();
                string sotc = sdr.GetInt32(2).ToString().Trim();
                string dstq = sdr.GetString(3);
                string dsmt = sdr.GetString(4);
                string kh = sdr.GetString(5);
                string gv = sdr.GetString(6);
                string sohk = sdr.GetString(7);

                string[] row = new string[9] { stt, mahp, mon, sotc, dstq, dsmt, kh, gv, sohk };
                dataGridView1.Rows.Add(row);

            }

            sc.Close();

            }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        public Form findForm(string formName)
        {
            Form foundform = null;
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == formName)
                {
                    foundform = f;
                    break;
                }
            }
            return foundform;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
                Form3 f = new Form3();
                f.Show();
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
