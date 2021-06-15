using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace UniverseProject
{
    class Planets:Data
    {
        string name;
        
        string type;
        bool life;
        int numcount;
        public Planets() { }
        public Planets(string name,string type, bool life, string input_data, string[] splitter) :base(input_data,splitter)
        {
            this.Input_data = input_data;
            this.Splitter = splitter;
            this.name = name;
            this.type = type;
            this.life = life;
        }

        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public bool Life { get => life; set => life = value; }
       
        public int Numcount { get => numcount; set => numcount = value; }

        public string StarNameCheck()
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
        public string TypeCheck()
        {

            string[] typecheck = { "terrestrial", "giant planet", "ice giant", "mesoplanet", "mini - neptune", "planetar", "super - earth", "super - jupiter", "sub - earth" };
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
            return type;
        }
        public string Checklife()
        {
            string answer;
            if (Input_data.Contains("yes") | Input_data.Contains("Yes"))
            {
                answer = "Support life: yes";
            }
            else
            {
                answer = "Support life: no";
            }
            return answer;
        
        }

    }
}
