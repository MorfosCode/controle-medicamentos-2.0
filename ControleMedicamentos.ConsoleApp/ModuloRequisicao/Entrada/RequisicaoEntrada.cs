using System;
using System.Collections.Generic;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao.Entrada
{
    internal class RequisicaoEntrada : EntidadeBase
    {
        public Medicamento medicamento { get; set; }

        public Funcionario funcionario { get; set; }
        public DateTime DataRequisicao { get; set; }
        public int QuantidadeEntrada { get; set; }

        public override string[] Validar()
        {
            throw new NotImplementedException();
        }

        public bool EntradaMedicamento()
        {
            Medicamento.Quantidade += QuantidadeEntrada;
            return true;
        }
    }
}
