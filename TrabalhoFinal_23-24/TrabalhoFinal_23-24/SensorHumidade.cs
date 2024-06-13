using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal_23_24
{
    internal class SensorHumidade: Sensor
    {
        public SensorHumidade()
        {
            tipo = "Humidade";
            unidadeMedida = "Percentual";
        }
        public override void ObterDados()
        {
            Random rand = new Random();
            valorAtual = rand.Next(0, 100);
            ultimaAtualizacao = DateTime.Now;

        }
    }
}
