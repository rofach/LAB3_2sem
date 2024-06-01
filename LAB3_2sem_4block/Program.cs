using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;

namespace lab
{
	class Programm
	{
		static void PrintListOfLists(List<List<int>> listOfLists)
		{
			foreach (var list in listOfLists) 
			{ 
				foreach (var num in list)
					Console.Write(num + " ");	
				Console.WriteLine();
			}
		}
		static void FillMatrixListManual(List<List<int>> list, int rows, int cols)
		{
			for (int i = 0; i < rows; i++)
			{
				string[] tmp = Console.ReadLine().Trim().Split();
				var tmpList = new List<int>();
				for (int j = 0; j < cols; j++)
					tmpList.Add(int.Parse(tmp[j]));
				list.Add(tmpList);
			}
		}
		static void FillMatrixListRandomly(List<List<int>> list, int rows, int cols)
		{
			Random rand = new Random();
			for (int i = 0; i < rows; i++)
			{
				List<int> tmp = new List<int>();			
				for (int j = 0; j < cols; j++)
					tmp.Add(rand.Next(0, 10));
				list.Add(tmp);
			}
		}	

		static void FillListOfListsRandomly(List<List<int>> q, List<int> z)
		{
			for (int i = 0; i < z.Count; i++)
			{
				Random rand = new Random();
				List<int> tmp = new List<int>();
				for (int j = 0; j < z[i]; j++)
					tmp.Add(rand.Next(0, 10));
				q.Add(tmp);
			}
		}
		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			Console.WriteLine("Розміри матриці: ");
			int[] size = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);	
			var p = new List<List<int>>();
			var z = new List<int>();
			int rows = size[0];
			int cols = size[1];
			Console.WriteLine("0 - вручну, інші - рандомно");
			int choice = int.Parse(Console.ReadLine());
			if (choice == 0) FillMatrixListManual(p, rows, cols);
			else FillMatrixListRandomly(p, rows, cols);
			
			Console.WriteLine("Введена матриця: ");
			PrintListOfLists(p);
		    
			foreach (var list in p)
			{
				int zeroIdx = list.LastIndexOf(0);
				if (zeroIdx == -1) z.Add(list.Count);
				else z.Add(zeroIdx + 1);
			}
			Console.WriteLine("\nМасив Z: ");
			foreach(var item in z) Console.Write(item + " ");
			
			Console.WriteLine("\nМасив Q: ");
			var q = new List<List<int>>();
			
			FillListOfListsRandomly(q, z);

			foreach (var list in q)
				list.Sort((a,b)  => b.CompareTo(a));
			
			PrintListOfLists(q);
		}
	
	}
}