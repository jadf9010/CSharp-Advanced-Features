//  Created by Javier Alejandro Domínguez Falcón on 18/05/2020.
//  Copyright © 2020 Javier Alejandro Domínguez Falcón. All rights reserved.

using System;

namespace SimpleMatrixPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            int R = 5;
            int C = 5;
            int[] m = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };

            int Ri = 10;
            int Ci = 7;
            int[] mi = { 1, 2, 3, 4, 5, 6, 7, 11, 12, 13, 14, 15, 16, 17, 21, 22, 23, 24, 25, 26, 27, 31, 32, 33, 34, 35, 36, 37, 41, 42, 43, 44, 45, 46, 47, 51, 52, 53, 54, 55, 56, 57, 61, 62, 63, 64, 65, 66, 67, 71, 72, 73, 74, 75, 76, 77, 81, 82, 83, 84, 85, 86, 87, 91, 92, 93, 94, 95, 96, 97 };

            int Ro = 10;
            int Co = 10;
            int[] mo = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100 };

            int Ru = 4;
            int Cu = 7;
            int[] mu = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28 };

            //using the same algorithm to move in the matrix...
            MatrixMovementPattern matrixMovementPattern = new MatrixMovementPattern();

            //...and only defining a new iteration pattern...
            matrixMovementPattern.iteractionPattern = new ClockwiseIterationPattern();
            var ClockwiseResult = matrixMovementPattern.Traversal(m, R, C);

            //...we can get different results
            Console.WriteLine(ClockwiseResult);
            Console.WriteLine("\n");

            //Applying another iteration pattern (CounterClockwise)
            matrixMovementPattern.iteractionPattern = new CounterClockwiseIterationPattern();
            var CounterClockwiseResult = matrixMovementPattern.Traversal(m, R, C);

            Console.WriteLine(CounterClockwiseResult);
        }
    }
}
