using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal_23_24
{
    public class Leitura
    {
        private DateTime ultimaAtualizacao;

        public DateTime dataHora { get; private set; }
        public double valor { get; private set; }
        public string tipo { get; private set; }
        public string unidadeMedida { get; private set; }
        public string localizacao { get; private set; }
        public int SensorId { get; private set; }

        public Leitura(DateTime ultimaAtualizacao, double valor, string tipo, string unidadeMedida, string localizacao, int sensorId)
        {
            this.ultimaAtualizacao = ultimaAtualizacao;
            this.valor = valor;
            this.tipo = tipo;
            this.unidadeMedida = unidadeMedida;
            this.localizacao = localizacao;
            this.SensorId = sensorId;
        }

        public string ObterLocalizacao()
        {
            return localizacao;
        }
        public string ObterTipo()
        {
            return tipo;
        }
    }
}
