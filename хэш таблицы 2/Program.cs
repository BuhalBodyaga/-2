using System;


namespace хэш_таблицы_2
{

    internal class Program
    {



        static void Main(string[] args)
        {


            var table = new HashTable(11);


            table.Add(new FullName("Антонов", "Курица", "Толстый"), new Data(06, 11, 2022),new Trip("NM", 1345) ) ;
            table.Add(new FullName("Антонов", "Курица", "Толстый"), new Data(06, 11, 2022), new Trip("NM", 2345));
            table.Add(new FullName("Антонов", "Курица", "Толстый"), new Data(06, 11, 2022), new Trip("NM", 4345));
            table.Add(new FullName("Антонов", "Курица", "Толстый"), new Data(06, 11, 2022), new Trip("NM", 5345));
            table.Add(new FullName("Антонов", "Курица", "Толстый"), new Data(06, 11, 2022), new Trip("NM", 6345));

            table.delete(new FullName("Антонов", "Курица", "Толстый"), new Data(06, 11, 2022), new Trip("NM", 1345));
            table.delete(new FullName("Антонов", "Курица", "Толстый"), new Data(06, 11, 2022), new Trip("NM", 2345));
            table.delete(new FullName("Антонов", "Курица", "Толстый"), new Data(06, 11, 2022), new Trip("NM", 4345));
            table.delete(new FullName("Антонов", "Курица", "Толстый"), new Data(06, 11, 2022), new Trip("NM", 5345));
            table.delete(new FullName("Антонов", "Курица", "Толстый"), new Data(06, 11, 2022), new Trip("NM", 6345));

            table.Add(new FullName("Антонов", "Курица", "Толстый"), new Data(06, 11, 2022), new Trip("NM", 1345));
            table.Add(new FullName("Антонов", "Курица", "Толстый"), new Data(06, 11, 2022), new Trip("NM", 2345));



            table.Print();





        }
    }
}

