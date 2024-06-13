using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal_23_24
{
    internal class SensorTemperatura: Sensor
    {
        public SensorTemperatura()
        {
            tipo = "Temperatura";
            unidadeMedida = "Celsius";
        }
    
        public override void ObterDados()
        {
            Random rand = new Random();
            valorAtual = rand.Next(-10, 35);
            ultimaAtualizacao = DateTime.Now;
        }
    }
}
