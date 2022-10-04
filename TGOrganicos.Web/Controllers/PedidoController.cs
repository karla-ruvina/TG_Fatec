using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TGOrganicos.Data;

namespace TGOrganicos.Web.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            DataLinq db = new DataLinq();

            return View(db.Pedidos.ToList());
        }

        public ActionResult Cadastro(int? id)
        {
            DataLinq db = new DataLinq();
            Pedido pedido = new Pedido();

            if (id.HasValue && id.Value > 0)
            {
                var aux = db.Pedidos.FirstOrDefault(c => c.Id == id);
                pedido.Id = aux.Id;
                pedido.IdCliente = aux.IdCliente;
                pedido.DataPedido = aux.DataPedido;
                pedido.ValorPedido = aux.ValorPedido;
                pedido.TipoEntrega = aux.TipoEntrega;
                pedido.QuantidadeItens = aux.QuantidadeItens;
            }

            return View(pedido);
        }

        public ActionResult Salvar(Pedido model)
        {
            DataLinq db = new DataLinq();

            try
            {
                var obj = model.Id > 0 ? db.Pedidos.SingleOrDefault(c => c.Id == model.Id) : new Pedido();
                obj.IdCliente = model.IdCliente;
                obj.DataPedido = model.DataPedido;
                obj.ValorPedido = model.ValorPedido;
                obj.TipoEntrega = model.TipoEntrega;
                obj.QuantidadeItens = model.QuantidadeItens;

                if (obj.Id == 0)
                {
                    db.Pedidos.InsertOnSubmit(obj);
                }
                db.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return RedirectToAction("Cadastro", model);
            }
        }

        public ActionResult Excluir(int? id)
        {
            DataLinq db = new DataLinq();

            try
            {
                Pedido obj = db.Pedidos.FirstOrDefault(c => c.Id == id);
                db.Pedidos.DeleteOnSubmit(obj);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                db.Dispose();
                return RedirectToAction("Index", "Pedido");
            }

            return RedirectToAction("Index", "Pedido");
        }
    }
}