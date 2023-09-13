using System;
using System.Collections.Generic;
using System.Text;

namespace de.schumacher_bw.Strava.Util
{
    /// <summary>Class that holds the Usage Limits</summary>
    public class LimitUsage
    {
        /// <summary>The available limit</summary>
        public int? Limit { get; private set; }
        /// <summary>The used value</summary>
        public int? Usage { get; private set; }

        internal LimitUsage(string limit, string usage, bool shortSpan)
        {
            if (limit == null) Limit = null;
            else Limit = Int32.Parse(limit.Split(',')[shortSpan ? 0 : 1], System.Globalization.CultureInfo.GetCultureInfo("EN-US"));


            if (usage == null) Usage = null;
            else Usage = Int32.Parse(usage.Split(',')[shortSpan ? 0 : 1], System.Globalization.CultureInfo.GetCultureInfo("EN-US"));

        }
    }

}
