using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;

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

            bool conseguiuDarEntrada = entidade.EntradaMedicamento();



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
                "{0, -10} | {1, -15} | {2, -15} | {3, -20} | {4, -5}",
                "Id", "Data da Requisição", "Dados do Mendicamento", "Data de Requisição", "Quantidade"
            );
        }

        protected override EntidadeBase ObterRegistro()
        {
            telaFuncionario.VisualizarRegistros(false);

            Console.Write("Digite o ID do Funcionario requisitante: ");
            int idFuncionario = Convert.ToInt32(Console.ReadLine());

            Funcionario funcionarioSelecionado = (Funcionario)repositorioFuncionario.SelecionarPorId(idFuncionario);

            telaMedicamento.VisualizarRegistros(false);

            Console.Write("Digite o ID do medicamento requisitado: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamentoSelecionado = (Medicamento)repositorioMedicamento.SelecionarPorId(idMedicamento);

            Console.Write("Digite a quantidade do medicamente que deseja registrar: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            RequisicaoEntrada novaRequisicao = new RequisicaoEntrada

            return novaRequisicao;
        }
    }
}
}

//Registrar Requisição de Entrada:
//O usuário poderá fazer uma requisição de entrada de medicamento que incluirá:
//  * data da requisição;
//  * dados do medicamento;
//  * dados do fornecedor;
//  * dados do funcionário;
//  * quantidade requisitada do medicamento.
//  * a quantidade do medicamento deve ser atualizada.
//
//Visualizar Requisições de Entrada:
//Exibe uma lista exibindo detalhes de todas as requisições de Entrada registradas.
