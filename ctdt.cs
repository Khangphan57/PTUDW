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
        SqlDataAdapter sda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet dslhp = new DataSet();
        public void chendulieu(string hedt, string khoa, string nganh, string ct, string nam, string lop)
        {
            textBox1.Text = hedt;
            textBox2.Text = khoa;
            textBox3.Text = nganh;
            textBox4.Text = ct;
            textBox5.Text = nam;
            textBox6.Text = lop;
        }
        public ctdt(string ct, string nam)
        {

            InitializeComponent();
            DataGrid(ct, nam);

        }
        public void DataGrid(string ct, string nam)
        {
            sc.Open();
            DataTable dtable = new DataTable();
            sda = new SqlDataAdapter(
   "select ctmh.sohk  , malophp , mh.tenmon , mh.sotc, mh.dsmontienquyet , mh.dsmontruoc , kh.tenkh , gv.tengv " +
   "from(((LOPHOCPHAN lhp join MONHOC mh ON lhp.mamon = mh.mamon) Join(GIAOVIEN gv  join KHOA kh ON gv.makh = kh.makh) ON lhp.magv = gv.magv) " +
   "join(LOPHOC lh   Join CHUONGTRINH ct ON lh.mact = ct.mact) ON lhp.malophoc = lh.malophoc) Join CHUONGTRINHMONHOC ctmh ON ctmh.mact=lh.mact and lhp.mamon=ctmh.mamon  " +
   " where ct.tenct=N'" + ct + "'" + "and namvao=N'" + nam + "' ORDER BY ctmh.sohk ASC", sc);
            sda.Fill(dtable);
            dataGridView2.DataSource = dtable;
            sc.Close();
        }


        private void Form1_Load(object sender, EventArgs e)
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
            themLHP f = new themLHP(textBox4.Text);
            f.chendulieu(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            f.Show();
            
        }

        

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGrid(textBox4.Text,textBox5.Text);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
