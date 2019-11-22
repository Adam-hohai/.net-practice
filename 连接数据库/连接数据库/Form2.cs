using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 连接数据库
{
    public partial class Form2 : Form
    {
        public string sno_text, cno_text, grade_text;
        public bool ok;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sno_text = textBox1.Text;
            cno_text = textBox2.Text;
            grade_text = textBox3.Text;
            ok = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ok = false;
            this.Close();
        }

        
    }
}
