using NLite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruce.GuoPan.Data
{
    public partial class BruceContext : DbContext
    {
        public BruceContext(string connection) : base(connection)
        {

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
