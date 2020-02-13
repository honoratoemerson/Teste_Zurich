using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Zurich.Dominio.Entidades;

namespace Teste_Zurich.Dominio.Interfaces.Servicos
{
    public interface ICalculoSeguroServico
    {
        Seguro CalcularSeguro(Veiculo veiculo, Segurado segurado);

    }
}
