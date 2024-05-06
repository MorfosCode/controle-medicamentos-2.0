using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao.Saida;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao.Entrada
{

    internal class TelaRequisicaoEntrada : TelaBase
    {
        public TelaMedicamento telaMedicamento = null;

        public TelaFuncionario telaFuncionario = null;

        public RepositorioMedicamento repositorioMedicamento = null;

        public RepositorioFuncionario repositorioFuncionario = null;

        public override void Registrar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            RequisicaoEntrada entidade = (RequisicaoEntrada)ObterRegistro();

            string[] erros = entidade.Validar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                return;
            }
            entidade.EntradaMedicamento();

            repositorio.Cadastrar(entidade);
            
            ExibirMensagem($"O {tipoEntidade} foi cadastrado com sucesso!", ConsoleColor.Green);
        }

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Requisições de Entrada...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -20} | {3, -20} | {4, -5}",
                "Id", "Data da Requisição", "Medicamento", "Funcionario", "Quantidade"
            ); 
            EntidadeBase[] requisicoesCadastradas = repositorio.SelecionarTodos();

            foreach (RequisicaoEntrada requisicao in requisicoesCadastradas)
            {
                if (requisicao == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -20} | {4, -5}",
                    requisicao.Id,
                    requisicao.DataRequisicao.ToString(),
                    requisicao.medicamento,
                    requisicao.funcionario,
                    requisicao.QuantidadeEntrada
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o ID do medicamento requisitado: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamento = (Medicamento)repositorioMedicamento.SelecionarPorId(idMedicamento);
            
            telaFuncionario.VisualizarRegistros(false);

            Console.Write("Digite o ID do Funcionario requisitante: ");
            int idFuncionario = Convert.ToInt32(Console.ReadLine());

            Funcionario funcionario = (Funcionario)repositorioFuncionario.SelecionarPorId(idFuncionario);

            telaMedicamento.VisualizarRegistros(false);

            Console.Write("Digite a quantidade do medicamente que deseja registrar: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            RequisicaoEntrada novaRequisicao = new RequisicaoEntrada(medicamento, funcionario, quantidade);

            return novaRequisicao;
        }
    }
}

