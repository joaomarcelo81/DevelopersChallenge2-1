using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xayah.FIControl.Common
{
    public static class Extensions
    {

        public static DateTime OFXFormatteddDate(this string value)
        {
            //Open Financial Exchange (OFX) Specification and Schemas Version 2.3
            /*
                YYYYMMDD 12:00 AM(the start of the day), GMT
                YYYYMMDDHHMMSS GMT
                YYYYMMDDHHMMSS.XXX GMT
            */
           
            switch (value.Length)
            {
              
                //YYYYMMDDHHMMSS[ONN:GMT]
                case 23:
                   
          
                    return new DateTime(int.Parse(value.Substring(0,4))
                        , int.Parse(value.Substring(4,2))
                        , int.Parse(value.Substring(6,2))
                        , int .Parse(value.Substring(8, 2))
                        , int.Parse(value.Substring(10, 2))
                        , int.Parse(value.Substring(12, 2))
                        );
                break;
                default:
                    break;
            }


            return new DateTime();

        }

        public static string ToAbbreviation(this TimeZone theTimeZone)
        {

            string timeZoneString = theTimeZone.StandardName;
            string result = string.Concat(System.Text.RegularExpressions.Regex
               .Matches(timeZoneString, "[A-Z]")
               .OfType<System.Text.RegularExpressions.Match>()
               .Select(match => match.Value));

            return result;
        }
    }
}
