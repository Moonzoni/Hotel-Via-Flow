using System;
namespace Hotelaria
{
    class Hospede
    {
        void EntraHospede()
        {
           Console.WriteLine("Nome: ");
           Console.ReadKey ();
           Console.WriteLine("Idade: ");
           Console.ReadKey ();
           Console.WriteLine("Telefone: ");
           Console.ReadKey ();
           Console.WriteLine("E-mail: ");
           Console.ReadKey ();
           Console.WriteLine("Método de Pagamento: ");
           Console.ReadKey ();
        }
    }
    class Quarto
    {
        void EntraQuarto()
        {
           Console.WriteLine("Numero do quarto: ");
           Console.ReadKey ();
           Console.WriteLine("Preço: ");
           Console.ReadKey ();
           Console.WriteLine("Tipo: ");
           Console.ReadKey ();
        }
                
    }
      
        static void Main()
        {
        EntraHospede();
        }


        
    

}