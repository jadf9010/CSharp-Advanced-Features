//  Created by Javier Alejandro Domínguez Falcón on 19/05/2020.
//  Copyright © 2020 Javier Alejandro Domínguez Falcón. All rights reserved.

using System;

namespace IntegerToString
{
    /// <summary>
    /// Write an integer to string function without using any built-in functionality, conversions or castings with a base of up to 16. The allocation should be handled on behalf of the caller.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("___________Recursive Function_________________\n");

            Console.WriteLine("Decimal :" + IntToString.toStr(1750, 10));
            Console.WriteLine("Hexadecimal :" + IntToString.toStr(1750, 16));
            Console.WriteLine("Binary :" + IntToString.toStr(1750, 2));

            Console.WriteLine("\n");

            Console.WriteLine("___________Convert Int to String!______________ \n");

            Console.WriteLine("Decimal :" + IntToString.Itoa(1750, 10));
            Console.WriteLine("Hexadecimal :" + IntToString.Itoa(1750, 16));
            Console.WriteLine("Binary :" + IntToString.Itoa(1750, 2));
        }


        static class IntToString
        {
            /// <summary>
            /// Recursive itoa Function 
            /// </summary>
            /// <param name="value"></param>
            /// <param name="base"></param>
            /// <returns></returns>
            public static string toStr(int value, int @base)
            {
                var chars = "0123456789ABCDEF".ToCharArray();
                var str = new char[32]; // maximum number of chars in any base

                //base case
                if (value < @base)
                {
                    return new string(chars[value], 1);
                }

                else if ((value % @base) == 0)
                {
                    return toStr(value / @base, @base) + chars[0];
                }

                else
                {
                    return toStr(value / @base, @base) + chars[value % @base];
                }
            }

            public static string Itoa(int value, int @base)
            {
                var chars = "0123456789ABCDEF".ToCharArray();
                var str = new char[32]; // maximum number of chars in any base
                var i = str.Length;
                bool isNegative = (value < 0);
                if (value <= 0) // handles 0 and int.MinValue special cases
                {
                    str[--i] = chars[-(value % @base)];
                    value = -(value / @base);
                }

                while (value != 0)
                {
                    str[--i] = chars[value % @base];
                    value /= @base;
                }

                if (isNegative)
                {
                    str[--i] = '-';
                }

                return new string(str, i, str.Length - i);
            }
        }
    }
}
