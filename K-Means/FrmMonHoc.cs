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
    public partial class FrmMonHoc : Form
    {
        public FrmMonHoc()
        {
            InitializeComponent();
        }
      //  public DataTable Dulieu();
        Clsdatabase cls = new Clsdatabase();
        private void FrmMonHoc_Load(object sender, EventArgs e)
        {
            cls.loaddatagridview(dataGridView1, "select * from MonHoc");
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cls.kttrungkhoa(txtmamh.Text, "select MaMH from MonHoc"))
                {
                    string insert = "insert into MonHoc values('" + txtmamh.Text + "',N'" + txttenmh.Text + "',N'" + txtstc.Text + "',N'" + txthk.Text + "',N'" + cbhp.Text + "')";
                    cls.thucthiketnoi(insert);
                    cls.loaddatagridview(dataGridView1, "select * from MonHoc");
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
                string del = "delete from MonHoc where MaMH=N'" + txtmamh.Text + "'";
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    cls.thucthiketnoi(del);
                    cls.loaddatagridview(dataGridView1, "select * from MonHoc");
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
                string update = "update MonHoc set TenMH=N'" + txttenmh.Text + "',SoTC=N'" + txtstc.Text + "',HocKy=N'" + txthk.Text + "',HocPhan=N'" + cbhp.Text + "' where MaMH=N'" + txtmamh.Text + "'";
                cls.thucthiketnoi(update);
                cls.loaddatagridview(dataGridView1, "select * from MonHoc");
                MessageBox.Show("Sửa thành công");
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void btmoi_Click(object sender, EventArgs e)
        {
            cbhp.Text = "";
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
            txtmamh.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txttenmh.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtstc.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txthk.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            cbhp.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txthk.Text=="")
            {
                cls.loaddatagridview(dataGridView1, "select * from MonHoc where HocPhan=N'" + cbhp.Text + "' ");
            }else
            {
                cls.loaddatagridview(dataGridView1, "select * from MonHoc where HocPhan=N'" + cbhp.Text + "' and HocKy=N'" +txthk.Text+ "'");
            }
            
        }
    }
}
