/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18*/

int GetNumber(string message)
{
    Console.Write(message);
    int number = int.Parse(Console.ReadLine() ?? "");
    return number;
}

int[,] InitMatrix(int row, int column, int minRnd, int maxRnd)
{
    int[,] resultMatrix = new int[row, column];
    Random rnd = new Random();
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
            resultMatrix[i, j] = rnd.Next(minRnd, maxRnd);
    }
    return resultMatrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] MatrixProduct(int[,] matrix1, int[,] matrix2)
{
    int[,] resultMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    int product = 0;
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)
        {
            product = 0;
            for (int k = 0; k < matrix1.GetLength(1); k++)
                product += matrix1[i, k] * matrix2[k, j];
            resultMatrix[i, j] = product;
        }
    }
    return resultMatrix;
}


int row1 = GetNumber("Введите колличество строк в 1 матрице: ");
int col1 = GetNumber("Введите колличество столбцов в 1 матрице: ");
int min1 = GetNumber("Введите минимально возможное значение элементов 1 матрицы: ");
int max1 = GetNumber("Введите максимально возможное значение элементов 1 матрицы: ");
int[,] matrix1 = InitMatrix(row1, col1, min1, max1);

int row2 = GetNumber("Введите колличество строк во 2 матрице: ");
int col2 = GetNumber("Введите колличество столбцов во 2 матрице: ");
int min2 = GetNumber("Введите минимально возможное значение элементов 2 матрицы: ");
int max2 = GetNumber("Введите максимально возможное значение элементов 2 матрицы: ");
int[,] matrix2 = InitMatrix(row2, col2, min2, max2);
PrintMatrix(matrix1);
PrintMatrix(matrix2);
if (col1 == row2)
{
    int[,] resultMatrix = MatrixProduct(matrix1, matrix2);
    Console.WriteLine("Результирующая матрица:");
    PrintMatrix(resultMatrix);
}
else
    Console.WriteLine("Матрицы несоместимы и не могут быть перемножены");
