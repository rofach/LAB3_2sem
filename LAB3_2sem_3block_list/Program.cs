using System;
using System.Collections.Generic;

namespace lab
{
	class Programm
	{
		static int GetIndexOfRowWithMaxElement(List<List<int>> lists)
		{
			int maxRowIndex = 0;
			int max = lists[0].Max();
			int count = 0;
			foreach (var list in lists)
			{
				int tmp = list.Max();
				if (tmp > max) { maxRowIndex = count; max = tmp; }
				count++;
			}0.i
			return maxRowIndex;
		}
		static void PrintList(List<List<int>> lists)
		{
			int n = lists.Count;
			int count = 0;
			foreach (var list in lists)
			{
				Console.Write($"{count++} : ");
				foreach(var item in list)
				{
					Console.Write(item + " ");
				}
				Console.WriteLine();
			}
		}
		static void FillListManual(List<List<int>> list, int rows)
		{
			for (int i = 0; i < rows; i++)
			{
				string[] tmp = Console.ReadLine().Trim().Split();
				var tmpList = new List<int>();
				for (int j = 0; j < tmp.Length; j++)
					tmpList.Add(int.Parse(tmp[j]));
				list.Add(tmpList);
			}
		}
		static void FillListRandomly(List<List<int>> list, int rows)
		{
			
			Random rand = new Random();
			for (int i = 0; i < rows; i++)
			{
				int length = rand.Next(1, 10);
				List<int> tmp = new List<int>();
				for (int j = 0; j < length; j++)
					tmp.Add(rand.Next(0, 10));
				list.Add(tmp);
			}
		}
		static void Main(string[] args)
		{
			Console.WriteLine("Кількість рядків: ");
			int n = int.Parse(Console.ReadLine());
			var lists = new List<List<int>>();
			Console.WriteLine("0 - вручну, інші - рандомно");
			int choice = int.Parse(Console.ReadLine());
			if (choice == 0) FillListManual(lists, n);
			else FillListRandomly(lists, n);
			Console.WriteLine("Масив перед видаленням");
			PrintList(lists);
			int index = GetIndexOfRowWithMaxElement(lists);
			lists.Remove(lists[index]);
			Console.WriteLine("Видалено рядок: {0}", index);
			Console.WriteLine("Після видалення:");
			PrintList(lists);
			
		}
	}
}