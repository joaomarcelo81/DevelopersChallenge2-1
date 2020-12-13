using System;
using System.Collections.Generic;
using System.Text;
using Xayah.FIControl.Domain;
using Xayah.FIControl.Domain.Domain.Interfaces.Business;
using Xayah.FIControl.Domain.Domain.Interfaces.Repositories;
using Xayah.FIControl.Domain.Enitties;

namespace Xayah.FIControl.Business
{
    public class BankStatementBusiness : BaseBusiness<BankStatement>, IBankStatementBusiness
    {

        private IBankStatementRepository _Repository { get; set; }

        public BankStatementBusiness(IBankStatementRepository serviceBase)
            : base(serviceBase)
        {
            _Repository = serviceBase;



        }



        
    }
}
