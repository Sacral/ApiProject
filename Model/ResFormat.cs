using System.Collections.Generic;
using System;


namespace ApiProject.Model
{
    public class ResFormat<T>
    {

        public int status { get; set; }
        public string msg { get; set; }
        public string resMsg { get; set; }
        public List<T> resData { get; set; }

    }
}
