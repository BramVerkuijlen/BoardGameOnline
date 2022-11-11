using DTO.Class;

namespace InterfaceDAL.Interface
{
    public interface IGameCollectionDAL
    {
        public List<GameDTO> GetAll();
        public void Create(string name, string description);
        public void Delete(int id);
        public GameDTO Get(int id);
    }
}
