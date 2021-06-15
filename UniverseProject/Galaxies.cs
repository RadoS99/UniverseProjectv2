using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;
using System.Globalization;


namespace UniverseProject
{
    class Galaxies : Data
    {


        string name;
        string type;
        double age;
        string strage;
        
        string agesymbol;
        int numcount;

        public string Name { get => name; set => name = value; }

        public string Type { get => type; set => type = value; }
        public double Age { get => age; set => age = value; }
        public string Strage { get => strage; set => strage = value; }
        
        public int Numcount { get => numcount; set => numcount = value; }

        public Galaxies() { }

        public Galaxies(string input_data, string name, string type, string [] splitter, double age, string strage) : base(input_data, splitter)
        {
            this.Input_data = input_data;
            this.Splitter = splitter;
            this.age = age;
            this.Input_data = input_data;
            this.name = name;
            this.type = type;



        }
        
        public string NameCheck()
        {

            {
                try
                {
                    name = Input_data.Split('[', ']')[1];
                }
                catch (System.IndexOutOfRangeException)
                {
                    if (Input_data.Contains("[") == false || Input_data.Contains("]") == false)
                    {
                        name = "Not found";
                    }
                }
            }
            return name;
        }
        public string TypeCheck()
        {

            {

                string[] typecheck = { "elliptical", "lenticular", "spiral", "irregular" };
                foreach (string item in typecheck)
                {
                    if (Input_data.Contains(item))
                    {
                        type = item;
                        break;
                    }
                    else
                    { type = "none"; }
                }

            }
            return type;
        }
        public string AgeCheck()
        {


            foreach (string item in Splitter)
            {
                if (double.TryParse(item, out var parsedNumber) == true)
                {

                    double temp;
                    double.TryParse(item, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out temp);
                    age = temp;
                }
            }

            if (age > 1000000000)
            {
                age = Math.Round(age / 1000000000, 1);
                agesymbol = "B";
            }
            else if (age < 1000000000)
            {
                age = Math.Round(age / 1000000, 1);
                agesymbol = "M";
            }
            strage = $"{age}{agesymbol}";


            return strage;
        }

    }
}
    
    

