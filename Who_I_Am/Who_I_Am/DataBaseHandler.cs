using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using System.Dynamic;

namespace Who_I_Am
{
    static class DataBaseHandler
    {
        static string backingFile = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public static SQLiteConnection db = new SQLiteConnection(Path.Combine(backingFile, "Test.db"));// SQLiteOpenFlags.Create);

        public static List<ItemList> GetAll()
        {
            return db.Table<ItemList>().ToList();

        }

        public static void CreateTable(){
            db.CreateTable<ItemList>();
        }

        public static void AddList(ItemList itemList)
        {
            db.Insert(itemList);
        }
        public static void Dispose()
        {
            db.Dispose();
            
        }
        public static string ToString()
        {
            return db.Table<ItemList>().ToList().ToString(); 
        }
    
    
    }
}
