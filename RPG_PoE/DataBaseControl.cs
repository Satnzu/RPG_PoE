using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
namespace RPG_PoE
{
    class DataBaseControl
    {
        string con = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetCurrentDirectory() + @"\POEDB.mdf;Initial Catalog=PoECharacters;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //string con = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RPG_Poe;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connection = new SqlConnection();

        public void yhdista()
        {
            try
            {
                connection.ConnectionString = con;
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void SetHightscore(Score score, int id)
        {
            using (connection)
            {
                yhdista();
                string command = "UPDATE hightscore SET playernam = @nam, lvl = @lvl WHERE Id = @id";
                SqlCommand komento = new SqlCommand(command, connection);
                komento.Parameters.AddWithValue("@nam", score.Name);
                komento.Parameters.AddWithValue("@lvl", score.Lvl);
                komento.Parameters.AddWithValue("@id", 1);
                komento.ExecuteNonQuery();
            }
        }

        public Score HaeHightscore()
        {
            Score score = new Score();
            string command = "Select * From hightscore";
            SqlCommand komento = new SqlCommand(command, connection);
            using (connection)
            {
                yhdista();
                using (SqlDataReader reader = komento.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        score.Lvl = reader.GetInt32(2);
                        score.Name = reader.GetString(1);
                    }
                }
            }
            return score;
        }

        public List<Playerstats> HaeHahmot()
        {
            List<Playerstats> players = new List<Playerstats>();
            using (connection)
            {
                yhdista();
                string command = "Select * From characters";
                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Playerstats player = new Playerstats();
                            player.Id = reader.GetInt32(0);
                            player.Name = reader.GetString(1);
                            player.Increaseddmg = reader.GetDecimal(10);
                            player.Lifeleech = reader.GetDecimal(2);
                            player.Manaleech = reader.GetDecimal(3);
                            player.Def = reader.GetDecimal(4);
                            player.Dmg = reader.GetDecimal(5);
                            player.Speed = reader.GetDecimal(6);
                            player.Hp = reader.GetDecimal(7);
                            player.Accuracy = reader.GetDecimal(8);
                            player.Lvl = reader.GetInt32(9);
                            player.Critchance = reader.GetDecimal(11);
                            player.Critdmg = reader.GetDecimal(12);
                            player.LocationX = reader.GetInt32(13);
                            player.LocationY = reader.GetInt32(14);
                            player.Towerlvl = reader.GetInt32(15);
                            player.Hpregen = reader.GetDecimal(16);
                            player.Inchp = reader.GetDecimal(17);
                            player.Exp = reader.GetInt32(18);
                            player.Exptonext = reader.GetInt32(19);
                            players.Add(player);
                        }
                    }
                }
            }
            List<Playerstats> allplayerstats = new List<Playerstats>();
            foreach (Playerstats player in players)
            {
                Haeskilltree(player);
                allplayerstats.Add(player);
            }
            return allplayerstats;
        }

        public Playerstats Haeskilltree(Playerstats player)
        {
            string command = "Select * From skillpoints WHERE characterid = @id";
            using (SqlCommand sqlCommand = new SqlCommand(command, connection))
            {
                yhdista();
                sqlCommand.Parameters.AddWithValue("@id", player.Id);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        player.Def1 = reader.GetInt32(4);
                        player.Def2 = reader.GetInt32(5);
                        player.Dmg1 = reader.GetInt32(2);
                        player.Dmg2 = reader.GetInt32(3);
                        player.Dmglesslife = reader.GetInt32(7);
                        player.Doublearmor = reader.GetBoolean(15);
                        player.Dualstrike = reader.GetBoolean(8);
                        player.Life1 = reader.GetInt32(11);
                        player.Life2 = reader.GetInt32(12);
                        player.Lifereg1 = reader.GetInt32(13);
                        player.Lifereg2 = reader.GetInt32(14);
                        player.Lifesteal1 = reader.GetInt32(9);
                        player.Lifesteal2 = reader.GetInt32(10);
                        player.Bigdef = reader.GetInt32(6);
                    }
                }
            }
            return player;
        }

        public void luohahmo(Playerstats player)
        {
            using (connection)
            {
                yhdista();
                string command = "INSERT INTO characters(Name, lifeleech, manaleech, defence, dmg, speed, hp, accuracy, level, incdmg, critchance, critdmg, locationX, locationY, towerlvl, hpregen ,inchp, exp, exptonextlvl) VALUES(@name, @lifeleech, @manaleech, @def, @dmg, @speed, @hp, @accuracy, @lvl, @incDMG, @critchance, @critdmg, @locationX, @locationY, @towerlvl, @hpregen, @inchp, @exp, @expToNext)";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@name", player.Name);
                sqlCommand.Parameters.AddWithValue("@lifeleech", player.Lifeleech);
                sqlCommand.Parameters.AddWithValue("@manaleech", player.Manaleech);
                sqlCommand.Parameters.AddWithValue("@def", player.Def);
                sqlCommand.Parameters.AddWithValue("@dmg", player.Dmg);
                sqlCommand.Parameters.AddWithValue("@speed", player.Speed);
                sqlCommand.Parameters.AddWithValue("@hp", player.Hp);
                sqlCommand.Parameters.AddWithValue("@accuracy", player.Accuracy);
                sqlCommand.Parameters.AddWithValue("@lvl", player.Lvl);
                sqlCommand.Parameters.AddWithValue("@critchance", player.Critchance);
                sqlCommand.Parameters.AddWithValue("@critdmg", player.Critdmg);
                sqlCommand.Parameters.AddWithValue("@locationX", player.LocationX);
                sqlCommand.Parameters.AddWithValue("@locationY", player.LocationY);
                sqlCommand.Parameters.AddWithValue("@towerlvl", player.Towerlvl);
                sqlCommand.Parameters.AddWithValue("@hpregen", player.Hpregen);
                sqlCommand.Parameters.AddWithValue("@inchp", player.Inchp);
                sqlCommand.Parameters.AddWithValue("@incDMG", player.Increaseddmg);
                sqlCommand.Parameters.AddWithValue("@exp", player.Exp);
                sqlCommand.Parameters.AddWithValue("@expToNext", player.Exptonext);
                sqlCommand.ExecuteNonQuery();
                // tässä välissä haetaan pelaajan id koska sitä tarvitaan
                command = "SELECT TOP 1 * FROM characters ORDER BY ID DESC";
                using (sqlCommand = new SqlCommand(command, connection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            player.Id = reader.GetInt32(0);
                        }
                    }
                }
                command = "INSERT INTO skillpoints(characterid, dmg1, dmg2, def1, def2, bigdef, life1, life2, lifesteal1, lifesteal2, dmglesslife, dualstrike, lifereg1, lifereg2, doublearmor) Values(@characterid, @dmg1, @dmg2, @def1, @def2, @bigdef, @life1, @life2, @lifesteal1, @lifesteal2, @dmglesslife, @dualstrike, @lifereg1, @lifereg2, @doublearmor)";
                sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@dmg1", player.Dmg1);
                sqlCommand.Parameters.AddWithValue("@dmg2", player.Dmg2);
                sqlCommand.Parameters.AddWithValue("@def1", player.Def1);
                sqlCommand.Parameters.AddWithValue("@def2", player.Def2);
                sqlCommand.Parameters.AddWithValue("@dmglesslife", player.Dmglesslife);
                sqlCommand.Parameters.AddWithValue("@doublearmor", player.Doublearmor);
                sqlCommand.Parameters.AddWithValue("@dualstrike", player.Dualstrike);
                sqlCommand.Parameters.AddWithValue("@life1", player.Life1);
                sqlCommand.Parameters.AddWithValue("@life2", player.Life2);
                sqlCommand.Parameters.AddWithValue("@lifereg1", player.Lifereg1);
                sqlCommand.Parameters.AddWithValue("@lifereg2", player.Lifereg2);
                sqlCommand.Parameters.AddWithValue("@lifesteal1", player.Lifesteal1);
                sqlCommand.Parameters.AddWithValue("@lifesteal2", player.Lifesteal2);
                sqlCommand.Parameters.AddWithValue("@bigdef", player.Bigdef);
                sqlCommand.Parameters.AddWithValue("@characterid", player.Id);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void VieHahmo(Playerstats player)
        {
            using (connection)
            {
                yhdista();
                string command = "INSERT INTO characters(Name, lifeleech, manaleech, defence, dmg, speed, hp, accuracy, level, incdmg, critchance, critdmg, locationX, locationY, towerlvl, hpregen ,inchp, exp, exptonextlvl) VALUES(@name, @lifeleech, @manaleech, @def, @dmg, @speed, @hp, @accuracy, @lvl, @incDMG, @critchance, @critdmg, @locationX, @locationY, @towerlvl, @hpregen, @inchp, @exp, @expToNext)";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@name", player.Name);
                sqlCommand.Parameters.AddWithValue("@lifeleech", player.Lifeleech);
                sqlCommand.Parameters.AddWithValue("@manaleech", player.Manaleech);
                sqlCommand.Parameters.AddWithValue("@def", player.Def);
                sqlCommand.Parameters.AddWithValue("@dmg", player.Dmg);
                sqlCommand.Parameters.AddWithValue("@speed", player.Speed);
                sqlCommand.Parameters.AddWithValue("@hp", player.Hp);
                sqlCommand.Parameters.AddWithValue("@accuracy", player.Accuracy);
                sqlCommand.Parameters.AddWithValue("@lvl", player.Lvl);
                sqlCommand.Parameters.AddWithValue("@critchance", player.Critchance);
                sqlCommand.Parameters.AddWithValue("@critdmg", player.Critdmg);
                sqlCommand.Parameters.AddWithValue("@locationX", player.LocationX);
                sqlCommand.Parameters.AddWithValue("@locationY", player.LocationY);
                sqlCommand.Parameters.AddWithValue("@towerlvl", player.Towerlvl);
                sqlCommand.Parameters.AddWithValue("@hpregen", player.Hpregen);
                sqlCommand.Parameters.AddWithValue("@inchp", player.Inchp);
                sqlCommand.Parameters.AddWithValue("@incDMG", player.Increaseddmg);
                sqlCommand.Parameters.AddWithValue("@exp", player.Exp);
                sqlCommand.Parameters.AddWithValue("@expToNext", player.Exptonext);
                sqlCommand.ExecuteNonQuery();
                ViePassivetree(player);
            }
        }

        public void ViePassivetree(Playerstats player)
        {
            using (connection)
            {
                string command = "UPDATE skillpoints SET dmg1 = @dmg1, dmg2 = @dmg2, def1 = @def1, def2 = @def2, bigdef = @bigdef, life1 = @life1, life2 = @life2, lifesteal1 = @lifesteal1, lifesteal2 = @lifesteal2, dmglesslife = @dmglesslife, dualstrike = @dualstrike, lifereg1 = @lifereg1, lifereg2 = @lifereg2, doublearmor = @doublearmor WHERE characterid = @id";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@id", player.Id);
                sqlCommand.Parameters.AddWithValue("@dmg1", player.Dmg1);
                sqlCommand.Parameters.AddWithValue("@dmg2", player.Dmg2);
                sqlCommand.Parameters.AddWithValue("@def1", player.Def1);
                sqlCommand.Parameters.AddWithValue("@def2", player.Def2);
                sqlCommand.Parameters.AddWithValue("@dmglesslife", player.Dmglesslife);
                sqlCommand.Parameters.AddWithValue("@doublearmor", player.Doublearmor);
                sqlCommand.Parameters.AddWithValue("@dualstrike", player.Dualstrike);
                sqlCommand.Parameters.AddWithValue("@life1", player.Life1);
                sqlCommand.Parameters.AddWithValue("@life2", player.Life2);
                sqlCommand.Parameters.AddWithValue("@lifereg1", player.Lifereg1);
                sqlCommand.Parameters.AddWithValue("@lifereg2", player.Lifereg2);
                sqlCommand.Parameters.AddWithValue("@lifesteal1", player.Lifesteal1);
                sqlCommand.Parameters.AddWithValue("@lifesteal2", player.Lifesteal2);
                sqlCommand.Parameters.AddWithValue("@bigdef", player.Bigdef);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void Deleteplayer(int id)
        {
            using (connection)
            {
                yhdista();
                string command = "DELETE FROM characters WHERE Id = @id";
                SqlCommand komento = new SqlCommand(command, connection);
                komento.Parameters.AddWithValue("@id", id);
                komento.ExecuteNonQuery();
                command = "DELETE FROM PlayerItems WHERE characterId = @id";
                komento.ExecuteNonQuery();
                command = "DEFETE FROM skillpoints WHERE characterid = @id";
                komento.ExecuteNonQuery();
            }
        }

        public void VieAmuletti(Amulet amulet, int id)
        {
            string command;
            command = "INSERT INTO PlayerItems (characterId, lifeleech, manaleech, extradmg, hp, accuracy, defence, itemtype, equiped) VALUES(@id, @lifeleech, @manaleech, @extradmg, @hp, @accuracy, @def, @itemtype, @equiped)";
            SqlCommand komento = new SqlCommand(command, connection);
            komento.Parameters.AddWithValue("@id", id);
            komento.Parameters.AddWithValue("@lifeleech", amulet.Lifeleech);
            komento.Parameters.AddWithValue("@manaleech", amulet.Manaleech);
            komento.Parameters.AddWithValue("@hp", amulet.Hp);
            komento.Parameters.AddWithValue("@accuracy", amulet.Accuracy);
            komento.Parameters.AddWithValue("@def", amulet.Def);
            komento.Parameters.AddWithValue("@extradmg", amulet.ElderExtradmg);
            komento.Parameters.AddWithValue("@incdef", amulet.Increaseddef);
            komento.Parameters.AddWithValue("@itemtype", "amulet");
            komento.Parameters.AddWithValue("@equiped", amulet.Equiped);
            komento.ExecuteNonQuery();
        }

        public void VieBeltti(Belt belt, int id)
        {
            string command = "INSERT INTO PlayerItems (characterId, hp, accuracy, incdef, defence, itemtype, equiped) VALUES(@id, @hp, @accuracy, @incdef, @def, @itemtype, @equiped)";
            SqlCommand komento = new SqlCommand(command, connection);
            komento.Parameters.AddWithValue("@id", id);
            komento.Parameters.AddWithValue("@accuracy", belt.Accuracy);
            komento.Parameters.AddWithValue("@def", belt.Def);
            komento.Parameters.AddWithValue("@hp", belt.Hp);
            komento.Parameters.AddWithValue("@incdef", belt.Increaseddef);
            komento.Parameters.AddWithValue("@itemtype", "belt");
            komento.Parameters.AddWithValue("@equiped", belt.Equiped);
            komento.ExecuteNonQuery();
        }

        public void VieBody(Body body, int id)
        {
            string command = "INSERT INTO PlayerItems (characterId, hp, accuracy, incdef, defence, itemtype, equiped) VALUES(@id, @hp, @accuracy, @incdef, @def, @itemtype, @equiped)";
            SqlCommand komento = new SqlCommand(command, connection);
            komento.Parameters.AddWithValue("@id", id);
            komento.Parameters.AddWithValue("@accuracy", body.Accuracy);
            komento.Parameters.AddWithValue("@def", body.Def);
            komento.Parameters.AddWithValue("@hp", body.Hp);
            komento.Parameters.AddWithValue("@incdef", body.Increaseddef);
            komento.Parameters.AddWithValue("@itemtype", "body");
            komento.Parameters.AddWithValue("@equiped", body.Equiped);
            komento.ExecuteNonQuery();
        }

        public void VieBoots(Boots bootsit, int id)
        {
            string command = "INSERT INTO PlayerItems (characterId, speed, hp, accuracy, incdef, defence, itemtype, equiped) VALUES(@id, @speed, @hp, @accuracy, @incdef, @def, @itemtype, @equiped)";
            SqlCommand komento = new SqlCommand(command, connection);
            komento.Parameters.AddWithValue("@id", id);
            komento.Parameters.AddWithValue("@accuracy", bootsit.Accuracy);
            komento.Parameters.AddWithValue("@def", bootsit.Def);
            komento.Parameters.AddWithValue("@hp", bootsit.Hp);
            komento.Parameters.AddWithValue("@incdef", bootsit.Increaseddef);
            komento.Parameters.AddWithValue("@speed", bootsit.Speed);
            komento.Parameters.AddWithValue("@itemtype", "bootsit");
            komento.Parameters.AddWithValue("@equiped", bootsit.Equiped);
            komento.ExecuteNonQuery();
        }

        public void VieGloves(Gloves glove, int id)
        {
            string command = "INSERT INTO PlayerItems (characterId, lifeleech, hp, accuracy, defence, addeddmg, itemtype, equiped) VALUES(@id, @lifeleech, @hp, @accuracy, @def, @adddmg, @itemtype, @equiped)";
            SqlCommand komento = new SqlCommand(command, connection);
            komento.Parameters.AddWithValue("@id", id);
            komento.Parameters.AddWithValue("@accuracy", glove.Accuracy);
            komento.Parameters.AddWithValue("@adddmg", glove.Addeddmg);
            komento.Parameters.AddWithValue("@def", glove.Def);
            komento.Parameters.AddWithValue("@hp", glove.Hp);
            komento.Parameters.AddWithValue("@incdef", glove.Increaseddef);
            komento.Parameters.AddWithValue("@lifeleech", glove.Lifeleech);
            komento.Parameters.AddWithValue("@itemtype", "gloves");
            komento.Parameters.AddWithValue("@equiped", glove.Equiped);
            komento.ExecuteNonQuery();
        }

        public void VieHelmets(Helmet helmet, int id)
        {
            string command = "INSERT INTO PlayerItems (characterId, hp, accuracy, incdef, defence, itemtype, equiped) VALUES(@id, @hp, @accuracy, @incdef, @def, @itemtype, @equiped)";
            SqlCommand komento = new SqlCommand(command, connection);
            komento.Parameters.AddWithValue("@id", id);
            komento.Parameters.AddWithValue("@accuracy", helmet.Accuracy);
            komento.Parameters.AddWithValue("@def", helmet.Def);
            komento.Parameters.AddWithValue("@hp", helmet.Hp);
            komento.Parameters.AddWithValue("@incdef", helmet.Increaseddef);
            komento.Parameters.AddWithValue("@itemtype", "helmet");
            komento.Parameters.AddWithValue("@equiped", helmet.Equiped);
            komento.ExecuteNonQuery();
        }

        public void VieRings(Ring ring, int id)
        {
            string command = "INSERT INTO PlayerItems (characterId, lifeleech, manaleech, hp, accuracy, defence, addeddmg, itemtype, equiped) VALUES(@id, @lifeleech, @manaleech, @hp, @accuracy, @def, @adddmg, @itemtype, @equiped)";
            SqlCommand komento = new SqlCommand(command, connection);
            komento.Parameters.AddWithValue("@id", id);
            komento.Parameters.AddWithValue("@accuracy", ring.Accuracy);
            komento.Parameters.AddWithValue("@adddmg", ring.Addeddmg);
            komento.Parameters.AddWithValue("@def", ring.Def);
            komento.Parameters.AddWithValue("@hp", ring.Hp);
            komento.Parameters.AddWithValue("@incdef", ring.Increaseddef);
            komento.Parameters.AddWithValue("@lifeleech", ring.Lifeleech);
            komento.Parameters.AddWithValue("@manaleech", ring.Manaleech);
            komento.Parameters.AddWithValue("@itemtype", "ring");
            komento.Parameters.AddWithValue("@equiped", ring.Equiped);
            komento.ExecuteNonQuery();
        }

        public void VieWeapons(weapon weapon, int id)
        {
            string command = "INSERT INTO PlayerItems (characterId, dmg, extradmg, accuracy, incdmg, itemtype, equiped, critdmg, critchance) VALUES(@id, @dmg, @extradmg, @accuracy, @incdmg, @itemtype, @equiped, @critdmg, @critchance)";
            SqlCommand komento = new SqlCommand(command, connection);
            komento.Parameters.AddWithValue("@id", id);
            komento.Parameters.AddWithValue("@accuracy", weapon.Accuracy);
            komento.Parameters.AddWithValue("@dmg", weapon.Dmg);
            komento.Parameters.AddWithValue("@extradmg", weapon.Elderextra);
            komento.Parameters.AddWithValue("@incdmg", weapon.Increaseddmg);
            komento.Parameters.AddWithValue("@itemtype", "weapon");
            komento.Parameters.AddWithValue("@equiped", weapon.Equiped);
            komento.Parameters.AddWithValue("@critdmg", weapon.Critdmg);
            komento.Parameters.AddWithValue("@critchance", weapon.Critchance);
        }

        public void VieEsineet(List<Esineet> esineet, int id)
        {
            using (connection)
            {
                yhdista();
                string command = "DELETE FROM PlayerItems WHERE characterId = @id";
                SqlCommand komento = new SqlCommand(command, connection);
                komento.Parameters.AddWithValue("@id", id);
                komento.ExecuteNonQuery();
                foreach (Esineet esine in esineet)
                {
                    if (esine is Amulet)
                    {
                        VieAmuletti((Amulet)esine, id);
                    }
                    else if (esine is Belt)
                    {
                        VieBeltti((Belt)esine, id);
                    }
                    else if (esine is Body)
                    {
                        VieBody((Body)esine, id);
                    }
                    else if (esine is Boots)
                    {
                        VieBoots((Boots)esine, id);
                    }
                    else if (esine is Gloves)
                    {
                        VieGloves((Gloves)esine, id);
                    }
                    else if (esine is Helmet)
                    {
                        VieHelmets((Helmet)esine, id);
                    }
                    else if (esine is Ring)
                    {
                        VieRings((Ring)esine, id);
                    }
                    else if (esine is weapon)
                    {
                        VieWeapons((weapon)esine, id);
                    }
                }
            }
        }

        public List<Esineet> HaeEsineet(int id)
        {
            List<Esineet> inventory = new List<Esineet>();
            try
            {
                using (connection)
                {
                    yhdista();
                    string command;
                    command = "Select * From PlayerItems Where characterid = @id";
                    SqlCommand komento = new SqlCommand(command, connection);
                    komento.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = komento.ExecuteReader())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            reader.Read();
                            string vertaa = reader.GetString(13);
                            switch (vertaa)
                            {
                                case "amulet":
                                    Amulet amulet = new Amulet();
                                    amulet.Accuracy = reader.GetDecimal(8);
                                    amulet.Def = reader.GetDecimal(9);
                                    amulet.Hp = reader.GetDecimal(7);
                                    amulet.Increaseddef = reader.GetDecimal(12);
                                    amulet.ElderExtradmg = reader.GetDecimal(6);
                                    amulet.Lifeleech = reader.GetDecimal(2);
                                    amulet.Manaleech = reader.GetDecimal(3);
                                    amulet.Equiped = reader.GetBoolean(14);
                                    inventory.Add(amulet);
                                    break;
                                case "belt":
                                    Belt belt = new Belt();
                                    belt.Accuracy = reader.GetDecimal(8);
                                    belt.Def = reader.GetDecimal(9);
                                    belt.Hp = reader.GetDecimal(7);
                                    belt.Increaseddef = reader.GetDecimal(12);
                                    belt.Equiped = reader.GetBoolean(14);
                                    inventory.Add(belt);
                                    break;
                                case "body":
                                    Body body = new Body();
                                    body.Accuracy = reader.GetDecimal(8);
                                    body.Def = reader.GetDecimal(9);
                                    body.Hp = reader.GetDecimal(7);
                                    body.Increaseddef = reader.GetDecimal(12);
                                    body.Equiped = reader.GetBoolean(14);
                                    inventory.Add(body);
                                    break;
                                case "bootsit":
                                    Boots boots = new Boots();
                                    boots.Accuracy = reader.GetDecimal(8);
                                    boots.Def = reader.GetDecimal(9);
                                    boots.Hp = reader.GetDecimal(7);
                                    boots.Increaseddef = reader.GetDecimal(12);
                                    boots.Speed = reader.GetDecimal(5);
                                    boots.Equiped = reader.GetBoolean(14);
                                    inventory.Add(boots);
                                    break;
                                case "gloves":
                                    Gloves gloves = new Gloves();
                                    gloves.Accuracy = reader.GetDecimal(8);
                                    gloves.Def = reader.GetDecimal(9);
                                    gloves.Hp = reader.GetDecimal(7);
                                    gloves.Increaseddef = reader.GetDecimal(12);
                                    gloves.Addeddmg = reader.GetDecimal(10);
                                    gloves.Lifeleech = reader.GetDecimal(2);
                                    gloves.Equiped = reader.GetBoolean(14);
                                    inventory.Add(gloves);
                                    break;
                                case "helmet":
                                    Helmet helmet = new Helmet();
                                    helmet.Accuracy = reader.GetDecimal(8);
                                    helmet.Def = reader.GetDecimal(9);
                                    helmet.Hp = reader.GetDecimal(7);
                                    helmet.Increaseddef = reader.GetDecimal(12);
                                    helmet.Equiped = reader.GetBoolean(14);
                                    inventory.Add(helmet);
                                    break;
                                case "ring":
                                    Ring ring = new Ring();
                                    ring.Accuracy = reader.GetDecimal(8);
                                    ring.Def = reader.GetDecimal(9);
                                    ring.Hp = reader.GetDecimal(7);
                                    ring.Increaseddef = reader.GetDecimal(12);
                                    ring.Lifeleech = reader.GetDecimal(2);
                                    ring.Manaleech = reader.GetDecimal(3);
                                    ring.Addeddmg = reader.GetDecimal(10);
                                    ring.Equiped = reader.GetBoolean(14);
                                    inventory.Add(ring);
                                    break;
                                case "weapon":
                                    weapon weapon = new weapon();
                                    weapon.Elderextra = reader.GetDecimal(6);
                                    weapon.Dmg = reader.GetDecimal(4);
                                    weapon.Increaseddmg = reader.GetDecimal(11);
                                    weapon.Equiped = reader.GetBoolean(14);
                                    weapon.Critchance = reader.GetDecimal(16);
                                    weapon.Critdmg = reader.GetDecimal(15);
                                    inventory.Add(weapon);
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return inventory;
        }
    }
}