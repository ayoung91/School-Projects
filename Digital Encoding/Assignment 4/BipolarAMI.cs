using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class BipolarAMI
    {
        public string binStr;

        public BipolarAMI(string bs)
        {
             this.binStr = bs;
        }
        public string getResult()
        {
            string result = "";
            int len = binStr.Length;
            int numOnes = 0;

            for (int i = 0; i < len; i++)
            {
                try
                {
                    if (binStr.Substring(i, 1) == binStr.Substring(i + 1, 1))
                    {
                        if (binStr.Substring(i, 1) == "1")
                        {
                            numOnes++;
                            if (numOnes % 2 == 1)
                                result += "++";
                            else
                                result += "--";
                            result += "||";
                        }
                        else
                            result += "__";                              
                    }
                    else
                    {
                        if (binStr.Substring(i, 1) == "1")
                        {                            
                            numOnes++;
                            if (numOnes % 2 == 1)
                                result += "++";
                            else
                                result += "--";
                            result += "|";
                        }
                        else
                            result += "__|";
                    }
                }
                catch
                {
                    if(binStr.Substring(i, 1) == "1")
                    {
                        numOnes++;
                        if (numOnes % 2 == 1)
                            result += "++";
                        else
                            result += "--";
                    }
                    else
                        result += "__";
                }                
            }
            return result;
        }
    }
}
