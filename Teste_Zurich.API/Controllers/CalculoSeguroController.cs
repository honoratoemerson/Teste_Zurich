using System;
using System.Net;
using System.Web.Http;
using Teste_Zurich.API.Models;
using Teste_Zurich.Dominio.Entidades;
using Teste_Zurich.Dominio.Interfaces.Servicos;

namespace Teste_Zurich.API.Controllers
{
 
    public class CalculoSeguroController : ApiController
    {
        private readonly ICalculoSeguroServico _calculoSeguroServico;


        public CalculoSeguroController(ICalculoSeguroServico calculoSeguroServico)
        {
            _calculoSeguroServico = calculoSeguroServico ?? throw new ArgumentNullException($"{nameof(calculoSeguroServico)}");
        }


        // POST api/values
        public Seguro Post([FromBody] Modelo modelo)
        {
            return _calculoSeguroServico.CalcularSeguro(modelo.Veiculo, modelo.Segurado);
        }

    }
}
