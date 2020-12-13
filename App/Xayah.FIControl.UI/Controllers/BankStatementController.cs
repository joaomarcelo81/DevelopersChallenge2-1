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
    public class BankStatementController : Controller
    {

        private readonly IBankStatementBusiness _BankStatementBusiness;
        public BankStatementController(IBankStatementBusiness BankStatementBusiness)
        {
            _BankStatementBusiness = BankStatementBusiness;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        [HttpPost]
        public void Post([FromBody] BankStatement BankStatement)
        {


            //BankStatement BankStatement = new BankStatement()
            //{
            //    BankStatementBrand = BankStatementDto.BankStatementBrand,
            //    BankStatementholderName = BankStatementDto.BankStatementholderName,
            //    CVS = BankStatementDto.CVS,
            //    BankStatementType = BankStatementDto.BankStatementType,
            //    Id = BankStatementDto.BankStatementId,
            //    ExpirationDate = BankStatementDto.ExpirationDate,
            //    Number = BankStatementDto.Number,
            //    CreatedDate = BankStatementDto.CreatedDate
            //};

            try
            {
                //   _BankStatementBusiness.SaveAndUpdate(BankStatement);
                _BankStatementBusiness.Save();
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
        public IEnumerable<BankStatement> Get()
        {
            return _BankStatementBusiness.GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BankStatementId"></param>
        /// <returns></returns>
        [HttpGet("{BankStatementId}")]
        public BankStatement Get(string BankStatementId)
        {
            var id = Guid.Parse(BankStatementId);
            return _BankStatementBusiness.Get(id);
        }

    }


}
