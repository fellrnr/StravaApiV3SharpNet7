using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace de.schumacher_bw.Strava.Util
{
    internal class EnumUtil
    {
        private static IEnumerable<T> GetValues<T>()
        {
            return System.Enum.GetValues(typeof(T)).Cast<T>();
        }
        public static string GetEnumAttrValue<T>(T enumVal)
        {
            var flags = typeof(T).GetCustomAttributes(false).OfType<FlagsAttribute>().FirstOrDefault();
            if (flags != null)
            {
                string returnStr = "";
                foreach (var elm in Util.EnumUtil.GetValues<T>())
                    if (((int)(object)enumVal & (int)(object)elm) > 0) returnStr += GetEnumMemberAttrValue(elm) + ",";
                return returnStr.Length > 0 ? returnStr.Substring(0, returnStr.Length - 1) : "";

            }
            else return GetEnumMemberAttrValue(enumVal);
        }

        public static T GetEnumValue<T>(string attributVal)
        {

            var flags = typeof(T).GetCustomAttributes(false).OfType<FlagsAttribute>().FirstOrDefault();

            T value = (T)(object)0;
            string commaAttributVal = "," + attributVal + ","; // ensure every value has a "," before and after

            foreach (var elm in Util.EnumUtil.GetValues<T>())
                if (commaAttributVal.Contains("," + Util.EnumUtil.GetEnumMemberAttrValue<T>(elm) + ","))
                {
                    if (flags != null) // in case of flags, add the intager value to the object
                        value = (T)(object)((int)(object)value | (int)(object)elm);
                    else // in case of not a flag, set the value
                        value = elm;
                }

            return value;
        }

        private static string GetEnumMemberAttrValue<T> (T enumVal)
        {
            var memInfo = typeof(T).GetMember(enumVal.ToString());
            var attr = memInfo[0].GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();
            return attr?.Value ?? "";
        }
    }
}
