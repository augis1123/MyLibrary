using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Objects;

namespace MyLibrary.MathLibrary
{
    public class Matrices
    {
        public static double[,] GenerateRandomMatrix(int rows, int cols, int minValue, int maxValue)
        {
            Random random = new Random();
            double[,] matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int randomValue = random.Next(minValue, maxValue + 1);
                    matrix[i, j] = (double)randomValue;
                }
            }

            return matrix;
        }
        public static double[,] Addition(double[,] A, double[,] B)
        {
            if (A == null)
            {
                throw new ArgumentNullException(nameof(A));
            }
            if (B == null) 
            { 
                throw new ArgumentNullException(nameof(B)); 
            }
            if (A.GetLength(0) != B.GetLength(0))
            {
                throw new Exception("A and B is not the same");
            }
            if (A.GetLength(1) != B.GetLength(1))
            {
                throw new Exception("A and B is not the same");
            }

            double[,] C = new double[A.GetLength(0),A.GetLength(1)];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    C[i,j] = A[i,j] + B[i,j];
                }
            }
            return C;
        }

        public static double[,] Subbtraction(double[,] A, double[,] B)
        {
            if (A == null)
            {
                throw new ArgumentNullException(nameof(A));
            }
            if (B == null)
            {
                throw new ArgumentNullException(nameof(B));
            }
            if (A.GetLength(0) != B.GetLength(0))
            {
                throw new Exception("A and B is not the same");
            }
            if (A.GetLength(1) != B.GetLength(1))
            {
                throw new Exception("A and B is not the same");
            }

            double[,] C = new double[A.GetLength(0), A.GetLength(1)];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    C[i, j] = A[i, j] - B[i, j];
                }
            }
            return C;
        }

        public static double[,] Multiplication(double[,] A, double[,] B)
        {
            if (A == null)
            {
                throw new ArgumentNullException(nameof(A));
            }
            if (B == null)
            {
                throw new ArgumentNullException(nameof(B));
            }
            if (A.GetLength(1) != B.GetLength(0))
            {
                throw new Exception("Collum and row count do not match");
            }

            double[,] C = new double[A.GetLength(0), B.GetLength(1)];

            for (int i = 0; i < C.GetLength(0); i++)
            {
                for (int j = 0; j < C.GetLength(1); j++)
                {
                    double sum = 0;
                    for (int k = 0; k < A.GetLength(0); k++)
                    {
                        sum = sum + A[i, k] * B[k,j];
                    }
                    C[i, j] = sum;
                }
            }
            return C;
        }

        public static double[,] Multiplication(double[,] A, double B)
        {
            if (A == null)
            {
                throw new ArgumentNullException(nameof(A));
            }
            if (B == null)
            {
                throw new ArgumentNullException(nameof(B));
            }

            double[,] C = new double[A.GetLength(0), A.GetLength(1)];

            for (int i = 0; i < C.GetLength(0); i++)
            {
                for (int j = 0; j < C.GetLength(1); j++)
                {
                    C[i,j] = A[i,j]*B;
                }
            }
            return C;
        }

        public static double[,] Transpose(double[,] A)
        {
            if (A == null)
            {
                throw new ArgumentNullException(nameof(A));
            }

            double[,] C = new double[A.GetLength(1), A.GetLength(0)];

            for (int i = 0; i < C.GetLength(0); i++)
            {
                for (int j = 0; j < C.GetLength(1); j++)
                {
                    C[j, i] = A[i, j];
                }
            }
            return C;
        }

        public static double[,] Inverse(double[,] A)
        {
            if (A == null)
            {
                throw new ArgumentNullException(nameof(A));
            }
            if (A.GetLength(0) != A.GetLength(1))
            {
                throw new Exception("Math error");
            }

            double[,] C = new double[A.GetLength(0), A.GetLength(1) * 2];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    C[i, j] = A[i, j];
                }
            }

            for (int i = 0; i < C.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        C[i, j + A.GetLength(1)] = 1;
                    }
                    else
                    {
                        C[i, j + A.GetLength(1)] = 0;
                    }
                }
            }

            for (int i = 0; i < C.GetLength(0); i++)
            {
                if (C[i, i] == 0)
                {
                    throw new Exception("Math error");
                }
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (i != j)
                    {
                        double Ratio = C[j, i] / C[i, i];

                        for (int k = 0; k < C.GetLength(1); k++)
                        {
                            C[j, k] = C[j, k] - Ratio * C[i, k];
                        }
                    }
                }
            }

            double[,] D = new double[A.GetLength(0), A.GetLength(1)];
            for (int i = 0; i < D.GetLength(0); i++)
            {
                for (int j = 0; j < D.GetLength(1); j++)
                {
                    D[i, j] = C[i, j + D.GetLength(1)];
                }
            }
            return C;
        }
        public static double DeterminantLaplace(double[,] A)
        {
            if (A == null)
            {
                throw new ArgumentNullException(nameof(A));
            }
            if (A.GetLength(0) != A.GetLength(1))
            {
                throw new Exception("Math error");
            }
            double determinant = 0;
            determinant = DeterminantLaplaceRecursive(1, A);
            return determinant;
        }
        private static double DeterminantLaplaceRecursive(double coefficient, double[,] A)
        {
            MatrixForLaplaceExpansion matrix = new MatrixForLaplaceExpansion(A);
            if (A.GetLength(0) == 2 && A.GetLength(1) == 2)
            {
                Console.WriteLine("Koef: {0}",coefficient);
                Console.WriteLine(matrix.CalculateDeterminant2x2());
                Console.WriteLine(matrix);
                Console.WriteLine("-----------------------------");
                return matrix.CalculateDeterminant2x2();
            }
            double determinant = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                double[,] matrix1 = matrix.MakeMatrixSmaller(i,0);
                MatrixForLaplaceExpansion matrix11 = new MatrixForLaplaceExpansion(matrix1);
                Console.WriteLine("Minusas {0}", Math.Pow(-1,i));
                determinant += (Math.Pow(-1, i)) *(A[i, 0] * DeterminantLaplaceRecursive(A[i, 0], matrix1));
            }
            return determinant;
        }
    }
}
