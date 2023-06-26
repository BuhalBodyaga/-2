using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace хэш_таблицы_2
{
    internal class Item

    {
        public FullName fullname;
        public Trip trip;
        public Data data;
        public int status;
        public int hash;


        public Item(FullName fullname,Data data, Trip trip,  int hash)
        {
            this.hash = hash;
            this.fullname = fullname;
            this.trip = trip;
            this.data = data;
            status = 1;
        }
        public Item()
        {
            fullname = new FullName("", "", "");
            trip = new Trip("", 0);
            data = new Data(0, 0, 0);
            status = 0;
        }
    }
}
