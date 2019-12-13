using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var intList = new GenericList<int>(2);
            intList.Add(5);
            intList.Add(7);
            intList.Add(10);
            intList.Add(11);
            intList.Add(12);
            intList.Add(13);
            var stringList = new GenericList<string>(5);
            stringList.Add("sfsf");
            stringList.Add("Fgnfh");
            //Console.WriteLine( intList.ReadElem(2));
            //intList.InsertAtIndex(0, 15);
            //Console.WriteLine(intList.ReadElem(0));
            //stringList.InsertAtIndex(3, "ana are mere");
            ////Console.WriteLine( stringList.ReadElem(3));
            //Console.WriteLine(stringList.ReadElem(0));
            //Console.WriteLine(stringList.RemoveElem(null, 0));
            //Console.WriteLine(stringList.ReadElem(0));
            //Console.WriteLine(intList.RemoveElem(0, 0));
            //stringList.ClearList();

            //Console.WriteLine(stringList.ReadElem(0));
            //Console.WriteLine(stringList.ReadElem(1));

            // Console.WriteLine(intList.ReadElem(2));
            // Console.WriteLine(intList.ReadElem(5));

            //Console.WriteLine(intList.Max());
            //intList.ReadElem(6);

            //Console.WriteLine(intList.Min());


            Console.WriteLine(stringList.FindElem("sfsd"));

            Console.WriteLine(intList.FindElem(6));
            Console.ReadLine();
        }
    }
    public class GenericList<T> where T : IComparable
    {
        private T[] array;
        private int size;
        private int elemIndex ;
        public GenericList(int size) 
        {
            this.size = size;
            this.elemIndex = 0;
            this.array = new T[size];

        }
        public void AutoGrow()
        {
            if (elemIndex >= size)
            {
                var array2 = new T[size * 2];
                array.CopyTo(array2, 0);
                array = array2;
                size = size*2;
            }
        }

        public void Add(T value)
        {
            if (this.elemIndex >= size)
            {
                    AutoGrow();
            }
            array[elemIndex] = value;
            this.elemIndex++;

        }
        public void ReadElem(int index)
        {
            try
            {
                 Console.WriteLine( array[index]);
                
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine("elem not in list",ex);
            }
            
        }
        public T RemoveElem(int index)
        {
            return this.array[index] = default(T);
            
        }
        public void InsertAtIndex(int index,T value)
        {
            this.array[index] = value;
        }
        public void ClearList()
        {
            for (int i = 0; i < array.Length; i++)
            {
               array[i] = default(T);
            }
        }
        public bool FindElem(T value)
        {
            var result = false;
            for (int i = 0; i < array.Length; i++)
            {
                var x = value.CompareTo(array[i]);
                    if(x == 0)
                {
                    result = true;
                }
            }
            return result;
        }
        
        public T Max()
        {
            var max = array[0];
            for (int i = 0; i < array.Length; i++)
            {

               var x=  max.CompareTo(array[i]);
                if(x == -1)
                {
                    max = array[i];
                }
               
            }
            return max;
        }
        public T Min()
        {
            var min = array[0];
            for (int i = 0; i < array.Length; i++)
            {

                var x = min.CompareTo(array[i]);
                if (x == 1)
                {
                    min = array[i];
                }

            }
            return min;
        }




    }

}
