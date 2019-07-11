using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RekenmachineClassLibrary
{
    public class BinairConverteren
    {
        public static string ConvertNaarBinair(string input)
        {
            string resultaat = string.Empty;

            int getal = int.Parse(input);
            int rest;
            while (getal > 0)
            {
                rest = getal % 2;
                getal /= 2;
                resultaat = rest.ToString() + resultaat;
            }
            return resultaat;
        }

        public static string ConvertNaarDec(string input)
        {
            int lengte = input.Length;
            string resultaat;

            int[] getal = new int[lengte];
            double result = 0;
            for (int i = 0; i < lengte; i++)
            {
                getal[i] = Convert.ToInt32(Char.GetNumericValue(input[i]));
            }
            for (int i = lengte - 1; i >= 0; i--)
            {
                if (getal[i] == 1)
                {
                    result += Math.Pow(2, lengte - 1 - i);
                }
            }
            resultaat = result.ToString();
            return resultaat;
        }
    }
}
