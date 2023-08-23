using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Objects
{

    public class MatrixForLaplaceExpansion
    {
        private double[,] matrix { get; set; }

        public MatrixForLaplaceExpansion(double[,] matrix)
        {
            this.matrix = matrix;
        }
        public double CalculateDeterminant2x2()
        {
            double result = (this.matrix[0, 0] * this.matrix[1,1] - this.matrix[0, 1] * this.matrix[1,0]);
            return result;
        }
        public double[,] MakeMatrixSmaller(int x, int y)
        {
            double[,] Matrix = new double[this.matrix.GetLength(0) - 1, this.matrix.GetLength(1) - 1];
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int i2 = 0; i2 < this.matrix.GetLength(1); i2++)
                {
                    if (i != x && i2 != y)
                    {
                        if (i < x && i2 < y)
                        {
                            Matrix[i, i2] = this.matrix[i, i2];
                        }
                        else if (i > x && i2 < y)
                        {
                            Matrix[i-1, i2] = this.matrix[i, i2];
                        }
                        else if (i > x && i2 > y)
                        {
                            Matrix[i - 1, i2-1] = this.matrix[i, i2];
                        }
                        else if (i < x && i2 > y)
                        {
                            Matrix[i, i2 - 1] = this.matrix[i, i2];
                        }
                    }
                }
            }
            return Matrix;
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result += matrix[i, j] + "\t";
                }
                result += "\n";
            }
            return result;
        }
    }



}
