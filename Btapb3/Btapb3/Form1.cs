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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "MSNV";
            dataGridView1.Columns[1].Name = "Tên NV";
            dataGridView1.Columns[2].Name = "Lương CB";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Form2 employeeForm = new Form2();
            if (employeeForm.ShowDialog() == DialogResult.OK)
            {
                string[] row = { employeeForm.MSNV, employeeForm.TenNV, employeeForm.LuongCB };
                dataGridView1.Rows.Add(row);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa nhân viên này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                Form2 employeeForm = new Form2();

               
                employeeForm.MSNV = selectedRow.Cells[0].Value.ToString();
                employeeForm.TenNV = selectedRow.Cells[1].Value.ToString();
                employeeForm.LuongCB = selectedRow.Cells[2].Value.ToString();

                if (employeeForm.ShowDialog() == DialogResult.OK)
                {
                   
                    selectedRow.Cells[0].Value = employeeForm.MSNV;
                    selectedRow.Cells[1].Value = employeeForm.TenNV;
                    selectedRow.Cells[2].Value = employeeForm.LuongCB;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
