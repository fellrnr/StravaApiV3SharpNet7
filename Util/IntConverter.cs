using Newtonsoft.Json;
using System;

namespace de.schumacher_bw.Strava.Util
{
    internal class IntConverter : JsonConverter<int?>
    {
        public override void WriteJson(JsonWriter writer, int? value, JsonSerializer serializer)
            => writer.WriteValue(value);

        public override int? ReadJson(JsonReader reader, Type objectType, int? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            int? returnVal = null;

            if (reader.Value is long longVal) 
                returnVal = (int)longVal;
            else if (reader.Value is double doubleVal) 
                returnVal = (int)doubleVal;

            return returnVal;
        }
    }
}
