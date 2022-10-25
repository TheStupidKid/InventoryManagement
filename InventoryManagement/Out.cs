﻿
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class Out : Form
    {
        public Out()
        {
            InitializeComponent();
        }
        private bool CheckNull()
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || sl_nhap.Text == "")
            {
                MessageBox.Show("All Input is not Null, please try again", "Notification", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool CheckNull1()
        {
            if (comboBox6.Text == "" || comboBox5.Text == "" || comboBox4.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("All Input is not Null, please try again", "Notification", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                return true;
            }
        }
        public void LoadData()
        {


            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            List<PhieuXuatHang> list = new List<PhieuXuatHang>();
            using (InventoryManagementContext context = new InventoryManagementContext())
            {
                list = context.PhieuXuatHangs.ToList();

            }
            foreach (PhieuXuatHang item in list)
            {
                dataGridView1.Rows.Add(item.MsPhieuXuat, item.NgayLapPhieuXuat, item.MsKho, item.Msnv, item.MsMatHang, item.SlXuat);
                dataGridView2.Rows.Add(item.MsPhieuXuat, item.NgayLapPhieuXuat, item.MsKho, item.Msnv, item.MsMatHang, item.SlXuat);
                dataGridView3.Rows.Add(item.MsPhieuXuat, item.NgayLapPhieuXuat, item.MsKho, item.Msnv, item.MsMatHang, item.SlXuat);
            }
        }
        private void add_btn_Click(object sender, EventArgs e)
        {
            if (!CheckNull())
            {
                return;
            }
            add_btn.Enabled = false;
            PhieuXuatHang dt = new PhieuXuatHang();
            var id = textBox1.Text;
            dt.NgayLapPhieuXuat = dateTimePicker1.Value;
            dt.MsKho = int.Parse(comboBox1.SelectedValue.ToString());
            dt.Msnv = int.Parse(comboBox2.SelectedValue.ToString());
            dt.MsMatHang = int.Parse(comboBox3.SelectedValue.ToString());
            dt.SlXuat = int.Parse(sl_nhap.Text);
            var db = new InventoryManagementContext();
            db.PhieuXuatHangs.Add(dt);
            db.SaveChanges();
            MessageBox.Show("Them thanh cong don");
            add_btn.Enabled = true;
            LoadData();
        }

        private void xem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn1"].Value.ToString();
            dateTimePicker2.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn2"].Value.ToString();
            var db = new InventoryManagementContext();
            var list1 = db.Khos.Select(p => new { Text = p.MsKho, Value = p.TenKho }).ToList();
            comboBox6.ValueMember = "Text";
            comboBox6.DisplayMember = "Value";
            comboBox6.DataSource = (list1.ToArray());
            var list2 = db.NhanViens.Select(p => new { Text = p.Msvn, Value = p.TenNv }).ToList();
            comboBox5.ValueMember = "Text";
            comboBox5.DisplayMember = "Value";
            comboBox5.DataSource = (list1.ToArray());
            var list3 = db.MatHangs.Select(p => new { Text = p.MsMatHang, Value = p.TenHang }).ToList();
            comboBox4.ValueMember = "Text";
            comboBox4.DisplayMember = "Value";
            comboBox4.DataSource = (list1.ToArray());
            textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn6"].Value.ToString();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (!CheckNull1())
            {
                return;
            }
            update_btn.Enabled = false;
            int id = int.Parse(textBox2.Text);
            var db = new InventoryManagementContext();
            var obj = db.PhieuXuatHangs.Where(x => x.MsPhieuXuat == id).FirstOrDefault();
            obj.NgayLapPhieuXuat = dateTimePicker2.Value;
            obj.MsKho = int.Parse(comboBox6.SelectedValue.ToString());
            obj.Msnv = int.Parse(comboBox5.SelectedValue.ToString());
            obj.MsMatHang = int.Parse(comboBox4.SelectedValue.ToString());
            obj.SlXuat = int.Parse(textBox3.Text);
            db.PhieuXuatHangs.Update(obj);
            db.SaveChanges();
            MessageBox.Show("Update thanh cong don :" + id);
            update_btn.Enabled = true;
            LoadData();
        }

        private void watch_1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void add_Click(object sender, EventArgs e)
        {
            Slide_panel.Height = add.Height;
            Slide_panel.Top = add.Top;
            panel1.BringToFront();
        }

        private void update_Click(object sender, EventArgs e)
        {
            Slide_panel.Height = update.Height;
            Slide_panel.Top = update.Top;
            panel3.BringToFront();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            Slide_panel.Height = delete.Height;
            Slide_panel.Top = delete.Top;
            panel5.BringToFront();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView3.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn7"].Value.ToString();
            dateTimePicker3.Text = dataGridView3.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn8"].Value.ToString();
            var db = new InventoryManagementContext();
            var list1 = db.Khos.Select(p => new { Text = p.MsKho, Value = p.TenKho }).ToList();
            comboBox9.ValueMember = "Text";
            comboBox9.DisplayMember = "Value";
            comboBox9.DataSource = (list1.ToArray());
            var list2 = db.NhanViens.Select(p => new { Text = p.Msvn, Value = p.TenNv }).ToList();
            comboBox8.ValueMember = "Text";
            comboBox8.DisplayMember = "Value";
            comboBox8.DataSource = (list1.ToArray());
            var list3 = db.MatHangs.Select(p => new { Text = p.MsMatHang, Value = p.TenHang }).ToList();
            comboBox7.ValueMember = "Text";
            comboBox7.DisplayMember = "Value";
            comboBox7.DataSource = (list1.ToArray());
            textBox8.Text = dataGridView3.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn12"].Value.ToString();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            delete_btn.Enabled = false;
            int id = int.Parse(textBox7.Text);
            var db = new InventoryManagementContext();
            var obj = db.PhieuXuatHangs.Where(x => x.MsPhieuXuat == id).FirstOrDefault();
            if (obj != null)
            {
                DialogResult dialogResult = MessageBox.Show("Ban co chac muon xoa don", "Xoa don", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    db.PhieuXuatHangs.Remove(obj);
                    MessageBox.Show("Xoa don thanh cong :" + id);
                    db.SaveChanges();
                    LoadData();
                }
                else if (dialogResult == DialogResult.No)
                {
                    // ko lam gi
                }
            }

            delete_btn.Enabled = true;
        }

        private void watch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            string text = textBox12.Text;
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            var db = new InventoryManagementContext();
            List<PhieuXuatHang> list = db.PhieuXuatHangs.Where(x => x.NgayLapPhieuXuat.ToString().Contains(text)).ToList();
            foreach (PhieuXuatHang item in list)
            {
                dataGridView1.Rows.Add(item.MsPhieuXuat, item.NgayLapPhieuXuat, item.MsKho, item.Msnv, item.MsMatHang, item.SlXuat);
                dataGridView2.Rows.Add(item.MsPhieuXuat, item.NgayLapPhieuXuat, item.MsKho, item.Msnv, item.MsMatHang, item.SlXuat);
                dataGridView3.Rows.Add(item.MsPhieuXuat, item.NgayLapPhieuXuat, item.MsKho, item.Msnv, item.MsMatHang, item.SlXuat);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void Out_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
