using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace RestaurantApp
{
    class Program
    {
        //Database Location
        private static string cs = @"server= 127.0.0.1;userid=root;password=root;database=SampleRestaurantDatabase;port=3307";
        //Output Location
        private static string _directory = AppDomain.CurrentDomain.BaseDirectory + "/output/";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Admin, What Would You Like To Do Today?");
            Console.WriteLine("1. Convert The Restaurant Profile Table From SQL To JSON");
            Console.WriteLine("5. Exit");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    LoadDataToFile(ExtractTransformLoadData());
                    Console.WriteLine("File was successfully created and saved to the 'output' folder in the root application directory.");
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
        private static void LoadDataToFile(string Data)
        {
            Directory.CreateDirectory(_directory);
            using (StreamWriter file = File.CreateText(_directory + "RondonLazaro_ConvertedData.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Data);
            }
        }
        private static string ExtractTransformLoadData()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(cs))
            {
                using (MySqlCommand cmd = new MySqlCommand("select id,restaurantname,address,phone,hoursofoperation,price,usacitylocation,cuisine,foodrating,servicerating,ambiencerating,valuerating,overallrating,overallpossiblerating from restaurantprofiles", con))
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
                    con.Close();
                    return JsonConvert.SerializeObject(rows);
                }
            }
        }
    }
}
