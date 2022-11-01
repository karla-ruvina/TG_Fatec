using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TGOrganicos.Web.Models.Enums
{
    public enum TipoProduto
    {
        [Description("Vegetal")]
        Vegetal = 1,
        [Description("Fruta")]
        Fruta = 2,
        [Description("Suco")]
        Suco = 3,
        [Description("Grão")]
        Grao = 4,

    }
}