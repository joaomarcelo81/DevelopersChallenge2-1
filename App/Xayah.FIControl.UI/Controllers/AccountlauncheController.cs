using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xayah.FIControl.Domain.Domain.Interfaces.Business;
using Xayah.FIControl.Domain.Enitties;

namespace Xayah.FIControl.UI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    //[Authorize("Bearer")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountlauncheController : Controller
    {

        private readonly IAccountlauncheBusiness _AccountlauncheBusiness;
        public AccountlauncheController(IAccountlauncheBusiness AccountlauncheBusiness)
        {
            _AccountlauncheBusiness = AccountlauncheBusiness;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        [HttpPost]
        public void Post([FromBody] Accountlaunche Accountlaunche)
        {


            //Accountlaunche Accountlaunche = new Accountlaunche()
            //{
            //    AccountlauncheBrand = AccountlauncheDto.AccountlauncheBrand,
            //    AccountlauncheholderName = AccountlauncheDto.AccountlauncheholderName,
            //    CVS = AccountlauncheDto.CVS,
            //    AccountlauncheType = AccountlauncheDto.AccountlauncheType,
            //    Id = AccountlauncheDto.AccountlauncheId,
            //    ExpirationDate = AccountlauncheDto.ExpirationDate,
            //    Number = AccountlauncheDto.Number,
            //    CreatedDate = AccountlauncheDto.CreatedDate
            //};

            try
            {
                //   _AccountlauncheBusiness.SaveAndUpdate(Accountlaunche);
                _AccountlauncheBusiness.Save();
            }
            catch (Exception ex)
            {


                //  throw new System.Web.Http.HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Accountlaunche> Get()
        {
            return _AccountlauncheBusiness.GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BankStatementId"></param>
        /// <returns></returns>
        [HttpGet("{BankStatementId}")]
        public IEnumerable<Accountlaunche> GetByBankStatementId(string BankStatementId)
        {
            var id = Guid.Parse(BankStatementId);

            return _AccountlauncheBusiness.FinByParams(x => x.BankStatementId == id);
        }

    }


}
