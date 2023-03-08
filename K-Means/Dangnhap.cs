using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
namespace K_Means
{
    public partial class Dangnhap : Form
    {
        //Connection kn = new Connection();
        //DataTable dt;
    //    private SqlConnection Con = null;
        public Dangnhap()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection Con = new SqlConnection("Data Source=DESKTOP-U1D119Q\\SQLEXPRESS;Initial Catalog=QLSinhVien;Integrated Security=True");
            try
            {
                Con.Open();
                string select = "Select * From TaiKhoan where TenDangNhap='" + textBox1.Text + "' and MatKhau='" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(select, Con);
                SqlDataReader reader = cmd.ExecuteReader();    
                if (reader.Read()==true)
                {
                    MessageBox.Show("Đăng nhập vào hệ thống thành công!", "Thông báo !");
                    Form2 f = new Form2();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu k đúng!", "Thông báo !");
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
           
        }
    }
}
