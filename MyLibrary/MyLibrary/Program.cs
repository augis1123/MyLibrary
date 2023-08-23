// See https://aka.ms/new-console-template for more information
using MyLibrary.MathLibrary;
using MyLibrary.Objects;

//Console.WriteLine("Hello, World!");

////double[,] matrix = new double[,] { { 5, 5, 5 }, { 12, 10, 9 }, { 55, 20, 11 } };
//double[,] matrix = new double[,] { { 1, -2}, { 3, 4} };
//double [,] matrix2 = Matrices.Inverse(matrix);

//for (int i = 0; i < matrix.GetLength(0); i++)
//{
//    for (int j = 0; j < matrix.GetLength(1); j++)
//    {
//        Console.Write("{0}  ",matrix[i,j]);
//    }
//    Console.WriteLine();
//}
//Console.WriteLine();
//for (int i = 0; i < matrix.GetLength(0); i++)
//{
//    for (int j = 0; j < matrix.GetLength(1); j++)
//    {
//        Console.Write("{0}  ", matrix2[i, j]);
//    }
//    Console.WriteLine();
//}
//Console.WriteLine(matrix.ToString());
//Console.WriteLine(matrix2.ToString());

Console.WriteLine(2%2);
//double[,] matrix = new double[,] { { 3, 7 }, { 1, -4} };
//double[,] matrix = new double[,] { { 5, 9, 11 }, { 12, 10, 9 }, { 55, 20, 19 } };
double[,] matrix = Matrices.GenerateRandomMatrix(5, 5,1,10);
Console.WriteLine("determinant");
Console.WriteLine("Determinant {0}",Matrices.DeterminantLaplace(matrix));
Console.WriteLine("--------------------------------");
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write("{0}  ", matrix[i, j]);
    }
    Console.WriteLine();
}
Console.WriteLine("--------------------");
MatrixForLaplaceExpansion mmm = new MatrixForLaplaceExpansion(matrix);
double[,] matrix1 = mmm.MakeMatrixSmaller(1, 1);
for (int i = 0; i < matrix1.GetLength(0); i++)
{
    for (int j = 0; j < matrix1.GetLength(1); j++)
    {
        Console.Write("{0}  ", matrix1[i, j]);
    }
    Console.WriteLine();
}
//Console.WriteLine(mmm.CalculateDeterminant());
