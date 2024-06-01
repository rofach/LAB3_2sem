using System;

namespace lab
{
	class Programm
	{
		
		static int GetLastMaxIndex(int[] arr)
		{
			int maxIndex = 0;
			for (int i = 1; i < arr.Length; i++)
			{
				if (arr[i] >= arr[maxIndex]) maxIndex = i;
			}
			return maxIndex;
		}
		static int GetFirstMinIndex(int[] arr)
		{
			int minIndex = 0;
			for(int i = 1; i < arr.Length; i++)
			{
				if (arr[i] < arr[minIndex]) minIndex = i;
			}
			return minIndex;
		}
		static void DeleteElements(ref int[] arr)
		{
			int begin = GetFirstMinIndex(arr);
			int end = GetLastMaxIndex(arr);
			if(begin > end) (begin, end) = (end, begin);
			int newLength = begin + 1 + arr.Length - end;
			for (int i = begin + 1; end < arr.Length; i++, end++)
			{
				arr[i] = arr[end];
			}
			
			Array.Resize(ref arr, newLength);
		}
		static void PrintArray(int[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
				Console.Write(arr[i] + " ");
		}
		static void Main(string[] args)
		{
			// var 10
			// 1 2 3 4 5 6 7 8 9
			// 1 1 2 3 4 5 6 7 7
			// 9 8 7 6 5 4 3 2 1
			// 9 9 8 7 6 5 4 1 1
			// 1 2 3 9 8 7 6 5 4
			// 4 3 2 9 8 7 1 5 4
			// 1 2 4 3 1 8 9 8 9 2 3 1
			// 2 3 4 5 1 9 5 7 4 1
			string[] input = Console.ReadLine().Trim().Split();
			int[] arr = new int[input.Length];
			for(int i = 0; i < input.Length; i++)
				arr[i] = int.Parse(input[i]);
			PrintArray(arr);
			DeleteElements(ref arr);
			Console.WriteLine();
			PrintArray(arr);
		}
	}
}
