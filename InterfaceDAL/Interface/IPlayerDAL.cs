using DTO.Class;
using DTO.ResponseObject;

namespace InterfaceDAL.Interface
{
    public interface IPlayerDAL
    {
        public ResponseObject<PlayerDTO> UpdatePlayer();
    }
}
