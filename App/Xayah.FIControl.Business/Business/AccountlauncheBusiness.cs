using System;
using System.Collections.Generic;
using System.Text;
using Xayah.FIControl.Domain;
using Xayah.FIControl.Domain.Domain.Interfaces.Business;
using Xayah.FIControl.Domain.Domain.Interfaces.Repositories;
using Xayah.FIControl.Domain.Enitties;

namespace Xayah.FIControl.Business
{
    public class AccountlauncheBusiness : BaseBusiness<Accountlaunche>, IAccountlauncheBusiness
    {

        private IAccountlauncheRepository _Repository { get; set; }

        public AccountlauncheBusiness(IAccountlauncheRepository serviceBase)
            : base(serviceBase)
        {
            _Repository = serviceBase;
        }
    }
}
