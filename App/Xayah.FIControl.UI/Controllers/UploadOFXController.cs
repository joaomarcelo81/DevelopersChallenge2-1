using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xayah.FIControl.Business;
using Xayah.FIControl.Common;
using Xayah.FIControl.Domain;
using Xayah.FIControl.Domain.Domain.Interfaces.Business;
using Xayah.FIControl.Domain.Enitties;

namespace Xayah.FIControl.UI.Controllers
{
    public class UploadOFXController : Controller
    {

        private readonly IBankStatementBusiness _BankStatementBusiness;
        public UploadOFXController(IBankStatementBusiness BankStatementBusiness)
        {
            _BankStatementBusiness = BankStatementBusiness;
        }


        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Index()
        {
            try
            {        

                var file = Request.Form.Files[0];

               
                var folderName = Path.Combine("Resources", "File");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    //var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    //var fullPath = Path.Combine(pathToSave, fileName);
                    //var dbPath = Path.Combine(folderName, fileName);
                    //using (var stream = new FileStream(fullPath, FileMode.Create))
                    //{


                    var stream = file.OpenReadStream();
                    //     file.CopyTo(stream);
                    OFXDataBusiness business = new OFXDataBusiness();
                    OFXReader OFXReader = new OFXReader(stream);
                    var data = business.LoadData(OFXReader);

                    _BankStatementBusiness.Add(new Domain.Enitties.BankStatement()
                    {
                        Active = true,
                        CreatedDate = DateTime.Now,
                        Accttype = data.ACCTTYPE,
                        Balamt = data.BALAMT,
                        Bankid = data.BANKID,
                        Curdef = data.CURDEF,
                        Dtasof = data.DTASOF.OFXFormatteddDate(),
                        Dataserver = data.DTSERVER.OFXFormatteddDate(),
                        Language = data.LANGUAGE,
                        Ofx = data.OFX,
                        Severity = data.SEVERITY,
                        Acctid = data.ACCTID,
                        Trnuid = data.TRNUID,
                        Code = data.CODE,
                        Accountlaunches = data.statements.Select(x => new Accountlaunche()
                        {
                            Active = true,
                            CreatedDate = DateTime.Now,
                            Dtposted = x.DTPOSTED.OFXFormatteddDate(),
                            Memo = x.MEMO,
                            Trnamt = x.TRNAMT,
                            Trntype = x.TRNTYPE
                        }).ToList()
                    });
                    _BankStatementBusiness.Save();


                }

                    //var folderName = Path.Combine("Resources", "Images");
                    //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    //if (file.Length > 0)
                    //{
                    //    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    //    var fullPath = Path.Combine(pathToSave, fileName);
                    //    var dbPath = Path.Combine(folderName, fileName);
                    //    using (var stream = new FileStream(fullPath, FileMode.Create))
                    //    {
                    //        file.CopyTo(stream);
                    //    }
                    //    return Ok(new { dbPath });
                    //}
                    //else
                    //{
                    //    return BadRequest();
                    //}
                }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
            return Ok();
        }
    }
}
