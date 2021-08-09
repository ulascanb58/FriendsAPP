using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;
using System.Configuration;


namespace DataAccessLayer
{
    public class FriendDAL
    {
        //SqlConnection bgl = new SqlConnection(ConfigurationManager.AppSettings["Connection"]);

       

        public static List<Friend> FriendList()
        {
         
            List<Friend> Friends = new List<Friend>();

            SqlCommand cmd = new SqlCommand("Select * from Friends",config.Connection.cnn);
            Connect(cmd);

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Friend fr = new Friend();
                fr.FriendID = Convert.ToInt32(rdr["FriendID"]);
                fr.FirstName = rdr["FirstName"].ToString();
                fr.LastName = rdr["LastName"].ToString();
                fr.Age = Convert.ToInt32(rdr["Age"]);
                fr.BirthDate = rdr["BirthDate"].ToString();
                fr.Email = rdr["Email"].ToString();
                fr.Gender = rdr["Gender"].ToString();
                fr.City = rdr["City"].ToString();
                fr.PhoneNumber = rdr["PhoneNumber"].ToString();
                Friends.Add(fr);
            }
            rdr.Close();
            return Friends;

        }

        public static int FriendAdd(Friend friend)
        {
            SqlCommand cmd = new SqlCommand("Insert into Friends values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)",config.Connection.cnn);
            Connect(cmd);
           
            cmd.Parameters.AddWithValue("@p1", friend.FirstName);
            cmd.Parameters.AddWithValue("@p2", friend.LastName);
            cmd.Parameters.AddWithValue("@p3", friend.Age);
            cmd.Parameters.AddWithValue("@p4", friend.BirthDate);
            cmd.Parameters.AddWithValue("@p5", friend.Email);
            cmd.Parameters.AddWithValue("@p6", friend.Gender);
            cmd.Parameters.AddWithValue("@p7", friend.City);
            cmd.Parameters.AddWithValue("@p8", friend.PhoneNumber);
            return cmd.ExecuteNonQuery();
        }

        public static int FriendDelete(int FriendID)
        {
            SqlCommand cmd = new SqlCommand("Delete from Friends where FriendID =@p1",config.Connection.cnn);
            Connect(cmd);
            cmd.Parameters.AddWithValue("@p1", FriendID);
            return cmd.ExecuteNonQuery();
        }

       
        public static bool FriendUpdate(Friend friend)
        {
            SqlCommand cmd = new SqlCommand("Update Friends set FirstName=@p1,LastName=@p2,Age=@p3,BirthDate=@p4,Email=@p5,Gender=@p6,City=@p7,PhoneNumber=@p8 where FriendID=@p9", config.Connection.cnn);
            Connect(cmd);
            cmd.Parameters.AddWithValue("@p1", friend.FirstName);
            cmd.Parameters.AddWithValue("@p2", friend.LastName);
            cmd.Parameters.AddWithValue("@p3", friend.Age);
            cmd.Parameters.AddWithValue("@p4", friend.BirthDate);
            cmd.Parameters.AddWithValue("@p5", friend.Email);
            cmd.Parameters.AddWithValue("@p6", friend.Gender);
            cmd.Parameters.AddWithValue("@p7", friend.City);
            cmd.Parameters.AddWithValue("@p8", friend.PhoneNumber);
            cmd.Parameters.AddWithValue("@p9", friend.FriendID);
            return cmd.ExecuteNonQuery()>0;
        }

        public static List<Friend> FriendSearch(string search)
        {

            List<Friend> Friends = new List<Friend>();

            SqlCommand cmd = new SqlCommand("Select * from Friends where FirstName like '%"+search+"%'", config.Connection.cnn);
            Connect(cmd);

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Friend fr = new Friend();
                fr.FriendID = Convert.ToInt32(rdr["FriendID"]);
                fr.FirstName = rdr["FirstName"].ToString();
                fr.LastName = rdr["LastName"].ToString();
                fr.Age = Convert.ToInt32(rdr["Age"]);
                fr.BirthDate = rdr["BirthDate"].ToString();
                fr.Email = rdr["Email"].ToString();
                fr.Gender = rdr["Gender"].ToString();
                fr.City = rdr["City"].ToString();
                fr.PhoneNumber = rdr["PhoneNumber"].ToString();
                Friends.Add(fr);
            }
            rdr.Close();
            return Friends;

        }

        public static List<Friend> FriendSearch2(string lastName)
        {

            List<Friend> Friends = new List<Friend>();

            SqlCommand cmd = new SqlCommand("Select * from Friends where LastName like '%" + lastName + "%'", config.Connection.cnn);
            Connect(cmd);

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Friend fr = new Friend();
                fr.FriendID = Convert.ToInt32(rdr["FriendID"]);
                fr.FirstName = rdr["FirstName"].ToString();
                fr.LastName = rdr["LastName"].ToString();
                fr.Age = Convert.ToInt32(rdr["Age"]);
                fr.BirthDate = rdr["BirthDate"].ToString();
                fr.Email = rdr["Email"].ToString();
                fr.Gender = rdr["Gender"].ToString();
                fr.City = rdr["City"].ToString();
                fr.PhoneNumber = rdr["PhoneNumber"].ToString();
                Friends.Add(fr);
            }
            rdr.Close();
            return Friends;

        }
        public static List<Friend> FriendSearch3(string city)
        {

            List<Friend> Friends = new List<Friend>();

            SqlCommand cmd = new SqlCommand("Select * from Friends where City like '%" + city + "%'", config.Connection.cnn);
            Connect(cmd);

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Friend fr = new Friend();
                fr.FriendID = Convert.ToInt32(rdr["FriendID"]);
                fr.FirstName = rdr["FirstName"].ToString();
                fr.LastName = rdr["LastName"].ToString();
                fr.Age = Convert.ToInt32(rdr["Age"]);
                fr.BirthDate = rdr["BirthDate"].ToString();
                fr.Email = rdr["Email"].ToString();
                fr.Gender = rdr["Gender"].ToString();
                fr.City = rdr["City"].ToString();
                fr.PhoneNumber = rdr["PhoneNumber"].ToString();
                Friends.Add(fr);
            }
            rdr.Close();
            return Friends;

        }
       

        private static void Connect(SqlCommand cmd)
        {
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }

        }
    }
}
