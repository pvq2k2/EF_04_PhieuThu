using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_04_PhieuThu.Helper
{
    public class InputHelper
    {
        public static int InputInt(string message, string error, int minValue = int.MinValue, int maxValue = int.MaxValue, string errorLength = "")
        {
            string num;
            bool isNum;
            int numResult;
            do
            {
                Console.Write(message);
                num = Console.ReadLine();
                isNum = int.TryParse(num, out numResult);
                if (!isNum)
                {
                    Console.WriteLine(error);
                }
                else if (numResult < minValue && numResult > maxValue)
                {
                    Console.WriteLine(errorLength);
                }
            } while (!isNum);

            return numResult;
        }

        public static double InputDouble(string message, string error, string errorLength, double minValue = double.MinValue, double maxValue = double.MaxValue)
        {
            string num;
            bool isNum;
            double numResult;
            do
            {
                Console.Write(message);
                num = Console.ReadLine();
                isNum = double.TryParse(num, out numResult);
                if (!isNum)
                {
                    Console.WriteLine(error);
                }
                else if (numResult < minValue && numResult > maxValue)
                {
                    Console.WriteLine(errorLength);
                }
            } while (!isNum);

            return numResult;
        }

        public static string InputString(string message, string error = "", int minValue = int.MinValue, int maxValue = int.MaxValue, Func<string, bool> validationFunc = null, string errorRegex = "")
        {
            string str;
            bool isValid = false;

            do
            {
                Console.Write(message);
                str = Console.ReadLine();
                if (str.Length < minValue || str.Length > maxValue)
                {
                    Console.WriteLine(error);
                }
                else if (validationFunc != null && !validationFunc(str))
                {
                    Console.WriteLine(errorRegex);
                }
                else
                {
                    isValid = true;
                }
            } while (!isValid);

            return str;
        }

        public static string InputName(string message, string error = "", int maxValue = int.MaxValue, string errorSoTu = "")
        {
            string str;
            bool isValid = false;

            do
            {
                Console.Write(message);
                str = Console.ReadLine();
                if (str.Length > maxValue)
                {
                    Console.WriteLine(error);
                }
                else if (str.Split("").Length < 2)
                {
                    Console.WriteLine(errorSoTu);
                }
                else
                {
                    isValid = true;
                }
            } while (!isValid);

            return str;
        }

        public static DateTime InputDateTime(string message, string error)
        {
            bool match;
            DateTime datePs;
            do
            {
                Console.Write(message);
                match = DateTime.TryParse(Console.ReadLine(), out datePs);
                if (!match)
                {
                    Console.WriteLine(error);
                }
            }
            while (!match);
            return datePs;
        }
    }
}
