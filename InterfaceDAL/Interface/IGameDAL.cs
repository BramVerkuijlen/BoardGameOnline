using DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDAL.Interface
{
    public interface IGameDAL
    {
        void Update(int id, string name, string description);
        public List<GameDTO> GetAll();
        public void Create(string name, string description);
        public void Delete(int id);
        public GameDTO Get(int id);
    }
}
