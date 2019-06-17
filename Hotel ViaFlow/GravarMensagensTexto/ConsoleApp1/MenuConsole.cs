using System;
using System.Collections.Generic;
using System.Text;

namespace GravarMensagensTexto
{
    public class MenuConsole
    {
        public static void showMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static bool confirm(string message)
        {
            
            bool invalidInput = true;
            bool confirmation = false;

            do
            {
                try
                {
                    confirmation = getBool(message);
                    invalidInput = false;
                }
                catch (Exception) {}                
            } while (invalidInput);

            return confirmation;
        }

        public static bool getBool()
        {
            var result = get();
            return Boolean.Parse(result);
        }

        public static bool getBool(string title)
        {
            showMessage(title);
            return getBool();
        }

        public static string getString()
        {
            return get();
        }

        public static string getString(string title)
        {
            return get(title);
        }

        public static int getInt()
        {
            var result = get();
            return int.Parse(result);
        }

        public static int getInt(string title)
        {
            showMessage(title);
            return getInt();
        }

        public static double getDouble()
        {
            var result = get();
            return double.Parse(result);
        }

        public static double getDouble(string title)
        {
            showMessage(title);
            return getDouble();
        }

        private static string get()
        {
            try
            {
                return Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Input inválido");
                Console.WriteLine("Mensagem de erro: ", e.Message);
                return null;
            }
        }

        private static string get(string title)
        {
            showMessage(title);
            return get();
        }

        
    }
}
