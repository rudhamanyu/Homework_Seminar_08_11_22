/*Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2*/

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

int[,] SortingRows(int[,] matrix)
{
    int[,] resultMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = j + 1; k <= matrix.GetLength(1); k++)
            {
                if (k < matrix.GetLength(1) && matrix[i, k] > matrix[i, j])
                {
                    (matrix[i, j], matrix[i, k]) = (matrix[i, k], matrix[i, j]);
                    resultMatrix[i, j] = matrix[i, k];
                }
                else
                    resultMatrix[i, j] = matrix[i, j];
            }
        }
    }
    return resultMatrix;
}


int row = GetNumber("Введите колличество строк в матрице: ");
int col = GetNumber("Введите колличество столбцов в матрице: ");
int min = GetNumber("Введите минимально возможное значение элементов матрицы: ");
int max = GetNumber("Введите максимально возможное значение элементов матрицы: ");
int[,] matrix = InitMatrix(row, col, min, max);
PrintMatrix(matrix);
PrintMatrix(SortingRows(matrix));