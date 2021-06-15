using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;


namespace UniverseProject
{
    class Stars : Data
    {
        string name;
        string classification;
        double[] allitems=new double[4];
        int M, K, G, F, A, B, O;
        int[] counter= new int[7];
        double mass;
        double size;
        double temp;
        double luminosity;
        
        int numcount;
        public Stars() { }
        
        public Stars(string name, double mass, double size, double temp, double luminosity, string input_data,string[]splitter, double[] allitems) : base(input_data, splitter)
        {
            this.Input_data = input_data;
            this.Splitter = splitter;
            this.name = name;
            this.mass = mass;
            this.size = size;
            this.temp = temp;
            this.luminosity = luminosity;
            this.allitems = allitems;
            

            
        }

        public string Name { get => name; set => name = value; }
        public double[] Allitems { get => allitems; set => allitems = value; }
        
        public int Numcount { get => numcount; set => numcount = value; }

        public string GalaxyNameCheck()
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
        public Double[] ItemsCheck()
        {
            int i = -1;
            foreach (string item in Splitter)
            {

                if (double.TryParse(item, out var parsedNumber)==true)
                {
                    i++;
                    double temp;
                    //double temp = Convert.ToDouble(item);
                    double.TryParse(item, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out temp);
                    allitems[i] = temp;
                }


            }
            return allitems;
        }
        
        

        public string Classification()
        {

            ItemsCheck();
            mass = allitems[0];
            size = allitems[1];
            temp = allitems[2];
            luminosity = allitems[3];
            
            
            //mass check and count
            if (mass <= 0.08 | mass < 0.45)//vtoriq mass check go slagam po malko ot max value za dadeniq class da nqma overlap
            { M++; counter[0]++; }
            else if (mass >= 0.45 & mass < 0.8)
            { K++; counter[1]++; }
            else if (mass >= 0.8 & mass < 1.04)
            { G++; counter[2]++; }
            else if (mass >= 1.04 & mass < 1.4)
            { F++; counter[3]++; }
            else if (mass >= 1.04 & mass < 2.1)
            { A++; counter[4]++; }
            else if (mass >= 2.1 & mass < 16)
            { B++; counter[5]++; }
            else if(mass>=16)
            { O++; counter[6]++; }
            //size check and count
            if (size <= 0.7)
            { M++; counter[0]++; }
            else if (size >= 0.71 & size < 0.96)
            { K++; counter[1]++; }
            else if (size >= 0.96 & size < 1.15)
            { G++; counter[2]++; }
            else if (size >= 1.15 & size < 1.4)
            { F++; counter[3]++; }
            else if (size >= 1.4 & size < 1.8)
            { A++; counter[4]++; }
            else if (size >= 1.8 & size < 6.6)
            { B++; counter[5]++; }
            else if (size >= 6.6)
            { O++; counter[6]++; }
            //temp check and count
            if (temp <= 2400 & temp < 3700)
            { M++; counter[0]++; }
            else if (temp >= 3700 & temp < 5200)
            { K++; counter[1]++; }
            else if (temp >= 5200 & temp < 6000)
            { G++; counter[2]++; }
            else if (temp >= 6000 & temp < 7500)
            { F++; counter[3]++; }
            else if (temp >= 7500 & temp < 10000)
            { A++; counter[4]++; }
            else if (temp >= 10000 & temp < 30000)
            { B++; counter[5]++; }
            else if (temp >= 30000)
            { O++; counter[6]++; }
            //luminosity check and count
            if (luminosity <= 0.08)
            { M++; counter[0]++; }
            else if (luminosity >=0.081 & luminosity < 0.6)
            { K++; counter[1]++; }
            else if (luminosity >= 0.6 & luminosity < 1.5)
            { G++; counter[2]++; }
            else if (luminosity >= 1.5 & luminosity < 5)
            { F++; counter[3]++; }
            else if (luminosity >= 5 & luminosity < 25)
            { A++; counter[4]++; }
            else if (luminosity >= 25 & luminosity < 30000)
            { B++; counter[5]++; }
            else if (luminosity >= 30000)
            { O++; counter[6]++; }

            int classselect = counter.Max();//to select the largest integer in the counter array example if F=2 , G=1 , M=1 to select class F
            //check which integer matches with the classselect to add the corresponding class in the string classification
            if (classselect == M)
            { classification = "Class: M"; }
            else if (classselect == K)
            { classification = "Class: K"; }
            else if (classselect == G)
            { classification = "Class: G"; }
            else if (classselect == F)
            { classification = "Class: F"; }
            else if (classselect == A)
            { classification = "Class: A"; }
            else if (classselect == B)
            { classification = "Class: B"; }
            else if (classselect == O)
            { classification = "Class: O"; }
            return $"{classification} ({mass},{size},{temp},{luminosity})";
        }
             
        public string NameIdentify()
        {
            int start = Input_data.IndexOf("[") + "[".Length;
            int end = Input_data.LastIndexOf("]");
            string name1 = Input_data.Substring(start, end - start);
            return name1;
        }
    }
    
}
