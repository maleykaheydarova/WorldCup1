using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorldCup1.Models;

namespace WorldCup1
{
    public class DB
    {
        public static List<Country> Countries { get; set; }
        public static List<Groups> Groups { get; set; }

        static DB()
        {
            Countries = new List<Country>();
            Groups = new List<Groups>();
        }
    }
}