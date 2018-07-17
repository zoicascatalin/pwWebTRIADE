using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using Facs.Models;

namespace Facs
{

    public class facUsers
    {
        public static string cnnStr = "Server=tcp:prjwork.database.windows.net,1433;Initial Catalog=ProjectWorkHotel;Persist Security Info=False;User ID=yourfather;Password=PRJwork1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static Users UserExists(Guid UserId)
        {
            Users usr = new Users();

            SqlConnection conn = new SqlConnection(cnnStr);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE ID = @id", conn);
                cmd.Parameters.AddWithValue("@id", UserId);
                var result = cmd.ExecuteReader();
                while (result.Read())
                {
                    usr.ID = Guid.Parse(result[0].ToString());
                    usr.Username = result[1].ToString();
                    usr.Password = result[2].ToString();
                    usr.CheckedOut = bool.Parse(result[5].ToString());
                    usr.Role = int.Parse(result[6].ToString());
                    if (usr.Username != "admin")
                        usr.NR_Camera = int.Parse(result[7].ToString());
                }

            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
            return usr;
        }
        public static Users UserExists(string username, string password)
        {
            Users usr = new Users();

            SqlConnection conn = new SqlConnection(cnnStr);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE username = @username AND password = @password", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                var result = cmd.ExecuteReader();
                while (result.Read())
                {
                    usr.ID = Guid.Parse(result[0].ToString());
                    usr.Username = result[1].ToString();
                    usr.Password = result[2].ToString();
                    usr.CheckedOut = bool.Parse(result[5].ToString());
                    usr.Role = int.Parse(result[6].ToString());
                    if (usr.Username != "admin")
                        usr.NR_Camera = int.Parse(result[7].ToString());
                }

            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
            return usr;
        }

        public static UtenteGuest GetCamera(Guid userId)
        {
            UtenteGuest res = new UtenteGuest();
            object floorId = null;
            SqlConnection conn = new SqlConnection(cnnStr);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT NR_Camera From Users WHERE ID = @id"
                                                , conn);
                cmd.Parameters.AddWithValue("@id", userId);
                SqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    res.Stanza = int.Parse(result[0].ToString());
                }

