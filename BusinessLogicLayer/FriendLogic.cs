using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
  public  class FriendLogic
    {
        public static List<Friend> LLFriendList()
        {
            return FriendDAL.FriendList();
        }

        public static int LLRegisterFriend(Friend friend)
        {
            if (friend.FirstName != " " && friend.LastName != " " && friend.Age >= 0)
            {
                return FriendDAL.FriendAdd(friend);
            }
            else
            {
                return -1;
            }
        }

        public static int LLDeleteFriend(int FriendID)
        {
            if (FriendID >= 1)
            {
                return FriendDAL.FriendDelete(FriendID);

            }
            else
            {
                return -1;

            }
        }

  
        public static bool LLUpdateFriend(Friend friend)
        {
            if (friend.FirstName != " " && friend.LastName != " " && friend.Age >= 0 && friend.FirstName.Length>= 3 && friend.LastName.Length>=3)
            {
                return FriendDAL.FriendUpdate(friend);
            }
            else
            {
                return false;
            }
        }
        public static List<Friend> LLFriendSearch(string search)
        {
            if (search != "")
            {
                return FriendDAL.FriendSearch(search);
            }
            else
            {
                return FriendDAL.FriendList();
            }
        }
        public static List<Friend> LLFriendSearch2(string search)
        {
            if (search != "")
            {
                return FriendDAL.FriendSearch2(search);
            }
            else
            {
                return FriendDAL.FriendList();
            }
        }

        public static List<Friend> LLFriendSearch3(string search)
        {
            if (search != "")
            {
                return FriendDAL.FriendSearch3(search);
            }
            else
            {
                return FriendDAL.FriendList();
            }
        }
    }
}
