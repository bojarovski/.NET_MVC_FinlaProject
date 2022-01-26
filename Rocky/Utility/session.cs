using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace Rocky.Utility
{
    public static class session
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T Get<T>(this ISession session, string key, T value)
        {
            var value1 = session.GetString(key);
            return value1 == null ? default : JsonSerializer.Deserialize<T>(value1);
           
        }
    }
}
