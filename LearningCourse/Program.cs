using System;
using System.Text.RegularExpressions;

namespace LearningCourse
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string amountOfChars;
            bool isUpperCase = true;
            bool containsSpecialCharacters = true;
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

            Console.WriteLine("Votre mot de passe est {0}", generatePassword(checkedNumber, isUpperCase, containsSpecialCharacters));

        }
        static string generatePassword(byte size, bool isUpperCase, bool containsSpecialChar)


        {
            char[] characters = { 'A', 'B', 'C', 'D', 'E', 'F', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
            'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            '1', '2', '3', '4', '5', '6', '7', '8', '9', '{', '}', '€', '_', '-', '?'};

            char[] password = new char[size];

            Random range = new Random();

            char chosenChar;

            for (int i = 0; i < size; i++)
            {
                int charIndex;

                if(containsSpecialChar)
                  charIndex = range.Next(0, 41);
                else
                  charIndex = range.Next(0, 35);       
                
                chosenChar = characters[charIndex];

                password[i] = chosenChar;

            }

            byte specialCharRangeInList = (byte) range.Next(36, 41);

            chosenChar = characters[specialCharRangeInList];

            if (containsSpecialChar)
            {
                if (!Array.Exists(password, element => element == chosenChar))
                {
                    password[range.Next(0, size)] = chosenChar;
                }
            }

            string passwordString = new string(password);

            if (isUpperCase)
                return passwordString;

            else
                return passwordString.ToLower();
            
        }
        static byte checkIsNumeric(string value)
        {
            bool isNumeric = byte.TryParse(value, out byte size);

            if(isNumeric) return size;

            else return 0;
        }

    }

}

