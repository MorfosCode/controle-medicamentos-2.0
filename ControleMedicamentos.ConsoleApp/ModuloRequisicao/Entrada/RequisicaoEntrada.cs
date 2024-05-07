using System;
using System.Collections;
using System.Collections.Generic;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao.Entrada
{
    internal class RequisicaoEntrada : EntidadeBase
    {

        public Medicamento medicamento { get; set; }

        public Funcionario funcionario { get; set; }
        public DateTime DataRequisicao { get; set; }
        public int QuantidadeEntrada { get; set; }


        public RequisicaoEntrada(Medicamento medicamento, Funcionario funcionario, int quantidade)
        {
            this.medicamento = medicamento;
            this.funcionario = funcionario;
            QuantidadeEntrada = quantidade;

            DataRequisicao = DateTime.Now;
        }

        public override ArrayList Validar()
        {

            ArrayList erros = new ArrayList();

            if (medicamento == null)
                erros.Add = "O medicamento precisa ser preenchido";

            if (funcionario == null)
                eerros.Add = "O funcionario precisa ser informado";

            if (QuantidadeEntrada < 1)
                erros.Add = "Por favor informe uma quantidade válida";

            return erros;
        }

        public void EntradaMedicamento()
        {
            medicamento.Quantidade += QuantidadeEntrada;
        }

        public override void AtualizarRegistro(EntidadeBase novoregistro)
        {
            throw new NotImplementedException();
        }
    }
}
