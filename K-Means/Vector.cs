using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Means
{
    public class Vector
    {
        public List<double> item = new List<double>();               
        public double tinhKC(Vector input)
        {          
          
            double sum = 0;
            for (int i = 0; i < item.Count; i++)
            {
                     sum += (item[i] - input.item[i]) * (item[i] - input.item[i]);                                          
            }            
            return Math.Sqrt(sum);
        }
        public double tinhKC2(Vector input)
        {
            double sum = 0;
            for (int i = 0; i < item.Count; i++)
            {
               // if(item[i]!=-1)
                {
                    sum += (item[i] - input.item[i]) * (item[i] - input.item[i]);
                }                     
            }
            return Math.Sqrt(sum);
        }
        public void tinhTong(Vector input)
        {
            for (int i = 0; i < input.item.Count; i++)
            {
                if (item[i] != -1)
                item[i] += input.item[i];
            }            
        }
        public void trungBinh(int dem)
        {
            
            for (int i = 0; i < item.Count; i++)
                if (item[i] != -1)
                item[i] /= dem;
        }
    }
}
