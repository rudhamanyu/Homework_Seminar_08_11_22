/*Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07*/

int GetNumber(string message)
{
    Console.Write(message);
    int number = int.Parse(Console.ReadLine() ?? "");
    return number;
}
int[,] GetSpiralMatrix(int row, int column)
{
    int[,] resultMatrix = new int[row, column];
    int number = 1;
    int maxNums = row * column;
    int count = 0;
    int countRow = row - 1;
    int countCol = column - 1;
    while (number < maxNums)
    {
        for (int j = count; j < countCol; j++){
            resultMatrix[count, j] = number;
            number++;
        }        
        for (int i = count; i < countRow; i++){
            resultMatrix[i, countCol] = number;
            number++;
        }        
        for (int j = countCol; j > count; j--){
            resultMatrix[countRow, j] = number;
            number++;
        }
        for (int i = countRow; i > count; i--){
            resultMatrix[i, count] += number;
            number++;
        }
        countRow--;
        countCol--;
        count++;
    }
    return resultMatrix;
}
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] < 10)
                Console.Write($"0{matrix[i, j]} ");
            else
                Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}
int row = GetNumber("Введите четное колличество строк и столбцов в матрице: ");
int col = row;
int[,] matrix = GetSpiralMatrix(row, col);
PrintMatrix(matrix);