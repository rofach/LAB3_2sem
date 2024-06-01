using System;

namespace lab
{
	class Programm
	{
		static void PrintList(List<int> list)
		{
			foreach(int i in list)
				Console.Write(i + " ");
		}
		static void FillList(List<int> list)
		{
			Console.WriteLine("Введіть елементи рядка: ");
			string[] input = Console.ReadLine().Trim().Split();
			for(int i = 0; i < input.Length; i++)
			{
				list.Add(int.Parse(input[i]));
			}
		}
		static void Main(string[] args)
		{
			// 1 2 3 4 5 6 7 8 9
			// 1 1 2 3 4 5 6 7 7
			// 9 8 7 6 5 4 3 2 1
			// 9 9 8 7 6 5 4 1 1
			// 1 2 3 9 8 7 6 5 4
			// 4 3 2 9 8 7 1 5 4
			// 1 2 4 3 1 8 9 8 9 2 3 1
			// 2 3 4 5 1 9 5 7 4 1
			var list = new List<int>();
			FillList(list);
			int start = list.IndexOf(list.Min());
			int end = list.LastIndexOf(list.Max());
			if (start > end) (start, end) = (end, start);
			Console.WriteLine("Масив перед видаленням");
			PrintList(list);
			list.RemoveRange(start + 1, end - start - 1);
			Console.WriteLine("Масив Після видалення");
			PrintList(list);

		}
	}
}
