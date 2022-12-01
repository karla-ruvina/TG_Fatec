using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TGOrganicos.Web.Models
{
    public class PedidoCadastro
    {

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorPedido { get; set; }
        public decimal QuantidadeItens { get; set; }
        public string Status { get; set; }
        public List<ItensPedido> ItensPedido { get; set; }

    }

    public class ItensPedido
    {
        public bool Remove{ get; set; }
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