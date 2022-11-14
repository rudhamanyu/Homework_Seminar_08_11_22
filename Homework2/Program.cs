/*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка*/

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

int FindRowWhithMinSumNums(int[,] matrix)
{
    int resultRow = 0;    
    int minSum = int.MaxValue;
    int sum = 0;   
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        sum  = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
            sum += matrix[i, j];        
        if (minSum > sum){
            minSum = sum;
            resultRow = i + 1;
        }
    }
    return resultRow;
}


int row = GetNumber("Введите колличество строк в матрице: ");
int col = GetNumber("Введите колличество столбцов в матрице: ");
int min = GetNumber("Введите минимально возможное значение элементов матрицы: ");
int max = GetNumber("Введите максимально возможное значение элементов матрицы: ");
int[,] matrix = InitMatrix(row, col, min, max);
PrintMatrix(matrix);
int findRow = FindRowWhithMinSumNums(matrix);
Console.WriteLine($"{findRow} cтрока содержит наименьшую сумму элементов");