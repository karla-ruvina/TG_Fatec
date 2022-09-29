using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGOrganicos.Data
{
    public partial class DataLinq
    {
        public DataLinq()
            : base(ConfigurationManager.ConnectionStrings["LinqConnectionString"].ConnectionString)
        {
            OnCreated();
        }

    }
}
