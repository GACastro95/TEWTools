using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace TEWTools
{
    public partial class Form1 : Form
    {

        public List<Company> companies = new List<Company>();
        public List<Contract> contracts = new List<Contract>();
        public List<Worker> workers = new List<Worker>();
        public List<Attributes> attributes = new List<Attributes>();
        public string[] primarySkills = { "Brawling", "Puroresu", "Hardcore", "Technical", "Aerial", "Flashiness" };
        public string[] mentalSkills = { "Psychology", "Experience", "Reputation", "Respect" };
        public string[] performanceSkills = { "Charisma", "Microphone", "Acting", "StarQuality", "SexAppeal", "Menace" };
        public string[] basicSkills = { "Basics", "Selling", "Consistency", "Safety" };
        public string[] physicalAbilities = { "Stamina", "Athleticism", "Power", "Toughness", "Resilience" };
        public string[] otherSkills = { "Announcing", "Colour", "Refereeing", "BusinessReputation", "BookingReputation", "BookingSkill" };
        public string[] talents = { "Reputation", "Negotiating", "Motivating", "Creativity", "Leadership", "Diplomacy", "SilverTongue", "UnallocatedPoints" };
        public string[] physical = { "Head", "Body", "Arms", "Legs" };
        public string[] usaPop = { "GreatLakes", "MidAtlantic", "MidSouth", "MidWest", "NewEngland", "NorthWest", "SouthEast", "SouthWest", "TriState", "PuertoRico", "Hawaii" };
        public string[] canadaPop = { "Maritimes", "Quebec", "Ontario", "Alberta", "Saskatchewan", "Manitoba", "BritishColumbia" };
        public string[] mexicoPop = { "Noreste", "Noroccidente", "Sureste", "Sur", "Centro", "Occidente" };
        public string[] britishPop = { "Midlands", "NorthernEngland", "Scotland", "SouthernEngland", "Ireland", "Wales" };
        public string[] japanPop = { "Tohoku", "Kanto", "Chubu", "Kansai", "Chugoku", "Shikoku", "Kyushu", "Hokkaido" };
        public string[] europePop = { "WesternEurope", "Iberia", "SouthernMediterranean", "SouthernEurope", "CentralEurope", "Scandinavia", "EasternEurope", "Russia" };
        public string[] oceaniaPop = { "NewSouthWales", "Queensland", "SouthAustralia", "Victoria", "WesternAustralia", "Tasmania", "NewZealand" };
        public string[] indiaPop = { "NorthernIndia", "CentralIndia", "SouthernIndia" };
        public List<Worker> chosenWorkers = new List<Worker>();
        public List<DataGridView> userDGV;
        public SaveGame saveGame = new SaveGame();
        public PlayerInfo playerInfo = new PlayerInfo();
        public string rootDirectory;


        public Form1()
        {
            InitializeComponent();
        }

        private void loadDatabase()
        {
            companies.Clear();
            contracts.Clear();
            workers.Clear();
            string file = openFileDialog1.FileName;
            label3.Text = openFileDialog1.SafeFileName;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            tabControl1.Enabled = true;
            using (OdbcConnection myConnection = new OdbcConnection())
            {
                myConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb)};" + "Dbq=" + file + ";PWD=2020Vision";
                myConnection.Open();

                //execute queries, etc
                OdbcCommand cmd = myConnection.CreateCommand();
                cmd.CommandText = "SELECT Picdir, CurrentDateM, CurrentDateY FROM tblGameInfo";
                OdbcDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    saveGame.PictureFolder = (string)reader["Picdir"];
                    saveGame.Current_Date_Month = Convert.ToInt32(reader["CurrentDateM"]);
                    saveGame.Current_Date_Year = Convert.ToInt32(reader["CurrentDateY"]);
                }

                reader.Close();
                cmd.CommandText = "SELECT Player, Reputation, Talent_Points, Talent_Negotiating, Talent_Motivating, Talent_Creativity, Talent_Leadership, Talent_Diplomacy, Talent_Silver FROM tblPlayerInfo";
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    playerInfo.ID = (int)reader["Player"];
                    playerInfo.Reputation = Convert.ToInt32(reader["Reputation"]);
                    playerInfo.UnallocatedPoints = Convert.ToInt32(reader["Talent_Points"]);
                    playerInfo.Negotiating = Convert.ToInt32(reader["Talent_Negotiating"]);
                    playerInfo.Motivating = Convert.ToInt32(reader["Talent_Motivating"]);
                    playerInfo.Creativity = Convert.ToInt32(reader["Talent_Creativity"]);
                    playerInfo.Leadership = Convert.ToInt32(reader["Talent_Leadership"]);
                    playerInfo.Diplomacy = Convert.ToInt32(reader["Talent_Diplomacy"]);
                    playerInfo.SilverTongue = Convert.ToInt32(reader["Talent_Silver"]);
                }

                reader.Close();
                cmd.CommandText = "SELECT tblFed.UID, tblFed.Name, tblFed.Initials, tblFed.ClosedMonth, tblFed.ClosedYear, tblFed.Logo, tblFedStyle.Style_Name, tblFedStyle.ProductBase, tblFed.Mediagroup, tblFedPower.Owner," +
                    "tblFedPower.Headbooker, tblFedPower.OwnerType, tblFed.Money, tblFed.Size, tblFed.Ranking, tblFed.Prestige, tblFed.Momentum, tblFed.Based_In, tblFed.Ace, tblFed.YoungLion, tblFed.Announce1," +
                    " tblFed.Announce2, tblFed.Announce3, tblFedOver.Over1, tblFedOver.Over2, tblFedOver.Over3, tblFedOver.Over4, tblFedOver.Over5, tblFedOver.Over6, tblFedOver.Over7, tblFedOver.Over8, tblFedOver.Over9," +
                    " tblFedOver.Over10, tblFedOver.Over11, tblFedOver.Over12, tblFedOver.Over13, tblFedOver.Over14, tblFedOver.Over15, tblFedOver.Over16, tblFedOver.Over17, tblFedOver.Over18, tblFedOver.Over19," +
                    " tblFedOver.Over20, tblFedOver.Over21, tblFedOver.Over22, tblFedOver.Over23, tblFedOver.Over24, tblFedOver.Over25, tblFedOver.Over26, tblFedOver.Over27, tblFedOver.Over28, tblFedOver.Over29," +
                    " tblFedOver.Over30, tblFedOver.Over31, tblFedOver.Over32, tblFedOver.Over33, tblFedOver.Over34, tblFedOver.Over35, tblFedOver.Over36, tblFedOver.Over37, tblFedOver.Over38, tblFedOver.Over39," +
                    " tblFedOver.Over40, tblFedOver.Over41, tblFedOver.Over42, tblFedOver.Over43, tblFedOver.Over44, tblFedOver.Over45, tblFedOver.Over46, tblFedOver.Over47, tblFedOver.Over48, tblFedOver.Over49," +
                    " tblFedOver.Over50, tblFedOver.Over51, tblFedOver.Over52, tblFedOver.Over53, tblFedOver.Over54, tblFedOver.Over55, tblFedOver.Over56 FROM ((tblFed INNER JOIN tblFedStyle ON tblFed.UID = tblFedStyle.FedUID)" +
                    " INNER JOIN tblFedPower ON tblFed.UID = tblFedPower.FedUID) INNER JOIN tblFedOver ON tblFed.UID = tblFedOver.FedUID";
                reader = cmd.ExecuteReader();

                for (int i = -1; i < 1; i++)
                {
                    Company pholder = new Company();
                    pholder.Id = i;
                    switch (i)
                    {
                        case -1:
                            pholder.Name = "All";
                            break;
                        case 0:
                            pholder.Name = "Unemployed";
                            break;
                    }
                    companies.Add(pholder);
                }

                while (reader.Read())
                {
                    Company company = new Company();

                    company.Id = (int)reader["UID"];
                    company.Logo = (string)reader["Logo"];
                    company.Name = (string)reader["Name"];
                    company.Initials = (string)reader["Initials"];
                    company.StyleName = (string)reader["Style_Name"];
                    company.ProductBase = Convert.ToInt32(reader["ProductBase"]);
                    company.MediaGroupOwner = Convert.ToInt32(reader["Mediagroup"]);
                    company.Owner = Convert.ToInt32(reader["Owner"]);
                    company.OwnerType = Convert.ToInt32(reader["OwnerType"]);
                    company.HeadBooker = Convert.ToInt32(reader["Headbooker"]);
                    company.Money = Convert.ToInt32(reader["Money"]);
                    company.Size = Convert.ToInt32(reader["Size"]);
                    company.Ranking = Convert.ToInt32(reader["Ranking"]);
                    company.Prestige = Convert.ToInt32(reader["Prestige"]);
                    company.Momentum = Convert.ToInt32(reader["Momentum"]);
                    company.Based = Convert.ToInt32(reader["Based_In"]);
                    company.Ace = Convert.ToInt32(reader["Ace"]);
                    company.YoungLion = (bool)reader["YoungLion"];
                    company.Announcer1 = Convert.ToInt32(reader["Announce1"]);
                    company.Announcer2 = Convert.ToInt32(reader["Announce2"]);
                    company.Announcer3 = Convert.ToInt32(reader["Announce3"]);
                    company.GreatLakes = (int)Math.Floor(Convert.ToDouble(reader["Over1"]) / 10);
                    company.MidAtlantic = (int)Math.Floor(Convert.ToDouble(reader["Over2"]) / 10);
                    company.MidSouth = (int)Math.Floor(Convert.ToDouble(reader["Over3"]) / 10);
                    company.MidWest = (int)Math.Floor(Convert.ToDouble(reader["Over4"]) / 10);
                    company.NewEngland = (int)Math.Floor(Convert.ToDouble(reader["Over5"]) / 10);
                    company.NorthWest = (int)Math.Floor(Convert.ToDouble(reader["Over6"]) / 10);
                    company.SouthEast = (int)Math.Floor(Convert.ToDouble(reader["Over7"]) / 10);
                    company.SouthWest = (int)Math.Floor(Convert.ToDouble(reader["Over8"]) / 10);
                    company.TriState = (int)Math.Floor(Convert.ToDouble(reader["Over9"]) / 10);
                    company.PuertoRico = (int)Math.Floor(Convert.ToDouble(reader["Over10"]) / 10);
                    company.Hawaii = (int)Math.Floor(Convert.ToDouble(reader["Over11"]) / 10);
                    company.Maritimes = (int)Math.Floor(Convert.ToDouble(reader["Over12"]) / 10);
                    company.Quebec = (int)Math.Floor(Convert.ToDouble(reader["Over13"]) / 10);
                    company.Ontario = (int)Math.Floor(Convert.ToDouble(reader["Over14"]) / 10);
                    company.Alberta = (int)Math.Floor(Convert.ToDouble(reader["Over15"]) / 10);
                    company.Saskatchewan = (int)Math.Floor(Convert.ToDouble(reader["Over16"]) / 10);
                    company.Manitoba = (int)Math.Floor(Convert.ToDouble(reader["Over17"]) / 10);
                    company.BritishColumbia = (int)Math.Floor(Convert.ToDouble(reader["Over18"]) / 10);
                    company.Noreste = (int)Math.Floor(Convert.ToDouble(reader["Over19"]) / 10);
                    company.Noroccidente = (int)Math.Floor(Convert.ToDouble(reader["Over20"]) / 10);
                    company.Sureste = (int)Math.Floor(Convert.ToDouble(reader["Over21"]) / 10);
                    company.Sur = (int)Math.Floor(Convert.ToDouble(reader["Over22"]) / 10);
                    company.Centro = (int)Math.Floor(Convert.ToDouble(reader["Over23"]) / 10);
                    company.Occidente = (int)Math.Floor(Convert.ToDouble(reader["Over24"]) / 10);
                    company.Midlands = (int)Math.Floor(Convert.ToDouble(reader["Over25"]) / 10);
                    company.NorthernEngland = (int)Math.Floor(Convert.ToDouble(reader["Over26"]) / 10);
                    company.Scotland = (int)Math.Floor(Convert.ToDouble(reader["Over27"]) / 10);
                    company.SouthernEngland = (int)Math.Floor(Convert.ToDouble(reader["Over28"]) / 10);
                    company.Ireland = (int)Math.Floor(Convert.ToDouble(reader["Over29"]) / 10);
                    company.Wales = (int)Math.Floor(Convert.ToDouble(reader["Over30"]) / 10);
                    company.Tohoku = (int)Math.Floor(Convert.ToDouble(reader["Over31"]) / 10);
                    company.Kanto = (int)Math.Floor(Convert.ToDouble(reader["Over32"]) / 10);
                    company.Chubu = (int)Math.Floor(Convert.ToDouble(reader["Over33"]) / 10);
                    company.Kansai = (int)Math.Floor(Convert.ToDouble(reader["Over34"]) / 10);
                    company.Chugoku = (int)Math.Floor(Convert.ToDouble(reader["Over35"]) / 10);
                    company.Shikoku = (int)Math.Floor(Convert.ToDouble(reader["Over36"]) / 10);
                    company.Kyushu = (int)Math.Floor(Convert.ToDouble(reader["Over37"]) / 10);
                    company.Hokkaido = (int)Math.Floor(Convert.ToDouble(reader["Over38"]) / 10);
                    company.WesternEurope = (int)Math.Floor(Convert.ToDouble(reader["Over39"]) / 10);
                    company.Iberia = (int)Math.Floor(Convert.ToDouble(reader["Over40"]) / 10);
                    company.SouthernMediterranean = (int)Math.Floor(Convert.ToDouble(reader["Over41"]) / 10);
                    company.SouthernEurope = (int)Math.Floor(Convert.ToDouble(reader["Over42"]) / 10);
                    company.CentralEurope = (int)Math.Floor(Convert.ToDouble(reader["Over43"]) / 10);
                    company.Scandinavia = (int)Math.Floor(Convert.ToDouble(reader["Over44"]) / 10);
                    company.EasternEurope = (int)Math.Floor(Convert.ToDouble(reader["Over45"]) / 10);
                    company.Russia = (int)Math.Floor(Convert.ToDouble(reader["Over46"]) / 10);
                    company.NewSouthWales = (int)Math.Floor(Convert.ToDouble(reader["Over47"]) / 10);
                    company.Queensland = (int)Math.Floor(Convert.ToDouble(reader["Over48"]) / 10);
                    company.SouthAustralia = (int)Math.Floor(Convert.ToDouble(reader["Over49"]) / 10);
                    company.Victoria = (int)Math.Floor(Convert.ToDouble(reader["Over50"]) / 10);
                    company.WesternAustralia = (int)Math.Floor(Convert.ToDouble(reader["Over51"]) / 10);
                    company.Tasmania = (int)Math.Floor(Convert.ToDouble(reader["Over52"]) / 10);
                    company.NewZealand = (int)Math.Floor(Convert.ToDouble(reader["Over53"]) / 10);
                    company.NorthernIndia = (int)Math.Floor(Convert.ToDouble(reader["Over54"]) / 10);
                    company.CentralIndia = (int)Math.Floor(Convert.ToDouble(reader["Over55"]) / 10);
                    company.SouthernIndia = (int)Math.Floor(Convert.ToDouble(reader["Over56"]) / 10);
                    if (Convert.ToInt32(reader["ClosedMonth"]) == 0)
                    {
                        companies.Add(company);
                    }
                }

                BindCompanyBox(comboBox1, companies);
                BindCompanyBox(comboBox5, companies);
                BindCompanyBox(comboBox7, companies);

                reader.Close();
                cmd.CommandText = "SELECT FedUID, WorkerUID FROM tblContract";
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Contract contract = new Contract();

                    contract.companyId = (int)reader["FedUID"];
                    contract.workerId = (int)reader["WorkerUID"];

                    contracts.Add(contract);
                }

                reader.Close();
                cmd.CommandText = "SELECT tblWorker.UID, tblWorker.Name, tblWorker.Picture, tblWorker.Male, tblWorker.Birth_Month, tblWorker.Birth_Year, tblWorker.Debut_Month, tblWorker.Debut_Year, tblWorker.BodyType," +
                    " tblWorker.Size, tblWorker.Nationality, tblWorker.Style, tblWorker.Race, tblWorker.Based_In, tblWorker.Sexuality, tblWorker.Outsiderel, tblWorkerSkill.Brawl, tblWorkerSkill.Air, tblWorkerSkill.Technical," +
                    " tblWorker.Dead, tblWorker.Retired, tblWorker.LeftBusiness, tblWorker.NonWrestler, tblWorkerSkill.Power, tblWorkerSkill.Athletic, tblWorkerSkill.Stamina, tblWorkerSkill.Psych, tblWorkerSkill.Basics, tblWorkerSkill.Tough," +
                    " tblWorkerSkill.Sell, tblWorkerSkill.Charisma, tblWorkerSkill.Mic, tblWorkerSkill.Menace, tblWorkerSkill.Respect, tblWorkerSkill.Reputation, tblWorkerSkill.Safety, tblWorkerSkill.Looks, tblWorkerSkill.Star," +
                    " tblWorkerSkill.Consistency, tblWorkerSkill.Act, tblWorkerSkill.Injury, tblWorkerSkill.Puroresu, tblWorkerSkill.Flash, tblWorkerBusiness.Business, tblWorkerBusiness.Booking_Reputation, tblWorkerBusiness.Booking_Skill," +
                    " tblWorkerSkill.Hardcore, tblWorkerSkill.Announcing, tblWorkerSkill.Colour, tblWorkerOver.Over1, tblWorkerOver.Over2, tblWorkerOver.Over3, tblWorkerOver.Over4, tblWorkerOver.Over5, tblWorkerOver.Over6, tblWorkerOver.Over7," +
                    " tblWorkerOver.Over8, tblWorkerOver.Over9, tblWorkerOver.Over10, tblWorkerOver.Over11, tblWorkerOver.Over12, tblWorkerOver.Over13, tblWorkerOver.Over14, tblWorkerOver.Over15, tblWorkerOver.Over16, tblWorkerOver.Over17," +
                    " tblWorkerOver.Over18, tblWorkerOver.Over19, tblWorkerOver.Over20, tblWorkerOver.Over21, tblWorkerOver.Over22, tblWorkerOver.Over23, tblWorkerOver.Over24, tblWorkerOver.Over25, tblWorkerOver.Over26," +
                    " tblWorkerOver.Over27, tblWorkerOver.Over28, tblWorkerOver.Over29, tblWorkerOver.Over30, tblWorkerOver.Over31, tblWorkerOver.Over32, tblWorkerOver.Over33, tblWorkerOver.Over34, tblWorkerOver.Over35," +
                    " tblWorkerOver.Over36, tblWorkerOver.Over37, tblWorkerOver.Over38, tblWorkerOver.Over39, tblWorkerOver.Over40, tblWorkerOver.Over41, tblWorkerOver.Over42, tblWorkerOver.Over43, tblWorkerOver.Over44," +
                    " tblWorkerOver.Over45, tblWorkerOver.Over46, tblWorkerOver.Over47, tblWorkerOver.Over48, tblWorkerOver.Over49, tblWorkerOver.Over50, tblWorkerOver.Over51, tblWorkerOver.Over52, tblWorkerOver.Over53," +
                    " tblWorkerOver.Over54, tblWorkerOver.Over55, tblWorkerOver.Over56, tblWorkerSkill.Refereeing, tblWorkerSkill.Experience, tblWorkerPhysical.Condition1, tblWorkerPhysical.Condition2," +
                    " tblWorkerPhysical.Condition3, tblWorkerPhysical.Condition4 FROM (((tblWorker INNER JOIN tblWorkerOver ON tblWorker.UID = tblWorkerOver.WorkerUID) INNER JOIN tblWorkerPhysical" +
                    " ON tblWorker.UID = tblWorkerPhysical.WorkerUID) INNER JOIN tblWorkerSkill ON tblWorker.UID = tblWorkerSkill.WorkerUID) INNER JOIN tblWorkerBusiness ON tblWorker.UID = tblWorkerBusiness.WorkerUID";
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Worker worker = new Worker();

                    worker.UID = (int)reader["UID"];
                    worker.Name = (string)reader["Name"];
                    worker.Picture = (string)reader["Picture"];
                    worker.Male = (bool)reader["Male"];
                    worker.BirthMonth = Convert.ToInt32(reader["Birth_Month"]);
                    worker.BirthYear = Convert.ToInt32(reader["Birth_Year"]);
                    worker.DebutMonth = Convert.ToInt32(reader["Debut_Month"]);
                    worker.DebutYear = Convert.ToInt32(reader["Debut_Year"]);
                    worker.BodyType = Convert.ToInt32(reader["BodyType"]);
                    worker.Size = Convert.ToInt32(reader["Size"]);
                    worker.Status = getStatus((bool)reader["Dead"], (bool)reader["LeftBusiness"], (bool)reader["Retired"], (bool)reader["NonWrestler"]);
                    worker.Nationality = Convert.ToInt32(reader["Nationality"]);
                    worker.Style = Convert.ToInt32(reader["Style"]);
                    worker.Race = Convert.ToInt32(reader["Race"]);
                    worker.Based = Convert.ToInt32(reader["Based_In"]);
                    worker.Sexuality = Convert.ToInt32(reader["Sexuality"]);
                    worker.OutsideRelationship = Convert.ToInt32(reader["Outsiderel"]);
                    worker.Brawling = (int)Math.Floor(Convert.ToDouble(reader["Brawl"]) / 10);
                    worker.Technical = (int)Math.Floor(Convert.ToDouble(reader["Technical"]) / 10);
                    worker.Aerial = (int)Math.Floor(Convert.ToDouble(reader["Air"]) / 10);
                    worker.Power = (int)Math.Floor(Convert.ToDouble(reader["Power"]) / 10);
                    worker.Athleticism = (int)Math.Floor(Convert.ToDouble(reader["Athletic"]) / 10);
                    worker.Stamina = (int)Math.Floor(Convert.ToDouble(reader["Stamina"]) / 10);
                    worker.Psychology = (int)Math.Floor(Convert.ToDouble(reader["Psych"]) / 10);
                    worker.Basics = (int)Math.Floor(Convert.ToDouble(reader["Basics"]) / 10);
                    worker.Toughness = (int)Math.Floor(Convert.ToDouble(reader["Tough"]) / 10);
                    worker.Selling = (int)Math.Floor(Convert.ToDouble(reader["Sell"]) / 10);
                    worker.Charisma = (int)Math.Floor(Convert.ToDouble(reader["Charisma"]) / 10);
                    worker.Microphone = (int)Math.Floor(Convert.ToDouble(reader["Mic"]) / 10);
                    worker.Menace = (int)Math.Floor(Convert.ToDouble(reader["Menace"]) / 10);
                    worker.Respect = (int)Math.Floor(Convert.ToDouble(reader["Respect"]) / 10);
                    worker.Reputation = (int)Math.Floor(Convert.ToDouble(reader["Reputation"]) / 10);
                    worker.Safety = (int)Math.Floor(Convert.ToDouble(reader["Safety"]) / 10);
                    worker.SexAppeal = (int)Math.Floor(Convert.ToDouble(reader["Looks"]) / 10);
                    worker.StarQuality = (int)Math.Floor(Convert.ToDouble(reader["Star"]) / 10);
                    worker.Consistency = (int)Math.Floor(Convert.ToDouble(reader["Consistency"]) / 10);
                    worker.Acting = (int)Math.Floor(Convert.ToDouble(reader["Act"]) / 10);
                    worker.Resilience = (int)Math.Floor(Convert.ToDouble(reader["Injury"]) / 10);
                    worker.Puroresu = (int)Math.Floor(Convert.ToDouble(reader["Puroresu"]) / 10);
                    worker.Flashiness = (int)Math.Floor(Convert.ToDouble(reader["Flash"]) / 10);
                    worker.Hardcore = (int)Math.Floor(Convert.ToDouble(reader["Hardcore"]) / 10);
                    worker.Announcing = (int)Math.Floor(Convert.ToDouble(reader["Announcing"]) / 10);
                    worker.Colour = (int)Math.Floor(Convert.ToDouble(reader["Colour"]) / 10);
                    worker.Refereeing = (int)Math.Floor(Convert.ToDouble(reader["Refereeing"]) / 10);
                    worker.Experience = (int)Math.Floor(Convert.ToDouble(reader["Experience"]) / 10);
                    worker.BusinessReputation = (int)Math.Floor(Convert.ToDouble(reader["Business"]) / 10);
                    worker.BookingReputation = (int)Math.Floor(Convert.ToDouble(reader["Booking_Reputation"]) / 10);
                    worker.BookingSkill = (int)Math.Floor(Convert.ToDouble(reader["Booking_Skill"]) / 10);
                    worker.PhysicalHead = (int)Math.Floor(Convert.ToDouble(reader["Condition1"]) / 10);
                    worker.PhysicalBody = (int)Math.Floor(Convert.ToDouble(reader["Condition2"]) / 10);
                    worker.PhysicalArms = (int)Math.Floor(Convert.ToDouble(reader["Condition3"]) / 10);
                    worker.PhysicalLegs = (int)Math.Floor(Convert.ToDouble(reader["Condition4"]) / 10);
                    worker.GreatLakes = (int)Math.Floor(Convert.ToDouble(reader["Over1"]) / 10);
                    worker.MidAtlantic = (int)Math.Floor(Convert.ToDouble(reader["Over2"]) / 10);
                    worker.MidSouth = (int)Math.Floor(Convert.ToDouble(reader["Over3"]) / 10);
                    worker.MidWest = (int)Math.Floor(Convert.ToDouble(reader["Over4"]) / 10);
                    worker.NewEngland = (int)Math.Floor(Convert.ToDouble(reader["Over5"]) / 10);
                    worker.NorthWest = (int)Math.Floor(Convert.ToDouble(reader["Over6"]) / 10);
                    worker.SouthEast = (int)Math.Floor(Convert.ToDouble(reader["Over7"]) / 10);
                    worker.SouthWest = (int)Math.Floor(Convert.ToDouble(reader["Over8"]) / 10);
                    worker.TriState = (int)Math.Floor(Convert.ToDouble(reader["Over9"]) / 10);
                    worker.PuertoRico = (int)Math.Floor(Convert.ToDouble(reader["Over10"]) / 10);
                    worker.Hawaii = (int)Math.Floor(Convert.ToDouble(reader["Over11"]) / 10);
                    worker.Maritimes = (int)Math.Floor(Convert.ToDouble(reader["Over12"]) / 10);
                    worker.Quebec = (int)Math.Floor(Convert.ToDouble(reader["Over13"]) / 10);
                    worker.Ontario = (int)Math.Floor(Convert.ToDouble(reader["Over14"]) / 10);
                    worker.Alberta = (int)Math.Floor(Convert.ToDouble(reader["Over15"]) / 10);
                    worker.Saskatchewan = (int)Math.Floor(Convert.ToDouble(reader["Over16"]) / 10);
                    worker.Manitoba = (int)Math.Floor(Convert.ToDouble(reader["Over17"]) / 10);
                    worker.BritishColumbia = (int)Math.Floor(Convert.ToDouble(reader["Over18"]) / 10);
                    worker.Noreste = (int)Math.Floor(Convert.ToDouble(reader["Over19"]) / 10);
                    worker.Noroccidente = (int)Math.Floor(Convert.ToDouble(reader["Over20"]) / 10);
                    worker.Sureste = (int)Math.Floor(Convert.ToDouble(reader["Over21"]) / 10);
                    worker.Sur = (int)Math.Floor(Convert.ToDouble(reader["Over22"]) / 10);
                    worker.Centro = (int)Math.Floor(Convert.ToDouble(reader["Over23"]) / 10);
                    worker.Occidente = (int)Math.Floor(Convert.ToDouble(reader["Over24"]) / 10);
                    worker.Midlands = (int)Math.Floor(Convert.ToDouble(reader["Over25"]) / 10);
                    worker.NorthernEngland = (int)Math.Floor(Convert.ToDouble(reader["Over26"]) / 10);
                    worker.Scotland = (int)Math.Floor(Convert.ToDouble(reader["Over27"]) / 10);
                    worker.SouthernEngland = (int)Math.Floor(Convert.ToDouble(reader["Over28"]) / 10);
                    worker.Ireland = (int)Math.Floor(Convert.ToDouble(reader["Over29"]) / 10);
                    worker.Wales = (int)Math.Floor(Convert.ToDouble(reader["Over30"]) / 10);
                    worker.Tohoku = (int)Math.Floor(Convert.ToDouble(reader["Over31"]) / 10);
                    worker.Kanto = (int)Math.Floor(Convert.ToDouble(reader["Over32"]) / 10);
                    worker.Chubu = (int)Math.Floor(Convert.ToDouble(reader["Over33"]) / 10);
                    worker.Kansai = (int)Math.Floor(Convert.ToDouble(reader["Over34"]) / 10);
                    worker.Chugoku = (int)Math.Floor(Convert.ToDouble(reader["Over35"]) / 10);
                    worker.Shikoku = (int)Math.Floor(Convert.ToDouble(reader["Over36"]) / 10);
                    worker.Kyushu = (int)Math.Floor(Convert.ToDouble(reader["Over37"]) / 10);
                    worker.Hokkaido = (int)Math.Floor(Convert.ToDouble(reader["Over38"]) / 10);
                    worker.WesternEurope = (int)Math.Floor(Convert.ToDouble(reader["Over39"]) / 10);
                    worker.Iberia = (int)Math.Floor(Convert.ToDouble(reader["Over40"]) / 10);
                    worker.SouthernMediterranean = (int)Math.Floor(Convert.ToDouble(reader["Over41"]) / 10);
                    worker.SouthernEurope = (int)Math.Floor(Convert.ToDouble(reader["Over42"]) / 10);
                    worker.CentralEurope = (int)Math.Floor(Convert.ToDouble(reader["Over43"]) / 10);
                    worker.Scandinavia = (int)Math.Floor(Convert.ToDouble(reader["Over44"]) / 10);
                    worker.EasternEurope = (int)Math.Floor(Convert.ToDouble(reader["Over45"]) / 10);
                    worker.Russia = (int)Math.Floor(Convert.ToDouble(reader["Over46"]) / 10);
                    worker.NewSouthWales = (int)Math.Floor(Convert.ToDouble(reader["Over47"]) / 10);
                    worker.Queensland = (int)Math.Floor(Convert.ToDouble(reader["Over48"]) / 10);
                    worker.SouthAustralia = (int)Math.Floor(Convert.ToDouble(reader["Over49"]) / 10);
                    worker.Victoria = (int)Math.Floor(Convert.ToDouble(reader["Over50"]) / 10);
                    worker.WesternAustralia = (int)Math.Floor(Convert.ToDouble(reader["Over51"]) / 10);
                    worker.Tasmania = (int)Math.Floor(Convert.ToDouble(reader["Over52"]) / 10);
                    worker.NewZealand = (int)Math.Floor(Convert.ToDouble(reader["Over53"]) / 10);
                    worker.NorthernIndia = (int)Math.Floor(Convert.ToDouble(reader["Over54"]) / 10);
                    worker.CentralIndia = (int)Math.Floor(Convert.ToDouble(reader["Over55"]) / 10);
                    worker.SouthernIndia = (int)Math.Floor(Convert.ToDouble(reader["Over56"]) / 10);
                    workers.Add(worker);
                }
                reader.Close();
                cmd.CommandText = "SELECT * FROM tblAttribute";
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Attributes attribute = new Attributes();

                    attribute.WorkerUID = (int)reader["WorkerUID"];
                    attribute.Attribute = Convert.ToInt32(reader["Attribute"]);
                    attribute.Hidden = (bool)reader["Hidden"];

                    attributes.Add(attribute);
                }
                reader.Close();
                cmd.CommandText = "SELECT * FROM tblNotepad";
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Notepad.Text = (string)reader["Notepad"];
                }

                loadPlayer();
                loadWorkers(((Company)comboBox1.SelectedItem).Id, comboBox2);
                loadStats();
                loadWorkers(((Company)comboBox5.SelectedItem).Id, comboBox6, chart2, comboBox4);
                loadWorkers(((Company)comboBox5.SelectedItem).Id, comboBox8, chart1, comboBox3);
                randomizeWrestlers();
                loadUserCompany();
            }
        }

        private void BindCompanyBox<T>(ComboBox comboBox, List<T> list)
        {
            comboBox.BindingContext = new BindingContext();
            comboBox.DataSource = list;
            comboBox.DisplayMember = "Name";
            comboBox.SelectedIndex = 0;

        }

        private void loadPlayer()
        {
            tabControl3.Visible = true;
            Worker selectedWorker = workers.Where(worker => worker.UID == playerInfo.ID).First();

            playerName.Text = selectedWorker.Name;

            try
            {
                userImage.Image = Image.FromFile($"{rootDirectory}\\Pictures\\{ saveGame.PictureFolder}\\People\\{selectedWorker.Picture}");
            }
            catch
            {
                userImage.Image = Image.FromFile($"{rootDirectory}\\Pictures\\{saveGame.PictureFolder}\\People\\_Wrestler.gif");
            }

            userDGV1.Rows.Clear();
            userDGV2.Rows.Clear();
            userDGV3.Rows.Clear();
            userDGV10.Rows.Clear();
            foreach (string talent in talents)
            {
                userDGV1.Rows.Add(string.Concat(talent.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' '), playerInfo.GetType().GetProperty(talent).GetValue(playerInfo));
            }
            userDGV2.Rows.Add("Gender", getGender(selectedWorker.Male));
            userDGV2.Rows.Add("Age", $"{getYears(selectedWorker.BirthMonth, selectedWorker.BirthYear)} years old");
            userDGV2.Rows.Add("Race", selectedWorker.RaceName[selectedWorker.Race]);
            userDGV2.Rows.Add("Nationality", selectedWorker.NationalityName[selectedWorker.Nationality]);
            userDGV2.Rows.Add("Based In", selectedWorker.LocationName[selectedWorker.Based]);
            userDGV2.Rows.Add("Sexuality", selectedWorker.SexualityName[selectedWorker.Sexuality]);
            userDGV2.Rows.Add("Outside Relationship", selectedWorker.RelationshipType[selectedWorker.OutsideRelationship]);
            userDGV2.Rows.Add("Experience", $"{getYears(selectedWorker.DebutMonth, selectedWorker.DebutYear)} years");

            Contract userContract = (Contract)contracts.Where(contract => contract.workerId == selectedWorker.UID).FirstOrDefault();
            if (userContract != null)
            {
                Company userCompany = companies.Where(company => company.Id == userContract.companyId).FirstOrDefault();
                try
                {
                    userImage.BackgroundImage = Image.FromFile($"{rootDirectory}\\Pictures\\{saveGame.PictureFolder}\\Logos\\{userCompany.Logo}");
                }
                catch { }
                userDGV3.Rows.Add("Employer", userCompany.Name);
                if (userCompany.Owner == selectedWorker.UID)
                    userDGV3.Rows.Add("Role", "Owner and Head Booker");
                else
                    userDGV3.Rows.Add("Role", "Head Booker");
            }
            else
            {
                userDGV3.Rows.Add("Employer", "Unemployed");
                userDGV3.Rows.Add("Role", "None");

            }
            userDGV3.Rows.Add("Status", selectedWorker.Status);
            userDGV3.Rows.Add("Style", selectedWorker.StyleName[selectedWorker.Style]);
            userDGV3.Rows.Add("Body Type", selectedWorker.BodyTypeName[selectedWorker.BodyType]);
            userDGV3.Rows.Add("Size", selectedWorker.SizeName[selectedWorker.Size]);
            //userDGV3.Rows.Add("Hall of Immortals", "N/A");

            fillDataGridView(primarySkills, userDGV4, selectedWorker);
            fillDataGridView(mentalSkills, userDGV5, selectedWorker);
            fillDataGridView(performanceSkills, userDGV6, selectedWorker);
            fillDataGridView(basicSkills, userDGV7, selectedWorker);
            fillDataGridView(physicalAbilities, userDGV8, selectedWorker);
            fillDataGridView(otherSkills, userDGV9, selectedWorker);
            fillDataGridView(physical, userDGV11, selectedWorker, "Physical");
            fillDataGridView(usaPop, userDGV12, selectedWorker);
            fillDataGridView(canadaPop, userDGV13, selectedWorker);
            fillDataGridView(mexicoPop, userDGV14, selectedWorker);
            fillDataGridView(britishPop, userDGV15, selectedWorker);
            fillDataGridView(japanPop, userDGV16, selectedWorker);
            fillDataGridView(europePop, userDGV17, selectedWorker);
            fillDataGridView(oceaniaPop, userDGV18, selectedWorker);
            fillDataGridView(indiaPop, userDGV19, selectedWorker);

            foreach (Attributes attribute in attributes)
            {
                if (selectedWorker.UID == attribute.WorkerUID && attribute.Hidden == false)
                    userDGV10.Rows.Add(attribute.AttributeName[attribute.Attribute]);
            }

            userDGV1.Height = userDGV1.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            userDGV2.Height = userDGV2.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            userDGV3.Height = userDGV3.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            userDGV4.Height = userDGV4.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            userDGV5.Height = userDGV5.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            userDGV9.Height = userDGV9.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            userDGV6.Height = userDGV6.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            userDGV8.Height = userDGV8.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            userDGV7.Height = userDGV7.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            userDGV10.Height = userDGV10.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            userDGV11.Height = userDGV11.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            userDGV12.Height = userDGV12.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            userDGV13.Height = userDGV13.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            userDGV14.Height = userDGV14.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            userDGV15.Height = userDGV15.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            userDGV16.Height = userDGV16.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            userDGV17.Height = userDGV17.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            userDGV19.Height = userDGV19.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            userDGV18.Height = userDGV18.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            tabControl3.Height = tableLayoutPanel12.Height;
            loadChartData(selectedWorker, chart1, Color.FromArgb(100, Color.Blue), comboBox3);
        }

        private void loadChartData(Worker worker, Chart chart, Color color, ComboBox comboBox)
        {
            if (chart.Series.IndexOf(worker.Name) == -1)
            {
                chart.Series.Add(worker.Name);
            }
            else
            {
                chart.Series[worker.Name].Points.Clear();
            }
            chart.Series[worker.Name].ChartType = SeriesChartType.Radar;
            chart.Series[worker.Name].Color = Color.FromArgb(100, color);
            chart.Series[worker.Name].BorderColor = Color.FromArgb(255, color);
            string[] stats;
            switch ((string)comboBox.SelectedItem)
            {
                default:
                    stats = primarySkills.Concat(mentalSkills).Concat(performanceSkills).Concat(basicSkills).Concat(physicalAbilities).Concat(otherSkills).ToArray();
                    break;
                case "Primary Skills":
                    stats = primarySkills;
                    break;
                case "Mental Skills":
                    stats = mentalSkills;
                    break;
                case "Performance Skills":
                    stats = performanceSkills;
                    break;
                case "Basic Skills":
                    stats = basicSkills;
                    break;
                case "Physical Abilities":
                    stats = physicalAbilities;
                    break;
                case "Other Skills":
                    stats = otherSkills;
                    break;
            }
            foreach (string stat in stats)
                chart.Series[worker.Name].Points.AddXY(string.Concat(stat.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' '), worker.GetType().GetProperty(stat).GetValue(worker));
        }

        private void loadWorkers(int companyID, ComboBox comboBox, Chart chart = null, ComboBox statComboBox = null)
        {
            BindingList<Worker> companyWorkers = new BindingList<Worker>();
            comboBox.BindingContext = new BindingContext();
            switch (companyID)
            {
                case -1:
                    foreach (Worker worker in workers)
                    {
                        companyWorkers.Add(worker);
                    }
                    comboBox.DataSource = companyWorkers;
                    loadComparedChartData(companyWorkers.OrderBy(x => x.Name).ElementAt(0), chart, statComboBox);
                    break;
                case 0:
                    foreach (Worker worker in workers)
                    {
                        bool contains = contracts.Any(contract => contract.workerId == worker.UID);
                        if (!contains)
                        {
                            companyWorkers.Add(worker);
                        }
                    }
                    comboBox.DataSource = companyWorkers;
                    loadComparedChartData(companyWorkers.OrderBy(x => x.Name).ElementAt(0), chart, statComboBox);
                    break;
                default:
                    foreach (Contract contract in contracts)
                    {
                        if (contract.companyId == companyID)
                        {
                            foreach (Worker worker in workers)
                            {
                                if (contract.workerId == worker.UID)
                                {
                                    companyWorkers.Add(worker);
                                }
                            }
                        }
                    }
                    comboBox.DataSource = companyWorkers;
                    loadComparedChartData(companyWorkers.OrderBy(x => x.Name).ElementAt(0), chart, statComboBox);
                    break;

            }
            comboBox.DisplayMember = "Name";
        }

        private void loadComparedChartData(Worker worker, Chart chart, ComboBox comboBox)
        {
            if (chart != null && comboBox != null)
            {
                if (chart.Series.Count == 2)
                    chart.Series.RemoveAt(1);
                if (chart.Series.IsUniqueName(worker.Name))
                    loadChartData(worker, chart, Color.Red, comboBox);
            }
        }


        private void loadStats()
        {
            tabControl2.Visible = true;
            chart2.Series.Clear();
            Worker selectedWorker = (Worker)comboBox2.SelectedItem;
            Company selectedCompany = (Company)comboBox1.SelectedItem;
            try
            {
                wrestlerImage.Image = Image.FromFile($"{rootDirectory}\\Pictures\\{saveGame.PictureFolder}\\People\\{selectedWorker.Picture}");
                if (selectedCompany.Id > 0)
                    wrestlerImage.BackgroundImage = Image.FromFile($"{rootDirectory}\\Pictures\\{saveGame.PictureFolder}\\Logos\\{selectedCompany.Logo}");
            }
            catch
            {
                wrestlerImage.Image = Image.FromFile($"{rootDirectory}\\Pictures\\{saveGame.PictureFolder}\\People\\_Wrestler.gif");
                if (selectedCompany.Id > 0)
                    wrestlerImage.BackgroundImage = Image.FromFile($"{rootDirectory}\\Pictures\\{saveGame.PictureFolder}\\Logos\\{selectedCompany.Logo}");
            }
            label4.Text = selectedWorker.Name;

            wrestlerDGV1.Rows.Clear();
            wrestlerDGV2.Rows.Clear();
            wrestlerDGV9.Rows.Clear();
            
            wrestlerDGV1.Rows.Add("Gender", getGender(selectedWorker.Male));
            wrestlerDGV1.Rows.Add("Age", $"{getYears(selectedWorker.BirthMonth, selectedWorker.BirthYear)} years old");
            wrestlerDGV1.Rows.Add("Race", selectedWorker.RaceName[selectedWorker.Race]);
            wrestlerDGV1.Rows.Add("Nationality", selectedWorker.NationalityName[selectedWorker.Nationality]);
            wrestlerDGV1.Rows.Add("Based In", selectedWorker.LocationName[selectedWorker.Based]);
            wrestlerDGV1.Rows.Add("Sexuality", selectedWorker.SexualityName[selectedWorker.Sexuality]);
            wrestlerDGV1.Rows.Add("Outside Relationship", selectedWorker.RelationshipType[selectedWorker.OutsideRelationship]);
            wrestlerDGV2.Rows.Add("Status", selectedWorker.Status);
            wrestlerDGV2.Rows.Add("Style", selectedWorker.StyleName[selectedWorker.Style]);
            wrestlerDGV2.Rows.Add("Body Type", selectedWorker.BodyTypeName[selectedWorker.BodyType]);
            wrestlerDGV2.Rows.Add("Size", selectedWorker.SizeName[selectedWorker.Size]);
            wrestlerDGV2.Rows.Add("Experience", $"{getYears(selectedWorker.DebutMonth, selectedWorker.DebutYear)} years");
            //wrestlerDGV2.Rows.Add("Hall of Immortals", "N/A");

            fillDataGridView(primarySkills, wrestlerDGV3, selectedWorker);
            fillDataGridView(mentalSkills, wrestlerDGV4, selectedWorker);
            fillDataGridView(performanceSkills, wrestlerDGV5, selectedWorker);
            fillDataGridView(basicSkills, wrestlerDGV6, selectedWorker);
            fillDataGridView(physicalAbilities, wrestlerDGV7, selectedWorker);
            fillDataGridView(otherSkills, wrestlerDGV8, selectedWorker);
            fillDataGridView(physical, wrestlerDGV10, selectedWorker, "Physical");
            fillDataGridView(usaPop, wrestlerDGV11, selectedWorker);
            fillDataGridView(canadaPop, wrestlerDGV12, selectedWorker);
            fillDataGridView(mexicoPop, wrestlerDGV13, selectedWorker);
            fillDataGridView(britishPop, wrestlerDGV14, selectedWorker);
            fillDataGridView(japanPop, wrestlerDGV15, selectedWorker);
            fillDataGridView(europePop, wrestlerDGV16, selectedWorker);
            fillDataGridView(oceaniaPop, wrestlerDGV17, selectedWorker);
            fillDataGridView(indiaPop, wrestlerDGV18, selectedWorker);

            foreach (Attributes attribute in attributes)
            {
                if (selectedWorker.UID == attribute.WorkerUID && attribute.Hidden == false)
                    wrestlerDGV9.Rows.Add(attribute.AttributeName[attribute.Attribute]);
            }

            wrestlerDGV1.Height = wrestlerDGV1.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            wrestlerDGV2.Height = wrestlerDGV2.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            wrestlerDGV3.Height = wrestlerDGV3.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            wrestlerDGV4.Height = wrestlerDGV4.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            wrestlerDGV5.Height = wrestlerDGV5.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            wrestlerDGV6.Height = wrestlerDGV6.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            wrestlerDGV7.Height = wrestlerDGV7.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            wrestlerDGV8.Height = wrestlerDGV8.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            wrestlerDGV9.Height = wrestlerDGV9.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            wrestlerDGV10.Height = wrestlerDGV10.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            wrestlerDGV11.Height = wrestlerDGV11.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            wrestlerDGV12.Height = wrestlerDGV12.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            wrestlerDGV13.Height = wrestlerDGV13.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            wrestlerDGV14.Height = wrestlerDGV14.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            wrestlerDGV15.Height = wrestlerDGV15.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            wrestlerDGV16.Height = wrestlerDGV16.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            wrestlerDGV17.Height = wrestlerDGV17.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            wrestlerDGV18.Height = wrestlerDGV18.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
            tabControl2.Height = tableLayoutPanel2.Height;
            loadChartData(selectedWorker, chart2, Color.FromArgb(100, Color.Blue), comboBox4);
        }

        private void loadUserCompany()
        {
            Worker selectedWorker = workers.Where(worker => worker.UID == playerInfo.ID).First();

            userCompanyDGV1.Rows.Clear();
            userCompanyDGV2.Rows.Clear();

            Contract userContract = (Contract)contracts.Where(contract => contract.workerId == selectedWorker.UID).FirstOrDefault();
            if (userContract != null)
            {
                Company userCompany = companies.Where(company => company.Id == userContract.companyId).FirstOrDefault();
                try
                {
                    usercompanyPicture.Image = Image.FromFile($"{rootDirectory}\\Pictures\\{saveGame.PictureFolder}\\Logos\\{userCompany.Logo}");
                }
                catch { }
                Worker ownerWorker = workers.Where(worker => worker.UID == userCompany.Owner).First();
                Worker bookerWorker = workers.Where(worker => worker.UID == userCompany.HeadBooker).First();
                Worker aceWorker = workers.Where(worker => worker.UID == userCompany.Ace).FirstOrDefault();
                userCompanyName.Text = userCompany.Name;
                userOwnerPicture.Image = Image.FromFile($"{rootDirectory}\\Pictures\\{saveGame.PictureFolder}\\People\\{ownerWorker.Picture}");
                userBookerPicture.Image = Image.FromFile($"{rootDirectory}\\Pictures\\{saveGame.PictureFolder}\\People\\{bookerWorker.Picture}");
                userOwnerPicture.BackgroundImage = Image.FromFile($"{rootDirectory}\\Pictures\\{saveGame.PictureFolder}\\Logos\\{userCompany.Logo}");
                userBookerPicture.BackgroundImage = Image.FromFile($"{rootDirectory}\\Pictures\\{saveGame.PictureFolder}\\Logos\\{userCompany.Logo}");
                userAcePicture.BackgroundImage = Image.FromFile($"{rootDirectory}\\Pictures\\{saveGame.PictureFolder}\\Logos\\{userCompany.Logo}");
                if (userCompany.OwnerTypeValue[userCompany.OwnerType] == "CEO")
                    userOwnerLabel.Text = "CEO";
                else
                    userOwnerLabel.Text = "Owner";
                userOwnerName.Text = ownerWorker.Name;
                userBookerName.Text = bookerWorker.Name;
                if (aceWorker != null)
                {
                    userAcePicture.Image = Image.FromFile($"{rootDirectory}\\Pictures\\{saveGame.PictureFolder}\\People\\{aceWorker.Picture}");
                    userAceName.Text = aceWorker.Name;
                }
                else
                {
                    userAceName.Text = "None";
                }
                userCompanyDGV1.Rows.Add("Style Name", userCompany.StyleName);
                userCompanyDGV1.Rows.Add("Product Base", userCompany.ProductName[userCompany.ProductBase]);
                userCompanyDGV1.Rows.Add("Money", $"${userCompany.Money}");
                userCompanyDGV1.Rows.Add("Media Group Owner", userCompany.MediaGroupOwner);
                userCompanyDGV2.Rows.Add("Ranking", userCompany.Ranking);
                userCompanyDGV2.Rows.Add("Prestige", userCompany.Prestige);
                userCompanyDGV2.Rows.Add("Momentum", userCompany.Momentum);
                userCompanyDGV2.Rows.Add("Size", userCompany.Size);

                fillDataGridView(usaPop, userCompanyDGV3, userCompany);
                fillDataGridView(canadaPop, userCompanyDGV4, userCompany);
                fillDataGridView(mexicoPop, userCompanyDGV5, userCompany);
                fillDataGridView(britishPop, userCompanyDGV6, userCompany);
                fillDataGridView(japanPop, userCompanyDGV7, userCompany);
                fillDataGridView(europePop, userCompanyDGV8, userCompany);
                fillDataGridView(oceaniaPop, userCompanyDGV9, userCompany);
                fillDataGridView(indiaPop, userCompanyDGV10, userCompany);

                userCompanyDGV1.Height = userCompanyDGV1.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
                userCompanyDGV2.Height = userCompanyDGV2.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
                userCompanyDGV3.Height = userCompanyDGV3.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
                userCompanyDGV4.Height = userCompanyDGV4.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
                userCompanyDGV5.Height = userCompanyDGV5.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
                userCompanyDGV6.Height = userCompanyDGV6.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
                userCompanyDGV7.Height = userCompanyDGV7.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
                userCompanyDGV8.Height = userCompanyDGV8.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
                userCompanyDGV9.Height = userCompanyDGV9.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
                userCompanyDGV10.Height = userCompanyDGV10.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) + 10;
                tabControl4.Height = tableLayoutPanel43.Height;
            }
            else
            {
                userCompanyName.Text = "Unemployed";
                usercompanyPicture.Image = null;
            }

        }

        private int getYears(int Month, int Year)
        {
            if (saveGame.Current_Date_Month <= Month)
                return saveGame.Current_Date_Year - Year - 1;
            return saveGame.Current_Date_Year - Year;
        }

        private string getStatus(bool Dead, bool LeftBusiness, bool Retired, bool NonWrestler)
        {
            if (Dead)
                return "Deceased";
            else
            {
                if (LeftBusiness)
                    return "Left the Business";
                else
                {
                    if (Retired)
                        return "Retired Wrestler";
                    else if (NonWrestler)
                        return "Non-Wrestler";
                    else
                        return "Active Wrestler";
                }
            }
        }

        private string getGender(bool Male)
        {
            if (Male)
                return "Male";
            else
                return "Female";
        }

        private void fillDataGridView<T>(string[] list, DataGridView dgv, T statObject, String statString = null)
        {
            dgv.Rows.Clear();
            foreach (string stat in list)
            {
                dgv.Rows.Add(string.Concat(stat.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' '), statObject.GetType().GetProperty(statString + stat).GetValue(statObject));
            }
        }

        private void randomizeWrestlers()
        {
            PictureBox[] boxes = { randomPicture1, randomPicture2, randomPicture3, randomPicture4, randomPicture5, randomPicture6 };
            Label[] names = { randomName1, randomName2, randomName3, randomName4, randomName5, randomName6 };
            DataGridView[] dgvs = { randomDGV1, randomDGV2, randomDGV3, randomDGV4, randomDGV5, randomDGV6 };
            chosenWorkers.Clear();

            for (int i = 0; i < 6; i++)
            {
                chosenWorkers.Insert(i, new Worker());
                rerollWrestler(i, boxes[i], dgvs[i], names[i]);
            }
            pollLink();
        }

        private void rerollWrestler(int i, PictureBox randomPicture, DataGridView randomDGV, Label randomName)
        {
            var random = new Random();
            int index = random.Next(workers.Count);
            while (chosenWorkers.Contains(workers[index]))
            {
                index = random.Next(workers.Count);
            }
            chosenWorkers[i] = workers[index];
            Contract userContract = (Contract)contracts.Where(contract => contract.workerId == playerInfo.ID).FirstOrDefault();
            randomDGV.Rows.Clear();
            try
            {
                randomPicture.Image = Image.FromFile($"{rootDirectory}\\Pictures\\{saveGame.PictureFolder}\\People\\{chosenWorkers[i].Picture}");
            }
            catch
            {
                randomPicture.Image = Image.FromFile($"{rootDirectory}\\Pictures\\{saveGame.PictureFolder}\\People\\_Wrestler.gif");
            }
            try
            {
                if (userContract != null)
                {
                    Company userCompany = companies.Where(company => company.Id == userContract.companyId).FirstOrDefault();
                    randomPicture.BackgroundImage = Image.FromFile($"{rootDirectory}\\Pictures\\{saveGame.PictureFolder}\\Logos\\{userCompany.Logo}");
                }
            }
            catch { }
            randomName.Text = chosenWorkers[i].Name;
            randomDGV.Rows.Add($"{getYears(chosenWorkers[i].BirthMonth, chosenWorkers[i].BirthYear)} years old");
            randomDGV.Rows.Add(chosenWorkers[i].Status);
            randomDGV.Rows.Add($"{chosenWorkers[i].NationalityName[chosenWorkers[i].Nationality]} {getGender(chosenWorkers[i].Male)}");
            randomDGV.Rows.Add($"{chosenWorkers[i].BodyTypeName[chosenWorkers[i].BodyType]} {chosenWorkers[i].SizeName[chosenWorkers[i].Size]} {chosenWorkers[i].StyleName[chosenWorkers[i].Style]}");
            randomDGV.Height = randomDGV.Rows.Cast<DataGridViewRow>().Sum(r => r.Height);
        }

        private void pollLink()
        {
            string url = "https://poll.ma.pe/?quickPoll=Who do you want signed?";
            foreach (Worker worker in chosenWorkers)
            {
                url += $";{worker.Name}";
            }
            try
            {
                Clipboard.SetText(url);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                loadDatabase();
                button4.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            folderBrowserDialog1.Description = "Select the TEW2020 Directory";
            rootDirectory = folderBrowserDialog1.SelectedPath;
            if (result == DialogResult.OK)
            {
                label2.Text = rootDirectory;
                button1.Enabled = true;
            }
            else
            {
                if (folderBrowserDialog1.SelectedPath != rootDirectory)
                {
                    button1.Enabled = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            randomizeWrestlers();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadDatabase();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            rerollWrestler(0, randomPicture1, randomDGV1, randomName1);
            pollLink();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            rerollWrestler(1, randomPicture2, randomDGV2, randomName2);
            pollLink();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            rerollWrestler(2, randomPicture3, randomDGV3, randomName3);
            pollLink();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            rerollWrestler(3, randomPicture4, randomDGV4, randomName4);
            pollLink();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            rerollWrestler(4, randomPicture5, randomDGV5, randomName5);
            pollLink();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            rerollWrestler(5, randomPicture6, randomDGV6, randomName6);
            pollLink();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadWorkers(((Company)comboBox1.SelectedItem).Id, comboBox2);
            loadStats();
            loadComparedChartData((Worker)comboBox6.SelectedItem, chart2, comboBox4);
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadStats();
            loadComparedChartData((Worker)comboBox6.SelectedItem, chart2, comboBox4);
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Worker selectedWorker = workers.Where(worker => worker.UID == playerInfo.ID).First();
            Worker comparedWorker = (Worker)comboBox8.SelectedItem;
            loadChartData(selectedWorker, chart1, Color.Blue, comboBox3);
            loadComparedChartData(comparedWorker, chart1, comboBox3);
        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Worker selectedWorker = (Worker)comboBox2.SelectedItem;
            Worker comparedWorker = (Worker)comboBox6.SelectedItem;
            loadChartData(selectedWorker, chart2, Color.Blue, comboBox4);
            loadComparedChartData(comparedWorker, chart2, comboBox4);
        }

        private void comboBox5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadWorkers(((Company)comboBox5.SelectedItem).Id, comboBox6, chart2, comboBox4);
        }

        private void comboBox6_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Worker selectedWorker = (Worker)comboBox6.SelectedItem;
            loadComparedChartData(selectedWorker, chart2, comboBox4);
        }

        private void comboBox7_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadWorkers(((Company)comboBox7.SelectedItem).Id, comboBox8, chart1, comboBox3);
        }

        private void comboBox8_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Worker selectedWorker = (Worker)comboBox8.SelectedItem;
            loadComparedChartData(selectedWorker, chart1, comboBox3);
        }
    }
}