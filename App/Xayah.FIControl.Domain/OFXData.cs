using System;
using System.Collections.Generic;

namespace Xayah.FIControl.Domain
{
    public class OFXData
    {

        public string OFX { get; set; }
        public string CODE { get; set; }
        public string SEVERITY { get; set; }
        public string DTSERVER { get; set; }
        public string LANGUAGE { get; set; }
        public string TRNUID { get; set; }

        public string CURDEF { get; set; }
        public string BANKID { get; set; }
        public string ACCTID { get; set; }
        public string ACCTTYPE { get; set; }
        public string BALAMT { get; set; }
        public string DTASOF { get; set; }


        public IEnumerable<OFXBankStatement> statements { get; set; }
        public OFXData()
        {
            statements = new List<OFXBankStatement>();
        }

        public void SetTag(string tagName, string value)
        {
            switch (tagName)
            {
                case "<OFX>":
                    OFX = value;
                    break;
                case "<CODE>":
                    CODE = value;
                    break;
                case "<SEVERITY>":
                    SEVERITY = value;
                    break;
                case "<DTSERVER>":
                    DTSERVER = value;
                    break;
                case "<LANGUAGE>":
                    LANGUAGE = value;
                    break;
                case "<TRNUID>":
                    TRNUID = value;
                    break;
                case "<CURDEF>":
                    CURDEF = value;
                    break;
                case "<BANKID>":
                    BANKID = value;
                    break;
                case "<ACCTID>":
                    ACCTID = value;
                    break;
                case "<ACCTTYPE>":
                    ACCTTYPE = value;
                    break;
                case "<BALAMT>":
                    BALAMT = value;
                    break;
                case "<DTASOF>":
                    DTASOF = value;
                    break;
            }

        }

    }
   
    public class OFXBankStatement
    {
        public void SetTag(string tagName, string value)
        {
            switch (tagName)
            {
                case "<TRNTYPE>":
                    TRNTYPE = value;
                    break;
                case "<DTPOSTED>":
                    DTPOSTED = value;
                    break;
                case "<TRNAMT>":
                    TRNAMT = value;
                    break;
                case "<MEMO>":
                    MEMO = value;
                    break;
            }

        }


        public string TRNTYPE { get; set; }
        public string DTPOSTED { get; set; }
        public string TRNAMT { get; set; }
        public string MEMO { get; set; }

        public bool IsComplete()
        {
            bool flag = true;
            if (string.IsNullOrEmpty(TRNTYPE)) return false;
            if (string.IsNullOrEmpty(DTPOSTED)) return false;
            if (string.IsNullOrEmpty(TRNAMT)) return false;
            if (string.IsNullOrEmpty(MEMO)) return false;
            return flag;
        }

        public override string ToString()
        {          

            return TRNTYPE + " " + DTPOSTED + " " + TRNAMT + "" + MEMO;
        }
    }

}
