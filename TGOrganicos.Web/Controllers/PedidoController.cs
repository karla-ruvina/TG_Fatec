using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TGOrganicos.Data;
using TGOrganicos.Web.Models;

namespace TGOrganicos.Web.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            DataLinq db = new DataLinq();
            var idcliente = Credential.IdCliente();
            var idprodutor = Credential.IdProdutor();
            var pedido = db.Pedidos.ToList();

            if (Credential.IsProdutor())
            {
                var query = (from itens in db.ItensPedidos
                             join pedidos in db.Pedidos on itens.IdPedido equals pedidos.Id
                             join prodprod in db.ProdutosProdutors on itens.IdProduto equals prodprod.IdProduto
                             join produtor in db.Produtors on prodprod.IdProdutor equals produtor.Id
                             join prodtos in db.Produtos on prodprod.IdProduto equals prodtos.Id

                             where produtor.Id == idprodutor
                             select pedidos.Id).Distinct().ToList();

                pedido = pedido.Where(c => query.Contains(c.Id)).ToList();
            }
            if (Credential.IsCliente())
            {
                pedido = pedido.Where(c => c.IdCliente == idcliente).ToList();
            }

            return View(pedido);
        }

        public ActionResult Carrinho()
        {
            DataLinq db = new DataLinq();

            PedidoCadastro carrinho = new PedidoCadastro();
            carrinho.Itens = new List<Models.ItensPedido>();

            return View(carrinho);
        }

        public ActionResult Detalhe(int? id)
        {
            DataLinq db = new DataLinq();
            var idcliente = Credential.IdCliente();
            var idprodutor = Credential.IdProdutor();

            var itenspedido = db.ItensPedidos.ToList();

            if (id.HasValue && id.Value > 0)
            {
                if (Credential.IsProdutor())
                {
                    var query = (from itens in db.ItensPedidos
                                 join pedidos in db.Pedidos on itens.IdPedido equals pedidos.Id
                                 join prodprod in db.ProdutosProdutors on itens.IdProduto equals prodprod.IdProduto
                                 join produtor in db.Produtors on prodprod.IdProdutor equals produtor.Id
                                 join prodtos in db.Produtos on prodprod.IdProduto equals prodtos.Id

                                 where produtor.Id == idprodutor
                                 where pedidos.Id == id
                                 select itens.Id).Distinct().ToList();

                    itenspedido = itenspedido.Where(c => query.Contains(c.Id)).ToList();
                }
                if (Credential.IsCliente())
                {
                    itenspedido = itenspedido.Where(c => c.IdPedido == id && c.Pedido.IdCliente == idcliente).ToList();
                }
            }

            return View(itenspedido);
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

        public ActionResult Salvar(PedidoCadastro model)
        {
            DataLinq db = new DataLinq();

            try
            {
                Pedido obj = model.Id > 0 ? db.Pedidos.SingleOrDefault(c => c.Id == model.Id) : new Pedido();
                obj.IdCliente = model.IdCliente;
                obj.DataPedido = DateTime.Now;
                obj.ValorPedido = model.ValorPedido;
                obj.QuantidadeItens = model.QuantidadeItens;
                obj.Status = "Processando";

                if (obj.Id == 0)
                {
                    db.Pedidos.InsertOnSubmit(obj);
                }
                db.SubmitChanges();

                if(model.Itens != null && model.Itens.Count > 0)
                {
                    foreach (var itens in model.Itens)
                    {
                        var objItem = itens.Id > 0 ? db.ItensPedidos.SingleOrDefault(c => c.Id == itens.Id) : new Data.ItensPedido();
                        objItem.IdPedido = obj.Id;
                        objItem.IdProduto = itens.IdProduto;
                        objItem.DataCadastro = DateTime.Now;
                        objItem.ValorUnitario = itens.ValorUnitario;
                        objItem.ValorTotal = itens.ValorTotal;
                        objItem.Quantidade = itens.Quantidade;
                        objItem.Status = "Processando";

                    }
                }
                


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

        public ActionResult AceitarPedido(int? idPedido)
        {
            DataLinq db = new DataLinq();

            try
            {
                var pedido = db.ItensPedidos.FirstOrDefault(c => c.Id == idPedido);
                pedido.Status = "Em preparação";

                db.SubmitChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                db.Dispose();
                return RedirectToAction("Index", "Pedido");
            }
            finally
            {
                db.Dispose();
            }

            return RedirectToAction("Index", "Pedido");
        }

        public ActionResult RecusarPedido(int? idPedido)
        {
            DataLinq db = new DataLinq();

            try
            {
                var pedido = db.ItensPedidos.FirstOrDefault(c => c.Id == idPedido);
                pedido.Status = "Recusado";

                db.SubmitChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                db.Dispose();
                return RedirectToAction("Index", "Pedido");
            }
            finally
            {
                db.Dispose();
            }

            return RedirectToAction("Index", "Pedido");
        }

        public ActionResult FinalizarPedido(int? idPedido)
        {
            DataLinq db = new DataLinq();

            try
            {
                var pedido = db.ItensPedidos.FirstOrDefault(c => c.Id == idPedido);
                pedido.Status = "Entregue";

                db.SubmitChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                db.Dispose();
                return RedirectToAction("Index", "Pedido");
            }
            finally
            {
                db.Dispose();
            }

            return RedirectToAction("Index", "Pedido");
        }

        public ActionResult ConcluirPedido(int? idPedido)
        {
            DataLinq db = new DataLinq();

            try
            {
                var pedido = db.ItensPedidos.FirstOrDefault(c => c.Id == idPedido);
                pedido.Status = "Concluido";

                db.SubmitChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                db.Dispose();
                return RedirectToAction("Index", "Pedido");
            }
            finally
            {
                db.Dispose();
            }

            return RedirectToAction("Index", "Pedido");
        }

        public ActionResult NaoConcluirPedido(int? idPedido)
        {
            DataLinq db = new DataLinq();

            try
            {
                var pedido = db.ItensPedidos.FirstOrDefault(c => c.Id == idPedido);
                pedido.Status = "Não Recebido";

                db.SubmitChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                db.Dispose();
                return RedirectToAction("Index", "Pedido");
            }
            finally
            {
                db.Dispose();
            }

            return RedirectToAction("Index", "Pedido");
        }

    }
}