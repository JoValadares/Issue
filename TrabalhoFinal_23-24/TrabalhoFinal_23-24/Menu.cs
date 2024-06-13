using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal_23_24
{
    public class Menu
    {
        private SistemaMonitorizacaoAmbiental sistema;

        public Menu()
        {
            sistema = new SistemaMonitorizacaoAmbiental();
        }

        public void Exibir()
        {
            int opcao;
            do
            {
                Console.WriteLine("1. | Criar Nó Sensor |");
                Console.WriteLine("2. | Estatísticas |");
                Console.WriteLine("3. | Dados |");
                Console.WriteLine("4. | Mostrar Nos Sensores |");
                Console.WriteLine("5. | Mostrar Sensores de um No |");
                Console.WriteLine("0. | Sair |");
                Console.Write("\n");
                Console.Write("Selecione uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarNoSensor();
                        break;
                    case 2:
                        Console.WriteLine("1. | Mostrar Estatisticas Por Local |");
                        Console.WriteLine("2. | Mostrar Estatisticas Por Sensor |");
                        Console.WriteLine("3. | Mostrar Estatisticas Por Tipo |");
                        Console.WriteLine("0. | Voltar |");
                        Console.Write("\n");
                        Console.Write("Selecione uma opção: ");
                        int estopcao = int.Parse(Console.ReadLine());
                        switch (estopcao)
                        {
                            case 1:
                                sistema.MostrarEstatisticasPorLocal();
                                break;
                            case 2:
                                sistema.MostrarEstatisticasPorSensor();
                                break;
                            case 3:
                                sistema.MostrarEstatisticasPorTipo();
                                break;
                            case 0:
                                Exibir();
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("1. | Atualizar Dados |");
                        Console.WriteLine("2. | Importar Dados |");
                        Console.WriteLine("3. | Exportar Dados |");
                        Console.WriteLine("0. | Voltar |");
                        Console.Write("\n");
                        Console.Write("Selecione uma opção: ");
                        int dadosopcao = int.Parse(Console.ReadLine());
                        switch (dadosopcao)
                        {
                            case 1:
                                sistema.RecolherDadosTodosSensores();
                                break;
                            case 2:
                                ImportarDados();
                                break;
                            case 3:
                                ExportarDados();
                                break;
                            case 0:
                                Exibir();
                                break;
                        }
                        break;
                    case 4:
                        sistema.MostrarNosSensores();
                        break;
                    case 5:
                        MostrarSensoresDeNo();
                        break;
                }
            } while (opcao != 0);
        }
        private void AdicionarNoSensor()
        {
            Console.Write("Localização do Nó Sensor: ");
            string localizacao = Console.ReadLine();
            sistema.CriarNoSensor(localizacao);

            var noSensor = sistema.noSensores.Last();
            Console.Write("Quantos sensores deseja adicionar? ");
            int qtdSensores = int.Parse(Console.ReadLine());

            for (int i = 0; i < qtdSensores; i++)
            {
                Console.WriteLine("Tipo de Sensor (1-Temperatura, 2-Humidade): ");
                int tipoSensor = int.Parse(Console.ReadLine());

                string tipo = tipoSensor == 0 ? "Temperatura" : "Humidade";
                sistema.CriarSensor(noSensor, tipo);
            }
        }

        private void ExportarDados()
        {
            Console.Write("Caminho do arquivo para exportar dados: ");
            string caminho = Console.ReadLine();
            sistema.ExportarDados(caminho);
        }

        private void ImportarDados()
        {
            Console.Write("Caminho do arquivo para importar dados: ");
            string caminho = Console.ReadLine();
            sistema.ImportarDados(caminho);
        }
        private void MostrarSensoresDeNo()
        {
            Console.Write("Localização do No Sensor: ");
            string localizacao = Console.ReadLine();
            sistema.MostrarSensoresDeNo(localizacao);
        }
    }
}
