using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TGOrganicos.Data;

namespace TGOrganicos.Web.Controllers
{
    public class AvaliacaoController : Controller
    {
        // GET: Avaliacao
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Cadastro(int? idPedido, int? idCliente)
        {
            DataLinq db = new DataLinq();
            Avaliacao avaliacao = new Avaliacao();

            var existente = db.Avaliacaos.FirstOrDefault(c => c.IdPedido == idPedido && c.IdCliente == idCliente);

            if (existente != null)
            {
                return RedirectToAction("Index", "Avaliacao", new { id = existente.Id});
            }

            ViewBag.IdPedido = idPedido;

            return View(avaliacao);
        }

        public ActionResult Salvar(Avaliacao model)
        {
            DataLinq db = new DataLinq();

            try
            {

                Avaliacao obj = db.Avaliacaos.FirstOrDefault(c => c.Id == model.Id) ?? new Avaliacao();
                obj.IdPedido = model.IdPedido;
                obj.Estrelas = model.Estrelas;
                obj.Comentario = model.Comentario;

                if (obj.Id == 0)
                {
                    db.Avaliacaos.InsertOnSubmit(obj);
                }

                db.SubmitChanges();

                return RedirectToAction("Index", "Avaliacao");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return RedirectToAction("Index", "Avaliacao");
            }
        }

    }
}