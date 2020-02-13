using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Zurich.Dominio.Interfaces.Repositorio.EF;
using Teste_Zurich.Dominio.Interfaces.Servicos;
using Teste_Zurich.Infra.Data.Contexto;
using Teste_Zurich.Infra.Data.Repositorio.EF;
using Teste_Zurich.Servicos.Servicos;

namespace Teste_Zurich.Infra.Data.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register(() => new DataBaseContext(), Lifestyle.Scoped);
            #region Repositorios
            container.Register<ISeguradoRepositorio, SeguradoRepositorio>(Lifestyle.Scoped);
            container.Register<ISeguroRepositorio, SeguroRepositorio>(Lifestyle.Scoped);
            container.Register<IVeiculoRepositorio, VeiculoRepositorio>(Lifestyle.Scoped);
            #endregion

            #region Dominio
            container.Register<ICalculoSeguroServico, CalculoSeguroServico>(Lifestyle.Scoped);
            #endregion

        }
    }
}
