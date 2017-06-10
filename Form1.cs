using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;

namespace GDIPlusDemo
{

    public partial class Form1 : Form
    {
         private string ConnectionString =
            "Data Source=123.206.17.200;Initial Catalog=numb;" +
    "Persist Security Info=True;UID=root;pwd=zmy12345";
        private MySqlConnection conn = null;
        private MySqlDataAdapter DataAdapter = null;
        private DataSet dataset = null;
        private string curNo = "";
        DataSet ds = new DataSet();
        private MySqlCommand cmd = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void showData()  //在控件dataGridView1显示数据
        {
            try
            {
                conn.Open();
                DataAdapter = new MySqlDataAdapter("SELECT * FROM student", conn);
                dataset = new DataSet();
                DataAdapter.Fill(dataset,"t1");
                dataGridView1.DataSource = dataset;
                dataGridView1.DataMember = dataset.Tables[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
                dataset.Dispose();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            
            //设置连接字符串
            string ConnectionString = "Data Source=123.206.17.200;Initial Catalog=numb;" +
"Persist Security Info=True;UID=root;pwd=zmy12345";
            DataSet dataset = new DataSet();    //创建数据集
            //创建一个新连接
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                //创建数据提供者
                MySqlDataAdapter DataAdapter =
                new MySqlDataAdapter("SELECT * FROM student", conn);
                //填充数据集dataset，并为本次填充的数据起名“student_table”
                DataAdapter.Fill(dataset, "t1");
                dataGridView1.DataSource = dataset;

                //在dataGridView1控件中显示名为student_table的填充数据
                dataGridView1.DataMember = "t1";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                dataset.Dispose();
            }
        }
       
        public showgrade s1;
        
        public search s2;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(720, 620);
            this.MinimumSize = new Size(720, 620);
            s1 = new showgrade();           
            s2 = new search();
            conn = new MySqlConnection(ConnectionString);
            showData3();
            try
            {
                conn = new MySqlConnection(ConnectionString);
                conn.Open();
                DataAdapter = new MySqlDataAdapter();
                dataset = new DataSet();
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM student";
                DataAdapter.SelectCommand = cmd;
                DataAdapter.Fill(dataset, "t1");
                comboBox1.Items.Clear();
                //先获取所有的字段，以用于构造查询条件
                for (int i = 0; i < dataset.Tables["t1"].Columns.Count; i++)
                    comboBox1.Items.Add(dataset.Tables["t1"].Columns[i].ToString());
                dataset.Clear();
                comboBox2.Items.Add(" = ");  //设置比较运算符
                comboBox2.Items.Add(" < ");
                comboBox2.Items.Add(" > ");
                comboBox2.Items.Add(" like ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn = new MySqlConnection(ConnectionString);
            showData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            string tb1 = textBox1.Text;
            if (comboBox2.Text == " like ") tb1 = "%" + textBox1.Text + "%";
            string strSQL = "SELECT * FROM student Where ";
            strSQL += comboBox1.Text + comboBox2.Text + "'" + tb1 + "'";
            try
            {
                cmd.CommandText = strSQL;
                DataAdapter.SelectCommand = cmd;
                dataset.Clear();
                DataAdapter.Fill(dataset, "t1");
                dataGridView1.DataSource = dataset;
                dataGridView1.DataMember = "t1";
            }
            catch
            {
                MessageBox.Show("请正确设置检索条件！");
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void showData3()  //在控件dataGridView1显示数据
        {
            try
            {
                if (conn == null) conn.Open();
                DataAdapter = new MySqlDataAdapter("SELECT * FROM student", conn);
                dataset = new DataSet();
                DataAdapter.Fill(dataset, "t1");
                dataGridView1.DataSource = dataset;
                dataGridView1.DataMember = "t1";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (conn != null) conn.Close();
                DataAdapter.Dispose();
                dataset.Dispose();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 1) return;
            int index = dataGridView1.CurrentRow.Index; 	//获取当记录的索引号 
            dataGridView1.Rows[index].Selected = true; 	//加亮显示 
            curNo = this.dataGridView1.Rows[index].Cells[0].Value.ToString();
            MySqlCommand command = null;
            string strSQL = "Delete From student Where 学号 = '" + curNo + "'";
            try
            {
                command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = strSQL;
                conn.Open();
                int n = command.ExecuteNonQuery();		//执行Delete 语句  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
                command.Dispose();
            }
            showData3();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            string strSQL = "INSERT INTO student VALUES(";
            strSQL += "'" + textBox2.Text;
            strSQL += "','" + textBox3.Text;
            strSQL += "','" + textBox4.Text;
            strSQL += "','" + textBox5.Text;
            strSQL += "','" + textBox6.Text;
            strSQL += "','" + textBox7.Text;
            strSQL += "','" + textBox8.Text;
            strSQL += "','" + textBox9.Text;
            strSQL += "','" + textBox10.Text;
            strSQL += "','" + textBox11.Text;
            strSQL += "','" + textBox12.Text;
            strSQL += "','" + textBox13.Text;
            strSQL += "','" + textBox14.Text;
            strSQL += "','" + textBox15.Text;
            strSQL += "','" + textBox16.Text;
            strSQL += "'," + textBox17.Text + ")";
            MySqlCommand command = null;
            try
            {
                command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = strSQL;
                conn.Open();
                int n = command.ExecuteNonQuery();		//执行SQL语句
                if (n > 0) MessageBox.Show("成功插入数据！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
                command.Dispose();
            }
            showData(); 
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommandBuilder builder = new MySqlCommandBuilder(DataAdapter);
                int n = DataAdapter.Update(dataset,"t1");
                MessageBox.Show("成功更新数据，有"
+ n.ToString() + "行受到更新！");
            }
            catch
            {
                MessageBox.Show("更新不成功！");
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            
        }
        class ExportClass
        {
            /// <param name="dgv">DataSet控件</param>
            /// <param name="strTitle">导出的Excel标题</param>
            public void DataGridViewExportToExcel(DataSet ds, string strTitle)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
                
                saveFileDialog.RestoreDirectory = true;
                
                saveFileDialog.FileName = strTitle + ".xls";
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel) //导出时，点击【取消】按钮
                {
                    return;
                }
                Stream myStream = saveFileDialog.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
                string strHeaderText = "";
                try
                {
                    //写标题
                    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                    {
                        if (i > 0)
                        {
                            strHeaderText += "\t";
                        }
                        strHeaderText += ds.Tables[0].Columns[i].ToString();
                    }
                    sw.WriteLine(strHeaderText);
                    //写内容
                    string strItemValue = "";
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        strItemValue = "";
                        for (int k = 0; k < ds.Tables[0].Columns.Count; k++)
                        {
                            if (k > 0)
                            {
                                strItemValue += "\t";
                            }
                            strItemValue += ds.Tables[0].Rows[j][k].ToString();
                        }
                        sw.WriteLine(strItemValue); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "软件提示");
                    throw ex;
                }
                finally
                {
                    sw.Close();
                    myStream.Close();
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            ExportClass MyExcel_Class = new ExportClass();       
            MyExcel_Class.DataGridViewExportToExcel(dataset, "查询导出Excel");  
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {

                MySqlCommandBuilder builder = new MySqlCommandBuilder(DataAdapter);
                int n = DataAdapter.Update(dataset, "t1");
                MessageBox.Show("成功更新数据，有"
                         + n.ToString() + "行受到更新！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新不成功！" + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
