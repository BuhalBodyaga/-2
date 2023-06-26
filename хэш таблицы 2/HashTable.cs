using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace хэш_таблицы_2
{
    internal class HashTable
    {
        private Item[] items;
        private int size;
        private int count;
        private int initialSize;
        private double loadFactorThreshold = 0.75; // Пороговое значение заполненности для увеличения и уменьшения размера

        // private int hash;

        public HashTable(int size) //1.Конструктор
        {

            items = new Item[size];
            this.size = size;
            count = 0;
            initialSize = size;

            for (int i = 0; i < size; i++)
            {
                items[i] = new Item();
            }

        }

        public int FirstHash(FullName fullname, Trip trip) //2.Первая хэш функция
        {
            string mass = "";
            int result = 0;
            string temp = "";
            mass = fullname.firstname + fullname.secondName + fullname.patronymic + trip.tripChar + trip.tripInt;



            for (int i = 0; i < mass.Length; i++)
            {
                temp += $"{(int)mass[i]}";
            }

            if (temp.Length % 2 != 0)
            {
                temp += 0;
            }

            for (int i = 0; i < temp.Length; i += 2)
            {
                String temp2 = $"{Char.GetNumericValue(temp[i])}{Char.GetNumericValue(temp[i + 1])}";
                result += int.Parse(temp2);
            }

            // hash = result % size;
            return result % size;

        }

         public int SecondHash(int hash) //3.вторая хэш функция
         {
            return (hash + 1) % size;
        }

        private int ResolveCollisionLinear(int index)
        {
            int startIndex = index;
            index = SecondHash(index);

            while (items[index].status != 0 && index != startIndex)
            {
                index = SecondHash(index);
            }

            return index;
        }
        public void Add(FullName fullname, Data data, Trip trip) // 4. Добавление
        {
            int index = FirstHash(fullname, trip);

            if (Search(fullname, data, trip) != -1)
            {
                return; // Если объект уже существует, прекращаем добавление
            }

            Item item = new Item(fullname, data, trip, index);

            if (items[index].status == 0 || items[index].status == 2) // Проверяем, что ячейка пустая или удаленная
            {
                items[index] = item;
                count++;
                items[index].status = 1; // Устанавливаем статус как занятую ячейку
            }
            else
            {
                index = ResolveCollisionLinear(index);

                if (items[index].status == 0 || items[index].status == 2) // Проверяем, что ячейка пустая или удаленная
                {
                    items[index] = item;
                    count++;
                    items[index].status = 1; // Устанавливаем статус как занятую ячейку
                }
                CheckLoadFactor();

            }
        }

        public void delete(FullName fullname, Data data, Trip trip)
        {
            int index = FirstHash(fullname, trip);

            if (index != -1)
            {
                items[index].status = 2; // Устанавливаем статус как удаленную ячейку
                items[index] = new Item(); // Обновляем элемент

                count--; // Обновляем значение count
            }
            CheckLoadFactor();
        }

        public int Search(FullName fullname3, Data data3, Trip trip3)
        {
            int index = FirstHash(fullname3, trip3);

            while (items[index].status != 0 && items[index].status != 2)
            {
                if (items[index].status == 1 &&
                    items[index].fullname.firstname == fullname3.firstname &&
                    items[index].fullname.secondName == fullname3.secondName &&
                    items[index].fullname.patronymic == fullname3.patronymic &&
                    items[index].trip.tripChar == trip3.tripChar &&
                    items[index].trip.tripInt == trip3.tripInt &&
                    items[index].data.day == data3.day &&
                    items[index].data.month == data3.month &&
                    items[index].data.year == data3.year)
                {
                    return index;
                }

                index = SecondHash(index);
            }

            return -1;
        }


        public void Print() //7.печать
        {
            for (int j = 0; j < size; j++)
            {
                if (items[j].status == 1)
                {
                    Console.WriteLine
                        ($"{j}|{items[j].fullname.firstname}" +
                        $" {items[j].fullname.secondName}" +
                        $" {items[j].fullname.patronymic}" +
                        $" {items[j].data.day}" +
                        $" {items[j].data.month}" +
                        $" {items[j].data.year}" +
                        $" {items[j].trip.tripChar}" +
                        $" {items[j].trip.tripInt}" +
                        $" " +
                        $"{items[j].status}" +
                        $"|hash={items[j].hash}");

                }

            }
            Console.WriteLine(size);
        }

        private void Resize(int newSize) // Внутренний метод для изменения размера хеш-таблицы
        {
            Item[] newItems = new Item[newSize];
             for (int i = 0; i < newSize; i++)
            {
                newItems[i] = new Item();
            }
            Array.Copy(items, newItems, count);
            items = newItems;
            size = newSize;
           
        }

        private void IncreaseSize() // Метод для увеличения размера хеш-таблицы
        {
            int newSize = size * 2; // Увеличиваем размер в два раза
            Resize(newSize);
        }

        private void DecreaseSize() // Метод для уменьшения размера хеш-таблицы
        {
            int newSize = Math.Max(size / 2, initialSize); // Уменьшаем размер до половины текущего размера, но не меньше исходного размера
            Resize(newSize);
        }

        public void CheckLoadFactor() // Метод для проверки и выполнения увеличения или уменьшения размера хеш-таблицы
        {
            double loadFactor = (double)count / size;

            if (loadFactor >= loadFactorThreshold) // Заполнение более или равно пороговому значению
            {
                IncreaseSize();
            }
            else if (loadFactor < loadFactorThreshold / 4 && size > initialSize) // Заполнение менее четверти и размер больше исходного размера
            {
                DecreaseSize();
            }
        }
    }


}

