using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            // Add your code here. 
            string A, B, C;
            string[] str1 = equation.Split("*");
            A = str1[0];
            string[] str2 = str1[1].Split("=");
            B = str2[0];
            C = str2[1];
            int a, b, c;

            if (C.Contains('?')){
                a = int.Parse(A);
                b = int.Parse(B);
                c = a * b;
                int i = C.IndexOf('?');
                string cString = c.ToString();
                if (cString.Length < C.Length)
                {
                    return -1;
                }

                //int missingDigit = cString[i];
                char digit = cString[i];
                int missingDigit = (int)Char.GetNumericValue(digit);
                return missingDigit;
            }

            else if (A.Contains('?')) {
                b = int.Parse(B);
                c = int.Parse(C);
                a = c / b;
                int i = A.IndexOf('?');
                string aString = a.ToString();
                if (aString.Length < A.Length || (c%b)!=0)
                {
                    return -1;
                }
                char digit = aString[i];
                int missingDigit = (int)Char.GetNumericValue(digit);
                return missingDigit;
            }

            else if (B.Contains('?')) {
                a = int.Parse(A);
                c = int.Parse(C);
                b = c / a;
                int i = B.IndexOf('?');
                string bString = b.ToString();
                if (bString.Length < B.Length || (c%a)!=0)
                {
                    return -1;
                }
                char digit = bString[i];
                int missingDigit = (int)Char.GetNumericValue(digit);
                return missingDigit;
            }

            throw new NotImplementedException();
        }
    }
}