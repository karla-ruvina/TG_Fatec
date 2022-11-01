using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.Json;
using TGOrganicos.Data;
using Anexs.Lib.Extensoes;

namespace TGOrganicos.Web.Models
{
    public class Credential
    {

        public Credential() { }

        public Credential(string login, string nome, int id, int tipo)
            : this()
        {
            this.Login = login;
            this.Nome = nome;
            this.Id = id;
            this.Tipo = tipo;

        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public int Tipo { get; set; }

        public static Credential Current
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.User != null && HttpContext.Current.User.Identity != null && HttpContext.Current.User.Identity.Name != "")
                    return JSON.Deserialize<Credential>(HttpContext.Current.User.Identity.Name);
                return new Credential();
            }
        }

        public static string GetName()
        {
            return Credential.Current.Nome;
        }

        //produtor é tipousuario 1
        public static bool IsProdutor()
        {
            DataLinq db = new DataLinq();

            var iduser = Credential.Current.Id;
            var usuario = db.Usuarios.FirstOrDefault(c => c.Id == iduser);
            return usuario.TipoUsuario == 1 ? true : false;
        }

        //cliente é tipousuario 2
        public static bool IsCliente()
        {
            DataLinq db = new DataLinq();

            var iduser = Credential.Current.Id;
            var usuario = db.Usuarios.FirstOrDefault(c => c.Id == iduser);
            return usuario.TipoUsuario == 2 ? true : false;
        }


    }
}