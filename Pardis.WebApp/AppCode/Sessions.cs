using Pardis.PublicFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pardis.WebApp
{
    public static class Sessions
    {
        public static void DestroyAllSession()
        {
            //=>SettionNameClass.Destroy();
        }

        public static int? GetLastSubSystemSessionId()
        {
            var sessionList = new string[] { "ProductId", "SaleFolderId" };

            foreach (var sessionName in sessionList)
            {
                var sessionValue = GetString(sessionName);
                if (Functions.ParseInt(sessionValue) == null)
                    continue;
                return Functions.ParseInt(sessionValue);
            }
            return null;
        }

        public static void Set(string val, string sessionName, Enums.SubSystemType subSystemType)
        {
            DestroyAllSession();
            ActiveSubSystemType.Set(subSystemType);
            ActiveSubSystemId.Set(val);
            HttpContext.Current.Session[sessionName] = val;
        }
        public static void Set(int val, string sessionName, Enums.SubSystemType subSystemType)
        {
            DestroyAllSession();
            ActiveSubSystemType.Set(subSystemType);
            ActiveSubSystemId.Set(val.ToString());
            HttpContext.Current.Session[sessionName] = val;
        }
        public static bool GetBoolean(string sessionName)
        {
            return HttpContext.Current.Session[sessionName]?.ToString() == "True";
        }
        public static string GetString(string sessionName)
        {
            return HttpContext.Current.Session[sessionName]?.ToString();
        }
        public static void Destroy(string sessionName)
        {
            HttpContext.Current.Session.Remove(sessionName);
            //ActiveSubSystemType = Enums.SubSystemType.none;
        }

        public static class ActiveSubSystemType
        {
            private static string sessionName = "ActiveSubSystemType";
            public static void Set(Enums.SubSystemType val) { HttpContext.Current.Session[sessionName] = val; }
            public static string Get() => GetString(sessionName);
            public static Enums.SubSystemType? GetValEnumType()
            {
                if (HttpContext.Current.Session[sessionName] == null)
                    return null;
                else
                    return (Enums.SubSystemType)Enum.Parse(typeof(Enums.SubSystemType),
                            HttpContext.Current.Session[sessionName]?.ToString(), true);
            }
            public static void Destroy() => Sessions.Destroy(sessionName);
        }
        public static class ActiveSubSystemId
        {
            private static string sessionName = "ActiveSubSystemId";
            public static void Set(string val) { HttpContext.Current.Session[sessionName] = val; }
            public static string Get() => GetString(sessionName);
            public static void Destroy() => Sessions.Destroy(sessionName);
        }

    }
}