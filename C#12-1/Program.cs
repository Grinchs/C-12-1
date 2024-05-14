using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_12_1
{
    internal class Program
    {
        public class myConsole
        {
            static string tagad = DateTime.Now.ToString("yyyy-MM-dd"); // Mainīgajam piešķirt patreizējo datumu. Formātu izvēlēties brīvi

            public static int NolasitKaInt()
            {
                while (true)
                {
                    Console.WriteLine("Ievadiet veselu skaitli:");
                    string input = Console.ReadLine();
                    try
                    {
                        int result = int.Parse(input);
                        return result;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Vērtība nav vesels skaitlis. Lūdzu, mēģiniet vēlreiz.");
                    }
                }
            }

            public static void Izvadit(string text)
            {
                Console.WriteLine(text);
            }

            public static void NomainitFonaKrasu()
            {
                Random rnd = new Random();
                Array colors = Enum.GetValues(typeof(ConsoleColor));
                ConsoleColor currentColor = Console.BackgroundColor;
                ConsoleColor newColor;
                do
                {
                    newColor = (ConsoleColor)colors.GetValue(rnd.Next(colors.Length));
                } while (newColor == currentColor);

                Console.BackgroundColor = newColor;
            }

            public static void NomainitBurtuKrasu()
            {
                Random rnd = new Random();
                Array colors = Enum.GetValues(typeof(ConsoleColor));
                ConsoleColor currentColor = Console.ForegroundColor;
                ConsoleColor newColor;
                do
                {
                    newColor = (ConsoleColor)colors.GetValue(rnd.Next(colors.Length));
                } while (newColor == currentColor);

                Console.ForegroundColor = newColor;
            }

            public static void FormatetVardu(string vards_uzvards)
            {
                string[] parts = vards_uzvards.Split(' ');
                if (parts.Length >= 2)
                {
                    string formattedName = $"{parts[0][0]}. {parts[1]}";
                    Console.WriteLine(formattedName);
                }
                else
                {
                    Console.WriteLine("Nepieciešams ievadīt gan vārdu, gan uzvārdu");
                }
            }

            public static string IzveidotParoli(int garums)
            {
                StringBuilder parole = new StringBuilder();
                Random rand = new Random();
                for (int i = 0; i < garums; i++)
                {
                    char c = (char)rand.Next(33, 127);
                    parole.Append(c);
                }
                return parole.ToString();
            }

            public static string SifretTekstu(string teksts)
            {
                char[] chars = teksts.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    if (char.IsLetter(chars[i]))
                    {
                        char originalChar = chars[i];
                        char newChar = (char)(originalChar + 1);
                        if (char.IsUpper(originalChar) && newChar > 'Z')
                            newChar = (char)(newChar - 26);
                        else if (char.IsLower(originalChar) && newChar > 'z')
                            newChar = (char)(newChar - 26);
                        chars[i] = newChar;
                    }
                }
                return new string(chars);
            }

            public static string AtsifretTekstu(string teksts)
            {
                char[] chars = teksts.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    if (char.IsLetter(chars[i]))
                    {
                        char originalChar = chars[i];
                        char newChar = (char)(originalChar - 1);
                        if (char.IsUpper(originalChar) && newChar < 'A')
                            newChar = (char)(newChar + 26);
                        else if (char.IsLower(originalChar) && newChar < 'a')
                            newChar = (char)(newChar + 26);
                        chars[i] = newChar;
                    }
                }
                return new string(chars);
            }
        }

        static void Main(string[] args)
        {
            int i = myConsole.NolasitKaInt();
            Console.WriteLine("Ievadītais skaitlis: " + i);

            myConsole.Izvadit("Ayo");

            myConsole.NomainitFonaKrasu();
            myConsole.NomainitBurtuKrasu();

            myConsole.FormatetVardu("Mārcis Grīnfelds");

            string password = myConsole.IzveidotParoli(8);
            Console.WriteLine("Jauna parole: " + password);

            string encryptedText = myConsole.SifretTekstu("LBTU");
            Console.WriteLine("Šifrētais teksts: " + encryptedText);

            string decryptedText = myConsole.AtsifretTekstu(encryptedText);
            Console.WriteLine("Atšifrētais teksts: " + decryptedText);

            Console.ReadLine();
        }
    }
}