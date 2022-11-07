using DTO.Class;
using DTO.ResponseObject;

namespace InterfaceDAL.Interface
{
    public interface IPlayerCollectionDAL
    {
        public ResponseObject<PlayerDTO> GetPlayer(int id);
        public ResponseObject<PlayerDTO> GetAllPlayers();
        public ResponseObject<PlayerDTO> DeletePlayer(int id);
        public ResponseObject<PlayerDTO> CreatePlayer();

    }
}
