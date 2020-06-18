using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using SQLite;
using System.IO;


namespace Who_I_Am
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ItemList list = new ItemList("Numbers" ,new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" });
        public MainPage()
        {
            InitializeComponent();



            
            OrientationSensor.Start(SensorSpeed.Game);
            OrientationSensor.ReadingChanged += Update;


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var backingFile = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            SQLiteConnection db = new SQLiteConnection(Path.Combine(backingFile, "Test1.db"));//, SQLiteOpenFlags.Create);
            
            
            db.CreateTable<ItemList>();
       
            db.Insert(list);
            listView.ItemsSource = db.Table<ItemList>().ToArray();

        }

        private string getString(float Angle, float Sensetivity = 30f)
        {



            if (Math.Abs(Angle) > 90 + Sensetivity)
            {
                return "True";

            }
            else if (Math.Abs(Angle) < 90 - Sensetivity)
            {
                return "False";
            }
            return "None";



        }

        public string OLD = "None";

        private void Update(object sender, OrientationSensorChangedEventArgs e)
        {
            var ea = (e.Reading.Orientation).ToEulerAngles();

            ea.X = 0f;//(float)Math.Round(ea.X, 2); 
            ea.Y = (float)Math.Round(ea.Y, 2) * (float)(180 / Math.PI);
            ea.Z = 0f;//(float)Math.Round(ea.Z, 2);
            var current = getString(ea.Y);

            label.Text = list.getCurrent().ToString();

            if (OLD != current)
            {
                if (current == "True")
                {
                    label.Text = list.GetNext().ToString();
                }
                if (current == "Fasle")
                {
                    label.Text = list.GetNext().ToString();
                }
            }


            OLD = getString(ea.Y);
        }
    }
}
