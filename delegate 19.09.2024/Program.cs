using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace pr2
{
    public class MyArray : IOutput, IMath, ICalc, IOutput2, ICalc2
    {
        private int[] array;

        public MyArray()
        {
            array = new int[0];
        }

        public MyArray(int size)
        {
            array = new int[size];
        }

        public MyArray(int[] initialArray)
        {
            array = new int[initialArray.Length];
            Array.Copy(initialArray, array, initialArray.Length);
        }

        public void SetValue(int index, int value)
        {
            if (index >= 0 && index < array.Length)
            {
                array[index] = value;
            }
            else
            {
                Console.WriteLine("Неправильный индекс!");
                return;
            }
        }

        public int GetValue(int index)
        {
            if (index >= 0 && index < array.Length)
            {
                return array[index];
            }
            else
            {
                Console.WriteLine("Неправильный индекс!");
                return -1;
            }
        }

        // реалізація інтерфейсів з 1 завдання Less, Greater
        public int Less(int valueToCompare)
        {
            int count = 0;
            foreach (int value in array)
            {
                if (value < valueToCompare)
                {
                    count++;
                }
            }
            return count;
        }

        public int Greater(int valueToCompare)
        {
            int count = 0;
            foreach (int value in array)
            {
                if (value > valueToCompare)
                {
                    count++;
                }
            }
            return count;
        }
        public void ShowEven()
        {
            Console.Write("Парные значения: ");
            foreach (int value in array)
            {
                if (value % 2 == 0)
                {
                    Console.Write(value + " ");
                }
            }
            Console.WriteLine();
        }

        public void ShowOdd()
        {
            Console.Write("Непарные значения: ");
            foreach (int value in array)
            {
                if (value % 2 != 0)
                {
                    Console.Write(value + " ");
                }
            }
            Console.WriteLine();
        }

        public int CountDistinct()
        {
            return array.Distinct().Count();
        }

        public int EqualToValue(int valueToCompare)
        {
            return array.Count(x => x == valueToCompare);
        }

        public int Size()
        {
            return array.Length;
        }

        public override string ToString()
        {
            return "[" + string.Join(", ", array) + "]";
        }

        public void Show()
        {
            Console.WriteLine(ToString());
        }

        public void Show(string info)
        {
            Console.WriteLine(info + ": " + ToString());
        }
        public int Max()
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Масив пустой");
                return -1;
            }

            int max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;
        }

        public int Min()
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Масив пустой");
                return -1;
            }

            int min = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }
        public double Avg()
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Масив пустой");
                return -1;
            }

            float sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum / array.Length;
        }
        public bool Search(int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        public void SortAsc()
        {
            Array.Sort(array);
        }

        public void SortDesc()
        {
            Array.Sort(array, (a, b) => b.CompareTo(a));
        }

        public void SortByParam(bool isAsc)
        {
            if (isAsc)
            {
                SortAsc();
            }
            else
            {
                SortDesc();
            }
        }
    }

}

namespace pr2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MyArray arrayWithSize = new MyArray(5);
            arrayWithSize.SetValue(0, 10);
            arrayWithSize.SetValue(1, 20);
            arrayWithSize.SetValue(2, 30);
            arrayWithSize.SetValue(3, 40);
            arrayWithSize.SetValue(4, 50);
            arrayWithSize.Show();

            int[] ar = { 1, 2, 3, 4, 5 };
            MyArray newArr = new MyArray(ar);
            newArr.Show();
            newArr.Show("Мой масив");

            Console.WriteLine("Максимум в максиве: " + newArr.Max());
            Console.WriteLine("Минимум в масиве: " + newArr.Min());
            Console.WriteLine("Среднеарифметическое в масиве: " + newArr.Avg());
            int value = 3;
            Console.WriteLine("Содержит ли массив значение " + value + "? " + (newArr.Search(value) ? "Так" : "Ні"));

            newArr.SortAsc();
            Console.WriteLine("Массив после сортировки по росту:");
            newArr.Show();

            newArr.SortDesc();
            Console.WriteLine("Массив после сортировки по убыванию:");
            newArr.Show();

            newArr.SortByParam(true);
            Console.WriteLine("Массив после сортировки по росту:");
            newArr.Show();

            newArr.SortByParam(false);
            Console.WriteLine("Массив после сортировки по убыванию:");
            newArr.Show();

            //Home Task

            int valueToCompare = 3;

            Console.WriteLine($"Количество элементов меньше {valueToCompare} = {newArr.Less(valueToCompare)}");
            Console.WriteLine($"Количество элементов больше {valueToCompare}= {newArr.Greater(valueToCompare)}");

            newArr.ShowEven();
            newArr.ShowOdd();

            int[] numbers = { 3, 7, 2, 3, 7, 2, 8 };
            MyArray myArray = new MyArray(numbers);
            myArray.Show();

            Console.WriteLine($"Количество уникальных значений: {myArray.CountDistinct()}");
            Console.WriteLine($"Количество элементов, равных {valueToCompare}: {myArray.EqualToValue(valueToCompare)}");

        }
    }
}