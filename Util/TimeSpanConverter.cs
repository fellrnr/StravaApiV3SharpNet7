using Newtonsoft.Json;
using System;

namespace de.schumacher_bw.Strava.Util
{
    internal class TimeSpanConverter : JsonConverter<TimeSpan?>
    {
        public override void WriteJson(JsonWriter writer, TimeSpan? value, JsonSerializer serializer)
            => writer.WriteValue((int) ((TimeSpan)value).TotalSeconds);
        public override TimeSpan? ReadJson(JsonReader reader, Type objectType, TimeSpan? existingValue, bool hasExistingValue, JsonSerializer serializer)
            => reader.Value == null ? (TimeSpan?) null : 
                (reader.Value is double ? TimeSpan.FromSeconds((double)reader.Value) : TimeSpan.FromSeconds((Int64)reader.Value));
    }
}
