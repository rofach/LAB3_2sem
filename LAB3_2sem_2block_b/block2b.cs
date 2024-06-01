using System;
using System.Diagnostics;

namespace lab
{
	class Programm
	{
		static int GetSumOfDigits(int num)
		{
			int sum = 0;
			while (num > 0)
			{
				sum += num % 10;
				num /= 10;
			}
			return sum;
		}

		static int CountOfMultiplies(int n, int i)
		{
			return n / i;
		}


		static void PrintArray(int[][] arr)
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
		static int GetMaxSum(int n)
		{
			int count = 0;
			int tmp = n;
			while (tmp > 9)
			{
				tmp /= 10;
				count++;
			}
			int sum1 = GetSumOfDigits(n);
			int sum2 = GetSumOfDigits((int)(tmp * Math.Pow(10, count)) - 1);
			if (sum1 < sum2)
				return sum2;
			else return sum1;
		}
		static void FillIndexSumJagArray(int[][] indexSumJagArr, int n) {
			int l = indexSumJagArr.Length - 1;
			for (int i = 1; i <= l; i++)
			{
				indexSumJagArr[i] = new int[CountOfMultiplies(n, i)];
				for (int j = 1, idx = 0; j <= n; j++)
					if (j % i == 0)
						indexSumJagArr[i][idx++] = j;
			}
		}
		static void Main(string[] args)
		{
			var currentProcess = Process.GetCurrentProcess();
			Console.WriteLine("Введіть n");
			int n = int.Parse(Console.ReadLine());
			int l = GetMaxSum(n);
			int[][] indexSumJagArr = new int[l + 1][];
			int[][] jagArr = new int[n][];
			FillIndexSumJagArray(indexSumJagArr, n);
			for (int i = 0; i < n; i++)
			{
				int digitsSum = GetSumOfDigits(i);
				jagArr[i] = indexSumJagArr[digitsSum];
			}
			Console.WriteLine("Використана пам'ять: {0} MB", currentProcess.PrivateMemorySize64 / 1024 / 1024);
			if(jagArr.Length < 120) PrintArray(jagArr);
		}
	}
}