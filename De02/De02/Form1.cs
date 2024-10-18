﻿using De02.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De02
{
    public partial class Form1 : Form
    {

        ModelSanPhamDB db = new ModelSanPhamDB();
        public Form1()
        {
            InitializeComponent();
            LoadData();

            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng form không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadLoaiSanPham();
        }
        private void LoadLoaiSanPham()
        {
            try
            {
                using (ModelSanPhamDB context = new ModelSanPhamDB())
                {
                    var loaiSanPhamList = context.LoaiSPs.ToList();
                    cboLoaiSP.DataSource = loaiSanPhamList;
                    cboLoaiSP.DisplayMember = "TenLoai";
                    cboLoaiSP.ValueMember = "MaLoai";    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadData()
        {
            try
            {

                using (ModelSanPhamDB context = new ModelSanPhamDB())
                {
                    List<Sanpham> listSanPham = context.Sanphams.ToList();

                    dgvSanPham.Rows.Clear();

                    foreach (var sp in listSanPham)
                    {
                        int index = dgvSanPham.Rows.Add();

                        dgvSanPham.Rows[index].Cells[0].Value = sp.MaSP;
                        dgvSanPham.Rows[index].Cells[1].Value = sp.TenSP;
                        dgvSanPham.Rows[index].Cells[2].Value = sp.Ngaynhap.ToString();
                        dgvSanPham.Rows[index].Cells[3].Value = sp.LoaiSP.TenLoai;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (ModelSanPhamDB context = new ModelSanPhamDB())
                {
                    Sanpham newSanpham = new Sanpham
                    {
                        MaSP = txtMaSP.Text,
                        TenSP = txtTenSP.Text,
                        Ngaynhap = dtNgayNhap.Value,
                        MaLoai = cboLoaiSP.SelectedValue.ToString()
                    };
                    context.Sanphams.Add(newSanpham);
                    context.SaveChanges();
                    LoadData();
                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                using (ModelSanPhamDB context = new ModelSanPhamDB())
                {
                    string maSP = txtMaSP.Text;
                    Sanpham sp = context.Sanphams.FirstOrDefault(p => p.MaSP == maSP);

                    if (sp != null)
                    {
                        sp.TenSP = txtTenSP.Text;
                        sp.Ngaynhap = dtNgayNhap.Value;
                        sp.MaLoai = cboLoaiSP.SelectedValue.ToString();

                        context.SaveChanges();
                        LoadData();
                        MessageBox.Show("Sửa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi sửa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (ModelSanPhamDB context = new ModelSanPhamDB())
                    {
                        string maSP = txtMaSP.Text;
                        Sanpham sp = context.Sanphams.FirstOrDefault(p => p.MaSP == maSP);

                        if (sp != null)
                        {
                            context.Sanphams.Remove(sp);
                            context.SaveChanges();
                            LoadData();
                            MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();

            }
        }
        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells[0].Value.ToString();
                txtTenSP.Text = row.Cells[1].Value.ToString();
                dtNgayNhap.Value = Convert.ToDateTime(row.Cells[2].Value);
                string tenLoai = row.Cells[3].Value.ToString();
                var loaiSP = db.LoaiSPs.FirstOrDefault(l => l.TenLoai == tenLoai);
                if (loaiSP != null)
                {
                    cboLoaiSP.SelectedValue = loaiSP.MaLoai;
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string tenSP = txtTim.Text.Trim();

                using (ModelSanPhamDB context = new ModelSanPhamDB())
                {
                    if (string.IsNullOrEmpty(tenSP))
                    {
                        LoadData();
                    }
                    else
                    {
                        
                        var listSanPham = context.Sanphams
                                                 .Where(p => p.TenSP.ToLower().Contains(tenSP.ToLower()))
                                                 .ToList();

                        if (listSanPham.Count > 0)
                        {
                            dgvSanPham.Rows.Clear();

                            foreach (var sp in listSanPham)
                            {
                                int index = dgvSanPham.Rows.Add();
                                dgvSanPham.Rows[index].Cells[0].Value = sp.MaSP;
                                dgvSanPham.Rows[index].Cells[1].Value = sp.TenSP;
                                dgvSanPham.Rows[index].Cells[2].Value = sp.Ngaynhap.ToString();
                                dgvSanPham.Rows[index].Cells[3].Value = sp.LoaiSP.TenLoai;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm có tên này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tìm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
        }

        private void btnKLuu_Click(object sender, EventArgs e)
        {
            
        }
    }
}