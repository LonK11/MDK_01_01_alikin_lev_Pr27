using System;
using System.Runtime.InteropServices;

namespace KINO_Alikin_2.Modell
{
    public class afisha
    {
        public int id {  get; set; }
        public string name { get; set; }
        public DateTime time { get; set; }
        public int price { get; set; }
        public int idKinoteatr { get; set; }
        public afisha (int id, string name, DateTime time, int price, int idKinoteatr)
        {
            this.id = id;
            this.name = name;
            this.time = time;
            this.price = price;
            this.idKinoteatr = idKinoteatr;
        }
    }
}
