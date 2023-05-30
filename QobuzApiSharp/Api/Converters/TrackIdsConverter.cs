using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Linq;

namespace QobuzApiSharp.Converters
{
    public class TrackIdsConverter : JsonConverter<List<long>>
    {
        public override List<long> ReadJson(JsonReader reader, Type objectType, List<long> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                // Handle the case where the "track_ids" property is an array of numbers
                return serializer.Deserialize<List<long>>(reader);
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                // Handle the case where the "track_ids" property is an object with string keys and number values
                var dictionary = serializer.Deserialize<Dictionary<string, long>>(reader);
                return dictionary.Values.ToList();
            }
            else
            {
                throw new JsonSerializationException("Unexpected token type for 'track_ids'");
            }
        }

        public override void WriteJson(JsonWriter writer, List<long> value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanWrite is false. The type will skip the converter.");
        }

        public override bool CanWrite
        {
            get { return false; }
        }
    }
}