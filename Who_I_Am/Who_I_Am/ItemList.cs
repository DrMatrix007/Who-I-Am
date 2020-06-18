using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using SQLitePCL;
using Microsoft.Data.Sqlite;
using SQLiteNetExtensions.Attributes;

namespace Who_I_Am
{
    class ItemList
    {
        [TextBlob("Lists")]
        public string[] list { get; set; } = new string[] { "Nothing HERE" };
        static int idCounter = 1;

        public string Name { get; set; }

        public string String { get; set; }

        private int id;
        [PrimaryKey, AutoIncrement,Column("Id")]
        public int Id { get => id; set => id = value; }


        ////public string ToString()
        ////{
        ////    return this.list.ToArray().ToString();
        ////}


        public int Current = 0;

        public int Length
        {
            get
            {
                return list.Length;
            }
        }


        public ItemList(string name,string[] list)
        {
            Name = name;
            this.list = list;
            Id = idCounter;
            idCounter++;
            String = list.ToString();
        }
        public ItemList()
        {
            this.list = null;
            Id = idCounter;
            idCounter++;
        }

        public string getCurrent()
        {
            return this.list[Current];
        }

        public string GetNext()
        {
            Current++;
            return this.list[Current];
        }


    }
}
