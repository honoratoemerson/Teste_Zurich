using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Teste_Zurich.Dominio.Entidades;
using Teste_Zurich.Infra.Data.Configuracao;

namespace Teste_Zurich.Infra.Data.Contexto
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(): base("MaquinaConexao")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

        }

        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Seguro> Seguro { get; set; }
        public DbSet<Segurado> Segurado { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ConfiguracaoVeiculo());
            modelBuilder.Configurations.Add(new ConfiguracaoSegurado());
            modelBuilder.Configurations.Add(new ConfiguracaoSeguro());

            base.OnModelCreating(modelBuilder);
        }


    }
}
