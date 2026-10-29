using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KINO_Alikin_2.Modell
{
    public class Kinoteatr
    {
        public int id {  get; set; }
        public string name { get; set; }
        public int countZal { get; set; }
        public int count {  get; set; }

        public Kinoteatr(int id, string name, int countZal, int count) 
        {
            this.id = id;
            this.name = name;
            this.countZal = countZal;
            this.count = count;
        }
    }
}
