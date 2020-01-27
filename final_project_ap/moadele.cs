using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project_ap
{
    class moadele
    {
        public int zarib_x_1;
        public int zarib_y_1;
        public int javab_1;
        public int zarib_x_2;
        public int zarib_y_2;
        public int javab_2;
        public static double res_1;
        public static double res_2;
        public moadele(int zarib_x_1 , int zarib_y_1 ,int javab_1 , int zarib_x_2 , int zarib_y_2 , int javab_2)
        {
            this.zarib_x_1 = zarib_x_1;
            this.zarib_x_2 = zarib_x_2;
            this.zarib_y_1 = zarib_y_1;
            this.zarib_y_2 = zarib_y_2;
            this.javab_1 = javab_1;
            this.javab_2 = javab_2;
        }
        public void cal()
        {
            if (zarib_x_1 * zarib_y_2 - zarib_x_2 * zarib_y_1 == 0)
                res_1 = -100;
            else
            {
                res_1 = (javab_1 * zarib_y_2 - zarib_y_1 * javab_2) / (zarib_x_1 * zarib_y_2 - zarib_y_1 * zarib_x_2);
                res_2 = (zarib_x_1 * javab_2 - javab_1 * zarib_x_2) / (zarib_x_1 * zarib_y_2 - zarib_y_1 * zarib_x_2);
            }
        }
    }
}
