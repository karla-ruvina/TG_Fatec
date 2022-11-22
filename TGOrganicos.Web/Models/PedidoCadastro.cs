using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TGOrganicos.Web.Models
{
    public class PedidoCadastro : Data.Pedido
    {
        public List<ItensPedido> Itens { get; set; }


        public PedidoCadastro()
        {
            Itens = new List<ItensPedido>();
        }
    }

    public class ItensPedido
    {
        public int Index { get; set; }
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public int IdPedido { get; set; }
        public DateTime DataCadastro{ get; set; }
        public decimal ValorUnitario { get; set; }
        public string UnidadeMedida { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Quantidade { get; set; }
        public string Status { get; set; }
    }

}