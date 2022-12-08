using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TGOrganicos.Data;
using TGOrganicos.Web.Models;

namespace TGOrganicos.Web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario

        public static string pastaUpload = "/UploadArquivos";

        public ActionResult Index()
        {
            DataLinq db = new DataLinq();

            return View(db.Usuarios.ToList());
        }

        public ActionResult Cadastro(int? id)
        {
            DataLinq db = new DataLinq();

            var usuario = new Models.Usuarios();
            usuario.User = new Usuario();
            usuario.UserCli = new UsuarioCliente();
            usuario.UserProd = new UsuarioProdutor();

            return View(usuario);
        }

        public ActionResult Salvar(Usuarios model)
        {
            DataLinq db = new DataLinq();

            try
            {
                var obj = model.User.Id > 0 ? db.Usuarios.SingleOrDefault(c => c.Id == model.User.Id) : new Usuario();
                obj.Nome = model.User.Nome;
                obj.CPF = model.User.CPF;
                obj.DataNascimento = model.User.DataNascimento;
                obj.Telefone = model.User.Telefone;
                obj.Email = model.User.Email;
                obj.Senha = model.User.Senha;
                obj.CEP = model.User.CEP;
                obj.Cidade = model.User.Cidade;
                obj.Estado = model.User.Estado;
                obj.UF = model.User.UF;
                obj.Logradouro = model.User.Logradouro;
                obj.Numero = model.User.Bairro;
                obj.Complemento = model.User.Complemento;
                obj.TipoUsuario = model.User.TipoUsuario;

                if (obj.Id == 0)
                {
                    db.Usuarios.InsertOnSubmit(obj);
                }
                db.SubmitChanges();

                if(model.User.TipoUsuario == 1)
                {
                    var objprod = new Produtor();
                    objprod.IdUsuario = obj.Id;
                    objprod.AceitaPix = model.UserProd.AceitaPix;
                    objprod.AceitaCartao = model.UserProd.AceitaCartao;
                    objprod.EnderecoProducao = model.UserProd.EnderecoProducao;
                    objprod.RealizaEntregas = model.UserProd.RealizaEntrega;

                    foreach (string fileName in Request.Files)
                    {
                        HttpPostedFileBase file = Request.Files[fileName];
                        //Save file content goes here
                        var fName = file.FileName;
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName1 = Path.GetFileName(file.FileName);

                            string NovaPasta = pastaUpload + "/Produtores/";

                            if (!System.IO.Directory.Exists(Server.MapPath(NovaPasta)))
                                System.IO.Directory.CreateDirectory(Server.MapPath(NovaPasta));

                            var path = string.Format("{0}{1}", NovaPasta, file.FileName);
                            file.SaveAs(Server.MapPath(path));

                            if (fileName == "Certificado")
                                objprod.CertificadoOrganico = path;
                        }
                    }


                    db.Produtors.InsertOnSubmit(objprod);
                }

                if (model.User.TipoUsuario == 2)
                {
                    var objcli = new Cliente();
                    objcli.IdUsuario = obj.Id;

                    db.Clientes.InsertOnSubmit(objcli);
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