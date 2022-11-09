using DTO.Class;

namespace InterfaceDAL.Interface
{
    public interface IPlayerCollectionDAL
    {
        public PlayerDTO GetPlayer(int id);
        public List<PlayerDTO> GetAllPlayers();
        public List<PlayerDTO> DeletePlayer(int id);
        public List<PlayerDTO> CreatePlayer();

    }
}
