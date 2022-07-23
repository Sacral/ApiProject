using ApiProject.Model;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace ApiProject.UtiFunction
{
    public class UtiFunctions
    {
        public static ResFormat ResponseString(int rowsAffected , string errMsg)
        {
            var res = new ResFormat();

            if (rowsAffected>=0)
            {
                res = new ResFormat
                {
                    status = 1,
                    msg = "success",
                    resData = ""
                };

            }
            else
            {
                //rowsAffected ==-1

                res = new ResFormat
                {
                    status = 0,
                    msg = "error",
                    resData = errMsg
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
                        if (Char.IsLetter(ch[i]))
                        {
                            return false;
                        }

                    }
                }
            }
            return false;
        }

        public static bool isChinese(char c)
        {
            return c >= 0x4E00 && c <= 0x9FA5;
        }
    }
}
