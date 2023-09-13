using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace de.schumacher_bw.Strava.Util
{
    internal class DoubleToIntArrayConverter : JsonConverter<int[]>
    {
        public override void WriteJson(JsonWriter writer, int[] value, JsonSerializer serializer) 
            => serializer.Serialize(writer, value);

        public override int[] ReadJson(JsonReader reader, Type objectType, int[] existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var origArray = JArray.Load(reader);

            if (origArray.First.Type == JTokenType.Float)
            {
                double[] array = (double[])origArray.ToObject(typeof(double[]), serializer);
                return array.Select(x => (int)x).ToArray();
            }

            if (origArray.First.Type == JTokenType.Integer)
            {
                return (int[])origArray.ToObject(typeof(int[]), serializer);
            }
            
            return null;
        }

    }
}
