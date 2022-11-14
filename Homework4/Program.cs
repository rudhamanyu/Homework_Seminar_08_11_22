/*Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, 
добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/

int GetNumber(string message)
{
    Console.Write(message);
    int number = int.Parse(Console.ReadLine() ?? "");
    return number;
}

int[] GetUniqueNumbers(int lenght)
{
    int[] array = new int[lenght];
    Random rnd = new Random();
    int num = 0;
    for (int i = 0; i < array.Length; i++)
    {
        num = rnd.Next(10, 100);
        if(!array.Contains(num))
            array[i] = num;
        else{
            i--;
            continue;
        }        
    }
    Console.WriteLine();
    return array;
}


int[,,] InitMatrix(int page, int row, int column, int[] array)
{
    int[,,] matrix = new int[page, row, column];
    int count = 0;
    for (int i = 0; i < page; i++)
    {
        for (int j = 0; j < row; j++)
        {
            for (int k = 0; k < column; k++){
                matrix[i, j, k] = array[count];
                count++;
            }
        }
    }
    return matrix;
}

void PrintMatrix(int[,,] matrix)
{
    for (int k = 0; k < matrix.GetLength(2); k++)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j, k]}({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
    }
    Console.WriteLine();
}

int page = GetNumber("Введите колличество страниц в матрице: ");
int row = GetNumber("Введите колличество строк в матрице: ");
int col = GetNumber("Введите колличество столбцов в матрице: ");
int lenght = page*row*col;
int[] array = GetUniqueNumbers(lenght);
int[,,] matrix = InitMatrix(page, row, col, array);
PrintMatrix(matrix);