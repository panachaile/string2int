﻿using System;
using System.Text;
using System.Text.RegularExpressions;

namespace string2intExam
{
	class Program
	{
		static void Main()
		{
			// function string2intWithoutParsing
			// จากโจทย์คือ You must not use any parsing, casting or converting function, either it is built-in or come from the library you use
			// วิธีที่ใช้คือ 
			// 1. รับ string มา 1 ชุด
			// 2. split string ให้ออกมาเป็น char array
			// 3. วนลูป char array เพื่อหาค่า int ที่จะต้องแสดงออกมา
			//	3.1 เช็คว่า char ที่วนมาเป็น digit หรือไม่ ถ้าไม่ก็ข้ามไปวนตัวต่อไป
			//	3.2 นำ char ที่เป็น digit มาลบกับตัว ascii code เพื่อได้ผลลัพธ์ของ digit
			//	3.3 กำหนดค่า result_int ให้เท่ากับ result_int * 10 (เพื่อเพิ่มจำนวนหลัก) + result_minus_ascii (ตัวเลขที่เป็นผลลัพธ์)
			// 4. return int กลับไปยัง Main
			// 5. Console.WriteLine ผลลัพธ์ที่ได้ออกมาแสดง
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
						result_int = (result_int * 10) + result_minus_ascii;
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
