using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class Manchester
    {
        public string binStr;

        public Manchester(string bs)
        {
             this.binStr = bs;
        }
        public string getResult()
        {
            string result = "";
            int len = binStr.Length;

            for(int i = 0; i < len; i++)
            {
                if (i != binStr.Length - 1)
                {
                    if (binStr.Substring(i, 1) != binStr.Substring(i + 1, 1))
                    {
                        if (binStr.Substring(i, 1) == "1")
                        {
                            result += "++||";
                        }
                        else
                        {
                            result += "--||";
                        }
                    }
                    else
                    {
                        if (binStr.Substring(i, 1) == "0")
                        {
                            result += "-||+||";
                        }
                        else
                        {
                            result += "+||-||";
                        }
                    }
                }  
                else
                {
                    if (binStr.Substring(i, 1) == "1")
                    {
                        result += "+";
                    }
                    else
                    {
                        result += "-";
                    }
                }
            }
            return result;
        }
    }
}
