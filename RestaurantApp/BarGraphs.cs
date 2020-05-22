using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace RestaurantApp
{
    class BarGraphs
    {
        public static void DrawGraph(string Rating)
        {
            //Colors given console text based on given criteria and resets the console after
            if (!string.IsNullOrWhiteSpace(Rating))
            {
                //Based on what rating we pass in we convert it to double and apply conditional logic based on result (i.e. color the bar graph)
                double AverageRatingDouble = double.Parse(Rating);
                if (AverageRatingDouble > 0.00 && AverageRatingDouble < 10.00)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("" + " ");
                    Console.ResetColor();
                }
                else if (AverageRatingDouble >= 10.00 && AverageRatingDouble < 20.00)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(" " + " ");
                    Console.ResetColor();
                }
                else if (AverageRatingDouble >= 20.00 && AverageRatingDouble < 30.00)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("  " + " ");
                    Console.ResetColor();
                }
                else if (AverageRatingDouble >= 30.00 && AverageRatingDouble < 40.00)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write("   " + " ");
                    Console.ResetColor();
                }
                else if (AverageRatingDouble >= 40.00 && AverageRatingDouble < 50.00)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write("    " + " ");
                    Console.ResetColor();
                }
                else if (AverageRatingDouble >= 50.00 && AverageRatingDouble < 60.00)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write("     " + " ");
                    Console.ResetColor();
                }
                else if (AverageRatingDouble >= 60.00 && AverageRatingDouble < 70.00)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write("      " + " ");
                    Console.ResetColor();
                }
                else if (AverageRatingDouble >= 70.00 && AverageRatingDouble < 80.00)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write("       " + " ");
                    Console.ResetColor();
                }
                else if (AverageRatingDouble >= 80.00 && AverageRatingDouble < 90.00)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write("        " + " ");
                    Console.ResetColor();
                }
                else if (AverageRatingDouble >= 90.00 && AverageRatingDouble < 100.00)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write("         " + " ");
                    Console.ResetColor();
                }
                else if (AverageRatingDouble == 100.00)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write("          " + " ");
                    Console.ResetColor();
                }
            }
        }
    }
}
