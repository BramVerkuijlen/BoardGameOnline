using Logic.DTO;
using Logic.Interfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Class
{
    internal class ProfileDAL : IPlayerDAL , IPlayerManagerDAL
    {
        public PlayerDTO AddFriend()
        {
            throw new NotImplementedException();
        }

        public List<PlayerDTO> GetAllFriends()
        {
            throw new NotImplementedException();
        }

        public PlayerDTO RemoveFriend()
        {
            throw new NotImplementedException();
        }
    }
}
