using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEWTools
{
    public class Worker
    {
        public int UID { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public bool Male { get; set; }
        public int BirthMonth { get; set; }
        public int BirthYear { get; set; }
        public int DebutMonth { get; set; }
        public int DebutYear { get; set; }
        public int BodyType { get; set; }
        public int Size { get; set; }
        public int Nationality { get; set; }
        public int Race { get; set; }
        public int Based { get; set; }
        public int Sexuality { get; set; }
        public int OutsideRelationship { get; set; }
        public string Status { get; set; }
        public int Style { get; set; }
        public int Brawling { get; set; }
        public int Aerial { get; set; }
        public int Technical { get; set; }
        public int Power { get; set; }
        public int Athleticism { get; set; }
        public int Stamina { get; set; }
        public int Psychology { get; set; }
        public int Basics { get; set; }
        public int Toughness { get; set; }
        public int Selling { get; set; }
        public int Charisma { get; set; }
        public int Microphone { get; set; }
        public int Menace { get; set; }
        public int Respect { get; set; }
        public int Reputation { get; set; }
        public int Safety { get; set; }
        public int SexAppeal { get; set; }
        public int StarQuality { get; set; }
        public int Consistency { get; set; }
        public int Acting { get; set; }
        public int Resilience { get; set; }
        public int Puroresu { get; set; }
        public int Flashiness { get; set; }
        public int Hardcore { get; set; }
        public int Announcing { get; set; }
        public int Colour { get; set; }
        public int Refereeing { get; set; }
        public int Experience { get; set; }
        public int BusinessReputation { get; set; }
        public int BookingReputation { get; set; }
        public int BookingSkill { get; set; }
        public int PhysicalHead { get; set; }
        public int PhysicalBody { get; set; }
        public int PhysicalArms { get; set; }
        public int PhysicalLegs { get; set; }
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


        public Dictionary<int, string> RaceName = new Dictionary<int, string>()
        {
            {1, "White"},
            {2, "Black"},
            {3, "Asian"},
            {4, "Hispanic"},
            {5, "American Indian"},
            {6, "Middle Eastern"},
            {7, "Indian"},
            {8, "Pacific"},
            {9, "Other"}
        };

        public Dictionary<int, string> NationalityName = new Dictionary<int, string>()
        {
            {1, "American"},
            {2, "Japanese"},
            {3, "Canadian"},
            {4, "Mexican"},
            {5, "English"},
            {6, "Scottish"},
            {7, "Welsh"},
            {8, "Irish"},
            {9, "Chinese"},
            {10, "Australian"},
            {11, "New Zealander"},
            {12, "South African"},
            {13, "Brazilian"},
            {14, "Argentinian"},
            {15, "Peruvian"},
            {16, "Hawaiian"},
            {17, "Puerto Rican"},
            {18, "Cuban"},
            {19, "French"},
            {20, "Italian"},
            {21, "Dutch"},
            {22, "German"},
            {23, "Austrian"},
            {24, "Swiss"},
            {25, "Russian"},
            {26, "Spanish"},
            {27, "Croatian"},
            {28, "Serbian"},
            {29, "Filipino"},
            {30, "Turkish"},
            {31, "South Korean"},
            {32, "Samoan"},
            {33, "Greek"},
            {34, "Swedish"},
            {35, "Polish"},
            {36, "Norwegian"},
            {37, "Ukranian"},
            {38, "Finnish"},
            {39, "Bulgarian"},
            {40, "Chilean"},
            {41, "Thai"},
            {42, "Ivorian"},
            {43, "Slovenian"},
            {44, "Danish"},
            {45, "Czech"},
            {46, "Indonesian"},
            {47, "Armenian"},
            {48, "Nigerian"},
            {49, "Malaysian"},
            {50, "Moldovan"},
            {51, "Belarusian"},
            {52, "Egyptian"},
            {53, "Lithuanian"},
            {54, "Hungarian"},
            {55, "Indian"},
            {56, "Israeli"},
            {57, "Vietnamese"},
            {58, "Romanian"},
            {59, "Venezuelan"},
            {60, "Haitian"},
            {61, "Dominican"},
            {62, "Belgian"},
            {63, "Icelandic"},
            {64, "Estonian"},
            {65, "Latvian"},
            {66, "Luxembourger"},
            {67, "Azerbaijani"},
            {68, "Georgian"},
            {69, "Tongan"},
            {70, "Algerian"},
            {71, "Mongolian"},
            {72, "Cameroonian"},
            {73, "Moroccan"},
            {74, "Portuguese"},
            {75, "Taiwanese"},
            {76, "Pakistani"},
            {77, "Iranian"},
            {78, "Lebanese"},
            {79, "Iraqi"},
            {80, "Salvadoran"},
            {81, "Panamanian"},
            {82, "Honduran"},
            {83, "Belizean"},
            {84, "Guatemalan"},
            {85, "Costa Rican"},
            {86, "Bolivian"},
            {87, "Jordanian"},
            {88, "Afghan"},
            {89, "Colombian"},
            {90, "Cypriot"},
            {91, "Aruban"},
            {92, "Congolese"},
            {93, "Guamanian"},
            {94, "Uruguayan"},
            {95, "Ghanaian"},
            {96, "Malagasy"},
            {97, "Papua New Guinean"},
            {98, "Tanzanian"},
            {99, "Ugandan"},
            {100, "Tunisian"},
            {101, "Gabonese"},
            {102, "Kenyan"},
            {103, "Nicaraguan"},
            {104, "Jamaican"},
            {105, "Uzbekistani"},
            {106, "Barbadian"},
            {107, "Zambian"},
            {108, "Namibian"},
            {109, "Cape Verdean"},
            {110, "Emirati"},
            {111, "Kazakhstani"},
            {112, "Bosnian"},
            {113, "Montenegrin"},
            {114, "Kyrgyzstani"},
            {115, "Sudanese"},
            {116, "Trinidadian"},
            {117, "Guyanese"},
            {118, "Ecuadorian"},
            {119, "Palestinian"},
            {120, "Saudi"},
            {121, "Fijian"},
            {122, "Slovakian"},
            {123, "Northern Irish"},
            {124, "Bahamian"},
            {125, "Dagestani"},
            {126, "Albanian"},
            {127, "Virgin Islander"},
            {128, "Nevisian"},
            {129, "Kittitian"},
            {130, "Santo Domingan"},
            {131, "Caymanian"},
            {132, "Anguillian"},
            {133, "Antiguan"},
            {134, "Saint Martiner"},
            {135, "Montserratian"},
            {136, "Guadeloupean"},
            {137, "Martinican"},
            {138, "Saint Lucian"},
            {139, "Vincentian"},
            {140, "Grenadian"},
            {141, "Tobagonian"},
            {142, "Singaporean"},
            {143, "Surinamese"},
            {144, "Zimbabwean"},
            {145, "Syrian"},
            {146, "American Samoan"},
            {147, "Andorran"},
            {148, "Angolan"},
            {149, "Bahraini"},
            {150, "Bangladeshi"},
            {151, "Basotho"},
            {152, "Beninese"},
            {153, "Bhutanese"},
            {154, "Bruneian"},
            {155, "Burkinabe"},
            {156, "Burmese"},
            {157, "Burundian"},
            {158, "Yemeni"},
            {159, "Cambodian"},
            {160, "Central African"},
            {161, "Chadian"},
            {162, "Cook Islander"},
            {163, "Djiboutian"},
            {164, "Eritrean"},
            {165, "Ethiopian"},
            {166, "Gambian"},
            {167, "Guinean"},
            {168, "Kosovan"},
            {169, "Kuwaiti"},
            {170, "Laotian"},
            {171, "Liberian"},
            {172, "Libyan"},
            {173, "Liechtensteiner"},
            {174, "Macedonian"},
            {175, "Malawian"},
            {176, "Maldivian"},
            {177, "Malinese"},
            {178, "Maltese"},
            {179, "Mauritian"},
            {180, "Botswanan"},
            {181, "Mozambican"},
            {182, "Nepalese"},
            {183, "North Korean"},
            {184, "Omani"},
            {185, "Paraguayan"},
            {186, "Qatari"},
            {187, "Rwandan"},
            {188, "Senegalese"},
            {189, "Sierra Leonean"},
            {190, "Somali"},
            {191, "Sri Lankan"},
            {192, "Swazi"},
            {193, "Tajikstani"},
            {194, "Timorese"},
            {195, "Togolese"},
            {196, "Turkmen"},
            {197, "Tuvaluan"},
            {198, "Vanuatuan"}
        };

        public Dictionary<int, string> LocationName = new Dictionary<int, string>
        {
            {1, "Great Lakes"},
            {2, "Mid Atlantic"},
            {3, "Mid South"},
            {4, "Mid West"},
            {5, "New England"},
            {6, "North West"},
            {7, "South East"},
            {8, "South West"},
            {9, "Tri State"},
            {10, "Puerto Rico"},
            {11, "Hawaii"},
            {12, "Maritimes"},
            {13, "Quebec"},
            {14, "Ontario"},
            {15, "Alberta"},
            {16, "Saskatchewan"},
            {17, "Manitoba"},
            {18, "British Columbia"},
            {19, "Noreste"},
            {20, "Noroccidente"},
            {21, "Sureste"},
            {22, "Sur"},
            {23, "Centro"},
            {24, "Occidente"},
            {25, "Midlands"},
            {26, "Northern England"},
            {27, "Scotland"},
            {28, "Southern England"},
            {29, "Ireland"},
            {30, "Wales"},
            {31, "Tohoku"},
            {32, "Kanto"},
            {33, "Chubu"},
            {34, "Kansai"},
            {35, "Chugoku"},
            {36, "Shikoku"},
            {37, "Kyushu"},
            {38, "Hokkaido"},
            {39, "Western Europe"},
            {40, "Iberia"},
            {41, "Southern Mediterranean"},
            {42, "Southern Europe"},
            {43, "Central Europe"},
            {44, "Scandinavia"},
            {45, "Eastern Europe"},
            {46, "Russia"},
            {47, "New South Wales"},
            {48, "Queensland"},
            {49, "South Australia"},
            {50, "Victoria"},
            {51, "Western Australia"},
            {52, "Tasmania"},
            {53, "New Zealand"},
            {54, "Northern India"},
            {55, "Central India"},
            {56, "Southern India"}
        };

        public Dictionary<int, string> SexualityName = new Dictionary<int, string>
        {
            {1, "Heterosexual"},
            {2, "Homosexual"},
            {3, "Bisexual"}
        };

        public Dictionary<int, string> StyleName = new Dictionary<int, string>
        {
            {1, "Regular"},
            {2, "Entertainer"},
            {3, "Comedy"},
            {4, "Powerhouse"},
            {5, "Impactful"},
            {6, "Striker"},
            {7, "Brawler"},
            {8, "Hardcore"},
            {9, "Psychopath"},
            {10, "Luchador"},
            {11, "High Flyer"},
            {12, "Technician"},
            {13, "Technician Flyer"},
            {14, "Technician Striker"},
            {15, "Daredevil"},
            {16, "MMA Crossover"},
            {17, "Never Wrestles"}
        };

        public Dictionary<int, string> BodyTypeName = new Dictionary<int, string>
        {
            {0, "Average"},
            {1, "Skinny"},
            {2, "Toned"},
            {3, "Muscular"},
            {4, "Ripped"},
            {5, "Flabby"},
            {6, "Bulky"},
            {7, "Obese"}
        };

        public Dictionary<int, string> SizeName = new Dictionary<int, string>
        {   
            {2, "Very Small"},
            {3, "Small"},
            {4, "Lightweight"},
            {5, "Middleweight"},
            {6, "Light Heavyweight"},
            {7, "Heavyweight"},
            {8, "Big Heavyweight"},
            {9, "Super Heavyweight"},
            {10, "Giant"}
        };

        public Dictionary<int, string> RelationshipType = new Dictionary<int, string>
        {
            {0, "No"},
            {1, "Dating"},
            {2, "Engaged"},
            {3, "Married"}
        };
    }
}
