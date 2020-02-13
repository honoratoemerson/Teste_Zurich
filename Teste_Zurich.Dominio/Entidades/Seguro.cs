using System.ComponentModel.DataAnnotations.Schema;

namespace Teste_Zurich.Dominio.Entidades
{
    public class Seguro
    {
        public int Id { get; set; }
   
        public virtual Segurado Segurado { get; set; }
        public int IdSegurado { get; set; }
        public virtual Veiculo Veiculo { get; set; }
        public int IdVeiculo { get; set; }
        public decimal ValorSeguro { get; set; }

    }
}
