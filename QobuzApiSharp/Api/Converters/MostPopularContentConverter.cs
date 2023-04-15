using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QobuzApiSharp.Models.Content;
using System;

namespace QobuzApiSharp.Converters
{
    public class MostPopularContentConverter : JsonConverter<MostPopularContent>
    {
        public override MostPopularContent ReadJson(JsonReader reader, Type objectType, MostPopularContent existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);
            string type = item["type"].ToString();

            if (type == "albums")
            {
                return item.ToObject<Album>(serializer);
            }
            else if (type == "tracks")
            {
                return item.ToObject<Track>(serializer);
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, MostPopularContent value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanWrite is false. The type will skip the converter.");
        }

        public override bool CanWrite
        {
            get { return false; }
        }
    }
}