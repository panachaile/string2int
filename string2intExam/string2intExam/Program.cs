using System;
using System.Text;
using System.Text.RegularExpressions;

namespace string2intExam
{
	class Program
	{
		static void Main()
		{
			Console.Write("Input your text here :");
			string input_text = Console.ReadLine();
			if (!string.IsNullOrWhiteSpace(input_text))
			{
				int result = string2intWithoutParsing(input_text);
				Console.WriteLine(result);
			}
			else
			{
				Console.WriteLine("input string is empty");
			}
		}

		public static int string2intWithoutParsing(string input_string)
		{
			int result_int = 0;
			// not sure (int) is meaning auto cast or not?
			//int zero_ascii = (int)'0';
			int zero_ascii = '\u0030';
			char[] input = input_string.ToCharArray();
			foreach (char each_char in input)
			{
				// not sure Char.IsDigit is meaning parsing or not?
				if (Char.IsDigit(each_char))
				{
					int parse_char_to_ascii = each_char;
					int result_minus_ascii = parse_char_to_ascii - zero_ascii;
					if (result_minus_ascii >= 0 && result_minus_ascii <= 9)
					{
						result_int = (result_int * 10) + (parse_char_to_ascii - zero_ascii);
					}
				}

			}
			return result_int;
		}

		public static string string2int(string input_string)
		{
			char[] input = input_string.ToCharArray();
			var result = "";
			foreach (char each_char in input)
			{
				if (Char.IsDigit(each_char))
				{
					result += each_char;
				}
			}
			return result;
		}

		public static string string2intRegexMethod(string input_string)
		{
			return Regex.Replace(input_string, "[^0-9.]", "");
		}
	}
}
