using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Who_I_Am
{
    class ItemList
    {
        public List<string> list = new List<string> {"Nothing HERE"};
        static int idCounter = 1;

        public string Name;

        public string String;

        private int id;
        [PrimaryKey, AutoIncrement]
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
                return list.Count;
            }
        }


        public ItemList(string name,List<string> list)
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
