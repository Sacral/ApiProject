using ApiProject.Model;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace ApiProject.UtiFunction
{
    public class UtiFunctions
    {
        public static ResFormat<T> ResponseString<T>(int rowsAffected , string resMsg , List<T> depData = null )
        {
            var res = new ResFormat<T>();

            if (rowsAffected>=0&& depData==null)
            {
                res = new ResFormat<T>
                {
                    status = 1,
                    msg = "success",
                    resMsg = resMsg
                };

            }else if (depData != null)
            {
                res = new ResFormat<T>
                {
                    status = 1,
                    msg = "success",
                    resData = depData
                };
            }
            else
            {
                //rowsAffected ==-1

                res = new ResFormat<T>
                {
                    status = 0,
                    msg = "error",
                    resMsg = resMsg
                };

            }

            return res;

        }

        public static bool checkString(string str)
        {
            char[] ch = str.ToCharArray();
            bool test;
            if (str != null)
            {
                for (int i = 0; i < ch.Length; i++)
                {
                    test = isChinese(ch[i]);

                    if (test == false)
                    {
                        //d=判斷是否為英文
                        if (!Char.IsLetter(ch[i]))
                        {
                            return false;
                        }

                    }
                }
            }
            return true;
        }

        public static bool isChinese(char c)
        {
            return c >= 0x4E00 && c <= 0x9FA5;
        }
    }
}
