using System.ComponentModel.DataAnnotations.Schema;

namespace Revisao.Business.Models
{
    public class Categoria : Entity
    {
        public string Descricao { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}