using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace OperationsTimer
{
    internal class Program
    {
        static int arrLength = 1000;
        static int[] myArr1 = new int[arrLength];
        static List<int> found = new();

        static int searchNum = 370;
        //static int searchNum = arrLength - 10;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var summary = BenchmarkRunner.Run<Testing>();
            /*
            Random random = new Random();
            searchNum = random.Next(arrLength);

            Stopwatch sw = new Stopwatch();
            do
            {
                sw.Start();
                FillArray(true);
                sw.Stop();
                Console.WriteLine($"Elapsed time: {sw.Elapsed};  Elapsed milliseconds: {sw.ElapsedMilliseconds}");
                /*
                sw.Reset();
                sw.Start();
                LineSearch(searchNum);
                sw.Stop();
                Console.WriteLine($"Elapsed time: {sw.Elapsed};  Elapsed milliseconds: {sw.ElapsedMilliseconds}");
                //* /
                sw.Reset();
                sw.Start();
                BinarySearchNoRecursion(searchNum);
                sw.Stop();
                Console.WriteLine($"Elapsed time: {sw.Elapsed};  Elapsed milliseconds: {sw.ElapsedMilliseconds}");

                Console.ReadKey();
                Console.WriteLine();
            } while (true);
            */


        }

        static void FillArray(bool isRandom)
        {
            Console.WriteLine($"Start filling array[{arrLength}], by {(isRandom ? "random" : "direct") } values ");
            Random rand = new Random();
            for (int i = 0; i < arrLength; i++)
            {
                if (isRandom)
                {
                    myArr1[i] = rand.Next(arrLength);
                } else
                {
                    myArr1[i] = i;
                }
            }
            Console.WriteLine("Filling complete");
        }
        
        static void SortArray()
        {
            Console.WriteLine($"Starting sorting array[{arrLength}]");
            Array.Sort(myArr1);
            Console.WriteLine($"Sort complete");
        }

        static void LineSearch(int num)
        {
            int counter = 0;
            Console.WriteLine($"Starting LINE search of number  \"{num}\" in array[{arrLength}]");
            for (int i = 0; i < arrLength; i++)
            {
                counter++;
                if (myArr1[i] == num)
                {
                    break;
                }
            }
            Console.WriteLine($"Search complete in   {counter:N0}   steps");
        }
        
        static void BinarySearch(int num)
        {
            int counter = 0;
            Console.WriteLine($"Starting BINARY search of number  \"{num}\" in array[{arrLength}]");
            SortArray();
            Split(ref num, ref counter, 0, arrLength - 1);

            Console.WriteLine($"Search complete in {counter:N0}   steps");
        }

        static void Split(ref int num, ref int counter, int rightPoint, int leftPoint)
        {
            counter++;
            int center = (rightPoint + (leftPoint - rightPoint) / 2);
            found.Add(myArr1[center]);
            Console.WriteLine($"Step #{counter, 5}: center is {center,8}, btw {rightPoint,8} and {leftPoint,8}");
            if (myArr1[center] == num)
            {
                Console.WriteLine($"WE FOUND!!! POSITION #{center}");
                return;
            } else
            {
                if (num < myArr1[center]) 
                {
                    Split(ref num, ref counter, rightPoint, center);
                    return;
                } else if (num > myArr1[center])
                {
                    Split(ref num, ref counter, center, leftPoint);
                    return;
                }
            }
        }

        static void BinarySearchNoRecursion(int num)
        {
            int counter = 0;
            Console.WriteLine($"Starting BINARY search WO RECURSION of number  \"{num}\" in array[{arrLength}]");
            SortArray();
            bool isFound = false;
            int left = 0;
            int right = arrLength - 1;
            int middle;
            int cur;
            while (left <= right)
            {
                counter++;
                middle = (left + right) / 2;
                cur = myArr1[middle];
                if (cur == num)
                {
                    isFound = true;
                    Console.WriteLine("___Position of search element is " + middle);
                    break;
                } else if (cur > num) 
                {
                    right = middle - 1;
                } else
                {
                    left = middle + 1;
                }
            }
            if (isFound)
            {
                Console.WriteLine($"Search complete in {counter:N0}   steps");
            } else
            {
                Console.WriteLine("There is no such element");
            }
        }
    }
}


/*          RESULTS:
 * random, arrLength = 100, filling = 2 ms
 * random, arrLength = 10000, filling = 2 ms
 * random, arrLength = 1000000, filling = 30 ms
 * random, arrLength = 3000000, filling ~ 90 ms
 * direct, arrLength = 3000000, filling ~ 25 ms
 * direct, arrLength = 3000000, filling ~ 25 ms,  line search ~ 17 ms 
 * 
 * direct, arrLength = 3000000, filling ~ 25 ms, sort ~ 60 ms
 * 
 * 
 */