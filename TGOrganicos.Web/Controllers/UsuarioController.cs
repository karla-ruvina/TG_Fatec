using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TGOrganicos.Data;

namespace TGOrganicos.Web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            DataLinq db = new DataLinq();

            return View(db.Usuarios.ToList());
        }

        public ActionResult Cadastro(int? id)
        {
            DataLinq db = new DataLinq();
            Usuario usuario = new Usuario();

            if (id.HasValue && id.Value > 0)
            {
                var aux = db.Usuarios.FirstOrDefault(c => c.Id == id);
                usuario.Id = aux.Id;
                usuario.Nome = aux.Nome;
                usuario.CPF = aux.CPF;
                usuario.DataNascimento = aux.DataNascimento;
                usuario.Telefone = aux.Telefone;
                usuario.Email = aux.Email;
                usuario.Senha = aux.Senha;
                usuario.CEP = aux.CEP;
                usuario.Cidade = aux.Cidade;
                usuario.Estado = aux.Estado;
                usuario.UF = aux.UF;
                usuario.Logradouro = aux.Logradouro;
                usuario.Numero = aux.Bairro;
                usuario.Complemento = aux.Complemento;
                usuario.TipoUsuario = aux.TipoUsuario;
            }

            return View(usuario);
        }

        public ActionResult Salvar(Usuario model)
        {
            DataLinq db = new DataLinq();

            try
            {
                var obj = model.Id > 0 ? db.Usuarios.SingleOrDefault(c => c.Id == model.Id) : new Usuario();
                obj.Nome = model.Nome;
                obj.CPF = model.CPF;
                obj.DataNascimento = model.DataNascimento;
                obj.Telefone = model.Telefone;
                obj.Email = model.Email;
                obj.Senha = model.Senha;
                obj.CEP = model.CEP;
                obj.Cidade = model.Cidade;
                obj.Estado = model.Estado;
                obj.UF = model.UF;
                obj.Logradouro = model.Logradouro;
                obj.Numero = model.Bairro;
                obj.Complemento = model.Complemento;
                obj.TipoUsuario = model.TipoUsuario;

                if (obj.Id == 0)
                {
                    db.Usuarios.InsertOnSubmit(obj);
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
                Usuario obj = db.Usuarios.FirstOrDefault(c => c.Id == id);
                db.Usuarios.DeleteOnSubmit(obj);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                db.Dispose();
                return RedirectToAction("Index", "Usuario");
            }

            return RedirectToAction("Index", "Usuario");
        }
    }
}