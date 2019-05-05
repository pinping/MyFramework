using System;
using System.Text.RegularExpressions;

namespace MyFramework {
    public static class StringExtension {

        public static bool IsNull(string str) {
            //if (string.IsNullOrWhiteSpace(str)) {
            //    return true;
            //}
            if (str.Length == 0) {
                return true;
            }
            if (str == "") {
                return true;
            }
            if (string.Empty == str) {
                return true;
            }
            if (string.IsNullOrEmpty(str)) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 去掉字符串中的数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveNumber(string str) {
            return Regex.Replace(str, @"\d", "");
        }

        /// <summary>
        /// 去掉字符串中的非数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveNotNumber(string str) {
            return Regex.Replace(str, @"[^\d]*", "");
        }

        ///<summary>
        /// 截前后字符(串)
        ///</summary>
        ///<param name="val">原字符串</param>
        ///<param name="str">要截掉的字符串</param>
        ///<param name="all">是否贪婪</param>
        ///<returns></returns>
        public static string GetString(string val, string str, bool all) {
            return Regex.Replace(val, @"(^(" + str + ")" + (all ? "*" : "") + "|(" + str + ")" + (all ? "*" : "") + "$)", "");
        }


        public static bool Contains(this string source, string toCheck, StringComparison comp) {
            return source.IndexOf(toCheck, comp) >= 0;
        }
    }
}
