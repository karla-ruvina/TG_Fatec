using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TGOrganicos.Data;

namespace TGOrganicos.Web.Models
{
    public class Usuarios
    {

        public Data.Usuario User { get; set; }
        public UsuarioProdutor UserProd { get; set; }
        public UsuarioCliente UserCli { get; set; }
    }

    public class UsuarioProdutor
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public bool AceitaCartao { get; set; }
        public bool AceitaPix { get; set; }
        public bool RealizaEntrega { get; set; }
        public string EnderecoProducao { get; set; }
        public string CertificadoOrganico { get; set; }

    }

    public class UsuarioCliente
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public bool AceitaReceberEmail { get; set; }
        public bool AceitaReceberSMS { get; set; }

    }


}