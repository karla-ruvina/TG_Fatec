using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TGOrganicos.Web.Models
{
    public class SelectItem
    {
        public int Id { get; set; }
        public string Texto { get; set; }
    }

    public class SelectItemLong
    {
        public long Id { get; set; }
        public string Texto { get; set; }
    }
    public class SelectItemQtd : SelectItem
    {
        public int Qtd { get; set; }
    }

    public class SelectItem2
    {
        public string id { get; set; }
        public string text { get; set; }
    }
}