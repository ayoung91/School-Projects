using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class HDB3
    {
        public string binStr;

        public HDB3(string bs)
        {
             this.binStr = bs;
        }
        public string getResult()
        {
            bool top = true;
            bool fourZeros = false;
            int j = 0;
            string result = "";
            int len = binStr.Length;
            int numOnes = 0;

            for (int i = 0; i < len; i++)
            {
                try
                {
                    for (j = i; j < i + 3; j++)
                    {
                        if (binStr.Substring(j, 1) == "0" && binStr.Substring(j, 1) == binStr.Substring(j + 1, 1))
                            fourZeros = true;
                        else
                        {
                            fourZeros = false;
                            break;
                        }
                    }

                    if (fourZeros == true)
                    {
                        if(top == true)
                            result += "____|--|__";
                        else
                            result += "____|++|__";
                        i += 3;
                        fourZeros = false;
                    }
                    
                    if (binStr.Substring(i, 1) == binStr.Substring(i + 1, 1))
                    {
                        if (binStr.Substring(i, 1) == "1")
                        {
                            numOnes++;
                            if (numOnes % 2 == 1)
                            {
                                result += "++";
                                top = false;
                            }
                            else
                            {
                                result += "--";
                                top = true;
                            }
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
                            {
                                result += "++";
                                top = false;
                            }
                            else
                            {
                                result += "--";
                                top = true;
                            }
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
                        {
                            result += "++";
                            top = false;
                        }
                        else
                        {
                            result += "--";
                            top = false;
                        } 
                    }
                    else
                        result += "__";
                }                
            }
            return result;
        }
    }
}
