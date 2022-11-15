using System;
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
            listView1.Items.Add(item);
            txtMSSV.Clear();
            txtTen.Clear();
            txtTuoi.Clear();
            txtEmail.Clear();
            txtLuong.Clear();
        }

        private void txtDelete_Click(object sender, EventArgs e)
        {
            if(listView1.Items.Count > 0 && listView1.SelectedItems.Count != 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
            else if(listView1.SelectedItems.Count == 0)
            {
                string message = "vui lòng chọn mssv ở danh sách";
                MessageBox.Show(message);
            }
        }
    }
}
