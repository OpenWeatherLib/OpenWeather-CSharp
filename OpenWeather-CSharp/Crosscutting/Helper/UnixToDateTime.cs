using System;

/*
 * Reference help
 * https://stackoverflow.com/questions/919244/converting-a-string-to-datetime
 * https://stackoverflow.com/questions/249760/how-to-convert-a-unix-timestamp-to-datetime-and-vice-versa
 */

namespace Crosscutting.Helper
{
    public static class UnixToDateTime
    {
        public static DateTime UnixTimeStampToDateTime(string unixTimeStampString)
        {
            double unixTimeStamp = 0;
            try
            {
                unixTimeStamp = Convert.ToDouble(unixTimeStampString);
            }
            catch (Exception) { }

            return UnixTimeStampToDateTime(unixTimeStamp);
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
