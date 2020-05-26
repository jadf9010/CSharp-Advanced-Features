using System;
namespace SimpleMatrixPatterns
{
    public interface IIteractionPattern
    {
        public SimpleMatrix                 sm              { get; set; }
        public IterationParametersPattern1D ipp             { get; set; }

        public void InitIteractionPattern(SimpleMatrix simpleMatriz);
    }

    public struct ClockwiseIterationPattern : IIteractionPattern
    {
        public void InitIteractionPattern(SimpleMatrix simpleMatriz)
        {
            sm = simpleMatriz;

            Console.WriteLine("Matrix Clockwise! \n");

            ipp = new IterationParametersPattern1D()
            {
                SM = sm, //stored by reference

                iterationParameters1D = new IterationParameters1D[]
                {
                    // Left to Right. Iterate through Cols
                    new IterationParameters1D {     B = 0,  E = sm.cols,    D = 1,          Row = true    },

                    // Top to Down. Iterate through Rows 
                    new IterationParameters1D {     B = 0,  E = sm.rows,    D = sm.cols,    Col = true    },

                    // Right to Left. Iterate through Cols 
                    new IterationParameters1D {     B = 0,  E = sm.cols,    D = -1,         Row = true    },

                    // Bottom to Up. Iterate through Rows 
                    new IterationParameters1D {     B = 0,  E = sm.rows,    D = -sm.cols,   Col = true    }
                }
            };
        }

        public IterationParametersPattern1D ipp { get; set; }
        public SimpleMatrix sm { get; set; }
    }

    public struct CounterClockwiseIterationPattern : IIteractionPattern
    {
        public void InitIteractionPattern(SimpleMatrix simpleMatriz)
        {
            sm = simpleMatriz;

            Console.WriteLine("Matrix CounterClockwise! \n");

            //Create Clockwise Pattern
            ipp = new IterationParametersPattern1D()
            {
                SM = sm, //stored by reference

                iterationParameters1D = new IterationParameters1D[]
                {
                    // Left to Right. Iterate through Cols
                    new IterationParameters1D {     B = 0,  E = sm.rows,    D = sm.cols,    Col = true    },

                    // Top to Down. Iterate through Rows 
                    new IterationParameters1D {     B = 0,  E = sm.cols,    D = 1,          Row = true    },

                    // Right to Left. Iterate through Cols 
                    new IterationParameters1D {     B = 0,  E = sm.rows,    D = -sm.cols,   Col = true    },

                    // Bottom to Up. Iterate through Rows 
                    new IterationParameters1D {     B = 0,  E = sm.cols,    D = -1,         Row = true    }
                }
            };
        }

        public IterationParametersPattern1D ipp { get; set; }
        public SimpleMatrix sm { get; set; }
    }
}
