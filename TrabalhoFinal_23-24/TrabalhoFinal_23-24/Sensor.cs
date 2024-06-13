using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal_23_24
{
    public abstract class Sensor
    {
        private static int nId = 1;
        public int id { get; set; }
        public double valorAtual { get; set; }
        public string tipo { get; set; }
        public string unidadeMedida { get; set; }
        public bool estadoAtivo { get; set; }
        public DateTime ultimaAtualizacao { get; set; }

        public Sensor()
        {
            id = nId++;
            estadoAtivo= true;
        }

        public abstract void ObterDados();
    }
}