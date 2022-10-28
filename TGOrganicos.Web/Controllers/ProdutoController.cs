using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TGOrganicos.Data;
using TGOrganicos.Web.Models;
using TGOrganicos.Web.Models.Enums;
using TGOrganicos.Web.Models.Helpers;

namespace TGOrganicos.Web.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            DataLinq db = new DataLinq();

            return View(db.Produtos.ToList());
        }

        public ActionResult Detalhe(int? id)
        {
            DataLinq db = new DataLinq();
            Produto produto = new Produto();

            if (id.HasValue && id.Value > 0)
            {
                var aux = db.Produtos.FirstOrDefault(c => c.Id == id);
                produto.Id = aux.Id;
                produto.Nome = aux.Nome;
                produto.Quantidade = aux.Quantidade;
                produto.Valor = aux.Valor;
                produto.Descricao = aux.Descricao;
                produto.UnidadeMedida = aux.UnidadeMedida;
                produto.Medida = aux.Medida;
            }


            return View(produto);
        }

        public ActionResult Cadastro(int? id)
        {
            DataLinq db = new DataLinq();
            Produto produto = new Produto();

            var listatipoprodutos = Enum.GetValues(typeof(TipoProduto)).Cast<TipoProduto>().Select(c => new SelectItem
            {
                Id = (int)c,
                Texto = c.GetDescription()
            }).ToList();

            ViewBag.TipoProduto = ComboBox.GerarBox(listatipoprodutos, true, true);

            if (id.HasValue && id.Value > 0)
            {
                var aux = db.Produtos.FirstOrDefault(c => c.Id == id);
                produto.Id = aux.Id;
                produto.Nome = aux.Nome;
                produto.Quantidade = aux.Quantidade;
                produto.Valor = aux.Valor;
                produto.Descricao = aux.Descricao;
                produto.UnidadeMedida = aux.UnidadeMedida;
                produto.Medida = aux.Medida;
                produto.TipoProduto = aux.TipoProduto;
                produto.Imagem = aux.Imagem;
            }

            return View(produto);
        }

        public ActionResult Salvar(Produto model)
        {
            DataLinq db = new DataLinq();

            try
            {
                var obj = model.Id > 0 ? db.Produtos.SingleOrDefault(c => c.Id == model.Id) : new Produto();
                obj.Nome = model.Nome;
                obj.Quantidade = model.Quantidade;
                obj.Valor = model.Valor;
                obj.Descricao = model.Descricao;
                obj.UnidadeMedida = model.UnidadeMedida;
                obj.Medida = model.Medida;
                obj.TipoProduto = model.TipoProduto;
                obj.Imagem = model.Imagem;

                if (obj.Id == 0)
                {
                    db.Produtos.InsertOnSubmit(obj);
                }
                db.SubmitChanges();

                var prodprodutor = new ProdutosProdutor();
                prodprodutor.IdProduto = obj.Id;
                prodprodutor.IdProdutor = Models.Credential.Current.Id;
                prodprodutor.DataCadastro = DateTime.Now;

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
                Produto obj = db.Produtos.FirstOrDefault(c => c.Id == id);
                db.Produtos.DeleteOnSubmit(obj);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                db.Dispose();
                return RedirectToAction("Index", "Produto");
            }

            return RedirectToAction("Index", "Produto");
        }

    }
}