using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetDurum.Model
{
    public class DurumContext : DbContext
    {
        public DbSet<InternetDrm> InternetDrm { get; set; }

    }
}
