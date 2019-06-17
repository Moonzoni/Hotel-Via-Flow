using System;
using System.Collections.Generic;
using System.Text;

namespace HOtelViaFlow
{
    public class Locacao
    {
        public Hospede hospede { get; set; }

        public Quarto quarto { get; set; }

        public List<Servico> servicosConsumidos { get; set; } = new List<Servico>();

        public double ValorTotal()
        {
            double vltotal = 0;
            if (quarto != null)
            {
                vltotal += quarto.Preco;
            }

            servicosConsumidos.ForEach(x => vltotal += x.Preco);

            return vltotal;
        }
    }
}
