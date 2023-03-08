using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_Means
{
    public partial class FrmBangDiem : Form
    {
        public FrmBangDiem()
        {
            InitializeComponent();
        }
        Clsdatabase cls = new Clsdatabase();
        private void FrmBangDiem_Load(object sender, EventArgs e)
        {
           
            cls.loadcombobox(txtmasv, "select * from SinhVien", 0);
            cls.loadcombobox(txtmamh, "select * from MonHoc", 0);
            cls.loaddatagridview(dataGridView1, "select * from BangDiem");
            txtmamh.ValueMember = "MaMH";
            txtmamh.DisplayMember = "TenMH";        
        }
        private void btthem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cls.kttrungkhoa(txtmasv.Text, "select MaSV from SinhVien") || cls.kttrungkhoa(txtmamh.Text, "select MaMH from MonHoc"))
                {
                    string insert = "insert into BangDiem values('" + txtmasv.Text + "',N'" + txtmamh.Text + "',N'" + txtdiem.Text + "')";
                    cls.thucthiketnoi(insert);
                    cls.loaddatagridview(dataGridView1, "select * from BangDiem");
                }
                else
                {
                    MessageBox.Show("Mã này đã tòn tại bạn có thể thử mã khác", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                string del = "delete from BangDiem where Masv=N'" + txtmasv.Text + "' and Mamh=N'"+txtmamh.Text+"'";
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    cls.thucthiketnoi(del);
                    cls.loaddatagridview(dataGridView1, "select * from BangDiem");
                }
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            try
            {
                string update = "update BangDiem set Diem =N'" + txtdiem.Text + "' where MaSV=N'" + txtmasv.Text + "' and Mamh=N'" + txtmamh.Text + "' ";
                cls.thucthiketnoi(update);
                cls.loaddatagridview(dataGridView1, "select * from BangDiem");
                MessageBox.Show("Sửa thành công");
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void btmoi_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.groupBox1.Controls)
            {
                if ((ctr is TextBox) || (ctr is ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtmasv.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtmamh.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtdiem.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
           
        }
    }
}
