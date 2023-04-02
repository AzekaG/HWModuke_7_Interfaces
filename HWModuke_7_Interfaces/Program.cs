using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/*Создайте интерфейс ICalc. В нём должно быть два
метода:
■ int Less(int valueToCompare) — возвращает количество
значений меньших, чем valueToCompare;
■ int Greater(int valueToCompare) — возвращает количество значений больших, чем valueToCompare.

/*
Создайте интерфейс IOutput2. В нём должно быть
два метода:
■ void ShowEven() — отображает четные значения из
контейнера с данными;
ДОМАШНЕЕ ЗАДАНИЕ
1
■ void ShowOdd() — отображает нечетные значения из
контейнера с данными.*/
/*Создайте интерфейс ICalc2. В нём должно быть два
метода:
■ int CountDistinct() — возвращает количество уникальных значений в контейнере данных;
■ int EqualToValue(int valueToCompare) — возвращает
количество значений равных valueToCompare.*/



namespace HWModuke_7_Interfaces
{
    internal class Program
    {
       interface  ICacl
        {
            int Less(int valueToCompare);
            int Greater(int valueToCompare);
           
        }
        interface ICacl2
        {
            int CountDistinct();
            int EqualToValue(int valueToCompare);

        }
        interface IOutput
        {

            void Show();
            void Show(string info);

        }
        interface IOutput2
        {
            void ShowEven();
            void ShowOdd();


        }

        class MyArray : IOutput , ICacl , IOutput2, ICacl2
        {
            int[] myArr;
            public MyArray(int size)
            {
                myArr = new int[size];
                Random random = new Random();
                for (int i = 0; i < size; i++)
                    myArr[i] = random.Next(0, 10);
            }
            public void Show()
            {
                int count = 0;
                foreach (int i in myArr)
                {
                    
                    if (count %10==0) Console.WriteLine();
                    Console.Write(i+"  ");
                    count++;
                }
            }
            public void Show(string info)
            {
                int count = 0;
                Console.WriteLine(info);
                foreach (int i in myArr)
                {
                    Console.Write($"{i}" + "   : index " + count++ + " ");
                    if (count % 10 == 0) Console.WriteLine();
                }
                
            }

            public int Less(int valueToCompare)
            {
                int count = 0;
                foreach (int i in myArr)
                    if (i < valueToCompare) count++;
                return count;
            }
            

            public int Greater(int valueToCompare)
            {
                int count = 0;
                foreach (int i in myArr)
                    if (i > valueToCompare) count++;
                return count;
            }
            public void ShowEven()
            { int count = 0;
                foreach (int i in myArr)
                {
                    if (i % 2 == 0) Console.Write(i + " ");
                    if (count%10 == 0) Console.WriteLine() ;
                    count++;
                }
            }
            public void ShowOdd()
            {
                int count = 0;
                foreach (int i in myArr)
                {
                    if (i % 2 != 0) Console.Write(i + " ");
                    if (count % 10 == 0) Console.WriteLine();
                    count++;
                }
            }

            public int CountDistinct()
            {
                
                int count = 0;
                
                for(int i = 0; i < myArr.Length; i++)
                {
                    int localCount = 0;
                    for (int j = 0; j < myArr.Length; j++)
                    {
                        if (myArr[i] == myArr[j]) ++localCount;
                        if (localCount == 2) { localCount = 0; break; }
                        if (j == myArr.Length - 1 && localCount<2) count++;
                    }
                }
                return count;
            }
           
            public int EqualToValue(int valueToCompare)
            {
                int count = 0;
               
                foreach (int i in myArr)
                    if(i == valueToCompare) count++;
                    return count;
            
            
            }
        }






        static void Main(string[] args)
        {


            Console.WriteLine("Enter a size of array. It will be initializated automaticly");
            int temp = int.Parse(Console.ReadLine());
            MyArray A = new MyArray(temp);
            A.Show();
            Console.WriteLine();
            Console.WriteLine("Enter a value for comparison : ");
            temp = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Amount of Values in array > " + temp + " = " + A.Greater(temp));
            Console.WriteLine("Amount of Values in array < " + temp + " = " + A.Less(temp));
            Console.WriteLine("Even values : ");
            A.ShowEven();
            Console.WriteLine();
            Console.WriteLine("Odd values : ");
            A.ShowOdd();
            Console.WriteLine();
            Console.WriteLine("CountDistinct : "+A.CountDistinct());
            Console.WriteLine("enter a value for Compare : ");
            temp = int.Parse(Console.ReadLine());
            Console.WriteLine("Count Equal To Value : " + A.EqualToValue(temp));

            
        
         
        
        }
    }
}
