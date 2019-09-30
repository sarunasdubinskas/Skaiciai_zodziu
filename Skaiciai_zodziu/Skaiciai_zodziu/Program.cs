using System;
using System.Collections.Generic;

namespace Skaiciai_zodziu
{
    class Program
    {
        static void Main()
        {
            long number = 0;
            bool isNegative = false;

            string numberByText;

            Console.WriteLine("Įrašykite skaičių");
            string numberCandidate = Console.ReadLine();
            bool isNumber = CheckIfStringIsNumber(numberCandidate);

            number = IfNumberThenConvertAndProceedApplication(number, numberCandidate, isNumber);
            isNegative = CheckIfNegative(number);
            number = GetNumberUnsignedPart(number, isNegative);

            numberByText = (WriteSignByText(isNegative) + NumberTextAssembler(number));
            Console.Write("Skaičius žodžiais :" + numberByText);

            WaitForInputBeforeExitApplication("\nProgramos pabaiga.Spauskite bet kokį klavišą...");
        }

        private static string NumberTextAssembler(long number)
        {
            int countOfThousands;
            string numberByText = "";

            List<int> everyThirdOfNumber = new List<int>();

            ExtractEveryThirdOfNumber(number, everyThirdOfNumber);

            countOfThousands = everyThirdOfNumber.Count - 1;

            if (number == 0)
            {
                return "nulis";
            }

            do
            {
                switch (countOfThousands)
                {
                    case 0:
                        numberByText = numberByText + GetHundredsTextOfNumber(everyThirdOfNumber[countOfThousands], "");
                        break;
                    case 1:
                        if (everyThirdOfNumber[countOfThousands] == 0) { break; }
                        numberByText = numberByText + (GetHundredsTextOfNumber(everyThirdOfNumber[countOfThousands], "tūkstan") + GetEndingTextOfThousands(everyThirdOfNumber[countOfThousands]));
                        break;
                    case 2:
                        if (everyThirdOfNumber[countOfThousands] == 0) { break; }
                        numberByText = numberByText + (GetHundredsTextOfNumber(everyThirdOfNumber[countOfThousands], "milijon") + GetEndingTextOfOtherNumbers(everyThirdOfNumber[countOfThousands]));
                        break;
                    case 3:
                        if (everyThirdOfNumber[countOfThousands] == 0) { break; }
                        numberByText = numberByText + (GetHundredsTextOfNumber(everyThirdOfNumber[countOfThousands], "milijard") + GetEndingTextOfOtherNumbers(everyThirdOfNumber[countOfThousands]));
                        break;
                    case 4:
                        if (everyThirdOfNumber[countOfThousands] == 0) { break; }
                        numberByText = numberByText + (GetHundredsTextOfNumber(everyThirdOfNumber[countOfThousands], "trilijon") + GetEndingTextOfOtherNumbers(everyThirdOfNumber[countOfThousands]));
                        break;
                    case 5:
                        if (everyThirdOfNumber[countOfThousands] == 0) { break; }
                        numberByText = numberByText + (GetHundredsTextOfNumber(everyThirdOfNumber[countOfThousands], "kvadralijon") + GetEndingTextOfOtherNumbers(everyThirdOfNumber[countOfThousands]));
                        break;
                    case 6:
                        if (everyThirdOfNumber[countOfThousands] == 0) { break; }
                        numberByText = numberByText + (GetHundredsTextOfNumber(everyThirdOfNumber[countOfThousands], "kvintilijon") + GetEndingTextOfOtherNumbers(everyThirdOfNumber[countOfThousands]));
                        break;
                    default:
                        numberByText = ("Write number funkcijos klaida. Blogas everyThirdOfNumber List ilgis.");
                        break;
                }
                countOfThousands--;
            } while (countOfThousands >= 0);


            return numberByText;
        }



        private static string GetEndingTextOfOtherNumbers(int number)
        {
            int tempNumber = number % 100;

            if ((tempNumber > 10 && tempNumber <= 19) || (tempNumber % 10 == 0))
            {
                return "ų ";
            }
            else if (tempNumber % 10 == 1)
            {
                return "as ";
            }
            else
            {
                return "ai ";
            }
        }

        private static string GetEndingTextOfThousands(int number)
        {
            int tempNumber = number % 100;

            if ((tempNumber > 10 && tempNumber <= 19) || (tempNumber % 10 == 0))
            {
                return "čių ";
            }
            else if (tempNumber % 10 == 1)
            {
                return "tis ";
            }
            else
            {
                return "čiai ";
            }
        }



        private static string GetNumberTextUpToTen(int number)
        {
            switch (number)
            {
                case 1:
                    return "vienas ";
                case 2:
                    return "du ";
                case 3:
                    return "trys ";
                case 4:
                    return "keturi ";
                case 5:
                    return "penki ";
                case 6:
                    return "šeši ";
                case 7:
                    return "septyni ";
                case 8:
                    return "aštuoni ";
                case 9:
                    return "devyni ";
                default:
                    ExitProgram();
                    return "Vienetų apdorojimo klaida. Ne skaičius";
            }
        }

