/*
Prime Factorization from Coding Challenges
by Silvio Duka

Last modified date: 2018-03-03

Every natural number can be expressed as a product of prime numbers. 
Such a product representation is called prime factorization. 

For Example: 
300 = 2 ^ 2 * 3 ^ 1 * 5 ^ 2 
580 = 2 ^ 2 * 5 ^ 1 * 29 ^ 1 

Task: 
Write a program to display the prime factorization of a given number. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactorization
{
    class Program
    {
        static int number = 300; // Insert a number to be expressed as a product of prime numbers
        static int[] numbers;

        static void Main(string[] args)
        {
            int input = number;

            FindPrimeNumbers(number);

            string result = String.Empty;

            int p = 2;

            while (true)
            {
                if (number % p == 0)
                {
                    number /= p;
                    result += p + " ";
                }
                else
                {
                    p = FindNext(p);
                }

                if (number == 1) break;
            }

            Console.WriteLine($"Prime Factorization of {input} = {FormatResult(result)}");
        }

        static void FindPrimeNumbers(int end)
        {
            numbers = new int[number + 1];

            for (int i = 0; i <= number; i++)
            {
                numbers[i] = i;
            }

            int p = 2;

            while (true)
            {
                for (int i = 2; i <= (number / p); i++)
                {
                    numbers[p * i] = -1;
                }

                p = FindNext(p);

                if (p == -1) break;
            }

        }

        static int FindNext(int p)
        {
            for (int i = p + 1; i <= number; i++)
            {
                if (numbers[i] != -1) return i;
            }

            return -1;
        }

        static string FormatResult(string r)
        {
            string result = String.Empty;
            string old = String.Empty;

            foreach(string n in r.TrimEnd().Split(' '))
            {
                int i = 0;

                if (old == n) continue;

                foreach (string m in r.TrimEnd().Split(' '))
                {
                    if (m == n) i++;
                }

                result += n + '^' + i + '*';
                old = n;
            }

            return result.TrimEnd('*');
        }
    }
}