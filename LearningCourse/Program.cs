
using System;

namespace LearningCourse
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string amountOfChars;
            bool isUpperCase = true;
            string upperCaseValidation;

            Console.WriteLine("Voulez vous que votre mot de passe soit généré en majuscule (Y pour oui et N pour non) ? : ");
            upperCaseValidation = Console.ReadLine();

            while (true)    
            {    
                if (upperCaseValidation.ToLower().Equals("y")) { 
                    isUpperCase = true; 
                    break; 
                }
                else if (upperCaseValidation.ToLower().Equals("n")) { 
                    isUpperCase = false; 
                    break; 
                }
                else
                {
                    Console.WriteLine("Cette entrée n'est pas valide");
                    upperCaseValidation = Console.ReadLine();
                }
            }



            Console.WriteLine("Combien de caractères voulez-vous que votre mot de passe contienne ? :");
            amountOfChars = Console.ReadLine();


            while (checkIsNumeric(amountOfChars) == 0) 
            {
                Console.WriteLine("Cette entrée n'est pas valide");
                amountOfChars = Console.ReadLine();
            }

            byte checkedNumber = checkIsNumeric(amountOfChars);

            Console.WriteLine(generatePassword(checkedNumber, isUpperCase));

        }
        static string generatePassword(byte size, bool isUpperCase)
        {
            char[] lettersAndDigits = { 'A', 'B', 'C', 'D', 'E', 'F', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
            'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            '1', '2', '3', '4', '5', '6', '7', '8', '9'};

            char[] code = new char[size];

            Random range = new Random();

            int charIndex;

            for (int i = 0; i < size; i++)
            {
                charIndex = range.Next(0, 35);
                char chosenChar = lettersAndDigits[charIndex];

                code[i] = chosenChar;

            }

            string codeString = new string(code);

            if (isUpperCase)
                return codeString;

            else
                return codeString.ToLower();
            
        }
        static byte checkIsNumeric(string value)
        {
            bool isNumeric = byte.TryParse(value, out byte size);

            if(isNumeric) return size;

            else return 0;

        }

    }

}

