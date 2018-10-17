using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetDurum.Model
{
    [Table("tblInternet")]
    public class InternetDrm
    {

        public int Id { get; set; }

        public string GelenNet { get; set; }

        public string GidenNet { get; set; }

    }
}
