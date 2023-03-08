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
    public partial class FrmSinhVien : Form
    {
        public FrmSinhVien()
        {
            InitializeComponent();
        }
        Clsdatabase cls = new Clsdatabase();
        private void FrmSinhVien_Load(object sender, EventArgs e)
        {
            cls.loaddatagridview(dataGridView1, "select * from SinhVien");
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cls.kttrungkhoa(txtmasv.Text, "select MaSV from SinhVien"))
                {
                    string insert = "insert into SinhVien values('" + txtmasv.Text + "',N'" + txttensv.Text + "',N'" + txtdiachi.Text + "',N'" + txtsdt.Text + "')";
                    cls.thucthiketnoi(insert);
                    cls.loaddatagridview(dataGridView1, "select * from SinhVien");
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
                string del = "delete from SinhVien where Masv=N'" + txtmasv.Text + "'";
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    cls.thucthiketnoi(del);
                    cls.loaddatagridview(dataGridView1, "select * from SinhVien");
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
                string update = "update SinhVien set TenSV =N'" + txttensv.Text + "',DiaChi=N'" + txtdiachi.Text + "',Sdt=N'" + txtsdt.Text + "' where MaSV=N'" + txtmasv.Text + "'";
                cls.thucthiketnoi(update);
                cls.loaddatagridview(dataGridView1, "select * from SinhVien");
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
            txttensv.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtdiachi.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtsdt.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
       
        }
    }
}
