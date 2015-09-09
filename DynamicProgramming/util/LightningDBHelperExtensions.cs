using System.Linq;
using System.Collections.Generic;
using System;

namespace LightningDB.Ext
{
    public static class LightningDBHelperExtensions
    {
        #region Put
        public static void Put(this LightningTransaction tx, LightningDatabase db, string key, string value)
        {
            var enc = System.Text.Encoding.UTF8;
            tx.Put(db, enc.GetBytes(key), enc.GetBytes(value));
        }
        public static void Put(this LightningTransaction tx, LightningDatabase db, Guid key, Guid value)
        {
            tx.Put(db, key.ToByteArray(), value.ToByteArray());
        } 
        #endregion

        #region Get
        public static string Get(this LightningTransaction tx, LightningDatabase db, string key)
        {
            var enc = System.Text.Encoding.UTF8;
            var result = tx.Get(db, enc.GetBytes(key));
            return enc.GetString(result);
        }

        public static Guid Get(this LightningTransaction tx, LightningDatabase db, Guid key)
        {
            var result = tx.Get(db, key.ToByteArray());
            return new Guid(result);
        } 
        #endregion

        #region Delete
        public static void Delete(this LightningTransaction tx, LightningDatabase db, string key)
        {
            var enc = System.Text.Encoding.UTF8;
            tx.Delete(db, enc.GetBytes(key));
        }
        public static void Delete(this LightningTransaction tx, LightningDatabase db, Guid key)
        {
            tx.Delete(db, key.ToByteArray());
        } 
        #endregion

        #region ContainsKey
        public static bool ContainsKey(this LightningTransaction tx, LightningDatabase db, string key)
        {
            var enc = System.Text.Encoding.UTF8;
            return tx.ContainsKey(db, enc.GetBytes(key));
        }

        public static bool ContainsKey(this LightningTransaction tx, LightningDatabase db, Guid key)
        {
            return tx.ContainsKey(db, key.ToByteArray());
        } 
        #endregion

        #region TryGet
        public static bool TryGet(this LightningTransaction tx, LightningDatabase db, string key, out string value)
        {
            var enc = System.Text.Encoding.UTF8;
            byte[] result;
            var found = tx.TryGet(db, enc.GetBytes(key), out result);
            value = enc.GetString(result);
            return found;
        }
        public static bool TryGet(this LightningTransaction tx, LightningDatabase db, Guid key, out Guid value)
        {
            byte[] result;
            var found = tx.TryGet(db, key.ToByteArray(), out result);
            value = new Guid(result);
            return found;
        } 
        #endregion

        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int parts)
        {
            return list
                .Select((x, i) => new {Index = i, Value = x})
                .GroupBy(x => x.Index / parts)
                .Select(x => x.Select(v => v.Value));
        }
    }
}