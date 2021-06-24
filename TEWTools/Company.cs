using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEWTools
{
    public class Company
    {
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public string StyleName { get; set; }
        public int ProductBase { get; set; }
        public int MediaGroupOwner { get; set; }
        public int Owner { get; set; }
        public int OwnerType { get; set; }
        public int HeadBooker { get; set; }
        public int Money { get; set; }
        public int Size { get; set; }
        public int Ranking { get; set; }
        public int Prestige { get; set; }
        public int Momentum { get; set; }
        public int Based { get; set; }
        public int Ace { get; set; }
        public bool YoungLion { get; set; }
        public int Announcer1 { get; set; }
        public int Announcer2 { get; set; }
        public int Announcer3 { get; set; }
        public string Brand1 { get; set; }
        public string Brand2 { get; set; }
        public string Brand3 { get; set; }
        public string Brand4 { get; set; }
        public string Brand5 { get; set; }
        public int GreatLakes { get; set; }
        public int MidAtlantic { get; set; }
        public int MidSouth { get; set; }
        public int MidWest { get; set; }
        public int NewEngland { get; set; }
        public int NorthWest { get; set; }
        public int SouthEast { get; set; }
        public int SouthWest { get; set; }
        public int TriState { get; set; }
        public int PuertoRico { get; set; }
        public int Hawaii { get; set; }
        public int Maritimes { get; set; }
        public int Quebec { get; set; }
        public int Ontario { get; set; }
        public int Alberta { get; set; }
        public int Saskatchewan { get; set; }
        public int Manitoba { get; set; }
        public int BritishColumbia { get; set; }
        public int Noreste { get; set; }
        public int Noroccidente { get; set; }
        public int Sureste { get; set; }
        public int Sur { get; set; }
        public int Centro { get; set; }
        public int Occidente { get; set; }
        public int Midlands { get; set; }
        public int NorthernEngland { get; set; }
        public int Scotland { get; set; }
        public int SouthernEngland { get; set; }
        public int Ireland { get; set; }
        public int Wales { get; set; }
        public int Tohoku { get; set; }
        public int Kanto { get; set; }
        public int Kansai { get; set; }
        public int Chubu { get; set; }
        public int Chugoku { get; set; }
        public int Shikoku { get; set; }
        public int Kyushu { get; set; }
        public int Hokkaido { get; set; }
        public int WesternEurope { get; set; }
        public int Iberia { get; set; }
        public int SouthernMediterranean { get; set; }
        public int SouthernEurope { get; set; }
        public int CentralEurope { get; set; }
        public int Scandinavia { get; set; }
        public int EasternEurope { get; set; }
        public int Russia { get; set; }
        public int NewSouthWales { get; set; }
        public int Queensland { get; set; }
        public int SouthAustralia { get; set; }
        public int Victoria { get; set; }
        public int WesternAustralia { get; set; }
        public int Tasmania { get; set; }
        public int NewZealand { get; set; }
        public int NorthernIndia { get; set; }
        public int CentralIndia { get; set; }
        public int SouthernIndia { get; set; }

        public Dictionary<int, string> ProductName = new Dictionary<int, string>
        {
            {1, "Classic Lucha Libre"},
            {2, "Deathmatch"},
            {3, "Extreme Hardcore"},
            {4, "Faux MMA"},
            {5, "Classic Sports Entertainment"},
            {6, "Crash TV"},
            {7, "Scripted Reality"},
            {8, "Anti-Establishment"},
            {9, "Classic Southern Rasslin"},
            {10, "Wrestling As A Sport"},
            {11, "Respectful Wrestling"},
            {12, "Campy Fun"},
            {13, "Lucharesu"},
            {14, "Comic Book Lucha Libre"},
            {15, "Family Friendly Pro Wrestling"},
            {16, "Monster Battle"},
            {17, "Performance Art"},
            {18, "Risque Adult"},
            {19, "PG Rated Sports Entertainment"},
            {20, "Wrestling Nerd Nirvana"},
            {21, "Wrestling Soap Opera"},
            {22, "High Flying Hardcore"},
            {23, "Skit Based"},
            {24, "Stoner Hardcore"},
            {25, "Stoner Entertainment"},
            {26, "Telenovela"},
            {27, "Episodic Lucha Libre"},
            {28, "Episodic Hardcore"},
            {29, "Episodic Entertainment"},
            {30, "Episodic Sport"},
            {31, "Psuedo Sport"},
            {32, "Hokey Southern Rasslin"},
            {33, "Absurdist Entertainment"},
            {34, "Lighthearted Entertainment"},
            {35, "Classic Wild West"},
            {36, "Bar Room Entertainment"},
            {37, "Gory Hardcore"},
            {38, "Hardcore Lucha Libre"},
            {39, "Puerto Rican Hardcore"},
            {40, "Golden Age Pro Wrestling"},
            {41, "Shoot-Style Wrestling"},
            {42, "Classic Mainstream Puroresu"},
            {43, "Fast And Furious"},
            {44, "Guerrilla Warfare"},
            {45, "Slobberknocker-Deathmatch Combined"},
            {46, "Junior-Deathmatch Combined"},
            {47, "Lucharesu Entertainment"},
            {48, "Classic Balanced"},
            {49, "Silver Age Pro Wrestling"},
            {50, "Lucha Libre Entertainment"},
            {51, "Grindhouse Lucha Libre"},
            {52, "Catch Wrestling"},
            {53, "Royal Puroresu"},
            {54, "Strong Puroresu"},
            {55, "Historic Lucha Libre"},
            {56, "Deathmatch Lucha Libre"},
            {57, "Avantgarde Puroresu"},
            {58, "Slobberknocker"},
            {59, "Lucha Libre Slobberknocker"},
            {60, "Hardcore Evolved"},
            {61, "No-Style Style"},
            {62, "Modern Throwback"},
            {63, "Risque Comedy"},
            {64, "Gritty Adult Noir"},
            {65, "East Meets West"},
            {66, "World Fusion"},
            {67, "Lucha Libre Burlesque"},
            {68, "Wrestling Burlesque"},
            {69, "Xtreme Adult Filth"},
            {70, "Ruthless Aggression"},
            {71, "Three Ring Circus"},
            {72, "Competitive Entertainment"},
            {73, "Carnival Days"},
            {74, "Psycho Circus"},
            {75, "Fast, Furious, Deadly"},
            {76, "Lucharesu Amped Up"},
            {77, "MMA Entertainment"},
            {78, "Comic Book Light"},
            {79, "Comic Book Dark"},
            {80, "Stunt Show"},
            {81, "Attitude Entertainment"},
            {82, "Memetic Wrestling"},
            {83, "Cartoon Wrestling"},
            {84, "Soap Opuro"},
            {85, "Morality Wrestling"}
        };

        public Dictionary<int, string> OwnerTypeValue = new Dictionary<int, string>
        {
            {1, "Lifetime"},
            {2, "Purchased"},
            {3, "CEO"}
        };
    }
}
