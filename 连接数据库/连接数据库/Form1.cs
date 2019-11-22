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

namespace 连接数据库
{
    public partial class Form1 : Form
    {
        private SqlConnection conn;
        private SqlCommand com;
        private DataSet myset;
        private SqlDataAdapter da;
        private SqlCommandBuilder myCbd;
        private BindingSource bing1;
        private DataRow datarow;

        public Form1()
        {
            InitializeComponent();
        }

        //加载表格数据
        private void dataview(string strsql)
        {
            string strconn = "Data Source = .; Initial Catalog = XSGL; Integrated Security = SSPI";
            conn = new SqlConnection(strconn);
            
            com = new SqlCommand(strsql, conn);
            da = new SqlDataAdapter();
            da.SelectCommand = com;
            myCbd = new SqlCommandBuilder(da);
            myset = new DataSet();
            bing1 = new BindingSource();
            try
            {
                da.Fill(myset, "sc");
                DataTable dt = myset.Tables["sc"];
                dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
                bing1.DataSource = myset;
                bing1.DataMember = "sc";
                bing1.Filter = "";
                dataGridView1.DataSource = bing1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + "失败，退出系统");
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string strsql = "select id, sno as '学号', cno as '课程号', grade as '成绩' from sc";
            dataview(strsql);
        }

        /*
         * 查询按钮事件
         */
        private void button1_Click(object sender, EventArgs e)
        {
            string strsql = "select id, sno as '学号', cno as '课程号', grade as '成绩' from sc ";
            Form2 f2 = new Form2();
            f2.ShowDialog();
            if (f2.ok == false) return;
            if (f2.sno_text != "")
            {
                if (f2.cno_text != "")
                {
                    if (f2.grade_text != "")
                        strsql += "where sno = '" + f2.sno_text + "' and cno = '" + f2.cno_text + "' and grade = " + f2.grade_text;
                    else strsql += "where sno = '" + f2.sno_text + "' and cno = '" + f2.cno_text + "'";
                }
                else
                {
                    if (f2.grade_text != "")
                        strsql += "where sno = '" + f2.sno_text + "' and grade = " + f2.grade_text;
                    else strsql += "where sno = '" + f2.sno_text + "'";
                }
            }
            else
            {
                if (f2.cno_text != "")
                {
                    if (f2.grade_text != "")
                        strsql += "where cno = '" + f2.cno_text + "' and grade = " + f2.grade_text;
                    else strsql += "where cno = '" + f2.cno_text + "'";
                }
                else
                {
                    if (f2.grade_text != "")
                        strsql += "where grade = " + f2.grade_text;
                    else ;
                }
            }

            dataview(strsql);
        }

        /*
         * 增加数据
         */
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            if (f2.ok == false) return;
            datarow = myset.Tables["sc"].NewRow();
            //获取选中的最后一行的id，新行的id加一，必须要选中
            datarow["id"] = Convert.ToInt32(dataGridView1.SelectedRows[dataGridView1.SelectedRows.Count - 1].Cells[0].Value) + 1;
            datarow["学号"] = f2.sno_text.Trim();
            datarow["课程号"] = f2.cno_text.Trim();
            datarow["成绩"] = Convert.ToDouble(f2.grade_text.Trim());
            myset.Tables["sc"].Rows.Add(datarow);
            //更新到数据库
            try
            {
                da.InsertCommand = myCbd.GetInsertCommand();
                da.Update(myset.Tables["sc"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("插入失败" + ex.Message);
            }

            /*
            myset.Tables[0].AcceptChanges();
            myset.Clear();
            da.Fill(myset, "sc");
            dataGridView1.Refresh();
            */
        }

        /*
         * 删除数据
         */
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除数据吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int k = dataGridView1.SelectedRows.Count;
                //控件selectionmode属性设为fullrowselect
                for (int i = k; i >= 1; i--)
                {
                    try
                    {
                        //这里选中行的索引不能有重复,否则会报错
                        int id = Convert.ToInt32(dataGridView1.SelectedRows[i - 1].Cells[0].Value);
                        DataRow row = myset.Tables["sc"].Rows.Find(id);
                        row.Delete();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                                
                }
            }
            //更新到数据库
            try
            {
                //da.InsertCommand = myCbd.GetInsertCommand();
                //da.UpdateCommand = myCbd.GetUpdateCommand();
                da.DeleteCommand = myCbd.GetDeleteCommand();
                da.Update(myset.Tables["sc"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "删除失败");
            }
        }

        //修改数据
        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            datarow = myset.Tables["sc"].Rows.Find(id);
            datarow.BeginEdit();
            
            Form2 f2 = new Form2();
            f2.ShowDialog();
            if (f2.ok == false) return;
            datarow["id"] = id;
            datarow["学号"] = f2.sno_text;
            datarow["课程号"] = f2.cno_text;
            datarow["成绩"] = f2.grade_text;
            datarow.EndEdit();
            //更新数据库

            try
            {
                //da.InsertCommand = myCbd.GetInsertCommand();
                da.UpdateCommand = myCbd.GetUpdateCommand();
                //da.DeleteCommand = myCbd.GetDeleteCommand();
                da.Update(myset.Tables["sc"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "更新失败");
            }
        }


        

        
    }
}
