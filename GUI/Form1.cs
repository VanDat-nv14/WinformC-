    using BUS;
    using BUS.Entity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace GUI
    {
        public partial class Form1 : Form
        {
            private readonly StudentService studentService = new StudentService();
            private readonly FacultyService facultyService = new FacultyService();

            public Form1()
            {
                InitializeComponent();
                dgvStudent.CellContentClick += new DataGridViewCellEventHandler(this.dgvStudent_CellContentClick);

            }

            private void Form1_Load(object sender, EventArgs e)
            {
                try
                {
                    setGridViewStyle(dgvStudent);
                    var listFacultys = facultyService.GetAll();
                    var listStudents = studentService.GetAll();
                    FillFalcultyCombobox(listFacultys);
                    BindGrid(listStudents);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            private void FillFalcultyCombobox(List<Faculty> listFacultys)
            {
                listFacultys.Insert(0, new Faculty());
                this.cmbFaculty.DataSource = listFacultys;
                this.cmbFaculty.DisplayMember = "FacultyName";
                this.cmbFaculty.ValueMember = "FacultyID";
            }

            private void BindGrid(List<Student> listStudent)
            {
            dgvStudent.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells[0].Value = item.StudentID;
                dgvStudent.Rows[index].Cells[1].Value = item.FullName;
                if (item.Faculty != null)
                    dgvStudent.Rows[index].Cells[2].Value = item.Faculty.FacultyName;
                dgvStudent.Rows[index].Cells[3].Value = item.AverageScore.ToString();
                if (item.MajorID != null && item.Major != null)
                    dgvStudent.Rows[index].Cells[4].Value = item.Major.Name;
            }
        }

        private void ShowAvatar(string ImageName)
        {
            if (string.IsNullOrEmpty(ImageName))
            {
                pictureBox1.Image = null; // Không có hình ảnh
            }
            else
            {
                string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string imagePath = Path.Combine(parentDirectory, "Images", ImageName);

                if (File.Exists(imagePath))
                {
                    pictureBox1.Image = Image.FromFile(imagePath);
                    pictureBox1.Refresh();
                }
                else
                {
                    MessageBox.Show("Hình ảnh không tồn tại.");
                    pictureBox1.Image = null; // Hoặc gán một hình ảnh mặc định
                }
            }
        }

            public void setGridViewStyle(DataGridView dgview)
            {
                dgview.BorderStyle = BorderStyle.None;
                dgview.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
                dgview.CellBorderStyle =
               DataGridViewCellBorderStyle.SingleHorizontal;
                dgview.BackgroundColor = Color.White;
                dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }

        

            private void chkUnregisterMajor_CheckedChanged_1(object sender, EventArgs e)
            {
                var listStudents = new List<Student>();
                if (this.chkUnregisterMajor.Checked)
                    listStudents = studentService.GetAllHasNoMajor();
                else
                    listStudents = studentService.GetAll();
                BindGrid(listStudents);
            }

            private void btnThem_Click(object sender, EventArgs e)
            {
                int studentID;

                // Kiểm tra xem giá trị nhập vào có thể chuyển đổi thành int hay không
                if (int.TryParse(txtMSSV.Text, out studentID))
                {
                    var newStudent = new Student
                    {
                        StudentID = studentID, // Sử dụng biến studentID đã chuyển đổi
                        FullName = txtHoTen.Text,
                        FacultyID = (int)cmbFaculty.SelectedValue,
                        AverageScore = double.TryParse(txtDTB.Text, out double avgScore) ? avgScore : 0,
                        Avatar = string.Empty // Cập nhật sau nếu có hình ảnh
                    };

                    // Gọi phương thức thêm sinh viên
                    studentService.InserUpdate(newStudent);
                    MessageBox.Show("Thêm sinh viên thành công!");

                    // Làm mới lưới dữ liệu
                    BindGrid(studentService.GetAll());
                }
                else
                {
                    MessageBox.Show("Mã sinh viên không hợp lệ. Vui lòng nhập lại.");
                }
            }

            private void btnXoa_Click(object sender, EventArgs e)
            {
                if (dgvStudent.CurrentRow != null)
                {
                    string studentID = dgvStudent.CurrentRow.Cells[0].Value.ToString(); // Giả sử ID ở cột đầu tiên

                    // Gọi phương thức xóa sinh viên
                    studentService.DeleteStudent(studentID);
                    MessageBox.Show("Xóa sinh viên thành công!");

                    // Làm mới lưới dữ liệu
                    BindGrid(studentService.GetAll());
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sinh viên để xóa.");
                }
            }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStudent.CurrentRow != null)
            {
                var selectedRow = dgvStudent.CurrentRow;
                if (selectedRow.Cells[0].Value != null)
                {
                    if (int.TryParse(selectedRow.Cells[0].Value.ToString(), out int studentID))
                    {
                        var student = studentService.FindById(studentID);
                        if (student != null)
                        {
                            txtMSSV.Text = student.StudentID.ToString();
                            txtHoTen.Text = student.FullName;
                            cmbFaculty.SelectedValue = student.FacultyID;
                            txtDTB.Text = student.AverageScore.ToString();

                            // Hiển thị ảnh đại diện
                            ShowAvatar(student.Avatar); // student.Avatar phải chứa đường dẫn ảnh
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sinh viên với ID: " + studentID);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã sinh viên không hợp lệ.");
                    }
                }
                else
                {
                    MessageBox.Show("Không có mã sinh viên ở cột đầu tiên.");
                }
            }
        }

                private void btnSua_Click(object sender, EventArgs e)
            {
                if (dgvStudent.CurrentRow != null)
                {
                    // Lấy ID của sinh viên đang được chọn
                    int studentID = (int)dgvStudent.CurrentRow.Cells[0].Value;

                    // Tạo đối tượng sinh viên mới với thông tin đã sửa
                    var updatedStudent = new Student
                    {
                        StudentID = studentID,
                        FullName = txtHoTen.Text,
                        FacultyID = (int)cmbFaculty.SelectedValue,
                        AverageScore = double.TryParse(txtDTB.Text, out double avgScore) ? avgScore : 0,
                        Avatar = string.Empty // Cập nhật sau nếu có hình ảnh
                    };

                    // Gọi phương thức sửa sinh viên
                    studentService.Update(updatedStudent);
                    MessageBox.Show("Sửa thông tin sinh viên thành công!");

                    // Làm mới lưới dữ liệu
                    BindGrid(studentService.GetAll());
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sinh viên để sửa.");
                }
            }

        private void đăngKýChuyênNgànhToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private string selectedAvatarPath = string.Empty;
        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);

                // Lưu đường dẫn tệp vào biến tạm thời
                selectedAvatarPath = Path.GetFileName(openFileDialog.FileName);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    }

