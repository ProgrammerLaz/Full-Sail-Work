using System;

namespace RestaurantApp
{
    class Program
    {
        //Database Location
        public static string cs = @"server= 127.0.0.1;userid=root;password=root;database=SampleRestaurantDatabase;port=3306";
        //Output Location
        public static string _directory = AppDomain.CurrentDomain.BaseDirectory + "/output/";
        public static void Main(string[] args)
        {
            //Present menu to the user and iterate over chosen option(s)
            Console.WriteLine("Hello Admin, What Would You Like To Do Today?");
            Console.WriteLine("1. Convert The Restaurant Profile Table From SQL To JSON");
            Console.WriteLine("2. Showcase Our 5 Star Rating System");
            Console.WriteLine("5. Exit");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    JSONConvert.LoadDataToFile(JSONConvert.ExtractTransformLoadData());
                    Console.WriteLine("File was successfully created and saved to the 'output' folder in the root application directory.");
                    break;
                case "2":
                    FiveStarRating.FiveStarRatingMenu();
                    break;
                case "5":
                    Console.WriteLine("Shutting down...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Incorrect option chosen, try again.");
                    Console.WriteLine();
                    Main(null);
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Press The Return Key To Go Back To The Main Menu...");
            Console.ReadKey();
            Main(null);
        }
    }
}
