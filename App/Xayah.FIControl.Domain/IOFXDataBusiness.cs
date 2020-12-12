using System;
using System.Collections.Generic;
using System.Text;

namespace Xayah.FIControl.Domain
{
    public interface IOFXDataBusiness
    {
        IList<OFXBankStatement> LoadStatements(OFXReader OFXReader);
    }
}
