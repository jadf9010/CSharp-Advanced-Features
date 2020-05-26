//  Created by Javier Alejandro Domínguez Falcón on 19/05/2020.
//  Copyright © 2020 Javier Alejandro Domínguez Falcón. All rights reserved.

using System;

namespace CSharpTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_______________Value TYPES___________________");
            //This kind of values are copies in memory in the Stack
            //They are called value types because their values are copies
            int a = 40;

            // They are value types so when we copy a value type to another variable the copy of that variable is copy at the target location in memory
            int b = a;

            //In this point only the variable "b" it'll be modified
            b += 40;

            Console.WriteLine(string.Format("a: {0}, b: {1}", a, b));
            Console.WriteLine("_______________REFERENCE TYPES___________________");

            //In the Stack is created the variable array1. The value inside this variable is a memory address and that is the address of the object in the Heap (The array {1, 2, 3, 4, 5}).
            //Array1 points to the object on the Heap.
            var array1 = new int[5] { 1, 2, 3, 4, 5 }; // When is initialized an object is created in the heap. This object is in a memory location with an address and inside of this memory location we have the values of the array 

            //When array2 is created another variable on the stack is built. Inside this variable, we have again a memory address. This memory address that holds array2 is the address of the array1 object that is on the heap.
            //Both objects array1 and array2 point to the same object in the heap {1, 2, 3, 4, 5}.
            //When we copy an object of References Type the memory address is copied no the actual value.
            var array2 = array1;

            //When we make any changes in the values of one of this array we are modifying the same object.
            array2[0] = 0;

            Console.WriteLine(string.Format("array[0]: {0}, array1[0]: {1} ", array1[0], array2[0]));

            Console.WriteLine("_______________Pointer TYPES___________________");

            DisplayPointer();
        }

        public static unsafe void DisplayPointer()
        {
            int x = 10;
            int y = 20;
            int* ptr1 = &x;
            int* ptr2 = &y;
            Console.WriteLine((int)ptr1);   //Displays the memory address
            Console.WriteLine((int)ptr2);   //Displays the memory address
            Console.WriteLine(*ptr1);       //Displays the value at the memory address.   
            Console.WriteLine(*ptr2);       //Displays the value at the memory address.   
        }
    }
}
