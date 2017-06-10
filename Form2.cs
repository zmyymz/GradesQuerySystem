using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace GDIPlusDemo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //设置连接字符串
            string ConnectionString = "Data Source=123.206.17.200;Initial Catalog=numb;" +
"Persist Security Info=True;uid=root;pwd=zmy12345";
            DataSet dataset = new DataSet();    //创建数据集
            //创建一个新连接
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                //创建数据提供者
                MySqlDataAdapter DataAdapter =
                new MySqlDataAdapter("SELECT * FROM student", conn);
                //填充数据集dataset，并为本次填充的数据起名“student_table”
                DataAdapter.Fill(dataset, "student_table");
                dataGridView1.DataSource = dataset;
                //在dataGridView1控件中显示名为student_table的填充数据
                dataGridView1.DataMember = "student_table";
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
    }
}
