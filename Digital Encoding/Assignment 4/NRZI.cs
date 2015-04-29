using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class NRZI 
    {
       public string binStr;
        public NRZI(string bs)
        {
             this.binStr = bs;
        }
        public string getResult()
        {            
            string result = "";
            string same = "--";
            int len = binStr.Length;
            int numOnes = 0;

            for (int i = 0; i < len; i++ )
            {
                try
                {
                    if (binStr.Substring(i, 1) == binStr.Substring(i + 1, 1))
                    {
                        if (binStr.Substring(i, 1) == "1")
                        {
                            if (i != 0)
                                result += "||";                       
                            numOnes++;
                            if (numOnes % 2 == 1)
                            {
                                result += "++";
                                same = "++";
                            }
                            else
                            {
                                result += "--";
                                same = "--";
                            }
                        }
                        else
                            result += same;
                    }
                    else
                    {
                        if (binStr.Substring(i, 1) == "1")
                        {
                            if (i != 0)
                                result += "||";                        
                            numOnes++;
                            if (numOnes % 2 == 1)
                            {
                                result += "++";
                                same = "++";
                            }
                            else
                            {
                                result += "--";
                                same = "--";
                            }
                        }
                        else
                            result += same;
                    }
                }
                catch
                {
                    if (binStr.Substring(i,1) == "1")
                    {
                        numOnes++;
                        if (numOnes % 2 == 1)
                        {
                            result += "||++";
                            same = "||++";
                        }
                        else
                        {
                            result += "||--";
                            same = "||--";
                        }
                    }
                    else
                        result += same;
                }
            }
            return result;
        }
    }
}
