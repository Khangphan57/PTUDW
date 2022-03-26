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

namespace GIAO_DIEN
{
    public partial class Tra_cuu_lop_hoc_phan : Form
    {
        string Sqlstring = @"Data Source=DESKTOP-J79GQJ1\SQLEXPRESS;Initial Catalog=QLSVtrang;Integrated Security=True";
        SqlConnection SqlCon = null;


        public Tra_cuu_lop_hoc_phan()
        {
            comboBox = new ComboBox[7];
            InitializeComponent();

            

            String suffer = @"USE QLSVtrang; SELECT DISTINCT @X FROM (SELECT E.bachoc,E.tenkh,E.tenng,E.tenct,E.namvao,E.malophoc,E.tenmon FROM (SELECT D.*,MH.tenmon FROM MONHOC AS MH 
RIGHT JOIN (SELECT C.*,LHP.malophp,LHP.mamon FROM  LOPHOCPHAN AS LHP RIGHT JOIN (SELECT B.*, LH.malophoc,LH.namvao  FROM LOPHOC AS LH RIGHT JOIN (SELECT A.*,NG.tenng
FROM NGANH AS NG RIGHT JOIN (SELECT CT.*,K.tenkh FROM KHOA AS K RIGHT JOIN CHUONGTRINH AS CT ON CT.makh=K.makh) AS A ON A.mang=NG.mang) AS B on B.mact=LH.mact) AS C
ON C.malophoc=LHP.malophoc) AS D ON D.mamon=MH.mamon) AS E) as I WHERE @X IS NOT NULL and 1=1 and 2=2 and 3=3 and 4=4 and 5=5 and 6=6 and 7=7";
            //them DS HEDAOTAO
            if (SqlCon == null)
            {
                SqlCon = new SqlConnection(Sqlstring);
                if (SqlCon.State == ConnectionState.Closed)
                { SqlCon.Open(); }
                String[] tenbien = { "bachoc", "tenkh", "tenng", "tenct", "namvao", "malophoc", "tenmon" };
               
                List<string> bienluu = new List<string>();


                //for (int i = 0; i < comboBox.Length; i++)
                //{
                //    comboBox[i].SelectedIndexChanged += (o, e) =>
                //    {
                //        string opt = comboBox[i].SelectedItem.ToString();
                //        suffer += String.Format(" AND %s = '%s'", tenbien[i], opt);
                //    }
                //}

                SqlCommand[] cmds = new SqlCommand[tenbien.Length]; for (int i = 0; i < cmds.Length; i++) cmds[i] = new SqlCommand();
                SqlDataReader[] drs = new SqlDataReader[tenbien.Length];
                for (int i = 0; i < tenbien.Length; i++)
                {
                    String cmd = suffer;
                    comboBox[i].SelectedIndexChanged += (o, e) =>
                        {
                            for (int j = i + 1; j < tenbien.Length; j++)
                            {
                                throw new ArithmeticException("1");
                                throw new ArithmeticException(suffer.Replace("@X", tenbien[j]).Replace(String.Format("%s=%s", i, i), opt));
                                cmds[j].CommandText = suffer.Replace("@X", tenbien[j]).Replace(String.Format("%s=%s", i, i), opt);
                                
                                drs[j] = cmds[j].ExecuteReader();
                                while (drs[j].Read())
                                {
                                    //bienluu.Add(drs[i].ToString());

                                    if (j != 4 && !comboBox[j].Items.Contains(drs[j].GetString(0)))
                                    {
                                        comboBox[j].Items.Add(drs[j].GetString(0));
                                    }
                                    else if (j == 4 && !comboBox[j].Items.Contains((drs[j].GetInt32(0))))
                                    {
                                        comboBox[j].Items.Add(drs[j].GetInt32(0));
                                    }
                                    //drs[j].Close();
                                }

                            }
                        };
                    cmds[i].CommandText = suffer.Replace("@X", tenbien[i]);
                    cmds[i].Connection = SqlCon;
                    drs[i] = cmds[i].ExecuteReader();
                    while (drs[i].Read())

                        //bienluu.Add(drs[i].ToString());

                        if (i!=4 && !comboBox[i].Items.Contains(drs[i].GetString(0)))
                        {
                            comboBox[i].Items.Add(drs[i].GetString(0));
                        }
                        else if (i == 4 && !comboBox[i].Items.Contains((drs[i].GetInt32(0))))
                    {
                        comboBox[i].Items.Add(drs[i].GetInt32(0));
                    }

                    drs[i].Close();
                }
                

                //comboBox[0].SelectedIndexChanged += (o, e) =>
                //{

                //}







            }


        }
    }
}

    




