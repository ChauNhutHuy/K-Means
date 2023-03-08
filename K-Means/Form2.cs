using OfficeOpenXml;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace K_Means
{
    public partial class Form2 : Form
    {
    
        Kmeans km = new Kmeans();
        public Form2()
        {
            InitializeComponent();
        }



        private void mônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMonHoc frm = new FrmMonHoc();
            frm.ShowDialog();
        }

        private void sinhViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmSinhVien frm = new FrmSinhVien();
            frm.ShowDialog();
        }

        private void bảngĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBangDiem frm = new FrmBangDiem();
            frm.ShowDialog();
        }

      

        private void button4_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < lstttcum.Items.Count; i++)
            {
                for (int j = 0; j < int.Parse(textBox1.Text); j++)
                {

                    StreamWriter write = new StreamWriter(@"D:\Cum " + (j + 1).ToString() + ".txt");
                    write.WriteLine(lstttcum.Items[i].SubItems[j].Text);
                    write.Close();
                }
            }    
        }

        private void biểuĐồToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmbieudo frm = new Frmbieudo();
            frm.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lsthienthi.SelectedItems.Count>0)
            {
                ListViewItem lvi = lsthienthi.SelectedItems[0];

            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsthienthi.Clear();
            lsthienthi.View = View.Details;
            for (int i = 0; i < lstdocifle.Columns.Count; i++)
            {
                lsthienthi.Columns.Add(lstdocifle.Columns[i].Text);
            }
            if(lstttcum.SelectedItems.Count>0)
            {
                string a = lstttcum.SelectedItems[0].SubItems[1].Text;
                string[] s = a.Split(';');
                for(int i=0;i<s.Length-1;i++)
                {
                    for(int j=1;j<lstdocifle.Items.Count;j++)
                    {                  
                        if (String.Compare(s[i],lstdocifle.Items[j].SubItems[0].Text, true) == 0)
                        {
                            ListViewItem lst1 = lsthienthi.Items.Add(lstdocifle.Items[j].SubItems[0].Text);
                            for (int t = 1; t < lstdocifle.Columns.Count;t++)
                            {                              
                                lst1.SubItems.Add(lstdocifle.Items[j].SubItems[t].Text);
                            }                                                  
                        }
                    }
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
    
        }

        private void bt_docfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {

                lstdocifle.Clear();
                km.input(lstdocifle, open.FileName);
            }
        }

        private void bt_them_Click(object sender, EventArgs e)
        {

            //Vector vt = new Vector();
            //ListViewItem lst1 = lstdocifle.Items.Add(5.ToString());       
            
            //lst1.SubItems.Add("Huy");
            //vt.item.Add(double.Parse(5.ToString()));
            //vt.item.Add(double.Parse(5.ToString()));
            //lst1.SubItems.Add(5.ToString());
            //lst1.SubItems.Add(5.ToString());
            //km.listItem.Add(vt);
            
            //km.danhDau1 = new int[km.listItem.Count+1];
            //km.danhDau2 = new int[km.listItem.Count+1];
            
        }

        private void lstttcum_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void lstdocifle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstttcum.SelectedItems.Count > 0)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

          
        }

        private void bt_thongke_Click(object sender, EventArgs e)
        {
         
        }



        private void button4_Click_1(object sender, EventArgs e)
        {
          
               
           
           // MessageBox.Show("So luong mon tren 5" + String.Format("{0:0.00}", dem) + ", Ti le rot mon " + String.Format("{0:0.00}", tong) + ", DTB: " + String.Format("{0:0.00}", dtb / dem2));
        }

        private void btthem_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

   

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void lstttcum_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            lsthienthi.Clear();
            lsthienthi.View = View.Details;
            for (int i = 0; i < lstdocifle.Columns.Count; i++)
            {
                lsthienthi.Columns.Add(lstdocifle.Columns[i].Text);
            }
            if (lstttcum.SelectedItems.Count > 0)
            {
                string a = lstttcum.SelectedItems[0].SubItems[1].Text;
                string[] s = a.Split(';');
                for (int i = 0; i < s.Length - 1; i++)
                {
                    for (int j = 1; j < lstdocifle.Items.Count; j++)
                    {

                        if (String.Compare(s[i], lstdocifle.Items[j].SubItems[0].Text, true) == 0)
                        {
                            ListViewItem lst1;
                            lst1 = lsthienthi.Items.Add(lstdocifle.Items[j].SubItems[0].Text);
                            for (int t = 1; t < lstdocifle.Columns.Count; t++)
                            {                                 
                                {                                
                                    lst1.SubItems.Add(lstdocifle.Items[j].SubItems[t].Text);       
                                }                                                               
                            }
                        }
                    }
                }
            }
        }

       
        public void Thongke()
        {        
            chart1.ChartAreas[0].AxisY.Maximum = 200;
            {
                Series s = new Series("Ten Cum");
                for (int i = 0; i < lstttcum.Items.Count; i++)
                {
                    DataPoint p = new DataPoint();
            
                    p.SetValueY(int.Parse(lstttcum.Items[i].SubItems[2].Text));
                  
                    p.AxisLabel = lstttcum.Items[i].SubItems[0].Text;
                  
                    s.Points.Add(p);     
                }
                chart1.Series.Add(s);         
            }
        }
        private void bt_thongke_Click_1(object sender, EventArgs e)
        {
            
        
        }
        public bool kt(int[] a,int n,int x)
        {
            for (int i = 0; i < n; i++)
                if (x == a[i])
                    return true;
            return false;
        }
        private void bt_xf_Click(object sender, EventArgs e)
        {

        }
        
        private void bt_thucthi_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Chưa nhập số cụm");
            }else
            {
                lstttcum.Clear();
      
                km.listCum.Clear();
                //   int[] b = new int[int.Parse(textBox1.Text)];
                // for (int t = 0; t < int.Parse(textBox1.Text); t++)
                // Random rd = new Random();
                for (int i = 0; i < int.Parse(textBox1.Text); i++)
                {
                    //b[i] = a;
                    Vector vt = new Vector();
                    // while (kt(b, int.Parse(textBox1.Text), a) == true)
                    //    a = rd.Next(1, lstdocifle.Items.Count);
                    //   MessageBox.Show("Dong" + a); 47 61
                    for (int j = 5; j < lstloc.Columns.Count; j++)
                    {
                        vt.item.Add(double.Parse(lstloc.Items[i].SubItems[j].Text));
                    }
                    km.listCum.Add(vt);
                    //  MessageBox.Show("" + vt.item[0] + " sO RAN DOM:" + a);
                }
                km.kmean();
                km.hienThi(lstttcum, lstloc);
             
                //MessageBox.Show("" + km.listCum[0].item[0]);
                Thongke();
            }
            //for(int i=0;i<20;i++)
            //  MessageBox.Show("" +km.listItem[0].item[i].ToString());
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int b = (lstdocifle.Items.Count - 1);
            string a = lstdocifle.Items[b].SubItems[0].Text;
            for (int i = 0; i < lstttcum.Items.Count; i++)
            {

                string[] s = lstttcum.Items[i].SubItems[1].Text.Split(';');
                for (int j = 0; j < s.Length - 1; j++)
                {
                    if (a == s[j])
                    {
                        lbxuatcum.Text = "Bộ dữ liêu này thuộc cụm: " + (i + 1);
                        return;
                    }
                }
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        int min(int a,int b,int c)
        {
            int max = a;
            if (b < max)
                max = b;
            if (c < max)
                max = c;
            return max;
        }
        int max(int a, int b, int c)
        {
            int max = a;
            if (b > max)
                max = b;
            if (c > max)
                max = c;
            return max;
        }


        private void bt_thongketp3_Click(object sender, EventArgs e)
        {
            if (lsthienthi.Items.Count == 0)
            {
                MessageBox.Show("Dữ liệu phân cụm chưa có");
            }else
            {
                 chart2.ChartAreas[0].AxisY.Maximum = 100;
            Series s = new Series("Tên Môn Học");
            double dem3 = 0.00;
            double dem4=0.00;
            double tong1 = 0.00;
           
            lstthongke.Columns.Add("Tên Môn Học").Width = 100; ;
            lstthongke.Columns.Add("Tỉ lệ rớt môn");
            for (int j = 56; j < lsthienthi.Columns.Count; j++)
            {
                for (int i = 0; i < lsthienthi.Items.Count; i++)
                {
                    if (double.Parse(lsthienthi.Items[i].SubItems[j].Text) != -1)
                        dem3++;
                    if (double.Parse(lsthienthi.Items[i].SubItems[j].Text) < 5.00 && double.Parse(lsthienthi.Items[i].SubItems[j].Text) > -1)
                        dem4++;               
                }
                {
                    tong1 = (dem4 / dem3) * 100;
                    ListViewItem lst1 = lstthongke.Items.Add(lsthienthi.Columns[j].Text);
                    lst1.SubItems.Add(String.Format("{0:0.00}", tong1));
                    DataPoint p = new DataPoint();

                    p.SetValueY(tong1);

                    p.AxisLabel = lsthienthi.Columns[j].Text;

                    s.Points.Add(p);
                }
            }
            chart2.Series.Add(s);
            }       
        }

        private void lstthongke_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstthongkr1.Clear();
            lstthongkr1.View = View.Details;
            double dem3 = 0.0;
            double dem4 = 0.0;
            double dem5 = 0.0;
            double dem6 = 0.0;
           // double dem7 = 0.0;
  
            double tong1 = 0.0;
            double tong2 = 0.0;
            double tong3 = 0.0;
            // for (int i = 0; i < lstdocifle.Columns.Count; i++)
            {
                lstthongkr1.Columns.Add("Gioi");
                lstthongkr1.Columns.Add("Kha");
                lstthongkr1.Columns.Add("Trung binh");
            }
           if (lstthongke.SelectedItems.Count > 0)
            {
               string a = lstthongke.SelectedItems[0].SubItems[0].Text;
            
               for (int j = 56; j < lsthienthi.Columns.Count; j++)
               {
                      if(a==lsthienthi.Columns[j].Text)
                      {
                          for (int i = 0; i < lsthienthi.Items.Count; i++)
                          {
                              if (double.Parse(lsthienthi.Items[i].SubItems[j].Text) != -1)
                                  dem3++;
                              if (double.Parse(lsthienthi.Items[i].SubItems[j].Text) < 5.00 && double.Parse(lsthienthi.Items[i].SubItems[j].Text) > -1)
                                  dem4++;
                              if (double.Parse(lsthienthi.Items[i].SubItems[j].Text) >= 5.00 && double.Parse(lsthienthi.Items[i].SubItems[j].Text) < 8)
                                  dem5++;
                              if (double.Parse(lsthienthi.Items[i].SubItems[j].Text) >= 8.00)
                                  dem6++;
                          }
                          tong1 = (dem4 / dem3) * 100;
                          tong2 = (dem5 / dem3) * 100;
                          tong3 = (dem6 / dem3) * 100;
                          {

                              ListViewItem lst1 = lstthongkr1.Items.Add(String.Format("{0:0.00}", tong1)+"%");
                              // for (int t = 1; t < lstdocifle.Columns.Count; t++)
                              {
                                  lst1.SubItems.Add(String.Format("{0:0.00}", tong2)+"%");
                                  lst1.SubItems.Add(String.Format("{0:0.00}", tong3)+"%");
                                  //  lst1.SubItems.Add(tong3.ToString());
                              }
                          }
                      }   
               }
            }
        }


        private void lsthienthi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cTKhungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMonHoc frm = new FrmMonHoc();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ListViewItem lvi = new ListViewItem("Nhập môn lập trình");
            lvi.SubItems.Add("Lập trình hướng đối tượng");
            lsttienquyet.Items.Add(lvi);


            lvi = new ListViewItem("Thực hành nhập môn lập trình");
            lvi.SubItems.Add("Lập trình hướng đối tượng");
            lsttienquyet.Items.Add(lvi);
            lvi = new ListViewItem("Lập trình hướng đối tượng");
            lvi.SubItems.Add("Cấu trúc dữ liệu và giải thuật");
            lsttienquyet.Items.Add(lvi);

            lvi = new ListViewItem("Cơ sở dữ liệu");
            lvi.SubItems.Add("Hệ quản trị cơ sở dữ liệu");
            lsttienquyet.Items.Add(lvi);
   
        }

        private void btmhsh_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem("Nhập môn lập trình");
            lvi.SubItems.Add("TH Nhập Môn Lập Trình");
            lstsonghanh.Items.Add(lvi);
            lvi = new ListViewItem("Lập trình hướng đối tượng");
            lvi.SubItems.Add("TH Lập Trình Hướng Đối Tượng");
            lstsonghanh.Items.Add(lvi);
            lvi = new ListViewItem("TH Nhập Môn Lập Trình");
            lvi.SubItems.Add("Lập Trình hướng đối tượng");
            lstsonghanh.Items.Add(lvi);
            lvi = new ListViewItem("Cấu trúc dữ liệu và giải thuật");
            lvi.SubItems.Add("TH Cấu trúc dữ liệu và giải thuật");
            lstsonghanh.Items.Add(lvi);
            lvi = new ListViewItem("Mạng máy tính");
            lvi.SubItems.Add("TH Mạng Máy Tính");

            lstsonghanh.Items.Add(lvi);
            lvi = new ListViewItem("Phân tích thiết kế hệ thống thông tin");
            lvi.SubItems.Add("TH Phân tích thiết kế hệ thống thông tin");

            lstsonghanh.Items.Add(lvi);
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem("Cơ sở dữ liệu");
            lvi.SubItems.Add("CN Java, LT Web, Công nghệ .NET");
            lstmhtr.Items.Add(lvi);

            //lvi = new ListViewItem("Cơ sở dữ liệu");
            //lvi.SubItems.Add("CN Java, LT Web, Công nghệ .NET");

            //lstmhtr.Items.Add(lvi);
        }

        private void button6_Click(object sender, EventArgs e)
        {

             
             MessageBox.Show(lstdocifle.Columns[47].Text);

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
  
           MessageBox.Show("" + lstdocifle.Columns.Count);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

      
        private void button7_Click(object sender, EventArgs e)
        {
            bt_thucthi.Enabled = true;
            lstloc.Clear();
            lstloc.View = View.Details;
            int a = 0;
            km.listItem = new List<Vector>();
            if (lstdocifle.Columns.Count > 38)
                a = lstdocifle.Columns.Count - 20;
            else
                a = lstdocifle.Columns.Count;
            for (int i = 0; i < a; i++)
            {            
                if(i<5)
                {
                    lstloc.Columns.Add(lstdocifle.Columns[i].Text);
                }else
                {
                    double kt = Convert.ToDouble(lstdocifle.Items[lstdocifle.Items.Count - 1].SubItems[i].Text);
                    if (kt >=0)
                    {
                        lstloc.Columns.Add(lstdocifle.Columns[i].Text);                
                    }  
                }              
            }          
            for (int j = 1; j < lstdocifle.Items.Count; j++)
            {
                Vector input = new Vector();
                ListViewItem lst1;
                lst1 = lstloc.Items.Add(lstdocifle.Items[j].SubItems[0].Text);
                for (int t = 1; t < a; t++)
                {
                    if(t<5)
                    {
                        lst1.SubItems.Add(lstdocifle.Items[j].SubItems[t].Text);
                    }else
                    {
                        double kt = Convert.ToDouble(lstdocifle.Items[lstdocifle.Items.Count - 1].SubItems[t].Text);
                        if (kt >= 0)
                        {
                            lst1.SubItems.Add(lstdocifle.Items[j].SubItems[t].Text);
                            input.item.Add(double.Parse(lstdocifle.Items[j].SubItems[t].Text));
                        }                      
                    }   
                }
                km.listItem.Add(input);
            }
      
            km.danhDau1 = new int[km.listItem.Count];
            km.danhDau2 = new int[km.listItem.Count];
         //   MessageBox.Show("" + lstloc.Columns.Count);
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void độcFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            int a = 0;
            int b = 0;
            if (cbhk2.Text == "học kỳ 1")
            {
             
                b = 5;
                a = 56;
            }
            else if (cbhk2.Text == "học kỳ 2")
            {
             
                a = 47;
                b = 11;
            }
            else if (cbhk2.Text == "học kỳ 3")
            {
                
                a = 37;
                b = 20;
            }
            else if (cbhk2.Text == "học kỳ 4")
            {
              
                a = 30;
                b = 29;
            }

            else if (cbhk2.Text == "học kỳ 5")
            {
              
                a = 26;
                b = 36;
            }
            else
            {
             
                a = 21;
                b = 40;
            }
            double c = 0;
            double kt1 = 0;
            double kt = 0;
            string monhocrot = "";
            for (int t = 0; t < lsttienquyet.Items.Count; t++)
            {
                for (int j = 5; j <= 66 - a; j++)
                {
                    if (lstdocifle.Columns[j].Text == lsttienquyet.Items[t].SubItems[0].Text)
                    {
                        c = Convert.ToDouble(lstdocifle.Items[lstdocifle.Items.Count - 1].SubItems[j].Text);
                        if (lstdocifle.Items[lstdocifle.Items.Count - 1].SubItems[j].Text == "-1" || c < 3.5)
                        {    
                            for (int i = 5; i < lstloc.Columns.Count; i++)
                            {
                                                
                                string cc = lsttienquyet.Items[t].SubItems[1].Text;
                                string cc1 = lstloc.Columns[i].Text;
                                if (cc1 == cc)
                                {
                                    kt1 = double.Parse(lstloc.Items[lstloc.Items.Count - 1].SubItems[i].Text);
                                }
                                else
                                {
                                    kt = 1;
                                }
                            }

                            if (kt == 0 || kt1 == 0 || kt1 < 3.5)
                            {
                                //txtdudoan.AppendText("\r\n");
                                //txtdudoan.AppendText("Bạn nên học môn này: " + lsttienquyet.Items[t].SubItems[0].Text + " Trước môn này:" + lsttienquyet.Items[t].SubItems[1].Text);
                                monhocrot += "TenMH!=N'" + lsttienquyet.Items[t].SubItems[1].Text + "' and ";
                            }
                            else if (kt1 > 3.5)
                            {
                                //txtdudoan.AppendText("\r\n");
                                //txtdudoan.AppendText("Bạn nên học lai mon nay: " + lsttienquyet.Items[t].SubItems[0].Text);
                            }
                        }
                    }
                }
            }
   
            Clsdatabase cls = new Clsdatabase();
            cls.loaddatagridview(dataGridView2, "select * from MonHoc where "+monhocrot+ "HocKy=N'" + cbhk2.Text + "' ORDER BY HocPhan");
            double dem3 = 0.00;
            double dem4=0.00;
            double tong1 = 0.00;
            double dem5 = 0.00;
            lsttktc.Clear();
            lsttktc.Columns.Add("Tên Môn Học").Width = 100;
          //  lsttktc.Columns.Add("Trên 8");
            lsttktc.Columns.Add("Trên 5");
            lsttktc.Columns.Add("Ti Le chon");
            double dem6=0;
            string s = "";
           // MessageBox.Show(""+monhocrot);
            for (int j = 53; j < lsthienthi.Columns.Count; j++)
            {
                for (int i = 0; i < lsthienthi.Items.Count; i++)
                {
                    if (double.Parse(lsthienthi.Items[i].SubItems[j].Text) != -1)
                        dem3++;
                    if (double.Parse(lsthienthi.Items[i].SubItems[j].Text) >= 8 && double.Parse(lsthienthi.Items[i].SubItems[j].Text) > -1)
                        dem4++;
                    if (double.Parse(lsthienthi.Items[i].SubItems[j].Text) >= 5 && double.Parse(lsthienthi.Items[i].SubItems[j].Text) > -1)
                        dem5++;
                    if (double.Parse(lsthienthi.Items[i].SubItems[j].Text) >= 0)
                        dem6++;                  
                 }
                 {               
                    ListViewItem lst1 = lsttktc.Items.Add(lsthienthi.Columns[j].Text);         
                    if(dem3==0)
                    {
                        lst1.SubItems.Add("khong có ai học hết");
                    }else
                    {
                        tong1 = (dem4 / dem3) * 100;
                        lst1.SubItems.Add(String.Format("{0:0.00}", (dem5/dem3)*100));
                        lst1.SubItems.Add(String.Format("{0:0.00}", (dem6 / (lsthienthi.Items.Count)) * 100));
                    }                
                }
            
                dem3 = 0;
                dem4 = 0;
                dem5 = 0;
                dem6 = 0;
            }
            if(cbhk2.Text=="học kỳ 1")
            {
                for (int i = 0; i < lsttktc.Items.Count; i++) //duyệt tất cả các item trong list
                {

                    if (lsttktc.Items[i].SubItems[0].Text != "Xác suất thống kê")//nếu item đó dc check
                    {
                        lsttktc.Items[i].Remove();//xóa item đó đi
                        i--;
                    }
                }
            }
            if(cbhk2.Text=="học kỳ 2")
            {
                for (int i = 0; i < lsttktc.Items.Count; i++) //duyệt tất cả các item trong list
                {

                    if (lsttktc.Items[i].SubItems[0].Text != "Kiến trúc máy tính")//nếu item đó dc check
                    {
                        lsttktc.Items[i].Remove();//xóa item đó đi
                        i--;
                    }
                }
            }
             if (cbhk2.Text == "học kỳ 3" || cbhk2.Text=="học kỳ 4")
            {
                for (int i = 0; i < lsttktc.Items.Count; i++) //duyệt tất cả các item trong list
                {             
                    {
                        lsttktc.Items[i].Remove();//xóa item đó đi
                        i--;
                    }
                }
            }
            if(cbhk2.Text=="học kỳ 5" )
            {
                for (int i = 0; i < lsttktc.Items.Count; i++) //duyệt tất cả các item trong list
                {

                    if (lsttktc.Items[i].SubItems[0].Text != "Hệ quản trị cơ sở dữ liệu Oracle" && lsttktc.Items[i].SubItems[0].Text != "Thực hành hệ quản trị cơ sở dữ liệu Oracle" && lsttktc.Items[i].SubItems[0].Text != "Kỹ thuật lập trình" && lsttktc.Items[i].SubItems[0].Text != "Thực hành kỹ thuật lập trình")//nếu item đó dc check
                    {
                        lsttktc.Items[i].Remove();//xóa item đó đi
                        i--;
                    }
                }
            }
            if(cbhk2.Text=="học kỳ 6")
            {
                for (int i = 0; i < lsttktc.Items.Count; i++) //duyệt tất cả các item trong list
                {

                    if (lsttktc.Items[i].SubItems[0].Text != "Cơ sở dữ liệu NoSQL" && lsttktc.Items[i].SubItems[0].Text != "Thực hành cơ sở dữ liệu NoSQL" && lsttktc.Items[i].SubItems[0].Text != "Kiểm định chất lượng phần mềm" && lsttktc.Items[i].SubItems[0].Text != "Thực hành kiểm định chất lượng phần mềm")//nếu item đó dc check
                    {
                        lsttktc.Items[i].Remove();//xóa item đó đi
                        i--;
                    }
                }
            }
           
        }

        private void lsttktc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Clsdatabase cls = new Clsdatabase();
            if(lstdocifle.Items.Count==0)
            {
                MessageBox.Show("Bạn chưa đọc file");
            }else
            {
                cbhk2.Text = "học kỳ 1";
                lbhoten.Text = "" + lstdocifle.Items[lstdocifle.Items.Count - 1].SubItems[2].Text + " " + lstdocifle.Items[lstdocifle.Items.Count - 1].SubItems[3].Text;
                lblop.Text = "" + lstdocifle.Items[lstdocifle.Items.Count - 1].SubItems[4].Text;

                comboBox1.Text = "Công nghệ phần mềm";
                // Coi học lực của học sinh
                int dem = 0;
                double tong = 0;
                for (int j = 5; j < 57; j++)
                {
                    for (int i = lstdocifle.Items.Count - 1; i < lstdocifle.Items.Count; i++)
                    {
                        if (double.Parse(lstdocifle.Items[i].SubItems[j].Text) > -1)
                        {
                            tong += double.Parse(lstdocifle.Items[i].SubItems[j].Text);
                            dem++;
                        }
                    }
                }
                lbdiem.Text = "" + (String.Format("{0:0.00}", (tong / dem)));
                if ((tong / dem) >= 8)
                {
                    lbhocluc.Text = "Gioi";
                }
                else if ((tong / dem) >= 7)
                {
                    lbhocluc.Text = "Khá";
                }
                else
                {
                    lbhocluc.Text = "Trung Bình";
                } 
            }
          

        }
        private void button11_Click(object sender, EventArgs e)
        {
            txtdudoan.Text = "";
            if(lstsonghanh.Items.Count==0 || lsttienquyet.Items.Count==0 || lstmhtr.Items.Count==0 || lstdocifle.Items.Count==0)
            {
                MessageBox.Show("Thiếu dữ liệu của các bảng");
            }else
            {
                int a = 0;
                int b = 0;
                if (cbhk2.Text == "học kỳ 1")
                {
                    lbhk.Text = "Học kì I là 3";
                    b = 5;
                    a = 56;
                }
                else if (cbhk2.Text == "học kỳ 2")
                {
                    lbhk.Text = "Học kì II là 2";
                    a = 47;
                    b = 11;
                }
                else if (cbhk2.Text == "học kỳ 3")
                {
                    lbhk.Text = "Học kì III là 0";
                    a = 37;
                    b = 20;
                }
                else if (cbhk2.Text == "học kỳ 4")
                {
                    lbhk.Text = "Học kỳ IV là 0";
                    a = 30;
                    b = 29;
                }

                else if (cbhk2.Text == "học kỳ 5")
                {
                    lbhk.Text = "Học kỳ V là 3";  
                    a = 26;
                    b = 36;
                }
                else if(cbhk2.Text=="học kỳ 6")
                {
                    lbhk.Text = "Học kỳ VI là 3";
                    a = 21;
                    b = 40;
                }
                double c = 0;
                string s = "";
                txtdudoan.AppendText("Danh sách những môn học lại");
                for (int j = 5; j < 66 - a; j++)
                {
                    c = Convert.ToDouble(lstdocifle.Items[lstdocifle.Items.Count - 1].SubItems[j].Text);
                    if (c < 3.5 && c > -1)
                    {
                        txtdudoan.AppendText("\r\n");
                        txtdudoan.AppendText(lstdocifle.Columns[j].Text);
                    }
                    if (c < 3.5)
                    {
                        s += "TenMH=N'" + lstdocifle.Columns[j].Text + "' or ";
                    }
                }
                txtdudoan.AppendText("\r\n");
                txtdudoan.AppendText("Danh sách những môn tự chọn học lại");
                for (int i = 65; i < lstdocifle.Columns.Count;i++)
                {
                    c = Convert.ToDouble(lstdocifle.Items[lstdocifle.Items.Count - 1].SubItems[i].Text);
                    if(c<3.5 && c>-1)
                    {
                        txtdudoan.AppendText("\r\n");
                        txtdudoan.AppendText(lstdocifle.Columns[i].Text);
                    }
                }
                    s += "TenMH=N'1'";
                //  MessageBox.Show(s);
                for (int t = 0; t < lstmhtr.Items.Count; t++)
                {
                    for (int j = 5; j <= 62 - a; j++)
                    {
                        if (lstdocifle.Columns[j].Text == lstmhtr.Items[t].SubItems[0].Text)
                        {
                            c = Convert.ToDouble(lstdocifle.Items[lstdocifle.Items.Count - 1].SubItems[j].Text);
                            if (lstdocifle.Items[lstdocifle.Items.Count - 1].SubItems[j].Text == "-1" || c < 3.5)
                            {
                                txtdudoan.AppendText("\r\n");
                                txtdudoan.AppendText("Bạn nên học môn: " + lstdocifle.Columns[j].Text + " Truoc :" + lstmhtr.Items[t].SubItems[1].Text);
                            }
                        }
                    }
                }
                double kt = 0;
                double kt1 = 0;
                string monhocrot = "";
                for (int t = 0; t < lsttienquyet.Items.Count; t++)
                {
                    for (int j = 5; j <= 66 - a; j++)
                    {
                        if (lstdocifle.Columns[j].Text == lsttienquyet.Items[t].SubItems[0].Text)
                        {
                            c = Convert.ToDouble(lstdocifle.Items[lstdocifle.Items.Count - 1].SubItems[j].Text);
                            if ((c < 3.5 && c>=-1))
                            {
                                for (int i = 5; i < lstloc.Columns.Count; i++)
                                {
                                    // for (int m = 0; m < lsttienquyet.Items.Count;m++ )                                
                                    string cc = lsttienquyet.Items[t].SubItems[1].Text;
                                    string cc1 = lstloc.Columns[i].Text;
                                    if (cc1 == cc)
                                    {
                                        kt1 = double.Parse(lstloc.Items[lstloc.Items.Count - 1].SubItems[i].Text);
                                    }
                                    else
                                    {
                                        kt = 1;
                                    }
                                }
                                if ((kt == 0 || kt1 == 0 || kt1 < 3.5))
                                {
                                    txtdudoan.AppendText("\r\n");
                                    txtdudoan.AppendText("Bạn nên học môn này: " + lsttienquyet.Items[t].SubItems[0].Text + " Trước môn này:" + lsttienquyet.Items[t].SubItems[1].Text);
                                    monhocrot += lsttienquyet.Items[t].SubItems[1].Text;
                                }
                                else if (kt1 > 3.5)
                                {
                                    txtdudoan.AppendText("\r\n");
                                    txtdudoan.AppendText("Bạn nên học lai mon nay: " + lsttienquyet.Items[t].SubItems[0].Text);
                                }
                            }else if(c==-2)
                            {
                                txtdudoan.AppendText("\r\n");
                                txtdudoan.AppendText("Bạn phải cố gắng học môn này: " + lsttienquyet.Items[t].SubItems[0].Text + " Sau đó bạn mới được đăng ký môn này:" + lsttienquyet.Items[t].SubItems[1].Text);
                            }
                        }
                    }
                }
                for (int t = 0; t < lstsonghanh.Items.Count; t++)
                {
                    for (int j = b; j <= 66 - a; j++)
                    {
                        if (lstdocifle.Columns[j].Text == lstsonghanh.Items[t].SubItems[0].Text)
                        {
                            if (lstdocifle.Items[lstdocifle.Items.Count - 1].SubItems[j].Text == "-1")
                            {
                                txtdudoan.AppendText("\r\n");
                                txtdudoan.AppendText("Học kỳ này bạn sẽ đăng kí 2 môn này : " + lstsonghanh.Items[t].SubItems[0].Text + " và môn: " + lstsonghanh.Items[t].SubItems[1].Text);
                            }
                        }
                    }
                }
                int dem = 0;
                double tong = 0;
                for (int j = 5; j < 57; j++)
                {
                    for (int i = lstdocifle.Items.Count - 1; i < lstdocifle.Items.Count; i++)
                    {
                        if (double.Parse(lstdocifle.Items[i].SubItems[j].Text) > -1)
                        {
                            tong += double.Parse(lstdocifle.Items[i].SubItems[j].Text);
                            dem++;
                        }
                    }
                }
                Clsdatabase cls = new Clsdatabase();
                cls.loaddatagridview(dataGridView1, "select * from MonHoc where " + s);
                if (cbhk2.Text == "")
                {
                    MessageBox.Show("Chọn học kỳ bạn muốn học môn tự chọn");
                }
                else if ((tong / dem) < 5)
                {
                    txtdudoan.AppendText("\r\n");
                    txtdudoan.AppendText("Bạn nên cải thiện điểm môn bắt buộc");

                }
                else if ((tong / dem) >= 5 && (tong / dem) < 7)               
                {
                    //double max = 0;                   
                    //for (int i = 0; i < lsttktc.Items.Count; i++)
                    //{
                      
                    //    // if(lsttktc)
                    //    //   double max1 = double.Parse(lsttktc.Items[i].SubItems[1].Text);
                    //    int a1 = lsttktc.Items.Count;
                    //    //MessageBox.Show("" + lsttktc.Items[i].SubItems[1].Text);
                    //    max = double.Parse(lsttktc.Items[0].SubItems[1].Text);
                    //    if (a1 == 1)
                    //    {
                    //        max = double.Parse(lsttktc.Items[0].SubItems[1].Text);
                    //    }
                    //    else
                    //    {
                    //        if (i < a1 - 1)
                    //        {
                    //            if (max < double.Parse(lsttktc.Items[i + 1].SubItems[1].Text))
                    //                max = double.Parse(lsttktc.Items[i + 1].SubItems[1].Text);
                    //        }
                    //    }
                    //}
                    double[] mang = new double[20];
                    double max = 0;
                    for (int i = 0; i < lsttktc.Items.Count; i++)
                    {
                        max = double.Parse(lsttktc.Items[i].SubItems[2].Text);
                        if (max > 25)
                            mang[i] = double.Parse(lsttktc.Items[i].SubItems[1].Text);
                        // MessageBox.Show("" + mang[i]);
                    }
                    for (int i = 0; i < lsttktc.Items.Count; i++)
                    {
                        max = 0;
                        if (max < mang[i])
                            max = mang[i];
                    }
                   // MessageBox.Show("" + max);
                    for (int j = 0; j < lsttktc.Items.Count; j++)
                    {
                        if (double.Parse(lsttktc.Items[j].SubItems[1].Text) == max)
                        {
                            txtdudoan.AppendText("\r\n");
                            txtdudoan.AppendText("Đề xuất môn học tự chọn" + lsttktc.Items[j].SubItems[0].Text);
                        }
                           
                    }
                }else
                {
                    if (cbhk2.Text == "học kỳ 1")
                    {
                        txtdudoan.AppendText("\r\n");
                        txtdudoan.AppendText("Học kỳ này tổng số tín chỉ tự chọn là 3 Ban nen hoc xac Xuat Thống Kê để nâng cao tư duy lập trình");
                    }
                    else if (cbhk2.Text == "học kỳ 2")
                    {
                        txtdudoan.AppendText("\r\n");
                        txtdudoan.AppendText("Học kỳ này tổng số tín chỉ tự chọn là 3 Ban nen hoc kiến trúc máy tính để nâng cao tư duy lập trình");
                    }
                    else if (cbhk2.Text == "học kỳ 3" || cbhk2.Text == "học kỳ 4")
                    {
                        txtdudoan.AppendText("\r\n");
                        txtdudoan.AppendText("Học kỳ này không có môn học tự chọn");
                    }
                    else if (cbhk2.Text == "học kỳ 5")
                    {
                        txtdudoan.AppendText("\r\n");
                        txtdudoan.AppendText("Tổng số tín chỉ học kỳ 5 là 3 bạn có các lựa chọn sau:");
                        txtdudoan.AppendText("\r\n");
                        txtdudoan.AppendText("Hệ quản trị cơ sở dữ liệu Oracle + Thực hành hệ quản trị cơ sở dữ liệu Oracle");
                        txtdudoan.AppendText("\r\n");
                        txtdudoan.AppendText("Kỹ thuật lập trình + Thực hành kỹ thuật lập trình");
                    }
                    else if (cbhk2.Text == "học kỳ 6")
                    {
                        txtdudoan.AppendText("\r\n");
                        txtdudoan.AppendText("Tổng số tín chỉ học kỳ 6 là 3: Kiểm định chất lượng phần mềm + Thực hành kiểm định chất lượng phần mềm");
                    }
                    else
                    {
                        txtdudoan.AppendText("\r\n");
                        txtdudoan.AppendText("Tổng số tín chỉ học kỳ 7 là 8 Bạn có 2 lựa chọn là Khoá luận tốt nghiệp 2 là: Đồ án chuyên ngành Hệ thống thông tin + Đồ án tốt nghiệp");
                    }
                }   
            }     
        }
        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" + lsthienthi.Items.Count);
        }
        private void lbhocluc_Click(object sender, EventArgs e)
        {

        }
        private void groupBox21_Enter(object sender, EventArgs e)
        {

        }

        private void btxemmh_Click(object sender, EventArgs e)
        {
           
        }
        private void lsttktc_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        private void button6_Click_2(object sender, EventArgs e)
        {
            // subitem laf cot 1

            for (int t = 0; t < lsttienquyet.Items.Count;t++ )
                MessageBox.Show("" + lsttienquyet.Items[t].SubItems[0].Text);
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            //  string a = lstttcum.SelectedItems[0].SubItems[0].Text;
            lstdsdiem.Clear();
            lstdsdiem.Columns.Add("Tên môn học");
            lstdsdiem.Columns.Add("Điểm");
            for (int i = 5; i < lstloc.Columns.Count; i++)
            {
                ListViewItem lst1 = lstdsdiem.Items.Add(lstloc.Columns[i].Text);
                lst1.SubItems.Add(lstloc.Items[lstloc.Items.Count - 1].SubItems[i].Text);
                // lst1.SubItems.Add(String.Format("{0:0.00}", tong1));
            }
            //double[] mang = new double[20];
            //double max = 0;
            //for (int i = 0; i < lsttktc.Items.Count; i++)
            //{
            //    max = double.Parse(lsttktc.Items[i].SubItems[2].Text);
            //    if (max > 25)
            //        if (double.Parse(lsttktc.Items[i].SubItems[1].Text)>50)
            //        mang[i] = double.Parse(lsttktc.Items[i].SubItems[1].Text);
            //    // MessageBox.Show("" + mang[i]);
            //}
            //for (int i = 0; i < lsttktc.Items.Count; i++)
            //{
            //    max = 0;
            //    if (max < mang[i])
            //        max = mang[i];
            //}
            //// MessageBox.Show("" + max);
            //for (int j = 0; j < lsttktc.Items.Count; j++)
            //{
            //    if (double.Parse(lsttktc.Items[j].SubItems[1].Text) == mang[j])
            //    {
            //        txtdudoan.AppendText("\r\n");
            //        txtdudoan.AppendText("Đề xuất môn học tự chọn" + lsttktc.Items[j].SubItems[0].Text);
            //    }

            //}
            //if ((tong / dem) >= 5 && (tong / dem) <= 6)
            //double[] mang = new double[20];
            //double max = 0;
            //for (int i = 0; i < lsttktc.Items.Count; i++)
            //{
            //    max = double.Parse(lsttktc.Items[i].SubItems[2].Text);
            //    if (max>25)
            //        mang[i] = double.Parse(lsttktc.Items[i].SubItems[1].Text);
            //   // MessageBox.Show("" + mang[i]);
            //}
            //for(int i=0;i < lsttktc.Items.Count; i++)
            //{
            //    max = 0;
            //    if (max < mang[i])
            //        max = mang[i];
            //}
            //MessageBox.Show("" + max);
            //for (int i = 0; i < lsttktc.Items.Count; i++)
            //{
            //     double tile = double.Parse(lsttktc.Items[i].SubItems[2].Text);
            //    if(tile>25)
            //    {
            //        int a1 = lsttktc.Items.Count;
            //        //MessageBox.Show("" + lsttktc.Items[i].SubItems[1].Text);
            //        max = 0;
            //        if (a1 == 1)
            //        {
            //            max = double.Parse(lsttktc.Items[0].SubItems[1].Text);
            //        }
            //        else
            //        {
            //            //if (tile > 25)
            //            {
            //                if (i < a1 - 1)
            //                {
            //                    if (max < double.Parse(lsttktc.Items[i + 1].SubItems[1].Text))
            //                        max = double.Parse(lsttktc.Items[i + 1].SubItems[1].Text);
            //                }
            //            }
            //        }
            //    }
               
            //}
            //// MessageBox.Show("" + max);
            //for (int j = 0; j < lsttktc.Items.Count; j++)
            //{
            //    if (double.Parse(lsttktc.Items[j].SubItems[1].Text) == max)
            //    {
            //        txtdudoan.AppendText("\r\n");
            //        txtdudoan.AppendText("Đề xuất môn học tự chọn" + lsttktc.Items[j].SubItems[0].Text);
            //    }

            //}
        }

        private void cbhk2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbhk2.Text == "học kỳ 1")
                lbhk.Text = "Tổng số tín chỉ học kỳ 1 là 3";
            if (cbhk2.Text == "học kỳ 2")
                lbhk.Text = "Tổng số tín chỉ học kỳ 2 là 2";
            if(cbhk2.Text=="học kỳ 3" )
                lbhk.Text="Tổng số tín chỉ học kỳ 3 là 0";
            if(cbhk2.Text=="học kỳ 4")
                lbhk.Text = "Tổng số tín chỉ học kỳ 4 là 0";
            if(cbhk2.Text=="học kỳ 5")
                lbhk.Text="Tổng số tín chỉ học kỳ 5 là 3";
            if(cbhk2.Text=="học kỳ 6")
                lbhk.Text="Tổng số tín chỉ học kỳ 6 là 3";
            if(cbhk2.Text=="học kỳ 7")
                lbhk.Text="Tổng số tín chỉ học kỳ 7 là 8";
        }

        private void groupBox24_Enter(object sender, EventArgs e)
        {

        }
    }
}
