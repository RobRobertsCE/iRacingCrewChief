using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace iRacing
{
    public class IntArrayConverter : JsonCreationConverter<int[]>
    {

        protected override int[] Create(Type objectType, JArray jArray)
        {
            List<int> tags = new List<int>();

            foreach (var id in jArray)
            {
                tags.Add(id.Value<int>());
            }

            return tags.ToArray();
        }
    }

    public class SingleArrayConverter : JsonCreationConverter<Single[]>
    {

        protected override Single[] Create(Type objectType, JArray jArray)
        {
            List<Single> tags = new List<Single>();

            foreach (var id in jArray)
            {
                tags.Add(id.Value<Single>());
            }

            return tags.ToArray();
        }
    }

    public class BooleanArrayConverter : JsonCreationConverter<bool[]>
    {

        protected override bool[] Create(Type objectType, JArray jArray)
        {
            List<bool> tags = new List<bool>();

            foreach (var id in jArray)
            {
                tags.Add(id.Value<bool>());
            }

            return tags.ToArray();
        }
    }

    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        /// <summary>
        /// Create an instance of objectType, based properties in the JSON Array
        /// </summary>
        /// <param name="objectType">type of object expected</param>
        /// <param name="jObject">contents of JSON Array that will be deserialized</param>
        /// <returns></returns>
        protected abstract T Create(Type objectType, JArray jObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray jArray = JArray.Load(reader);

            T target = Create(objectType, jArray);

            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
