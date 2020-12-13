using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Xayah.FIControl.Domain.Enitties
{
    public class BankStatement

    {

        [Key]
        public Guid BankStatementId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Active { get; set; }

        public string Ofx { get; set; }
        public string Code { get; set; }
        public string Severity { get; set; }
        public DateTime Dataserver { get; set; }
        public string Language { get; set; }
        public string Trnuid { get; set; }

        public string Curdef { get; set; }
        public string Bankid { get; set; }
        public string Acctid { get; set; }
        public string Accttype { get; set; }
        public string Balamt { get; set; }
        public DateTime Dtasof { get; set; }


        public virtual IEnumerable<Accountlaunche> Accountlaunches { get; set; }

    }
}
