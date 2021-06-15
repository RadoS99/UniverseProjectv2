using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace UniverseProject
{
    class Data
    {
        string input_data = "empty";
        string[] splitter;
        string name;
        public Data() { }
        public Data(string input_data, string[] splitter)
        {
            this.splitter = splitter;
            this.input_data = input_data;

        }

        public string Input_data { get => input_data; set => input_data = value; }
        public string[] Splitter { get => splitter; set => splitter = value; }
        public string Printname()
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

    }


    
}
