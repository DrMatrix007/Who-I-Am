using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Who_I_Am
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ItemList list = new ItemList("Numbers" ,new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9" });
        List<ItemList> lists = DataBaseHandler.GetAll();
        public MainPage()
        {
            InitializeComponent();



            DataBaseHandler.CreateTable();
            OrientationSensor.Start(SensorSpeed.Game);
            OrientationSensor.ReadingChanged += Update;


            listView.ItemsSource = lists;

            DataTemplate dataTemplate = new DataTemplate(() =>
            {
                var grid = new Grid();

                var nameLabel = new Label { FontAttributes = FontAttributes.Bold };
                var ageLabel = new Label();

                nameLabel.SetBinding(Label.TextProperty, "Name");
                ageLabel.SetBinding(Label.TextProperty, "String");


                grid.Children.Add(nameLabel);
                grid.Children.Add(ageLabel, 1, 0);

                return new ViewCell { View = grid };
            });

            listView.ItemTemplate = dataTemplate;


            


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
