using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithm
{
    public static class TextParserHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeSapan"></param>
        /// <returns></returns>
        public static int GetTimeSpanDoubleValue(string timeSapan)
        {
            int result = 0;

            if (timeSapan.Length % 2 == 1 || string.IsNullOrEmpty(timeSapan))
            {
                return -1;
            }

            for (int startIndex = 0; startIndex + 1 < timeSapan.Length; startIndex = startIndex + 2)
            {
                char charector = timeSapan[startIndex];
                int number;

                if (int.TryParse(charector.ToString(), out number))
                {
                    switch (timeSapan[startIndex + 1].ToString().ToLower())
                    {
                        case "y":
                            result += number * 365;
                            break;

                        case "m":
                            result += number * 30;
                            break;

                        case "w":
                            result += number * 7;
                            break;

                        case "d":
                            result += number * 1;
                            break;

                        default:
                            result = -1;
                            break;
                    }
                }
                else
                {
                    return -1;
                }
            }



            return result;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeSapan"></param>
        /// <returns></returns>
        public static string GetTimeSpanStringValueFromIntValue(int timeSapanDouble, string outputString = null)
        {
            string output = outputString;

            if (timeSapanDouble / 365 > 0)
            {
                output = timeSapanDouble / 365 + "y";
                return TextParserHelper.GetTimeSpanStringValueFromIntValue(timeSapanDouble % 365, output);
            }
            else if (timeSapanDouble / 30 > 0)
            {
                output = output + timeSapanDouble / 30 + "m";
                return TextParserHelper.GetTimeSpanStringValueFromIntValue(timeSapanDouble % 30, output);
            }
            else if (timeSapanDouble / 7 > 0)
            {
                output = output + timeSapanDouble / 7 + "w";
                return TextParserHelper.GetTimeSpanStringValueFromIntValue(timeSapanDouble % 7, output);
            }
            else if (timeSapanDouble / 1 > 0)
            {
                output = output + timeSapanDouble / 1 + "d";
                return TextParserHelper.GetTimeSpanStringValueFromIntValue(timeSapanDouble % 1, output);
            }

            return output;

        }

    }
}
