using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace RestaurantApp
{
    class FiveStarRating
    {
        //Present menu to the user and iterate over chosen option(s)
        public static void FiveStarRatingMenu()
        {
            Console.WriteLine("Hello, how would you like to sort the data: ");
            Console.WriteLine("1. List Restaurants Alphabetically");
            Console.WriteLine("2. List Restaurants in Reverse Alphabetical");
            Console.WriteLine("3. Sort Restaurants From Best to Worst");
            Console.WriteLine("4. Sort Restaurants From Worst to Best");
            Console.WriteLine("5. Show Only X and Up");
            Console.WriteLine("6. Show Average of Reviews for Restaurants");
            Console.WriteLine("7. Dinner Spinner (Selects Random Restaurant)");
            Console.WriteLine("8. Top 10 Restaurants");
            Console.WriteLine("9. Back To Main Menu");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    ListRestaurantsAlphabetically();
                    break;
                case "2":
                    ListRestaurantsAlphabeticallyReverse();
                    break;
                case "3":
                    SortRestaurantsFromBestToWorst();
                    break;
                case "4":
                    SortRestaurantsFromWorstToBest();
                    break;
                case "5":
                    Console.WriteLine("1. Show the best (5 stars)");
                    Console.WriteLine("2. Show 4 stars and up");
                    Console.WriteLine("3. Show 3 stars and up");
                    Console.WriteLine("4. Show the worst (1 star)");
                    Console.WriteLine("5. Show unrated");
                    Console.WriteLine("6. Back");
                    string option2 = Console.ReadLine();
                    switch (option2)
                    {
                        case "1":
                            ShowFiveStarRestaurants();
                            break;
                        case "2":
                            ShowFourStarAboveRestaurants();
                            break;
                        case "3":
                            ShowThreeStarAboveRestaurants();
                            break;
                        case "4":
                            ShowOneStarRestaurants();
                            break;
                        case "5":
                            ShowUnratedRestaurants();
                            break;
                        case "6":
                            FiveStarRatingMenu();
                            break;
                        default:
                            Console.WriteLine("Incorrect option chosen, try again.");
                            FiveStarRatingMenu();
                            break;
                    }
                    break;
                case "6":
                    ShowAverageReviewsForRestaurants();
                    break;
                case "7":
                    DinnerSpinner();
                    break;
                case "8":
                    TopTenRestaurants();
                    break;
                case "9":
                    Program.Main(null);
                    break;
                default:
                    Console.WriteLine("Incorrect option chosen, try again.");
                    FiveStarRatingMenu();
                    break;
            }
        }
        private static void ListRestaurantsAlphabetically()
        {
            //Initiates a MySQL connection and executes a MySQL command to search for two columns in a table, ordered by a specific column
            DataTable dt = new DataTable();
            _ = new Database(Program.cs);
            using (MySqlCommand cmd = new MySqlCommand("select restaurantname,overallrating from restaurantprofiles order by restaurantname", Database.con))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(string.Format("|{0}|{1}|", reader["restaurantname"].ToString(), reader["overallrating"].ToString()));
                }
                Database.con.Close();
            }
        }
        private static void ListRestaurantsAlphabeticallyReverse()
        {
            //Initiates a MySQL connection and executes a MySQL command to search for two columns in a table, ordered by a specific column in descending order
            DataTable dt = new DataTable();
            _ = new Database(Program.cs);
            using (MySqlCommand cmd = new MySqlCommand("select restaurantname,overallrating from restaurantprofiles order by restaurantname desc", Database.con))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(string.Format("|{0}|{1}|", reader["restaurantname"].ToString(), reader["overallrating"].ToString()));
                }
                Database.con.Close();
            }
        }
        private static void SortRestaurantsFromBestToWorst()
        {
            //Initiates a MySQL connection and executes a MySQL command to search for two columns in a table, ordered by a specific column in descending order
            DataTable dt = new DataTable();
            _ = new Database(Program.cs);
            using (MySqlCommand cmd = new MySqlCommand("select restaurantname,overallrating from restaurantprofiles order by overallrating desc", Database.con))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(string.Format("|{0}|{1}|", reader["restaurantname"].ToString(), reader["overallrating"].ToString()));
                }
                Database.con.Close();
            }
        }
        private static void SortRestaurantsFromWorstToBest()
        {
            //Initiates a MySQL connection and executes a MySQL command to search for two columns in a table, ordered by a specific column
            DataTable dt = new DataTable();
            _ = new Database(Program.cs);
            using (MySqlCommand cmd = new MySqlCommand("select restaurantname,overallrating from restaurantprofiles order by overallrating", Database.con))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(string.Format("|{0}|{1}|", reader["restaurantname"].ToString(), reader["overallrating"].ToString()));
                }
                Database.con.Close();
            }
        }
        private static void ShowFiveStarRestaurants()
        {
            //Initiates a MySQL connection and executes a MySQL command to search for two columns in a table, where a specific row is equal to the given value
            DataTable dt = new DataTable();
            _ = new Database(Program.cs);
            using (MySqlCommand cmd = new MySqlCommand("select restaurantname,overallrating from restaurantprofiles where overallrating = 5", Database.con))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write(string.Format("|{0}|", reader["restaurantname"].ToString()));
                    ColorRating(reader["overallrating"].ToString());
                    Console.WriteLine();
                }
                Database.con.Close();
            }
        }
        private static void ShowFourStarAboveRestaurants()
        {
            //Initiates a MySQL connection and executes a MySQL command to search for two columns in a table, where a specific row is equal to the given value
            DataTable dt = new DataTable();
            _ = new Database(Program.cs);
            using (MySqlCommand cmd = new MySqlCommand("select restaurantname,overallrating from restaurantprofiles where overallrating >= 4", Database.con))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write(string.Format("|{0}|", reader["restaurantname"].ToString()));
                    ColorRating(reader["overallrating"].ToString());
                    Console.WriteLine();
                }
                Database.con.Close();
            }
        }
        private static void ShowThreeStarAboveRestaurants()
        {
            //Initiates a MySQL connection and executes a MySQL command to search for two columns in a table, where a specific row is equal to the given value
            DataTable dt = new DataTable();
            _ = new Database(Program.cs);
            using (MySqlCommand cmd = new MySqlCommand("select restaurantname,overallrating from restaurantprofiles where overallrating >= 3", Database.con))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write(string.Format("|{0}|", reader["restaurantname"].ToString()));
                    ColorRating(reader["overallrating"].ToString());
                    Console.WriteLine();
                }
                Database.con.Close();
            }
        }
        private static void ShowOneStarRestaurants()
        {
            //Initiates a MySQL connection and executes a MySQL command to search for two columns in a table, where a specific row is equal to the given value
            DataTable dt = new DataTable();
            _ = new Database(Program.cs);
            using (MySqlCommand cmd = new MySqlCommand("select restaurantname,overallrating from restaurantprofiles where overallrating >= 1 and overallrating < 2", Database.con))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write(string.Format("|{0}|", reader["restaurantname"].ToString()));
                    ColorRating(reader["overallrating"].ToString());
                    Console.WriteLine();
                }
                Database.con.Close();
            }
        }
        private static void ShowUnratedRestaurants()
        {
            //Initiates a MySQL connection and executes a MySQL command to search for two columns in a table, where a specific row is equal to the given value
            DataTable dt = new DataTable();
            _ = new Database(Program.cs);
            using (MySqlCommand cmd = new MySqlCommand("select restaurantname,overallrating from restaurantprofiles where overallrating is null", Database.con))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write(string.Format("|{0}|", reader["restaurantname"].ToString()));
                    ColorRating(reader["overallrating"].ToString());
                    Console.WriteLine();
                }
                Database.con.Close();
            }
        }
        private static void ShowAverageReviewsForRestaurants()
        {
            //Initiates a MySQL connection and executes a MySQL command to search for two columns in a table, where a join is included to obtain reference data from another table
            DataTable dt = new DataTable();
            _ = new Database(Program.cs);
            using (MySqlCommand cmd = new MySqlCommand("select rp.restaurantname,avg(rr.reviewscore) as average from restaurantprofiles rp join restaurantreviews rr on rp.id = rr.restaurantid group by rp.restaurantname", Database.con))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!string.IsNullOrWhiteSpace(reader["average"].ToString()))
                    {
                        Console.Write(reader["restaurantname"].ToString() + " ");
                        BarGraphs.DrawGraph(reader["average"].ToString());
                        Console.Write(" Average: " + reader["average"].ToString() + "%");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write(reader["restaurantname"].ToString() + " ");
                        BarGraphs.DrawGraph(reader["average"].ToString());
                        Console.Write("Average: N/A");
                        Console.WriteLine();
                    }
                }
                Database.con.Close();
            }
        }
        private static void DinnerSpinner()
        {
            //Initiates a MySQL connection and executes a MySQL command to search for two columns in a table, where a specific row is equal to the given value
            DataTable dt = new DataTable();
            _ = new Database(Program.cs);
            using (MySqlCommand cmd = new MySqlCommand("select rp.restaurantname,avg(rr.reviewscore) as average from restaurantprofiles rp join restaurantreviews rr on rp.id = rr.restaurantid group by rp.restaurantname order by rand() limit 1", Database.con))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!string.IsNullOrWhiteSpace(reader["average"].ToString()))
                    {
                        Console.Write(reader["restaurantname"].ToString() + " ");
                        BarGraphs.DrawGraph(reader["average"].ToString());
                        Console.Write(" Average: " + reader["average"].ToString() + "%");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write(reader["restaurantname"].ToString() + " ");
                        BarGraphs.DrawGraph(reader["average"].ToString());
                        Console.Write("Average: N/A");
                        Console.WriteLine();
                    }
                }
                Database.con.Close();
            }
        }
        private static void TopTenRestaurants()
        {
            //Initiates a MySQL connection and executes a MySQL command to search for two columns in a table, where a join is included to obtain reference data from another table
            DataTable dt = new DataTable();
            _ = new Database(Program.cs);
            using (MySqlCommand cmd = new MySqlCommand("select rp.restaurantname,avg(rr.reviewscore) as average from restaurantprofiles rp join restaurantreviews rr on rp.id = rr.restaurantid where rr.reviewscore >= 70 group by rp.restaurantname desc limit 10", Database.con))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!string.IsNullOrWhiteSpace(reader["average"].ToString()))
                    {
                        Console.Write(reader["restaurantname"].ToString() + " ");
                        BarGraphs.DrawGraph(reader["average"].ToString());
                        Console.Write(" Average: " + reader["average"].ToString() + "%");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write(reader["restaurantname"].ToString() + " ");
                        BarGraphs.DrawGraph(reader["average"].ToString());
                        Console.Write("Average: N/A");
                        Console.WriteLine();
                    }
                }
                Database.con.Close();
            }
        }
        private static void ColorRating(string OverallRating)
        {
            //Colors given console text based on given criteria and resets the console after
            if (!string.IsNullOrWhiteSpace(OverallRating))
            {
                double OverallRatingDouble = Math.Round(double.Parse(OverallRating), MidpointRounding.AwayFromZero);
                if (OverallRatingDouble >= 1.00 && OverallRatingDouble < 1.50)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*");
                    Console.ResetColor();
                }
                else if (OverallRatingDouble >= 2.00 && OverallRatingDouble < 2.50)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("**");
                    Console.ResetColor();
                }
                else if (OverallRatingDouble >= 3.00 && OverallRatingDouble < 3.50)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("***");
                    Console.ResetColor();
                }
                else if (OverallRatingDouble >= 4.00 && OverallRatingDouble < 4.50)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("****");
                    Console.ResetColor();
                }
                else if (OverallRatingDouble >= 4.50)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("*****");
                    Console.ResetColor();
                }
            }
        }
    }
}
