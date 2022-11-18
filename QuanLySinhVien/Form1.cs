using ExcelDataReader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
            ListViewItem items = new ListViewItem(txtMSSV.Text);
            items.SubItems.Add(txtMSSV.Text);
            items.SubItems.Add(txtTen.Text);
            items.SubItems.Add(txtTuoi.Text);
            items.SubItems.Add(txtEmail.Text);
            dgvtab.Items.Add(items);
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
            foreach (ListViewItem item in dgvtab.Items)
            {
                Console.WriteLine(item.Text[1].ToString());
                if (txtMSSV.Text == item.Text) 
                {
                    MessageBox.Show("MSSV found !");
                }
                else
                {
                    MessageBox.Show("Khong tim duoc MSSV");
                }
                
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xlsx|All Files|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<int> cells = new List<int>();
                string filename = ofd.FileName;
                // Get the input file path
                var inputFile = new FileInfo(filename);

                // Create an instance of Fast Excel
                using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(inputFile, true))
                {
                    foreach (var worksheet in fastExcel.Worksheets)
                    {
                        Console.WriteLine(string.Format("Worksheet Name:{0}, Index:{1}", worksheet.Name, worksheet.Index));

                        //To read the rows call read
                        worksheet.Read();
                        var rows = worksheet.Rows.ToList();
                        foreach (var cell in rows[0].Cells)
                        {
                            if (cell.Value.ToString()
                                .ToUpper()
                                .Contains(@"MSSV") ||
                                cell.Value.ToString()
                                .ToUpper()
                                .Contains(@"TÊN") ||
                                cell.Value.ToString()
                                .ToUpper()
                                .Contains(@"TUOI") ||
                                cell.Value.ToString()
                                .ToUpper()
                                .Contains(@"EMAIL") 
                                )
                            {
                                cells.Add(cell.ColumnNumber);
                            }
                        }
                        rows.RemoveAt(0);
                        int count = 0;
                        
                        foreach (var row in rows)
                        {
                            ListViewItem item = new ListViewItem(row.Cells.ToArray()[0].Value.ToString());
                            item.SubItems.Add(row.Cells.ToArray()[1].Value.ToString());
                            item.SubItems.Add(row.Cells.ToArray()[2].Value.ToString());
                            item.SubItems.Add(row.Cells.ToArray()[3].Value.ToString());
                            dgvtab.Items.Add(item);
                            if (String.IsNullOrWhiteSpace(txtMSSV.Text))
                            {
                                MessageBox.Show(String.Format("Import {0} rows", count));
                                return;
                            }
                            count++;
                        }
                        MessageBox.Show(String.Format("Import {0} rows", count));
                        Console.WriteLine(string.Format("Worksheet Rows:{0}", rows.Count()));
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
