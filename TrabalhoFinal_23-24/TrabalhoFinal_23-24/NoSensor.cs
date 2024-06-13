using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal_23_24
{
    internal class NoSensor
    {
        public List<Sensor> sensores = new List<Sensor>();
 
        public string localizacao { get; set; }
        public bool estadoAtivo { get; set; }
        public static int totalNos;

        public NoSensor(string localizacao)
        {
            this.localizacao = localizacao;
            this.estadoAtivo = true; 
            sensores = new List<Sensor>();
        }

        public void AdicionarSensor(Sensor sensor)
        {
            sensores.Add(sensor);
        }

        public void RemoverSensor(Sensor sensor)
        {
            sensores.Remove(sensor);
        }

        public void AtivarSensor(Sensor sensor)
        {
            sensor.estadoAtivo = true;
        }
        public void DesativarSensor(Sensor sensor)
        {
            sensor.estadoAtivo = false;
        }
        public string ObterLocalizacaoNo()
        {
            return localizacao;
        }
        public List<Leitura> RecolherDados()
        {
            List<Leitura> leituras = new List<Leitura>();
            foreach (var sensor in sensores)
            {
                if (sensor.estadoAtivo)
                {
                    sensor.ObterDados();
                    leituras.Add(new Leitura(sensor.ultimaAtualizacao, sensor.valorAtual, sensor.tipo, sensor.unidadeMedida, localizacao, sensor.id));
                }
            }
            return leituras;
        }
    }
}
