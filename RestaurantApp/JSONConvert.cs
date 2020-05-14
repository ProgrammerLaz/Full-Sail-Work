using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace RestaurantApp
{
    class JSONConvert
    {
        public static void LoadDataToFile(string Data)
        {
            //Creates a directory (if it doesn't already exist) and starts writing streams of data into a .json file
            Directory.CreateDirectory(Program._directory);
            using (StreamWriter file = File.CreateText(Program._directory + "RondonLazaro_ConvertedData.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Data);
            }
        }
        public static string ExtractTransformLoadData()
        {
            //Initiates a MySQL connection and executes a MySQL command to search for all columns in a table so that it can be later loaded into a .json file
            DataTable dt = new DataTable();
            _ = new Database(Program.cs);
            using (MySqlCommand cmd = new MySqlCommand("select id,restaurantname,address,phone,hoursofoperation,price,usacitylocation,cuisine,foodrating,servicerating,ambiencerating,valuerating,overallrating,overallpossiblerating from restaurantprofiles", Database.con))
            {
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
                Database.con.Close();
                return JsonConvert.SerializeObject(rows);
            }
        }
    }
}
