using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project_ap
{
    public class information
    {

        public string esm;
        public string family;
        public float sen;
        public string shahr;
        public double x;
        public double y;
        public string moadele_1;
        public string moadele_2;
        public information(string esm, string family, float sen , string shahr, double x, double y
             ,string moadele_1 , string moadele_2)
        {
            this.esm = esm;
            this.family = family;
            this.sen = sen;
            this.shahr = shahr;
            this.x = x;
            this.y = y;
            this.moadele_1 = moadele_1;
            this.moadele_2 = moadele_2;
        }   
        public static bool num(string inp)
        {
            bool res=true;
            for(int i = 0; i < inp.Length; i++)
            {
                if (inp[i] == '1' || inp[i] == '2' || inp[i] == '3' || inp[i] == '4' || inp[i] == '5' ||
                    inp[i] == '6' || inp[i] == '7' || inp[i] == '8' || inp[i] == '9' || inp[i] == '0')
                    res = true;
                else
                    return false;
            }
            return res;
        }

    }
}
