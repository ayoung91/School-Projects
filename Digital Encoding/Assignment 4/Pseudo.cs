using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment_4
{
    class Pseudo
    {
        public string binStr;

        public Pseudo(string bs)
        {
             this.binStr = bs;
        }
        public string getResult()
        {
            string result = "";
            string same = "";
            int len = binStr.Length;
            int numOnes = 0;

            for (int i = 0; i < len; i++)
            {
                try
                {
                    if (binStr.Substring(i, 1) == binStr.Substring(i + 1, 1))
                    {
                        if (binStr.Substring(i, 1) == "0")
                        {

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
                            result += "||";
                        }
                        else
                            result += "__";
                    }
                    else
                    {
                        if (binStr.Substring(i, 1) == "0")
                        {
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
                    if (binStr.Substring(i, 1) == "0")
                    {
                        numOnes++;
                        if (numOnes % 2 == 1)
                        {
                            result += "++";
                        }
                        else
                        {
                            result += "--";
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
