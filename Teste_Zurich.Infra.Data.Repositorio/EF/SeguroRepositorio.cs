using Teste_Zurich.Dominio.Entidades;
using Teste_Zurich.Dominio.Interfaces.Repositorio.EF;
using Teste_Zurich.Infra.Data.Contexto;

namespace Teste_Zurich.Infra.Data.Repositorio.EF
{
    public class SeguroRepositorio : RepositoryBase<Seguro> , ISeguroRepositorio
    {
        public SeguroRepositorio(DataBaseContext context) : base(context)
        {
        }
    }
}
