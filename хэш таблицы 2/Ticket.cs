using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace хэш_таблицы_2
{
    internal class Ticket
    {


        public Data data;
        public FullName fullname;
        public Trip trip;


        public Ticket(FullName fullname, Data data,  Trip trip)
        {
            this.data = data;
            this.fullname = fullname;
            this.trip = trip;


        }

    }

    public class Data
    {
        public int day, month, year;
        public Data(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }
    };

    public class FullName
    {
        public string firstname, secondName, patronymic;
        public FullName(string firstname, string secondName, string patronymic)
        {
            this.firstname = firstname;
            this.secondName = secondName;
            this.patronymic = patronymic;
        }
    };

    public class Trip
    {

        public string tripChar;
        public int tripInt;
        public Trip(string tripChar, int tripInt)
        {
            this.tripInt = tripInt;
            this.tripChar = tripChar;
        }
    };
}
