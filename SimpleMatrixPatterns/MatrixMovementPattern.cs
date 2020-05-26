//  Created by Javier Alejandro Domínguez Falcón on 18/05/2020.
//  Copyright © 2020 Javier Alejandro Domínguez Falcón. All rights reserved.

using System;
namespace SimpleMatrixPatterns
{
    public struct IterationParameters1D
    {
        public int B; //Begin
        public int E; //End
        public int D; //Direction
        public bool Row; //move through Rows
        public bool Col; //move through Cols
    }

    public struct IterationParametersPattern1D
    {
        public SimpleMatrix SM { get; set; }
        public IterationParameters1D[] iterationParameters1D;
    }

    public class SimpleMatrix
    {
        public int rows;
        public int cols;
    }

    public class MatrixMovementPattern
    {
        private IterationParametersPattern1D _ipp;
        public IIteractionPattern iteractionPattern;

        public string Traversal(int[] matrix, int rows, int columns)
        {
            SimpleMatrix simpleMatrix = new SimpleMatrix() { rows = rows, cols = columns };

            iteractionPattern.InitIteractionPattern(simpleMatrix);
            _ipp = iteractionPattern.ipp;

            //Stop Condition
            int mi = 0;
            string matrixClockwise = "";

            while (simpleMatrix.rows > 0 && simpleMatrix.cols > 0)
            {
                var value = matrix[mi];

                for (int p = 0; p < _ipp.iterationParameters1D.Length; p++)
                {
                    if (simpleMatrix.cols <= 0 || simpleMatrix.rows <= 0)
                    {
                        break;
                    }

                    for (int pi = _ipp.iterationParameters1D[p].B; pi < _ipp.iterationParameters1D[p].E - 1; pi++)
                    {
                        if (mi < 0 || mi > matrix.Length - 1 || simpleMatrix.cols <= 0 || simpleMatrix.rows <= 0)
                        {
                            break;
                        }

                        mi += _ipp.iterationParameters1D[p].D;
                        value = matrix[mi];
                        matrixClockwise += value.ToString() + " : ";

                        //Check range
                        if (_ipp.iterationParameters1D[p].Row)
                        {
                            if (pi > simpleMatrix.cols - 2)
                                break;
                            else if (pi > simpleMatrix.cols - 3)
                                _ipp.SM.rows--;
                        }
                        else if (_ipp.iterationParameters1D[p].Col)
                        {
                            if (pi > simpleMatrix.rows - 2)
                                break;
                            else if (pi > simpleMatrix.rows - 3)
                                _ipp.SM.cols--;

                        }
                    }
                }
            }

            return matrixClockwise;
        }
    }
}
