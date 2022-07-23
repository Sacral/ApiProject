using System.Collections.Generic;
using System;


namespace ApiProject.Model
{

    public class ResFormat<T>
    {
        public const string errmsg1 = "包含了非中英文的字元";
        public const string errmsg2 = "id 不得為0或小於0";
        public int status { get; set; }
        public string msg { get; set; }
        public string resMsg { get; set; }
        public List<T> resData { get; set; }

    }
}
