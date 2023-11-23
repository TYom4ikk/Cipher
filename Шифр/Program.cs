using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Шифр
{
    internal class Program
    {
        /*  
            Не использовать существующие языки кодирования (придумать свой язык шифра).
            При создании своего шифра и дешифратора обязательно использовать массивы.
            После шифрования и расшифровки сообщения программа должна предложить
            пользователю продолжить или завершить работу.
        */
        static void Main(string[] args)
        {
            /* string myString = "Пример строки";
             int hashCode = myString.GetHashCode();
             Console.WriteLine(hashCode);
             Console.ReadKey();*/


            int shift = 7; // сдвиг

            int choice;
            while (true)
            {
                try
                {
                    Console.Write("Введите сообщение: ");
                    string str = Console.ReadLine();
                    Console.Write("Выберите действие\n1. Зашифровать\n2. Дешифровать\n0. Выйти из программы\n");
                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Некорректное действие!");
                        continue;
                    }
                    switch (choice)
                    {
                        case 0:
                            return;
                        case 1:
                            Console.WriteLine(Encrypt(str, shift));
                            if (Again())
                            {
                                break;
                            }
                            return;
                        case 2:
                            Console.WriteLine(Decrypt(str, shift));
                            if (Again())
                            {
                                break;
                            }
                            return;
                        default:
                            Console.WriteLine("Некорректное действие!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }     /*try
                    {
                        
                        using (RSA rsa = RSA.Create())
                        {
                           
                            RSAParameters publicKey = rsa.ExportParameters(false);
                            RSAParameters privateKey = rsa.ExportParameters(true);

                        
                            string originalText = "Hello, world!";

                            
                            byte[] encryptedData = Encrypt(Encoding.UTF8.GetBytes(originalText), publicKey);
                            byte[] decryptedData = Decrypt(encryptedData, privateKey);

                            string decryptedText = Encoding.UTF8.GetString(decryptedData);
                            Console.WriteLine("Исходный текст: " + originalText);
                            Console.WriteLine("Зашифрованные данные: " + Convert.ToBase64String(encryptedData));
                            Console.WriteLine("Расшифрованный текст: " + decryptedText);
                        }
                    }
                    catch (CryptographicException e)
                    {
                 
                }*/
        }
        static string Encrypt(string str, int shift)
        {
            char[] str_chars = str.ToCharArray();
            string encrypted_str_chars = string.Empty;
            int code;
            for (int i = 0; i < str_chars.Length; i++)
            {
                code = int.Parse(str_chars[i].ToString());
                code += code + shift;
                encrypted_str_chars += code.ToString();
            }
            return encrypted_str_chars;
        }

        static string Decrypt(string str, int shift)
        {
            char[] str_chars = str.ToCharArray();
            string encrypted_str_chars = string.Empty;
            int code;

            for (int i = 0; i < str_chars.Length; i++)
            {
                code = ((int.Parse(str_chars[i].ToString())) - shift);
                encrypted_str_chars += code.ToString();
            }
            return encrypted_str_chars;
        }

        static bool Again()
        {
            Console.WriteLine("Ещё раз?\n1. да\n2. нит");
            int choice = int.Parse(Console.ReadLine());
            while (true)
            {
                switch (choice)
                {
                    case 1:
                        return true;
                    case 2:
                        return false;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
            }
        }
    }
}
