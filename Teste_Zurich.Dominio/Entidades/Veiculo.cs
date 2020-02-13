using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Zurich.Dominio.Entidades
{
    public class Veiculo
    {
      
        public int IdVeiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal Valor { get; set; }
        public virtual Seguro Seguro { get; set; }

    }
}
