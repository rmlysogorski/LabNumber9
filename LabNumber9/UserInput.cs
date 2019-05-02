using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LabNumber9
{
    class UserInput
    {
        public static void PrintInColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        public static int GetValidStudentID(int dictLength, string message, string error)
        {
            try
            {
                Console.Write(message);
                if (!int.TryParse(Console.ReadLine(), out int number))
                {
                    throw new FormatException();
                }
                else if (number < 1 || number > dictLength)
                {
                    throw new Exception();
                }
                else
                {
                    return number;
                }
            }
            catch (Exception)
            {
                PrintInColor(error + "\n", ConsoleColor.Red);
                return GetValidStudentID(dictLength, message, error);
            }
            
        }

        public static string GetStudentData(string message = "Please enter a string: ", string error = "Error - oops, it looks like you forgot to enter something!\n")
        {
            Console.Write(message);
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                PrintInColor(error, ConsoleColor.Red);
                return GetStudentData(message, error);
            }
            else if (input.ToLower() == "hometown")
            {
                return input;
            }
            else if (input.ToLower() == "favorite food")
            {
                return input;
            }
            else if(input.ToLower() == "favorite color")
            {
                return input;
            }
            else if (input.ToLower() == "favorite number")
            {
                return input;
            }
            else
            {
                PrintInColor("That data does not exist.\n", ConsoleColor.Red);
                return GetStudentData(message, error);
            }
        }

        public static string GetStudentInfo(string userInput, StudentInfo student)
        {
            switch (userInput)
            {
                case "name": return student.name;

                case "hometown": return student.hometown;

                case "favorite food": return student.favFood;

                case "favorite color": return student.favColor;

                case "favorite number": return student.favNum;

                default: return "";

            }
        }

        public static string GetStudentName(string message = "Please enter a string: ", string error = "Error - oops, it looks like you forgot to enter something!\n")
        {
            Console.Write(message);
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                PrintInColor(error, ConsoleColor.Red);
                return GetStudentName(message, error);
            }
            else if (Regex.IsMatch(input,"([0-9])"))
            {
                PrintInColor("Names should contain only letters.\n", ConsoleColor.Red);
                return GetStudentName(message, error);
            }
            else
            {
                return input;
            }
        }

        public static string GetString(string message = "Please enter a string: ", string error = "Error - oops, it looks like you forgot to enter something!\n")
        {
            Console.Write(message);
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                PrintInColor(error, ConsoleColor.Red);
                return GetString(message, error);
            }
            else
            {
                return input;
            }
        }

        public static string GetAddLearnDelete(string message = "Please enter a string: ", string error = "Error - oops, it looks like you forgot to enter something!\n")
        {
            Console.Write(message);
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                PrintInColor(error + "\n", ConsoleColor.Red);
                return GetAddLearnDelete(message, error);
            }
            else if (input.ToLower() == "add")
            {
                return input;
            }
            else if (input.ToLower() == "learn")
            {
                return input;
            }
            else if (input.ToLower() == "delete")
            {
                return input;
            }
            else
            {
                PrintInColor(error + "\n", ConsoleColor.Red);
                return GetAddLearnDelete(message, error);
            }
        }

        public static int GetIDtoDelete(int dictLength, string message, string error)
        {
            try
            {
                Console.Write(message);
                if (!int.TryParse(Console.ReadLine(), out int number))
                {
                    throw new FormatException();
                }
                else if (number < 0 || number > dictLength)
                {
                    throw new Exception();
                }
                else
                {
                    return number;
                }
            }
            catch (Exception)
            {
                PrintInColor(error + "\n", ConsoleColor.Red);
                return GetIDtoDelete(dictLength, message, error);
            }

        }

    }
}
