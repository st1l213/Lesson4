using System;
using System.IO;

namespace Lesson4
{
    class Arrays
    {
        public override string ToString()
        {
            string printArr = string.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                printArr += arr[i] + " ";
            }

            return printArr + "\n";
        }
        public int[] arr;
        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    sum += arr[i];
                }
                return sum;
            }
        }
        public int CountMaxElements
        {
            get
            {
                int count = 0;
                int max = arr[0];
                for (int i = 0; i < arr.Length; i++)
                {
                    if (max < arr[i])
                    {
                        max = arr[i];
                        count = 1;
                    }
                    else if (max == arr[i])
                    {
                        count++;
                    }
                }
                return count;
            }
        }
        public void Inverse()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] *= -1;
            }
        }
        public void Multiply(int multiplier)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] *= multiplier;
            }
        }

        public Arrays(int size, int step)
        {
            arr = new int[size];
            int tempStep = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = tempStep; // 0
                tempStep += step; // step
            }
        }

        public static void Arr()
        {
            int counter = 0;
            Random random = new Random();
            int[] arr = new int[20];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-10, 10);
                Console.Write(arr[i] + "  ");
            }

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] % 3 == 0 || arr[i + 1] % 3 == 0) // чтобы не выйти за пределы массива , в for условие i < Length - 1;
                    counter++;
            }
            Console.WriteLine($"\nКол-во пар: {counter}");
        }
    }
    struct Account
    {


        public string Login { get; set; }
        public string Password { get; set; }

        public void ReadText(string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {

                    Login = reader.ReadLine();
                    Password = reader.ReadLine();
                }
            }
            else throw new Exception("Файл не найден.");
        }
    }

    class TwoDimensionArray
    {
        int[,] arr;
        public int counter = 0;   
        public int Max
        {
            get
            {
                int max = arr[0, 0];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                        if (max < arr[i, j])
                            max = arr[i, j];
                }
                return max;
            }
        }
        public int Min
        {
            get
            {
                int min = arr[0, 0];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                        if (min > arr[i, j])
                            min = arr[i, j];
                }
                return min;
            }
        }
        public TwoDimensionArray(int sizeX, int sizeY)
        {
            Random random = new Random();
            arr = new int[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                    arr[i, j] = random.Next(0,50);
            }
        }
        public int CountSum()
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    sum += arr[i, j];
            }
            return sum;
        }
        public int CountSum(int assign)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (arr[i, j] >= assign)
                        sum += arr[i, j];
            }
            return sum;
        }
        public void IndexOfMaxElement(out int[] x,out int[] y )
        {
            x = new int[arr.Length];
            y = new int[arr.Length];
            counter = 0;
            
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if(arr[i,j] == Max)
                        {
                            x[counter] = i+1;
                            y[counter] = j+1;
                            counter++;
                        }
                    }
            }
            
                
            
        }

        public override string ToString()
        {
            string printArr = string.Empty;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    printArr += arr[i, j] + "  ";
                printArr += "\n";
            }
            return printArr;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Arrays arrays = new Arrays(10, 1);
            Console.WriteLine($"Элементы массива: {arrays}\n");

            Console.WriteLine($"Cумма всех элеметнов: {arrays.Sum}\n");
            Console.WriteLine($"Кол-во макс элементов: {arrays.CountMaxElements}\n");

            arrays.Multiply(2);
            Console.WriteLine($"Элементы массива умноженные на 2 : {arrays}\n");

            arrays.Inverse();
            Console.WriteLine(arrays);

            Arrays.Arr(); // первое задание

            Account account = new Account() ;
            account.ReadText(@"C:\Users\nikita\source\repos\Lesson4\TextFile1.txt");
            Console.WriteLine("\nLogin:  " + account.Login);
            Console.WriteLine("\nPassword:  " + account.Password);
            TwoDimensionArray twoDimensionArray = new TwoDimensionArray(10, 10);
            Console.WriteLine("\n" + twoDimensionArray);

            
            int[] x;
            int[] y;
            twoDimensionArray.IndexOfMaxElement(out x,out y);
            Console.WriteLine("\n Индексы максимальных элемментов:");
            for(int i = 0; i < twoDimensionArray.counter; i++)
            {
                Console.WriteLine($"[{x[i]},{y[i]}]  ");
            }
            Console.WriteLine();
        }
    }
}
