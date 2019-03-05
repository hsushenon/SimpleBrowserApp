using Microsoft.Data.Sqlite;
using System;
using System.Collections.ObjectModel;

namespace SimpleBrowserApp
{
    class DataAccess
    {

        public static void InitializeDatabase()
        {
            using (SqliteConnection conn = new SqliteConnection("Filename=ChannelDB.db"))
            {
                try
                {
                    conn.Open();

                    String tableCommand = "CREATE TABLE IF NOT EXISTS " +
                        "T_CHANNEL (CHANNEL_ID VARCHAR(512) PRIMARY KEY , " + //todo PRIMARY KEY
                        "CHANNEL_NAME VARCHAR(128), ADDRESS VARCHAR(128))";

                    SqliteCommand createTable = new SqliteCommand(tableCommand, conn);

                    createTable.ExecuteReader();
                    conn.Close();
                }
                catch (SqliteException e)
                {
                    //TODO logging

                }

            }

        }


        public static void InsertData(ChannelItem channel)
        {
            using (SqliteConnection con = new SqliteConnection("Filename=ChannelDB.db"))
            {
                try
                {
                    con.Open();
                    SqliteCommand insertCommand = new SqliteCommand();
                    insertCommand.Connection = con;
                    insertCommand.CommandText = "INSERT INTO T_CHANNEL VALUES (@CHANNEL_ID, @CHANNEL_NAME,@ADDRESS);";
                    insertCommand.Parameters.AddWithValue("@CHANNEL_ID", channel.ChannelId);
                    insertCommand.Parameters.AddWithValue("@CHANNEL_NAME", channel.ChannelName);
                    insertCommand.Parameters.AddWithValue("@ADDRESS", channel.Address);

                    insertCommand.ExecuteReader();

                    con.Close();
                }
                catch (Exception)
                {
                    //TODO

                }
            }

        }


        public static ObservableCollection<ChannelItem> GetData()
        {

            ObservableCollection<ChannelItem> entries = new ObservableCollection<ChannelItem>();
            ChannelItem obj;

            using (SqliteConnection con = new SqliteConnection("Filename=ChannelDB.db"))
            {
                try
                {
                    con.Open();
                    SqliteCommand selectCommand = new SqliteCommand("SELECT * from T_CHANNEL", con);
                    SqliteDataReader query = selectCommand.ExecuteReader();
                    while (query.Read())
                    {
                        obj = new ChannelItem(query.GetString(0), query.GetString(1), query.GetString(2));
                        entries.Add(obj);
                    }

                    con.Close();

                }
                catch (SqliteException)
                {

                }
            }
            return entries;

        }


        public static void UpdateData(string channelId, string channelName, string address)
        {


            using (SqliteConnection con = new SqliteConnection("Filename=ChannelDB.db"))
            {


                try
                {

                    //if (channelId != null)
                    //{
                    //    con.Open();
                    //    SqliteCommand updateCommand = new SqliteCommand();
                    //    updateCommand.Connection = con;
                    //    updateCommand.CommandText = "UPDATE T_CHANNEL set DRUG_ID=@new_channel_id where DRUG_ID=@old_channel_id ";

                    //    updateCommand.Parameters.AddWithValue("@new_channel_id", channelId);
                    //    updateCommand.Parameters.AddWithValue("@old_channel_id", obj.ChannelId);
                    //    updateCommand.ExecuteReader();
                    //    con.Close();

                    //}

                    if (channelName != null)
                    {
                        con.Open();
                        SqliteCommand updateCommand = new SqliteCommand();
                        updateCommand.Connection = con;

                        updateCommand.CommandText = "UPDATE  T_CHANNEL set CHANNEL_NAME=@new_channel_name where CHANNEL_ID=@channel_id";
                        updateCommand.Parameters.AddWithValue("@new_channel_name", channelName);
                        updateCommand.Parameters.AddWithValue("@channel_id",channelId);
                        updateCommand.ExecuteReader();
                        con.Close();
                    }



                    if (address != null)
                    {
                        con.Open();
                        SqliteCommand updateCommand = new SqliteCommand();
                        updateCommand.Connection = con;

                        updateCommand.CommandText = "UPDATE  T_CHANNEL set QUANTITY=@new_address where  CHANNEL_ID=@channel_id";
                        updateCommand.Parameters.AddWithValue("@new_address", address);
                        updateCommand.Parameters.AddWithValue("@old_address", channelId);
                        updateCommand.ExecuteReader();
                        con.Close();
                    }


                }
                catch (SqliteException)
                {

                }
            }

        }


        public static void Delete_Data(int channel_id)
        {
            using (SqliteConnection con = new SqliteConnection("Filename=ChannelDB.db"))
            {
                try
                {
                    con.Open();
                    SqliteCommand DeleteCommand = new SqliteCommand();
                    DeleteCommand.Connection = con;
                    DeleteCommand.CommandText = "DELETE FROM T_CHANNEL WHERE CHANNEL_ID = @channel_id";
                    DeleteCommand.Parameters.AddWithValue("@channel_id", channel_id);
                    DeleteCommand.ExecuteReader();
                    con.Close();
                }
                catch (Exception)
                {
                }


            }
        }

    }
}
