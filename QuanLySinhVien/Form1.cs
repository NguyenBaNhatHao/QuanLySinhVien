using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label7.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMSSV.Text) || string.IsNullOrEmpty(txtTen.Text) || string.IsNullOrEmpty(txtTuoi.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtLuong.Text))
            {
                return;
            } 
            ListViewItem item = new ListViewItem(txtMSSV.Text);
            item.SubItems.Add(txtTen.Text);
            item.SubItems.Add(txtTuoi.Text);
            item.SubItems.Add(txtEmail.Text); ;
            dgvtab.Items.Add(item);
            txtMSSV.Clear();
            txtTen.Clear();
            txtTuoi.Clear();
            txtEmail.Clear();
            txtLuong.Clear();
        }

        private void txtDelete_Click(object sender, EventArgs e)
        {
            if(dgvtab.Items.Count > 0 && dgvtab.SelectedItems.Count != 0)
            {
                dgvtab.Items.Remove(dgvtab.SelectedItems[0]);
            }
            else if(dgvtab.SelectedItems.Count == 0)
            {
                string message = "vui lòng chọn mssv ở danh sách";
                MessageBox.Show(message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng nhập mã học sinh cần sửa", "Thông báo", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có chắc muốn thoát không?",
                "Error", MessageBoxButtons.YesNoCancel);
            Application.Exit();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtMSSV.Clear();
            txtTen.Clear();
            txtTuoi.Clear();
            txtEmail.Clear();
            txtLuong.Clear();
            dgvtab.Items.Clear();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem(txtMSSV.Text);
            item.Text = txtMSSV.Text;
        }
    }
}
