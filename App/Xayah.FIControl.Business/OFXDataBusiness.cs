using System;
using System.Collections.Generic;
using System.IO;
using Xayah.FIControl.Domain;

namespace Xayah.FIControl.Business
{
    public class OFXDataBusiness : IOFXDataBusiness
    {

        public OFXData LoadData(OFXReader OFXReader)
        {
            OFXData data = new OFXData();
            OFXBankStatement statement = null;
            var statements = new List<OFXBankStatement>();
            var fs = OFXReader.GetFileData();

            using (var reader = new StreamReader(fs, System.Text.Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    data = ReturnAll(line, "<OFX>", data);
                    data = ReturnAll(line, "<CODE>", data);
                    data = ReturnAll(line, "<SEVERITY>", data);
                    data = ReturnAll(line, "<DTSERVER>", data);
                    data = ReturnAll(line, "<LANGUAGE>", data);
                    data = ReturnAll(line, "<TRNUID>", data);
                    data = ReturnAll(line, "<CURDEF>", data);
                    data = ReturnAll(line, "<BANKID>", data);
                    data = ReturnAll(line, "<ACCTID>", data);
                    data = ReturnAll(line, "<ACCTTYPE>", data);
                    data = ReturnAll(line, "<BALAMT>", data);
                    data = ReturnAll(line, "<DTASOF>", data);
                    statement = ReturnAll(line, "<TRNTYPE>", statement, statements);
                    statement = ReturnAll(line, "<DTPOSTED>", statement, statements);
                    statement = ReturnAll(line, "<TRNAMT>", statement, statements);
                    statement = ReturnAll(line, "<MEMO>", statement, statements);
                }
                data.statements = statements;
            }

            return data;


        }


        public IList<OFXBankStatement> LoadStatements(OFXReader OFXReader)
        {
            var statements = new List<OFXBankStatement>();          

            OFXBankStatement statement = null;
            
            var fs = OFXReader.GetFileData();

            using (var reader = new StreamReader(fs, System.Text.Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    statement = ReturnAll(line, "<TRNTYPE>", statement, statements);
                    statement = ReturnAll(line, "<DTPOSTED>", statement, statements);
                    statement = ReturnAll(line, "<TRNAMT>", statement, statements);
                    statement = ReturnAll(line, "<MEMO>", statement, statements);
                }
            }

            return statements;
        }

        private string ReturnValue(string Line, string Begin)
        {
            return Line.Substring(Begin.Length, Line.Length - Begin.Length);
        }

        private OFXBankStatement ReturnAll(string line, string tagName, OFXBankStatement statement, IList<OFXBankStatement> statements)
        {
            if (line.IndexOf(tagName) >= 0)
            {
                if (statement == null)
                    statement = new OFXBankStatement();

                statement.SetTag(tagName, ReturnValue(line, tagName));

                if (statement.IsComplete())
                {
                    statements.Add(statement);
                    statement = null;
                }
            }
            return statement;
        }


        private OFXData ReturnAll(string line, string tagName, OFXData _OFXData)
        {
            if (line.IndexOf(tagName) >= 0)
            {
                if (_OFXData == null)
                    _OFXData = new OFXData();

                _OFXData.SetTag(tagName, ReturnValue(line, tagName));              
            }
            return _OFXData;
        }

    }
}
