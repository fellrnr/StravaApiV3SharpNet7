using de.schumacher_bw.Strava.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

#pragma warning disable CA1303

namespace de.schumacher_bw.Strava.Util
{
    internal class RouteStreamSetConverter : JsonConverter<Model.RouteStreamSet>
    {
        public override void WriteJson(JsonWriter writer, RouteStreamSet value, JsonSerializer serializer)
        {
            var probs = typeof(RouteStreamSet).GetProperties();
            var propToJsonProp = new Dictionary<System.Reflection.PropertyInfo, JsonPropertyAttribute>();
            foreach(var prob in probs)
                propToJsonProp.Add(prob, prob.GetCustomAttributes(typeof(JsonPropertyAttribute), true).Cast<JsonPropertyAttribute>().First());

            var ret = new JArray();
            foreach(var prop in propToJsonProp.OrderByDescending(x => x.Value.PropertyName))
            {
                var val = prop.Key.GetValue(value);
                JObject obj = (JObject) JsonConvert.DeserializeObject(
                    JsonConvert.SerializeObject(val, prop.Key.PropertyType, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
                if (obj == null) continue;
                obj.Add("type", prop.Value.PropertyName);
                ret.Add(obj);
            }
            ret.WriteTo(writer);
        }

        public override RouteStreamSet ReadJson(JsonReader reader, Type objectType, RouteStreamSet existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var val = (RouteStreamSet)Activator.CreateInstance(objectType, true);
            JArray array = JArray.Load(reader);

            var propToJsonProp = objectType.GetProperties().
                Select(x => new { Prop = x, JsonProp = x.GetCustomAttributes(typeof(JsonPropertyAttribute), true).Cast<JsonPropertyAttribute>().FirstOrDefault() }).
                Where(y => y.JsonProp != null);

            foreach (var elm in array)
            {
                JProperty type = (JProperty)elm.Children().Where(x => x is JProperty && ((JProperty)x).Name == "type").FirstOrDefault();
                if (type == null) throw new JsonReaderException("JSON does not have the expected RouteStreamSet format");
                string typeName = type.Value.ToString();

                var prop = propToJsonProp.Where(x => x.JsonProp.PropertyName == typeName).Select(y => y.Prop).FirstOrDefault();
                prop.SetValue(val, elm.ToObject(prop.PropertyType, serializer));
            }

            return val;
        }
    }
}
