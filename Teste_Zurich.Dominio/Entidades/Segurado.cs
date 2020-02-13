using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Zurich.Dominio.Entidades
{
    public class Segurado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }

        public virtual Seguro Seguro { get; set; }

    }
}
