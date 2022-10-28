using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TGOrganicos.Web.Models.Enums
{
    public enum TipoProduto
    {
        [Description("Vegetais")]
        Vegetais = 1,
        [Description("Frutas")]
        Frutas = 2,
        [Description("Sucos")]
        Sucos = 3,
        [Description("Grãos")]
        Graos = 4,

    }
}