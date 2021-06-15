using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace UniverseProject
{
    class Moons:Data
    {
        string name;
       
        int numcount;
        public Moons() { }
        public Moons(string name, string input_data,string[] splitter) : base(input_data, splitter)
        {
            this.Input_data = input_data;
            this.Splitter = splitter;
            this.name = name;
        }

        public string Name { get => name; set => name = value; }
        
        public int Numcount { get => numcount; set => numcount = value; }

        public string PlanetNameCheck()
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
            return name;
        }
        public string NameCheck()
        {

            try
            {
                name = Input_data.Split('[', ']')[3];
            }
            catch (System.IndexOutOfRangeException)
            {
                if (Input_data.Contains("[") == false || Input_data.Contains("]") == false)
                {
                    name = "Not found";
                }
            }
            return name;
        }
    }

}
