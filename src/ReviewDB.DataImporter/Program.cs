using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReviewDB.DataImporter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            LoadJson();
        }

        public static void LoadJson()
        {
            using (StreamReader r = new StreamReader("movie_ids_09_26_2018.json"))
            {
                string json = r.ReadToEnd();
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
            }
        }
    }

    public class Item
    {
        public bool adult;
        public int id;
        public string original_title;
        public double popularity;
        public bool video;
    }
}
