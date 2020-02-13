using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Zurich.Dominio.Entidades;
using Teste_Zurich.Dominio.Interfaces.Repositorio.EF;
using Teste_Zurich.Dominio.Interfaces.Servicos;

namespace Teste_Zurich.Servicos.Servicos
{
    public class CalculoSeguroServico : ICalculoSeguroServico
    {


        private readonly IVeiculoRepositorio _veiculoRepositorio;
        private readonly ISeguroRepositorio _seguroRepositorio;
        private readonly ISeguradoRepositorio _seguradoRepositorio;


        public CalculoSeguroServico(IVeiculoRepositorio veiculoRepositorio,
                                    ISeguroRepositorio seguroRepositorio,
                                    ISeguradoRepositorio seguradoRepositorio)
        {
            _veiculoRepositorio = veiculoRepositorio ?? throw new ArgumentNullException($"{nameof(veiculoRepositorio)}");
            _seguradoRepositorio = seguradoRepositorio ?? throw new ArgumentNullException($"{nameof(seguradoRepositorio)}");
            _seguroRepositorio = seguroRepositorio ?? throw new ArgumentNullException($"{nameof(seguroRepositorio)}");

        }


        public const decimal MARGEM_SEGURANCA = 3.0M;
        public const decimal LUCRO = 5.0M;

        public Seguro CalcularSeguro(Veiculo veiculo, Segurado segurado)
        {

            var taxaDeRiso = CalcularTaxaDeRisco(veiculo.Valor);
            var premioRisco = CalcularPremioDeRisco(taxaDeRiso, veiculo.Valor);
            var premioPuro = CalcularPremioPuro(premioRisco);
            var premioComercial = CalcularPremioComercial(premioPuro);

            _seguradoRepositorio.Add(segurado);
            _veiculoRepositorio.Add(veiculo);

            var seguro = new Seguro()
            {
                Segurado = segurado,
                Veiculo = veiculo,
                ValorSeguro = premioComercial,

            };
            _seguroRepositorio.Add(seguro);

            return seguro;
        }

        private decimal CalcularTaxaDeRisco(decimal valorDoVeiculo) =>
             (valorDoVeiculo * 5) / (2 * valorDoVeiculo);


        private decimal CalcularPremioDeRisco(decimal taxaDeRisco, decimal valorVeiculo)
        {
            taxaDeRisco = taxaDeRisco / 100;
            return valorVeiculo * taxaDeRisco;
        }
        private decimal CalcularPremioPuro(decimal premioRisco)
        {
            return premioRisco * (1 + (MARGEM_SEGURANCA / 100));
        }
        private decimal CalcularPremioComercial(decimal premioPuro)
        {
            var lucro = LUCRO / 100;
            return premioPuro += premioPuro * lucro;
        }

    }
}
