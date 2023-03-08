using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_Means
{
    public class Kmeans
    {   
        public List<Vector> listItem = new List<Vector>();  // ds các gia trị
        public List<Vector> listCum = new List<Vector>(); // ds cac cum
        public int[] danhDau1;
        public int[] danhDau2;
        public void input(ListView lst, string fileName)
        {

            var package = new ExcelPackage(new FileInfo(fileName));
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
            for (int i = workSheet.Dimension.Start.Row; i <= workSheet.Dimension.End.Row; i++)
            {
                Vector input = new Vector();
                
                ListViewItem itemListView = new ListViewItem();
                
                for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                {
                    if (i == 1)
                    {
                        try
                        {
                            lst.Columns.Add(workSheet.Cells[i, j].Value.ToString());
                        }
                        catch (Exception ex)
                        {
                            lst.Columns.Add("");
                        }
                    }
                    else
                    {
                        if (j == 1)
                            itemListView.Text = workSheet.Cells[i, j].Value.ToString();
                         else 
                        {                        
                            itemListView.SubItems.Add(workSheet.Cells[i, j].Value.ToString());
                            if (j > 5)
                            {                                
                                  input.item.Add(Double.Parse(workSheet.Cells[i, j].Value.ToString()));                       
                            }
                                
                        }
                    }
                }
               //Random rd = new Random();
               lst.Items.Add(itemListView);
               if (i != 1)
               {
                   listItem.Add(input);
               }
            }
            danhDau1 = new int[listItem.Count];
            danhDau2 = new int[listItem.Count];
        }

        public void khoiTaoVector(Vector newVT)
        {
            // 
            for (int i = 0; i < listItem[0].item.Count; i++)
            {
                newVT.item.Add(0);
            }
        }
       
        public void hienThi(ListView lst,ListView lst1)
        {
            double dem = 0.0;

            double tong = 0.0;
            lst.View = View.Details;
           
            lst.Columns.Add("Cụm");
            lst.Columns.Add("Phan tu cum");
            lst.Columns.Add("So Phan Tu");
            lst.Columns.Add("Ti le phan tram");
            for (int i = 0; i < listCum.Count; i++)
            {
                string s = "";
                ListViewItem item = lst.Items.Add("Cum" + (i + 1));
                dem = 0;

                for (int j = 0; j < listItem.Count; j++)
                {
                    if (danhDau1[j] == i)
                    {
                        s += j + 1 + ";";  
                        dem++;
                    }                
                }
                tong = (dem / (lst1.Items.Count - 1.0))*100;
                item.SubItems.Add(s);
                item.SubItems.Add(dem.ToString());
                item.SubItems.Add("" + String.Format("{0:0.00}", tong));
            }                 

        }
     
        public void kmean()
        {              
            // tao danh dau tat ca cac dong deu =1
            for (int i = 0; i < listItem.Count; i++)
            {                
                danhDau1[i] = 1; 
                danhDau2[i] = 1;
            }
            
            int lanLap = 0;
            while (true)
            {
                lanLap++;
                double min = 0;
                for (int i = 0; i < listItem.Count; i++)
                {
                     int vt = 0;
                 
                      min = listItem[i].tinhKC(listCum[vt]);
                     for (int j = 1; j < listCum.Count; j++)
                     {
                        double kc = 0;
                        
                         {
                              kc = listItem[i].tinhKC(listCum[j]);
                         }                                                                                      
                            
                        if (min > kc)
                        {
                            vt = j;
                            min = kc;
                        }                                       
                    }
                    danhDau1[i] = vt;
                }
                //tao tam moi
                for (int i = 0; i < listCum.Count; i++)
                {
                    int dem = 0;
                    Vector newVt = new Vector();
                    khoiTaoVector(newVt);
                    for (int j = 0; j < listItem.Count; j++)
                        if (danhDau1[j] == i)
                        {
                            dem++;
                            newVt.tinhTong(listItem[j]);
                        }
                    newVt.trungBinh(dem);
                    listCum[i] = newVt;
                }
                if (lanLap == 1)
                    danhDau2 = danhDau1;
                else
                {
                    bool check = true;
                    for (int i = 0; i < danhDau1.Length; i++)
                        if (danhDau1[i] != danhDau2[i])
                        {
                            danhDau2 = danhDau1;
                            check = false;
                            break;
                        }
                    if (check)  
                        break;
                }
            }
        }
    }
}
