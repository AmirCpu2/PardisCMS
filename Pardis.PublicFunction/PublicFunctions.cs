using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Pardis.PublicFunction
{
    public static class Functions
    {
        #region Parse Tools
        public static int? ParseInt(object entity)
        {
            int number = 0;
            if (entity != null)
                int.TryParse(entity.ToString(), out number);

            if (number.Equals(0))
                return null;
                
            return number;
        }

        public static long? ParseLong(object entity)
        {
            long number = 0;
            if (entity != null)
                long.TryParse(entity.ToString(), out number);

            if (number.Equals(0))
                return null;

            return number;
        }

        public static string ParsePersianNumber(string numberFa)
        {
            if (String.IsNullOrWhiteSpace(numberFa))
                return null;

            var dict = new Dictionary<string, string>{  { "۰" , "0" },
                                                        { "۱" , "1" },
                                                        { "۲" , "2"},
                                                        { "۳" , "3" },
                                                        { "۴" , "4" },
                                                        {"۵" , "5" },
                                                        {"۶" , "6" },
                                                        {"۷" , "7" },
                                                        {"۸" , "8" },
                                                        {"۹" , "9" } };
            var result = "";

            foreach(var item in numberFa)
            {
                if (dict.Keys.Contains(item.ToString()))
                {
                    
                    result += dict.FirstOrDefault(q => q.Key == item.ToString()).Value;
                }
                else
                {
                    result += item;
                }
            }

            return result;
        }

        #endregion

        #region System Tools
        public static int GetIdFromModel(this object src)
        {
            return GetPropertyFromModel<int>(src, "Id");
        }

        public static T GetPropertyFromModel<T>(this object src, string propertyName)
        {
            try
            {
                if (string.IsNullOrEmpty(propertyName) && src == null)
                    return default(T);

                var type = src?.GetType();
                var property = type?.GetProperty(propertyName);
                var value = (property?.GetValue(src, null) ?? default(T));
                var valueInType = (T)value;
                return valueInType;
            }
            catch
            {
                return default(T);
            }
        }

        #endregion

        #region Persian calender
        public static PersianDateTime DateTimeToPersianDateTime(DateTime dateTime) => new PersianDateTime(DateTime.Parse(dateTime.ToString()));

        public static string DateTimeToShortStringPersian(DateTime? dateTime)
        {
            try
            {
                return dateTime != null ?  $"{new PersianDateTime(DateTime.Parse(dateTime.ToString())).MonthName} " +
                                    $"{new PersianDateTime(DateTime.Parse(dateTime.ToString())).Day}" : null;
            }
            catch
            {
                return "";
            }
        }
        
        public static string DateTimeToStringPersian(DateTime? dateTime)
        {
            try
            {
                return dateTime != null ?  
                    $"{new PersianDateTime(DateTime.Parse(dateTime.ToString())).Year}/" +
                        $"{new PersianDateTime(DateTime.Parse(dateTime.ToString())).Month}/" +
                            $"{new PersianDateTime(DateTime.Parse(dateTime.ToString())).Day}" : null;
            }
            catch
            {
                return "";
            }
        }

        public static DateTime? ConvertPersianToGregorianDate(string persianDateTime)
        {
            try
            {

                persianDateTime = ParsePersianNumber(persianDateTime);

                if (persianDateTime == null)
                    return null;

                var textSplited = persianDateTime.Split('/', ' ', '-');
                if (textSplited.Length < 3)
                    return null;
                int Year = int.Parse(textSplited[0]);
                int Month = int.Parse(textSplited[1]);
                int Day = int.Parse(textSplited[2]);

                if (Year > 1900 || Day > 1900)
                    return Convert.ToDateTime(persianDateTime, new CultureInfo("en"));

                PersianDateTime ShamsiDate = new PersianDateTime(DateTime.Now);

                if (Year > 1000)
                    ShamsiDate = new PersianDateTime(Year, Month, Day);
                else if (Year <= 31)
                    //change day and year
                    ShamsiDate = new PersianDateTime(Day, Month, Year);
                else if (Year < 1000)
                    return null;

                DateTime result = ShamsiDate.ToDateTime();
                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public static string ConvertPersianToGregorianString(string persianDateTime)
        {
            if (string.IsNullOrWhiteSpace(persianDateTime))
                return null;
            var result = ConvertPersianToGregorianDate(persianDateTime);
            if (result.HasValue == false)
                return null;
            return result.Value.ToShortDateString();
        }

        #endregion

        #region Attribute Tools
        public static object GetCustomProperty(this Enum enu, Enums.CustomProperty ReturnAttributeName = Enums.CustomProperty.persianName)
        {
            return GetCustomProperty(enu?.GetType(), enu?.ToString(), ReturnAttributeName);
        }

        public static object GetCustomProperty(this Type type, string member = "", Enums.CustomProperty ReturnAttributeName = Enums.CustomProperty.persianName)
        {
            if (type == null)
                return "";
            MemberInfo[] memInfo = type.GetMember(member);
            if (memInfo.Length <= 0) return member;

            object[] attrs = memInfo[0].GetCustomAttributes(typeof(CustomPropertyAttribute), false);
            if (!attrs.Any())
                return "";

            var result = ((CustomPropertyAttribute)attrs[0]);

            switch (ReturnAttributeName)
            {
                case Enums.CustomProperty.description:
                    return result.Description;
                case Enums.CustomProperty.persianName:
                    return result.PersianName;
                case Enums.CustomProperty.name:
                    return result.Name;
                default:
                    return result.GetPropertyFromModel<object>(ReturnAttributeName.ToString());
            }
        }

        public static string ToPersianName(this Enum enu, Enums.CustomProperty ReturnAttributeName = Enums.CustomProperty.persianName)
        {
            var result = enu.GetCustomProperty(ReturnAttributeName);
            try
            {
                return result?.ToString();
            }
            catch
            {
                return "";
            }
        }
        #endregion
    }
}
