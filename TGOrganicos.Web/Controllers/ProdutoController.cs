using System;
using System.Collections.Generic;
using System.IO;
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

        public static string pastaUpload = "/UploadArquivos";

        public ActionResult Index(int? tipo)
        {
            DataLinq db = new DataLinq();
            ViewBag.Tipo = tipo;

            var prod = tipo != null && tipo > 0 ? db.Produtos.Where(c => c.TipoProduto == tipo).ToList() : db.Produtos.ToList();

            if (Credential.IsProdutor())
            {
                var user = Credential.Current.Id;

                var query = (from prodprod in db.ProdutosProdutors
                             join produtor in db.Produtors on prodprod.IdProdutor equals produtor.Id
                             join prodtos in db.Produtos on prodprod.IdProduto equals prodtos.Id
                             where produtor.Id == user 
                             select prodtos.Id).Distinct().ToList();

                prod = prod.Where(c => query.Contains(c.Id)).ToList();
            }

            return View(prod);
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
                produto.Imagem = aux.Imagem;
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

                Produto obj = db.Produtos.FirstOrDefault(c => c.Id == model.Id) ?? new Produto();
                obj.Nome = model.Nome;
                obj.Quantidade = model.Quantidade;
                obj.Valor = model.Valor;
                obj.Descricao = model.Descricao;
                obj.UnidadeMedida = model.UnidadeMedida;
                obj.TipoProduto = model.TipoProduto;

                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    var fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName1 = Path.GetFileName(file.FileName);

                        string NovaPasta = pastaUpload + "/Produtos/";

                        if (!System.IO.Directory.Exists(Server.MapPath(NovaPasta)))
                            System.IO.Directory.CreateDirectory(Server.MapPath(NovaPasta));

                        var path = string.Format("{0}{1}", NovaPasta, file.FileName);
                        file.SaveAs(Server.MapPath(path));

                        if (fileName == "Imagem")
                            obj.Imagem = path;
                    }
                }

                db.SubmitChanges();

                if (obj.Id == 0)
                {
                    db.Produtos.InsertOnSubmit(obj);
                }
                db.SubmitChanges();

                var prodprodutor = new ProdutosProdutor();
                prodprodutor.IdProduto = obj.Id;
                prodprodutor.IdProdutor = Credential.IdProdutor();
                prodprodutor.DataCadastro = DateTime.Now;
                db.ProdutosProdutors.InsertOnSubmit(prodprodutor);

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