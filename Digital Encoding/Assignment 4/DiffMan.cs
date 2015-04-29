using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class DiffMan
    {
        public string binStr;

        public DiffMan(string bs)
        {
            this.binStr = bs;
        }
        public string getResult()
        {
            bool oneTop = true;          //True if the transition for "1" is positive
            int numOnes = 0;             //Huge bug fix
            int i = 0;
            string result = "";
            int len = binStr.Length;

            if (binStr.Substring(0, 1) == "1")
            {
                result += "++||";
                oneTop = false;
            }
            else
            {
                result += "--||";
            }

            for (i = 0; i < len; i++)
            {
                if (i != binStr.Length - 1)
                {
                    if (binStr.Substring(i + 1, 1) == "1" && oneTop == true)
                    {
                        result += "++||";
                        oneTop = false;
                    }
                    else if (binStr.Substring(i + 1, 1) == "1" && oneTop == false)
                    {
                        result += "--||";
                        oneTop = true;
                    }
                    else if (binStr.Substring(i + 1, 1) == "0" && oneTop == true)
                    {
                        result += "+||-||";
                    }
                    else
                    {
                        result += "-||+||";
                    }
                }
                else
                {
                    if (binStr.Substring(i, 1) == "1" && oneTop == true)
                        result += "+";
                    else if (binStr.Substring(i, 1) == "1" && oneTop == false)
                        result += "-";
                    else if (binStr.Substring(i, 1) == "0" && oneTop == true)
                        result += "+";
                    else
                        result += "-";
                }
            }
            return result;
        }
    }
}

