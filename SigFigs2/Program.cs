using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigFigs2
{
	class Program
	{
		static void Main() {
			ConsoleColor defaultColor = Console.ForegroundColor;
			Console.WriteLine("Significant Figure calculator. (c) 2016 Daniel Shaw.");
			Console.Write("Enter the number to evaluate: ");
			string input = Console.ReadLine();
			double number;
			try
			{
				number = double.Parse(input);
			}
			catch (Exception)
			{
				Console.WriteLine("Invalid number.");
				return;
			}

			int result = CountFigures(number);

			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.Write("There " + ((result > 1) ? "are" : "is") + " ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write(result);
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine(" significant figures.\nGood bye.");
			Console.ForegroundColor = defaultColor;
		}

		static int CountFigures(double input)
		{
			string str = Convert.ToString(input);
			int total = 0, temp = 0;
			for (int i = 0; i < str.Length; i++)
			{
				char c = str.ElementAt(i);
				if (c == '0')
				{
					temp++;
				}
				else if (char.IsNumber(c))
				{
					total += temp + 1;
					temp = 0;
					continue;
				}
				if (i == str.Length - 1 && !str.Contains("."))
				{
					temp = 0;
					break;
				}
			}
			return total + temp;
		}
	}
}
