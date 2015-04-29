using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class B8ZS
    {
        public string binStr;

        public B8ZS(string bs)
        {
             this.binStr = bs;
        }
        public string getResult()
        {
            bool top = true;
            bool eightZeros = false;
            int j = 0;
            string result = "";
            string same = "";
            int len = binStr.Length;
            int numOnes = 0;

            for (int i = 0; i < len; i++)
            {
                try
                {
                    for (j = i; j < i + 7; j++)
                    {
                        if (binStr.Substring(j, 1) == "0" && binStr.Substring(j, 1) == binStr.Substring(j + 1, 1))
                            eightZeros = true;
                        else
                        { 
                            eightZeros = false;
                            break;
                        }
                    }

                    if (eightZeros == true)
                    {
                        if(top == true)
                        {
                            result += "______|--||++|__|++|__|";
                            numOnes++;
                        }
                        else
                        {
                            result += "______|++||--|__|--|__|";
                            numOnes++;
                        }
                        i += 8;
                        eightZeros = false;
                    }
                    if (binStr.Substring(i, 1) == binStr.Substring(i + 1, 1))
                    {
                        if (binStr.Substring(i, 1) == "1")
                        {
                            numOnes++;
                            if (numOnes % 2 == 1)
                            {
                                result += "++";
                                same = "++";
                                top = false;
                            }
                            else
                            {
                                result += "--";
                                same = "--";
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
                                same = "++";
                                top = false;
                            }
                            else
                            {
                                result += "--";
                                same = "--";
                                top = true;
                            }
                            result += "|";
                        }
                        else
                        {
                            result += "__|";
                        }
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
                    {
                        result += "__";
                    }
                }                
            }
            return result;
        }
    }
}
