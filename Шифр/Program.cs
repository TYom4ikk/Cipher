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
            int shift = 10; // сдвиг

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
            }     
        }
        static string Encrypt(string str, int shift)
        {
            string encrypted_str_chars = string.Empty;
            int code;
            for (int i = 0; i < str.Length; i++)
            {
                code = ((int)str[i]) + shift;
                if (code > 255) { code -= 256; }
                encrypted_str_chars += (char)code;
            }
            return encrypted_str_chars;
        }

        static string Decrypt(string str, int shift)
        {
            string decrypted_str_chars = string.Empty;
            int code;
            for (int i = 0; i < str.Length; i++)
            {
                code = ((int)str[i]) - shift;
                if (code < 0) { code += 256; }
                decrypted_str_chars += (char)code;
            }
            return decrypted_str_chars;
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
