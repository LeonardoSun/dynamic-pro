using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralLib.Ext
{
    public static class DictionaryExtension
    {
        public static TValue SetDefault<TKey, TValue>(this Dictionary<TKey, TValue> This, TKey key, TValue value = default(TValue))
        {
            if (!This.ContainsKey(key))
            {
                This.Add(key, value);
            }
            return This[key];
        }
        public static TValue Get<TKey, TValue>(this Dictionary<TKey, TValue> This, TKey key, TValue value = default(TValue))
        {
            if (!This.ContainsKey(key))
            {
                return value;
            }
            return This[key];
        }
    }
}
