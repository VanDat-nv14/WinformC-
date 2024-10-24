using QuanlyHocSinh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanlyHocSinh
{
    public partial class Form1 : Form
    {
        StudentContext context = new StudentContext();
        private int currentIndex = -1;

        public Form1()
        {
            InitializeComponent();
            LoadData();
            PopulateMajorComboBox();
        }

        private void LoadData()
        {
            dtgSinhVien.DataSource = context.Students.ToList();
            ClearTextFields();
        }

        private void ClearTextFields()
        {
            txtHoTen.Text = "";
            txtTuoi.Text = "";
            cmbNganh.SelectedIndex = -1;
        }

        private void PopulateMajorComboBox()
        {
            cmbNganh.Items.AddRange(new string[] { "Công nghệ thông tin", "Ngôn ngữ Anh", "Quản trị kinh doanh"});
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                var student = new Student
                {
                    FullName = txtHoTen.Text,
                    Age = int.Parse(txtTuoi.Text),
                    Major = cmbNganh.SelectedItem.ToString()
                };
                context.Students.Add(student);
                context.SaveChanges();
                LoadData();

                // Thông báo thêm sinh viên thành công
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DisplayCurrentStudent()
        {
            if (dtgSinhVien.Rows.Count > 0 && currentIndex >= 0)
            {
                var row = dtgSinhVien.Rows[currentIndex];
                txtHoTen.Text = row.Cells["FullName"].Value.ToString();
                txtTuoi.Text = row.Cells["Age"].Value.ToString();
                cmbNganh.SelectedItem = row.Cells["Major"].Value.ToString();
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtTuoi.Text) || cmbNganh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sinh viên!");
                return false;
            }
            if (!int.TryParse(txtTuoi.Text, out _))
            {
                MessageBox.Show("Tuổi phải là một số nguyên.");
                return false;
            }
            return true;
        }

        private void btNext_Click_2(object sender, EventArgs e)
        {
            if (currentIndex < dtgSinhVien.Rows.Count - 1)
            {
                currentIndex++;
                DisplayCurrentStudent();
            }
        }

        private void btPre_Click_2(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayCurrentStudent();
            }
        }

        private void btSua_Click_2(object sender, EventArgs e)
        {
            if (dtgSinhVien.CurrentRow != null && ValidateInputs())
            {
                int studentId = (int)dtgSinhVien.CurrentRow.Cells["StudentId"].Value;
                var student = context.Students.Find(studentId);
                if (student != null)
                {
                    student.FullName = txtHoTen.Text;
                    student.Age = int.Parse(txtTuoi.Text);
                    student.Major = cmbNganh.SelectedItem.ToString();
                    context.SaveChanges();
                    LoadData();

                    // Thông báo sửa sinh viên thành công
                    MessageBox.Show("Sửa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btXoa_Click_2(object sender, EventArgs e)
        {
            if (currentIndex >= 0 && currentIndex < dtgSinhVien.Rows.Count)
            {
                int studentId = (int)dtgSinhVien.Rows[currentIndex].Cells["StudentId"].Value;

                // Tìm sinh viên trong database
                var student = context.Students.Find(studentId);
                if (student != null)
                {
                    // Xóa sinh viên khỏi context
                    context.Students.Remove(student);
                    context.SaveChanges();

                    // Cập nhật lại dữ liệu sau khi xóa
                    LoadData();

                    // Điều chỉnh currentIndex nếu cần thiết để tránh vượt quá giới hạn
                    if (currentIndex >= dtgSinhVien.Rows.Count)
                    {
                        currentIndex = dtgSinhVien.Rows.Count - 1;
                    }

                    // Hiển thị sinh viên hiện tại (nếu còn sinh viên trong danh sách)
                    if (dtgSinhVien.Rows.Count > 0)
                    {
                        DisplayCurrentStudent();
                    }
                    else
                    {
                        // Nếu không còn sinh viên nào, làm trống các ô nhập liệu
                        ClearTextFields();
                    }

                    MessageBox.Show("Sinh viên đã được xóa thành công!");
                }
            }
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