        private static string GetNumberTextFromTenToTwenty(int number)
        {
            switch (number)
            {
                case 10:
                    return "dešimt ";
                case 11:
                    return "vienuolika ";
                case 12:
                    return "dvylika ";
                case 13:
                    return "trylika ";
                case 14:
                    return "keturiolika ";
                case 15:
                    return "penkiolika ";
                case 16:
                    return "šešiolika ";
                case 17:
                    return "septyniolika ";
                case 18:
                    return "aštuoniolika ";
                case 19:
                    return "devyniolika ";
                default:
                    ExitProgram();
                    return "11-19 skaičių apdorojimo klaida. Ne skaičius";
            }
        }

        private static string GetDecadeTextOfNumber(int number)
        {

            if (number >= 90)
            {
                if (number > 90)
                {
                    return ("devyniasdešimt " + GetNumberTextUpToTen(number % 10));
                }
                return "devyniasdešimt";
            }
            if (number >= 80)
            {
                if (number > 80)
                {
                    return ("aštuoniasdešimt " + GetNumberTextUpToTen(number % 10));
                }
                return "aštuoniasdešimt";
            }
            if (number >= 70)
            {
                if (number > 70)
                {
                    return ("septyniasdešimt " + GetNumberTextUpToTen(number % 10));
                }
                return "septyniasdešimt";
            }
            if (number >= 60)
            {
                if (number > 60)
                {
                    return ("šešiasdešimt " + GetNumberTextUpToTen(number % 10));
                }
                return "šešiasdešimt";
            }
            if (number >= 50)
            {
                if (number > 50)
                {
                    return ("penkiasdešimt " + GetNumberTextUpToTen(number % 10));
                }
                return "penkiasdešimt";
            }
            if (number >= 40)
            {
                if (number > 40)
                {
                    return ("keturiasdešimt " + GetNumberTextUpToTen(number % 10));
                }
                return "keturiasdešimt";
            }
            if (number >= 30)
            {
                if (number > 30)
                {
                    return ("trisdešimt " + GetNumberTextUpToTen(number % 10));
                }
                return "trisdešimt";
            }
            if (number >= 20)
            {
                if (number > 20)
                {
                    return ("dvidešimt " + GetNumberTextUpToTen(number % 10));
                }
                return "dvidešimt";
            }
            else { return "Dešimčių apdorojimo į tekstą klaida. Ne numeris "; }
        }

        private static string GetHundredsTextOfNumber(int number, string endingTextOfNumber)
        {
            string tempText;


            if (number / 100 > 0)
            {
                tempText = (GetNumberTextUpToTen(number / 100) + "šimt" + GetEndingTextOfOtherNumbers(number / 100));
            }
            else
            {
                tempText = "";
            }

            if (number % 100 >= 20)
            {
                tempText = tempText + GetDecadeTextOfNumber(number % 100);
            }
            else if (number % 100 >= 10)
            {
                tempText = tempText + GetNumberTextFromTenToTwenty(number % 100);
            }
            else if (number % 100 > 0)
            {
                tempText = tempText + GetNumberTextUpToTen(number % 100);
            }
            return (tempText + endingTextOfNumber);
        }



        private static void ExtractEveryThirdOfNumber(long number, List<int> everyThirdOfNumber)
        {
            int threeDigitsOfNumber;

            while (number > 0)
            {
                threeDigitsOfNumber = Convert.ToInt32(number % 1000);
                number /= 1000;
                everyThirdOfNumber.Add(threeDigitsOfNumber);
            }
        }

        private static long GetNumberUnsignedPart(long number, bool isNegative)
        {
            if (isNegative)
            {
                number *= -1;
            }

            return number;
        }

        private static long IfNumberThenConvertAndProceedApplication(long number, string numberCandidate, bool isNumber)
        {
            if (!isNumber)
            {
                ExitProgram();
            }
            else
            {
                number = Convert.ToInt64(numberCandidate);
            }

            return number;
        }

        private static int GetCountOfDigitsInNumber(long number)
        {
            return (int)Math.Floor(Math.Log10(number) + 1);
        }

        private static void WaitForInputBeforeExitApplication(string textToShow)
        {
            Console.WriteLine(textToShow);
            Console.ReadKey();
        }

        private static void ExitProgram()
        {
            Console.WriteLine("Ivestas ne skaičius. Spauskite bet kokį klavišą...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private static bool CheckIfNegative(long number)
        {
            if (number < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckIfSigned(char firstChar)
        {
            if (firstChar == '-' || firstChar == '+')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckIfStringIsNumber(string numberCandidate)
        {
            char[] charArr = numberCandidate.ToCharArray();
            int numberCandidateLength = charArr.Length;
            bool isNumber = true;
            bool isSigned = CheckIfSigned(charArr[0]);

            for (int index = 0; index < numberCandidateLength; index++)
            {
                if (isSigned && index == 0)
                { continue; }

                if (charArr[index] != '1' &&
                    charArr[index] != '2' &&
                    charArr[index] != '3' &&
                    charArr[index] != '4' &&
                    charArr[index] != '5' &&
                    charArr[index] != '6' &&
                    charArr[index] != '7' &&
                    charArr[index] != '8' &&
                    charArr[index] != '9' &&
                    charArr[index] != '0')
                {
                    isNumber = false;
                    break;
                }
            }
            return isNumber;
        }

        private static string WriteSignByText(bool isNegative)
        {
            switch (isNegative)
            {
                case true:
                    return "minus ";
                case false:
                    return "";
                default:
                    ExitProgram();
                    return "Ne skaičius";
            }
        }
    }
}