                SqlCommand cmd2 = new SqlCommand("SELECT ID_Piano,Temperatura,Porta from Rooms Where Camera = @RoomId", conn);
                cmd2.Parameters.AddWithValue("@RoomId", res.Stanza);
                result.Close();
                SqlDataReader result2 = cmd2.ExecuteReader();
                while (result2.Read())
                {
                    floorId = result2[0];
                    res.Temperatura = decimal.Parse(result2[1].ToString());
                    res.StatoPorta = bool.Parse(result2[2].ToString());

                }
                SqlCommand cmd3 = new SqlCommand("  SELECT Piano from Floors Where ID = @FloorId", conn);
                cmd3.Parameters.AddWithValue("@FloorId", floorId);
                result2.Close();
                SqlDataReader result3 = cmd3.ExecuteReader();
                while (result3.Read())
                {
                    res.Piano = int.Parse(result3[0].ToString());
                }
                result3.Close();

            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
            return res;
        }

        public static void SetPortaCamera(UtenteGuest utente)
        {
            SqlConnection conn = new SqlConnection(cnnStr);

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Rooms SET Porta = @stato WHERE Camera = @roomID", conn);
                cmd.Parameters.AddWithValue("@stato", utente.StatoPorta);
                cmd.Parameters.AddWithValue("@roomID", utente.Stanza);

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch
            {

                return;
            }

        }

        public static void SetTemperatura(UtenteGuest utente)
        {
            SqlConnection conn = new SqlConnection(cnnStr);

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Rooms SET Temperatura = @temp WHERE Camera = @roomID", conn);
                cmd.Parameters.AddWithValue("@temp", utente.Temperatura);
                cmd.Parameters.AddWithValue("@roomID", utente.Stanza);

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch
            {

                return;
            }
        }
        public static void SetTemperatura(int stanza, decimal temp)
        {
            SqlConnection conn = new SqlConnection(cnnStr);

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Rooms SET Temperatura = @temp WHERE Camera = @roomID", conn);
                cmd.Parameters.AddWithValue("@temp", temp);
                cmd.Parameters.AddWithValue("@roomID", stanza);

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch
            {

                return;
            }
        }
        public static Guid GetUserID(string username, string password)
        {
            Guid id = new Guid();

            SqlConnection conn = new SqlConnection(cnnStr);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID FROM Users WHERE username = @username AND password = @password", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                var result = cmd.ExecuteReader();
                while (result.Read())
                {
                    id = Guid.Parse(result[0].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Guid.Empty;
            }
            finally
            {
                conn.Close();
            }
            return id;
        }

        public static bool IsLogged(Guid UserId)
        {
            bool log = false;
            SqlConnection conn = new SqlConnection(cnnStr);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM AccessLog WHERE ID_User = @id ", conn);
                cmd.Parameters.AddWithValue("@id", UserId);
                var result = cmd.ExecuteReader();
                if (result != null)
                {
                    log = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                conn.Close();
            }

            return log;


        }

        public static void Logout(Guid userID)
        {
            SqlConnection conn = new SqlConnection(cnnStr);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE AccessLog SET Logged = 0 WHERE ID_User = @id", conn);
                cmd.Parameters.AddWithValue("@id", userID);
                cmd.ExecuteNonQuery();
                //SqlCommand cmd2 = new SqlCommand("UPDATE Users SET CheckedOut = 1 WHERE ID = @id", conn);
                //cmd2.Parameters.AddWithValue("@id", userID);
                //cmd2.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void Login(Guid userId)
        {
            SqlConnection conn = new SqlConnection(cnnStr);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE AccessLog SET Logged = 1,Datetime = @datetime WHERE ID_User = @id", conn);
                cmd.Parameters.AddWithValue("@id", userId);
                cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }

        }

        public static List<string> getFloors()
        {
            List<string> list = new List<string>();

            SqlConnection conn = new SqlConnection(cnnStr);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Piano FROM Floors", conn);
                var result = cmd.ExecuteReader();
                while (result.Read())
                {
                    list.Add("Piano " + result[0].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }

            return list;
        }

        public static List<UtenteGuest> getRooms(string x)
        {
            List<UtenteGuest> list = new List<UtenteGuest>();
            UtenteGuest ut = new UtenteGuest();
            SqlConnection conn = new SqlConnection(cnnStr);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT Rooms.Temperatura,Rooms.Porta,Rooms.Camera,Rooms.Occupata FROM Floors
                                                    JOIN Rooms ON Rooms.ID_Piano = Floors.ID AND Piano = @floor", conn);
                cmd.Parameters.AddWithValue("@floor", x);
                var result = cmd.ExecuteReader();
                while (result.Read())
                {
                    list.Add(new UtenteGuest()
                    {
                        Piano = int.Parse(x),
                        Stanza = int.Parse(result[2].ToString()),
                        Temperatura = decimal.Parse(result[0].ToString()),
                        StatoPorta = bool.Parse(result[1].ToString()),
                        Occupato = bool.Parse(result[3].ToString())
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }


            return list;
        }

        public static DataSet DSgetRooms(string x)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(cnnStr);
            try
            {
                conn.Open();
                string query = string.Format(@"SELECT Rooms.Temperatura,Rooms.Porta,Rooms.Camera FROM Floors
                                                    JOIN Rooms ON Rooms.ID_Piano = Floors.ID AND Piano = {0}", x);
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }
        public static void setPortaCamera(int stanza, bool porta)
        {

            SqlConnection conn = new SqlConnection(cnnStr);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Rooms SET Porta = @stato WHERE Camera = @roomID", conn);
                cmd.Parameters.AddWithValue("@stato", porta);
                cmd.Parameters.AddWithValue("@roomID", stanza);


                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }
        }


        public static DataSet GetRoom()
        {

            DataSet list = new DataSet();

            SqlConnection conn = new SqlConnection(cnnStr);
            try
            {
                conn.Open();
                SqlDataAdapter cmd = new SqlDataAdapter("SELECT Camera FROM Rooms WHERE Occupata = '0'", conn);


                cmd.Fill(list);

            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
            return list;

        }

        public static void AddGuest(int camera, string nome, string cognome, string username, string pwd, DateTime arrivo, DateTime partenza)
        {
            SqlConnection conn = new SqlConnection(cnnStr);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (ID, username, password, Nome, Cognome, CheckedOut, NR_Camera, Arrivo, Partenza)" +
                                                " Values (@id, @uname, @pwd, @nome, @cognome, '0', @camera, @arrivo, @partenza)", conn);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@cognome", cognome);
                cmd.Parameters.AddWithValue("@camera", camera);
                cmd.Parameters.AddWithValue("@uname", username);
                cmd.Parameters.AddWithValue("@pwd", pwd);
                cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@arrivo", arrivo);
                cmd.Parameters.AddWithValue("@partenza", partenza);



                cmd.ExecuteNonQuery();


                SqlCommand cmd2 = new SqlCommand("UPDATE Rooms SET Occupata = '1' WHERE Camera = @camera", conn);
                cmd2.Parameters.AddWithValue("@camera", camera);

                cmd2.ExecuteNonQuery();
            }
            catch
            {

                return;
            }
            finally
            {
                conn.Close();
            }

        }


        public static void setTemperatureCamera(int camera, int temperature)
        {
            SqlConnection conn = new SqlConnection(cnnStr);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Rooms SET Temperatura = @temp WHERE Camera = @camera", conn);
                cmd.Parameters.AddWithValue("@temp", temperature);
                cmd.Parameters.AddWithValue("@camera", camera);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
