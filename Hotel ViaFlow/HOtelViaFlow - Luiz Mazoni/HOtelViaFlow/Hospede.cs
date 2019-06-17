using System;
using System.Collections.Generic;
using System.Text;

namespace HOtelViaFlow
{
    public class Hospede
    {
        public string Nome { get; set; }

        public int Idade { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public MetodoPagamento metodoPagamento { get; set; }

        
    }

    
}
