using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xayah.FIControl.Domain.Domain.Interfaces.Repositories;
using Xayah.FIControl.Domain.Enitties;

namespace Xayah.FIControl.DataContext.Repositories
{
    public class BankStatementRepository : BaseRepository<BankStatement>, IBankStatementRepository
    {
        public BankStatementRepository(XayahFIControlDataContext _context)
            : base(_context)
        {

        }
        public override IEnumerable<BankStatement> GetAll()
        {
             //return Db.BankStatement.Include(bs => bs.Accountlaunches).ToList();
            return Db.Set<BankStatement>().Include(bs => bs.Accountlaunches).ToList();
        }
    }
}
