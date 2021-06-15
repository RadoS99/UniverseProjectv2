using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UniverseProject
{
    public class GList
    {
        public string str { get; set; }
        public int ID { get; set; }
        public int Printorder { get; set; }
        public string Name { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Data info = new Data();
            Galaxies Galaxy = new Galaxies();
            List<GList> G_temp = new List<GList>();
            List<GList> G_Perm = new List<GList>();
            List<GList> S_temp = new List<GList>(); List<GList> S_temp1 = new List<GList>();
            List<GList> S_Perm = new List<GList>();
            List<GList> P_temp = new List<GList>(); List<GList> P_temp1 = new List<GList>();
            List<GList> M_temp = new List<GList>(); List<GList> M_temp1 = new List<GList>();
            List<GList> Listing = new List<GList>();
            Stars Star = new Stars();
            Planets Planet = new Planets();
            Moons Moon = new Moons();
            S_temp.Add(new GList() { str ="Stars:" , ID=100, Name="", Printorder = 2 });
            P_temp.Add(new GList() { str = "Planets:", ID=100, Name = "", Printorder = 3 });
            M_temp.Add(new GList() { str = "Moons:", ID = 100 ,Name = "", Printorder = 4 });
            S_temp1.Add(new GList() { str = "Stars:", ID = 200, Name = "", Printorder = 2 });
            P_temp1.Add(new GList() { str = "Planets:", ID = 200, Name = "", Printorder = 3 });
            M_temp1.Add(new GList() { str = "Moons:", ID = 200, Name = "", Printorder = 4 });
            bool check = info.Input_data.Contains("exit");//inputdata=empty za da moje initial starta da e vinagi false
            int x = 0;
            int y = 0;
            
            for (int i = 0; check == false; i++)//for cikul za vseki red input dokato ne se napishe na nov red exit da prekrati
            {

                info.Input_data = Console.ReadLine();
                check = info.Input_data.Contains("exit");// ako inputa e exit shte prikluchi cikula
                info.Splitter = info.Input_data.Split(" ");// razdelqne na inputa 
                
                if (info.Input_data.Contains("add galaxy"))
                {
                    
                    x++;
                    
                    Galaxy.Input_data = info.Input_data; Galaxy.Splitter = info.Splitter;// predavane na inputa ot Data kum Galaxy
                    Galaxy.Numcount++;//prebroqvane na galaxyta za stats
                    G_temp.Add(new GList() {str= $"--Data for {Galaxy.NameCheck()} galaxy--\r\nType: {Galaxy.TypeCheck()}\r\n Age: {Galaxy.AgeCheck()}",ID=x, Name = Galaxy.NameCheck(), Printorder=1 });
                    Listing.Add(new GList() {Name=Galaxy.NameCheck(), ID=1000 });//otdelen list da vadq List of all researched galaxies, otkolkoto da pretursvam G_temp
                }
                else if (info.Input_data.Contains("add star"))
                {
                    
                    Star.Input_data = info.Input_data; Star.Splitter = info.Splitter;
                    
                    
                    if (Galaxy.NameCheck() == Star.GalaxyNameCheck())
                    {
                        Star.Numcount++;// prebroqvane na zvezdite ako spazvat uslovieto za stats
                        S_temp.Add(new GList() { str = $"-Name: {Star.NameCheck()}\r\n{Star.Classification()}", ID = x, Name = Star.NameCheck(), Printorder = 2 });
                        Listing.Add(new GList() { Name = Star.NameCheck(), ID = 1001 });
                    }
                    else if (Galaxy.NameCheck() != Star.GalaxyNameCheck())
                    {
                        Star.Numcount++; 
                        y++;
                        S_temp1.Add(new GList() { str = $"-Name: {Star.NameCheck()}\r\n{Star.Classification()}", ID = y, Name = Star.NameCheck(), Printorder = 2 });
                        Listing.Add(new GList() { Name = Star.NameCheck(), ID = 1001 });
                    }
                }
                else if (info.Input_data.Contains("add planet"))
                {      
                    Planet.Input_data = info.Input_data; Planet.Splitter = info.Splitter;
                    
                    if (Galaxy.NameCheck() == Star.GalaxyNameCheck() & Star.NameCheck() == Planet.StarNameCheck())
                    {
                        Planet.Numcount++;//prebroqvane na planetite za stats
                        P_temp.Add(new GList() { str = $"Name: {Planet.NameCheck()}\r\nType: {Planet.TypeCheck()}\r\n{Planet.Checklife()}", ID = x, Name = Planet.NameCheck(), Printorder = 3 });
                        Listing.Add(new GList() { Name = Planet.NameCheck(), ID = 1002 });   
                    }
                    else if (Galaxy.NameCheck() != Star.GalaxyNameCheck() & Star.NameCheck() == Planet.StarNameCheck())
                    {
                        Planet.Numcount++;
                        P_temp1.Add(new GList() { str = $"Name: {Planet.NameCheck()}\r\nType: {Planet.TypeCheck()}\r\n{Planet.Checklife()}", ID = y, Name = Planet.NameCheck(), Printorder = 3 });
                        Listing.Add(new GList() { Name = Planet.NameCheck(), ID = 1002 });
                    }   
                }
                else if (info.Input_data.Contains("add moon"))
                {
                    
                    Moon.Input_data = info.Input_data; Moon.Splitter = info.Splitter;
                    
                    if (Galaxy.NameCheck() == Star.GalaxyNameCheck() & Star.NameCheck() == Planet.StarNameCheck() & Planet.NameCheck() == Moon.PlanetNameCheck())
                    {
                        Moon.Numcount++;
                        M_temp.Add(new GList() { str = $"Name: {Moon.NameCheck()}", ID = x, Name = Moon.NameCheck(), Printorder = 4 });
                        Listing.Add(new GList() { Name = Moon.NameCheck(), ID = 1003 });    
                    }
                    else if (Galaxy.NameCheck() != Star.GalaxyNameCheck() & Star.NameCheck() == Planet.StarNameCheck() & Planet.NameCheck() == Moon.PlanetNameCheck())
                    {
                        Moon.Numcount++;
                        M_temp1.Add(new GList() { str = $"Name: {Moon.NameCheck()}", ID = y, Name = Moon.NameCheck(), Printorder = 4 });
                        Listing.Add(new GList() { Name = Moon.NameCheck(), ID = 1003 });
                    }
                }
                List<GList> distinct = new List<GList>();
                P_temp.AddRange(M_temp);// nedostatuk e ako printnesh i sled tova add star, planet, moon, shte budat razpechatani sled, ne spazva order poradi novo zavurtane v cikula
                S_temp.AddRange(P_temp);// dobavih nov item Printorder koito da sloja v Print statementa, da gi printva po order 1>4 sus OrderBy ili OrderByDescending i ne se poluchi
                G_temp.AddRange(S_temp);// izkara gi po index ot 0> 
                G_Perm.AddRange(G_temp);
                distinct.AddRange(G_Perm.Distinct());//premahvane na duplicate elements v G_Perm pri zavurtane na cikula otnovo
                List<GList> distinct1 = new List<GList>();
                P_temp1.AddRange(M_temp1);
                S_temp1.AddRange(P_temp1);
                S_Perm.AddRange(S_temp1);
                distinct1.AddRange(S_Perm.Distinct());
                if (info.Input_data.Contains("stats"))
                {
                    Console.WriteLine($"--Stats--\r\nGalaxies: {Galaxy.Numcount}\r\nStars: {Star.Numcount}\r\nPlanets: {Planet.Numcount}\r\nMoons: {Moon.Numcount}\r\n--End of stats--");
                }
                else if (info.Input_data.Contains("list galaxies"))
                {

                    Console.WriteLine("--List of all researched galaxies--");
                    foreach (var item in Listing)
                    {
                        if (item.ID==1000)//izpolzvane na ID za nai lesno izkarvane na galaxy names, 
                        { Console.WriteLine(item.Name); }
                    }
                    Console.WriteLine("--End of galaxies list--");

                }
                else if (info.Input_data.Contains("list stars"))
                {
                    Console.WriteLine("--List of all researched stars--");
                    foreach (var item in Listing)
                    {
                        if (item.ID == 1001)
                        { Console.WriteLine(item.Name); }
                    }
                    Console.WriteLine("--End of stars list--");
                }
                else if (info.Input_data.Contains("list planets"))
                {
                    Console.WriteLine("--List of all researched planets--");
                    foreach (var item in Listing)
                    {
                        if (item.ID == 1002)
                        { Console.WriteLine(item.Name); }
                    }
                    Console.WriteLine("--End of planets list--");
                }
                else if (info.Input_data.Contains("list moons"))
                {
                    Console.WriteLine("--List of all researched moons--");
                    foreach (var item in Listing)
                    {
                        if (item.ID == 1003)
                        { Console.WriteLine(item.Name); }
                    }
                    Console.WriteLine("--End of moons list--");
                }
                info.Input_data = Console.ReadLine();
                if (info.Input_data.Contains("print") & info.Input_data.Contains(info.Printname()))
                {
                    foreach (var element in distinct)
                    {
                        int x1;
                        if (element.Name.Contains(info.Printname()))//proverka dali v distinct Listata sus vsichki elementi sudurja Print imeto 
                        {
                           x1=element.ID;// sled proverkata prehvurlqm x1 s ID koeto razdelq dve otdelni grupi galaxies s tehnite zvezdi, planeti, luni
                            foreach (var element1 in distinct)
                            {
                                if (element1.ID == x1 | element1.ID == 100)//proverka na vseki element dali otgovarq na usloviqta za IDs i da budat razpechatani
                                {
                                    
                                     Console.WriteLine(element1.str);
                                }
                            }
                        }  
                    }
                }
                else if (info.Input_data.Contains("print") & info.Input_data.Contains(info.Printname()))
                {
                    
                    foreach (var element in distinct1)
                    {

                        int x1;
                        if (element.Name.Contains(info.Printname()))
                        {
                            
                            x1 = element.ID;
                            Console.WriteLine($"true {element.ID} {x1}");
                            foreach (var element1 in distinct1)
                            {
                                if (element1.ID == x1 | element1.ID == 200)
                                {
                                    Console.WriteLine(element1.str);
                                }
                            }
                        }
                    }
                }
                if (check == true)
                {
                    break;
                }
            }
        }
    }
}
