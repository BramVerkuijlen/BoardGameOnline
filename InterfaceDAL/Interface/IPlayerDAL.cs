using DTO.Class;

namespace InterfaceDAL.Interface
{
    public interface IPlayerDAL
    {
        public List<PlayerDTO> Update();
        public PlayerDTO Get(int id);
        public List<PlayerDTO> GetAll();
        public List<PlayerDTO> Delete(int id);
        public List<PlayerDTO> Create();
    }
}
