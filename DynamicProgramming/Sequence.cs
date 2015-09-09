using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class Sequence<T> : List<T>
    {
        // 需要能提供一个额外标记 tag/token ，来迅速索引到某一特殊行。
        internal Dictionary<string, T> _objToken = new Dictionary<string, T>();
        internal Dictionary<string, int> _indexToken = new Dictionary<string, int>();
        /// <summary>
        /// 标记元素
        /// </summary>
        /// <param name="token">标记</param>
        /// <param name="objIndex">元素索引</param>
        /// <param name="coverOldSetting"></param>
        /// <returns></returns>
        public bool TagObject(string token, int objIndex, bool coverOldSetting = false)
        {
            if (!coverOldSetting && _objToken.ContainsKey(token))
                return false;
            _objToken[token] = this[objIndex];
            return true;
        }
        /// <summary>
        /// 标记索引
        /// </summary>
        /// <param name="token">标记唯一标识</param>
        /// <param name="index">要标记的索引</param>
        /// <param name="coverOldSetting">覆盖已有标记符</param>
        /// <returns>返回标记是否成功</returns>
        public bool TagIndex(string token, int index, bool coverOldSetting = false)
        {
            if (!coverOldSetting && _indexToken.ContainsKey(token))
                return false;
            _indexToken[token] = index;
            return true;
        }

        // 需要能够对换某两行的位置，或者把某一行移动到某个位置
        public void Switch(int fstIndex, int secIndex)
        {
            var temp = this[fstIndex];
            this[fstIndex] = this[secIndex];
            this[secIndex] = temp;
        }

        // 遍历、逆序、等等 List所拥有的功能。
    }
}
