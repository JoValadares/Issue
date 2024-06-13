using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal_23_24
{
    internal class SistemaMonitorizacaoAmbiental: DadosAmbientais
    {
        static public int totalSensores;
        private DadosAmbientais dadosAmbientais;
        public List<NoSensor> noSensores { get; set; }
        List<Leitura> leituras { get; set; }

        public SistemaMonitorizacaoAmbiental()
        {
            this.dadosAmbientais = new DadosAmbientais();
            noSensores = new List<NoSensor>();
        }

        public void CriarNoSensor(string localizacao)
        {
            noSensores.Add(new NoSensor(localizacao));
        }
        public void CriarSensor(NoSensor noSensor, string tipo)
        {
            Sensor sensor;
            if (tipo == "Temperatura")
            {
                sensor = new SensorTemperatura();

            }
            if (tipo == "Humidade")
            {
                sensor = new SensorHumidade();
            }
            else
            {
                throw new ArgumentException("O tipo de sensor é inválido.");
            }
            noSensor.AdicionarSensor(sensor);
            totalSensores++;
        }

        public void ApagarSensor(NoSensor noSensor, Sensor sensor)
        {
            noSensor.RemoverSensor(sensor);
            totalSensores--;
        }
        public void RecolherDadosDeLocalizacao(string localizacao)
        {
            var no = noSensores.FirstOrDefault(n => n.localizacao == localizacao);
            if (no != null)
            {
                var leituras = no.RecolherDados();
                foreach (var leitura in leituras)
                {
                    DadosAmbientais.AdicionarLeitura(leitura);
                }
            }
        }
        public void RecolherDadosTodosSensores()
        {
            foreach (var NoSensor in noSensores)
            {
                var leituras = NoSensor.RecolherDados();
                foreach (var leitura in leituras)
                {
                    DadosAmbientais.AdicionarLeitura(leitura);
                }
            }
        }
        public void RecolherDadosDeTipo(string tipo)
        {
            foreach (var no in noSensores)
            {
                foreach (var sensor in no.sensores.Where(s => s.tipo == tipo && s.estadoAtivo))
                {
                    sensor.ObterDados();
                    DadosAmbientais.AdicionarLeitura(new Leitura(sensor.ultimaAtualizacao, sensor.valorAtual, sensor.tipo, sensor.unidadeMedida, no.localizacao, sensor.id));
                }
            }
        }
        public void MostrarEstatisticasPorLocal()
        {
            Console.WriteLine("Localização: ");
            string local = Console.ReadLine();
            RecolherDadosDeLocalizacao(local);
            var locais = DadosAmbientais.leituras.Select(l => l.localizacao).Distinct();
            foreach (var localizacao in locais)
            {
                var leituras = DadosAmbientais.ObterLeiturasPorLocal(local);
                var media = leituras.Average(l => l.valor);
                var minimo = leituras.Min(l => l.valor);
                var maximo = leituras.Max(l => l.valor);
                Console.WriteLine($"Localização: {localizacao}, Média Atual: {media}, Máximo: {maximo}, Mínimo: {minimo}");
            }
        }
        public string MostrarEstatisticasPorSensor()
        {
            Console.WriteLine("Id do Sensor: ");
            string SensorId = Console.ReadLine();
            var sensores = DadosAmbientais.leituras.Select(l => l.SensorId).Distinct();
            var estatisticas = "";
            foreach (var sensorId in sensores)
            {
                var leituras = DadosAmbientais.ObterLeiturasPorSensor(sensorId);
                var media = leituras.Average(l => l.valor);
                var minimo = leituras.Min(l => l.valor);
                var maximo = leituras.Max(l => l.valor);
                estatisticas += $"Sensor ID: {sensorId}, Média Atual: {media}, Máximo: {maximo}, Mínimo: {minimo}";
            }
            return estatisticas;
        }
        public void MostrarEstatisticasPorTipo()
        {
            Console.WriteLine("Tipo de Sensor (1-Temperatura, 2-Humidade): ");
            int tipoSensor = int.Parse(Console.ReadLine());
            string tipoS = tipoSensor == 0 ? "Temperatura" : "Humidade";

            var tipos = DadosAmbientais.leituras.Select(l => l.tipo).Distinct();
            foreach (var tipo in tipos)
            {
                var leituras = DadosAmbientais.ObterLeiturasPorTipo(tipoS);
                if (leituras.Any())
                {
                    var media = leituras.Average(l => l.valor);
                    Console.WriteLine($"Tipo: {tipo}, Média Atual: {media}\n");
                }
            }
        }
        public void MostrarNosSensores()
        {
            foreach (var no in noSensores)
            {
                Console.WriteLine($"No Sensor: {no.localizacao}, Estado: {(no.estadoAtivo ? "Ativo" : "Inativo")}");
            }
        }
        public void MostrarSensoresDeNo(string localizacao)
        {
            var no = noSensores.FirstOrDefault(n => n.localizacao == localizacao);
            if (no != null)
            {
                foreach (var sensor in no.sensores)
                {
                    Console.WriteLine($"Sensor ID: {sensor.id}, Tipo: {sensor.tipo}, Estado: {(sensor.estadoAtivo ? "Ativo" : "Inativo")}");
                }
            }
        }
        public void ExportarDados(string caminhoArquivo)
        {
            using (StreamWriter sw = new StreamWriter(caminhoArquivo))
            {
                foreach (var leitura in DadosAmbientais.leituras)
                {
                    sw.WriteLine($"{leitura.dataHora};{leitura.valor};{leitura.tipo};{leitura.unidadeMedida};{leitura.localizacao}");
                }
            }
        }
        public void ImportarDados(string caminhoArquivo)
        {
            if (File.Exists(caminhoArquivo))
            {
                using (StreamReader sr = new StreamReader(caminhoArquivo))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        var dados = linha.Split(';');
                        var leitura = new Leitura(DateTime.Parse(dados[0]), double.Parse(dados[1]), dados[2], dados[3], dados[4], int.Parse(dados[5]));
                        DadosAmbientais.AdicionarLeitura(leitura);
                    }
                }
            }
        }
    }
}
