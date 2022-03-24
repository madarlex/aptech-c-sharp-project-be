using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MobileRecharge.Converters
{
    public class DateConverter : JsonConverter<DateTime>
    {
        private string formatDate = "dd/MM/yyyy";
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var s = reader.GetString();
            return DateTime.ParseExact(s, formatDate, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(formatDate));
        }
    }
}
