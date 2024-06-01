using System;

namespace lab
{
	class Programm
	{
		static void FillArrayRandomly(int[][] arr)
		{
			int n = arr.Length;
			Random rand = new Random();
			for(int i = 0; i < n; i++)
			{
				int length = rand.Next(1, 100);
				arr[i] = new int[length];
				for (int j = 0; j < length; j++)
					arr[i][j] = rand.Next(0, 20);
			}
		}
		static int GetIndexOfRowWithMaxElement(int[][] arr)
		{
			int maxRowIndex = 0;
			for(int i = 1; i < arr.Length; i++)
			{
				if (arr[i].Max() > arr[maxRowIndex].Max()) maxRowIndex = i;
			}
			return maxRowIndex;
		}
		static void PrintJaggedArray(int[][] arr)
		{
			int n = arr.Length;
			for (int i = 0; i < n; i++)
			{
				Console.Write($"{i} : ");
				for (int j = 0; j < arr[i].Length; j++)
				{
					Console.Write(arr[i][j] + " ");
				}
				Console.WriteLine();
			}
		}

		static void DeleteRowWithMax(ref int[][] jagArr)
		{
			int index = GetIndexOfRowWithMaxElement(jagArr);
			for (int i = index; i < jagArr.Length - 1; i++)
			{
				jagArr[i] = jagArr[i + 1];
			}
			Array.Resize(ref jagArr, jagArr.Length - 1);
			Console.WriteLine("Видалено рядок: {0}", index);
		}
		static void Main(string[] args)
		{
			Console.WriteLine("Кількість рядків: ");
			int n = int.Parse(Console.ReadLine());
			int[][] jagArr = new int[n][];
			Console.WriteLine("0 - вручну, інші - рандомно");
			int choice = int.Parse(Console.ReadLine());
			if (choice == 0)
				for (int i = 0; i < n; i++)
				{
					Console.WriteLine("Вводьте елементи {0}-го рядка", i);
					jagArr[i] = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
				}
			else FillArrayRandomly(jagArr);
			Console.WriteLine("Масив перед видаленням");
			PrintJaggedArray(jagArr);
			DeleteRowWithMax(ref jagArr);

			Console.WriteLine("Після видалення:");
			PrintJaggedArray(jagArr);
			
		}
	}
}