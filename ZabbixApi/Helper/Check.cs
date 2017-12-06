using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Entities;

namespace ZabbixApi.Helper
{
    public class Check
    {
        public static void NotNull(object value, string name = null)
        {
            if (value == null)
                throw new NullReferenceException(string.Format("The field {0} is null", name));
        }

        public static void IsNotNullOrWhiteSpace(string value, string name = null)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new NullReferenceException(string.Format("The field {0} is null or empty", name));
        }

        public static void EntityHasId(EntityBase value, string name = null)
        {
            NotNull(value, name);
            IsNotNullOrWhiteSpace(value.Id, name + "'s Id");
        }

        public static void IEnumerableNotNullOrEmpty<T>(IEnumerable<T> value, string name = null)
        {
            NotNull(value, name);
            if(!value.Any())
                throw new ArgumentException(string.Format("{0} is empty", name));
        }
    }
}
