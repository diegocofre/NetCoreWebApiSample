using Newtonsoft.Json;
using System;

namespace WebapiSample.API.Helpers
{
    public static class JsonHelper
    {
        public static JsonSerializerSettings GetOps(bool ignoreNull)
        {
            var ops = new JsonSerializerSettings();
            if (ignoreNull)
            {
                ops.NullValueHandling = NullValueHandling.Ignore;
            }

            ops.MissingMemberHandling = MissingMemberHandling.Ignore;
            ops.DefaultValueHandling = DefaultValueHandling.Ignore;
            ops.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            ops.Converters.Add(new Newtonsoft.Json.Converters.IsoDateTimeConverter());

            return ops;
        }

        public static string Serialize(dynamic cmd)
        {
            string jsonCommand = JsonConvert.SerializeObject(cmd, Formatting.None, GetOps(false));
            return jsonCommand;
        }

        public static T Deserialize<T>(string command)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(command);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("The command has an incorrect format", ex);
            }
        }

        public static T Deserialize<T>(string command, bool ignoreNull)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(command, GetOps(ignoreNull));
            }
            catch
            {
                throw new InvalidOperationException("The command has an incorrect format");
            }
        }

    }
}
