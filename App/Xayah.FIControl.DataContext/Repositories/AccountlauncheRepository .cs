using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xayah.FIControl.Domain.Domain.Interfaces.Repositories;
using Xayah.FIControl.Domain.Enitties;

namespace Xayah.FIControl.DataContext.Repositories
{
    public class AccountlauncheRepository : BaseRepository<Accountlaunche>, IAccountlauncheRepository
    {
        public AccountlauncheRepository(XayahFIControlDataContext _context)
            : base(_context)
        {

        }
        public override IEnumerable<Accountlaunche> GetAll()
        {

        
            return Db.Set<Accountlaunche>().ToList().OrderByDescending(x=>x.Dtposted);
        }
    }
}
