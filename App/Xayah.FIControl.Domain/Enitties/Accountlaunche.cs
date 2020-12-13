using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Xayah.FIControl.Domain.Enitties
{

    public class Accountlaunche
    {
        [Key]
        public Guid AccountlauncheId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Active { get; set; }
        public string Trntype { get; set; }
        public DateTime Dtposted { get; set; }
        public string Trnamt { get; set; }
        public string Memo { get; set; }
        public Guid BankStatementId { get; set; }
    }
}
