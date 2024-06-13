using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal_23_24
{
    public class DadosAmbientais
    {
        public static List <Leitura> leituras {  get; set; }

        public DadosAmbientais()
        {
            leituras = new List<Leitura>();
        }

        public static void AdicionarLeitura(Leitura leitura)
        {
            List<Leitura> leituras;
            leituras = new List<Leitura>();
            leituras.Add(leitura);
        }

        public static List<Leitura> ObterLeiturasPorLocal(string localizacao)
        {
            return leituras.Where(l => l.localizacao == localizacao).ToList();
        }
        public static List<Leitura> ObterLeiturasPorSensor(int sensorId)
        {
            return leituras.Where(l => l.SensorId == sensorId).ToList();
        }
        public static List<Leitura> ObterLeiturasPorTipo(string tipo)
        {
            return leituras.Where(l => l.tipo == tipo).ToList();
        }
    }
}