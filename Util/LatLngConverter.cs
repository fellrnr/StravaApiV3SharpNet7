using de.schumacher_bw.Strava.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace de.schumacher_bw.Strava.Util
{
    internal class LatLngConverter : JsonConverter<LatLng>
    {
        public override void WriteJson(JsonWriter writer, LatLng value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, new double?[] { ((LatLng)value).Lat, ((LatLng)value).Lng });
        }

        public override LatLng ReadJson(JsonReader reader, Type objectType, LatLng existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            double[] array = (double[])JArray.Load(reader).ToObject(typeof(double[]), serializer);

            var propToJsonProp = objectType.GetProperties().
                Select(x => new { Prop = x, JsonProp = x.GetCustomAttributes(typeof(JsonPropertyAttribute), true).Cast<JsonPropertyAttribute>().FirstOrDefault() }).
                Where(y => y.JsonProp != null);


            var val = (LatLng)Activator.CreateInstance(objectType, true);
            var prop = propToJsonProp.Where(x => x.JsonProp.PropertyName == "lat").Select(y => y.Prop).FirstOrDefault();
            prop.SetValue(val, array.Length == 2 ? array[0] : double.NaN);
            prop = propToJsonProp.Where(x => x.JsonProp.PropertyName == "lng").Select(y => y.Prop).FirstOrDefault();
            prop.SetValue(val, array.Length == 2 ? array[1] : double.NaN);

            return val;
        }
    }
}
