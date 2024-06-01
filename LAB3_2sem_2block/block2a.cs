using System;
using System.Diagnostics;

namespace lab
{
	class Programm
	{
		static int GetSumOfDigits(int num)
		{
			int sum = 0;
			while(num > 0)
			{
				sum += (int)(num % 10);
				num /= 10;
			}
			return sum;
		}
		
		static int CountOfMultiplies(int n, int i)
		{
			int sumOfDigits = GetSumOfDigits(i);
			return n / sumOfDigits;
		}
		

		static void PrintJagedArray(int[][] arr)
		{
			int n = arr.Length;
			for (int i = 0; i < n; i++)
			{
				Console.Write($"#{i}: ");
				if (arr[i] == null)
				{
					i++;
					Console.Write($"\n#{i}: ");
				}
				for (int j = 0; j < arr[i].Length; j++)
				{
					Console.Write(arr[i][j] + " ");
				}
				Console.WriteLine();
			}
		}	

		static void FillJaggedArray(int[][] jagArr)
		{
			int n = jagArr.Length;
			for (int i = 1; i < n; i++)
			{
				jagArr[i] = new int[CountOfMultiplies(n, i)];
				int sumOfDigits = GetSumOfDigits(i);
				for (int j = sumOfDigits, idx = 0; j <= n; j += sumOfDigits)
					jagArr[i][idx++] = j;
			}
		}
		static void Main(string[] args)
		{
			var currentProcess = Process.GetCurrentProcess();
			Console.WriteLine("Введіть n");
			int n = int.Parse(Console.ReadLine());
			int[][] jagArr = new int[n][];			
			FillJaggedArray(jagArr);
			Console.WriteLine("Використана пам'ять: {0} MB", currentProcess.PrivateMemorySize64 / 1024 / 1024);
			if (jagArr.Length < 120) 
				PrintJagedArray(jagArr);
		}
	}
}