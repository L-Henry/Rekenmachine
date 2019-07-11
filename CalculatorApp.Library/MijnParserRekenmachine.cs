using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Library
{
    public static class MijnParserRekenmachine
    {


        public static double Bereken(string alles)
        {
            //int lengte = alles.Length;

            if (alles[0] == '-' && alles[1] == '-')
            {
                alles = alles.Remove(0, 2);
            }

            if (double.TryParse(alles, out double test))
            {
                return double.Parse(alles);
            }

            //haakjes
            if (alles.IndexOf('(') >= 0)
            {
                alles = Haakjes(alles).ToString();
            }

            //kwadraat en sqrt zijn niet diep getest.
            for (int tel = 1; tel < alles.Length - 1; tel++)
            {
                if (alles[tel] == '^')
                {
                    alles = VerwerkMacht(alles, tel).ToString();
                }
            }

            //vermeigvuldig en deling
            for (int tel = 1; tel < alles.Length - 1; tel++)
            {
                if (alles[tel] == '*' || alles[tel] == '/')
                {
                    alles = VerwerkMaalDeel(alles, tel).ToString();
                }
            }

            //som en verschil
            for (int tel = 1; tel < alles.Length - 1; tel++)
            {
                if ((alles[tel] == '-' && Char.IsNumber(alles[tel - 1])) || alles[tel] == '+')
                {
                    alles = VerwerkSomVerschil(alles, tel).ToString();
                }
            }
            return double.Parse(alles);
        }

        public static double Haakjes(string alles)
        {
            int lengte = alles.Length;

            int haakjeOpen = alles.LastIndexOf('(');
            string rest = alles.Substring(haakjeOpen + 1, lengte - haakjeOpen - 1);
            int haakjeToe = rest.IndexOf(')');
            string binnenHaakjes = rest.Substring(0, haakjeToe);
            string binnenHaakjesBerekend = Bereken(binnenHaakjes).ToString();
            if (haakjeOpen == 0)
            {
                return Bereken(binnenHaakjesBerekend + rest.Substring(haakjeToe + 1, rest.Length - haakjeToe - 1));
            }
            else if (haakjeToe == rest.Length - 1)
            {
                return Bereken(alles.Substring(0, haakjeOpen) + binnenHaakjesBerekend);
            }
            else
            {
                return Bereken(alles.Substring(0, haakjeOpen) + binnenHaakjesBerekend + rest.Substring(haakjeToe + 1, rest.Length - haakjeToe - 1));
            }
        }

        public static double VerwerkMacht(string alles, int tel)
        {
            int lengte = alles.Length;

            int Index = tel;
            int i = 0;
            int j = 1;

            while (Index - i > 0 && (Char.IsNumber(alles[Index - 1 - i]) || alles[Index - 1 - i] == ',' || (alles[Index - 1 - i] == '-' && tel - i - 1 > 0 && Char.IsSymbol(alles[Index - i - 2]))))//&& ( minIndex > 1 && Char.IsSymbol(alles[Index - i - 1]) ) ) ) )
            {
                i++;
            }
            while (Index + j < lengte - 1 && (Char.IsNumber(alles[Index + j + 1]) || alles[Index + j + 1] == ',' || (Char.IsSymbol(alles[Index]) && Char.IsSymbol(alles[Index + 1]))))
            {
                j++;
            }

            double min1 = double.Parse(alles.Substring(Index - i, i));
            double min2 = double.Parse(alles.Substring(Index + 1, j));
            double min;
            if (min1 < 0)
            {
                throw new Exception("Vierkantswortel van negatief getal kan niet.");
            }
            else if (min2 >= 1)
            {
                min = Math.Pow(min1, min2);
            }
            else
            {
                min = Math.Pow(min1, min2);
            }
            return Bereken(alles.Substring(0, Index - i) + min + alles.Substring(Index + j + 1, lengte - 1 - Index - j));
        }

        public static double VerwerkMaalDeel(string alles, int tel)
        {
            int lengte = alles.Length;

            int Index = tel;
            int i = 0;
            int j = 1;

            while (Index - i > 0 && (Char.IsNumber(alles[Index - 1 - i]) || alles[Index - 1 - i] == ',' || (alles[Index - 1 - i] == '-' && tel - i - 1 > 0 && Char.IsSymbol(alles[Index - i - 2]))))//&& ( minIndex > 1 && Char.IsSymbol(alles[Index - i - 1]) ) ) ) )
            {
                i++;
            }
            while (Index + j < lengte - 1 && (Char.IsNumber(alles[Index + j + 1]) || alles[Index + j + 1] == ',' || (Char.IsSymbol(alles[Index]) && Char.IsSymbol(alles[Index + 1]))))
            {
                j++;
            }

            double min1 = double.Parse(alles.Substring(Index - i, i));
            double min2 = double.Parse(alles.Substring(Index + 1, j));
            double min;
            if (alles[tel] == '*')
            {
                min = min1 * min2;
            }
            else if (min2 == 0)
            {
                throw new Exception("Delen door 0 kan niet.");
            }
            else
            {
                min = min1 / min2;
            }
            return Bereken(alles.Substring(0, Index - i) + min + alles.Substring(Index + j + 1, lengte - 1 - Index - j));
        }

        public static double VerwerkSomVerschil(string alles, int tel)
        {
            int lengte = alles.Length;

            int Index = tel;
            int i = 0;
            int j = 1;

            while (Index - i > 0 && (Char.IsNumber(alles[Index - 1 - i]) || alles[Index - 1 - i] == '-' || alles[Index - 1 - i] == ',')) //&& ( minIndex > 1 && Char.IsSymbol(alles[minIndex - i - 1]) ) ) ) )
            {
                i++;
            }
            while (Index + j < lengte - 1 && (Char.IsNumber(alles[Index + j + 1]) || alles[Index + j + 1] == ',' || (Char.IsSymbol(alles[Index]) && Char.IsSymbol(alles[Index + 1]))))
            {
                j++;
            }

            double min1 = double.Parse(alles.Substring(Index - i, i));
            double min2 = double.Parse(alles.Substring(Index + 1, j));
            double min;
            if (alles[tel] == '-')
            {
                min = min1 - min2;
            }
            else
            {
                min = min1 + min2;
            }
            return Bereken(alles.Substring(0, Index - i) + min + alles.Substring(Index + j + 1, lengte - 1 - Index - j));
        }











        //vergelijk //niet fucntioneel
        /*
        for (int tel = 1; tel < lengte - 1; tel++)
        {
            if (alles[tel] == '=' && Char.IsNumber(alles[tel - 1]))
            {
                int Index = tel;
                int i = 0;
                int j = 1;

                while (Index - i > 0 && (Char.IsNumber(alles[Index - 1 - i]) || alles[Index - 1 - i] == '-' || alles[Index - 1 - i] == ',')) //&& ( minIndex > 1 && Char.IsSymbol(alles[minIndex - i - 1]) ) ) ) )
                {
                    i++;
                }
                while (Index + j < lengte - 1 && (Char.IsNumber(alles[Index + j + 1]) || alles[Index + j + 1] == ',' || (Char.IsSymbol(alles[Index]) && Char.IsSymbol(alles[Index + 1]))))
                {
                    j++;
                }

                double min1 = double.Parse(alles.Substring(Index - i, i));
                double min2 = double.Parse(alles.Substring(Index + 1, j));
                double min;
                if (min1 == min2)
                {
                    min = 1;
                    Console.WriteLine($"{min1} is gelijk aan {min2}");
                }
                else
                {
                    min = 0;
                    Console.WriteLine($"{min1} is niet gelijk gelijk aan {min2}");

                }
                return min;
            }
            */
            // Niet functioneel
            /*
        public static bool IsGelijk(double min1, double min2)
        {
            if (min1 == min2)
            {
                Console.WriteLine($"{min1} is gelijk aan {min2}");

                return true;
            }
            else
            {
                Console.WriteLine($"{min1} is niet gelijk gelijk aan {min2}");
                return false;
            }
        }*/
    }
}
