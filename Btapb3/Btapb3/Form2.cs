using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Btapb3
{
    public partial class Form2 : Form
    {
        public string MSNV
        {
            get { return txtMSNV.Text; }
            set { txtMSNV.Text = value; }
        }

        public string TenNV
        {
            get { return txtTenNV.Text; }
            set { txtTenNV.Text = value; }
        }

        public string LuongCB
        {
            get { return txtLuong.Text; }
            set { txtLuong.Text = value; }
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void txtMSNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MSNV) || string.IsNullOrEmpty(TenNV) || string.IsNullOrEmpty(LuongCB))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
