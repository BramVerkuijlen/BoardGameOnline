﻿using DTO.Class;
using InterfaceDAL.ResponseObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDAL.Interface
{
    public interface IPlayerDAL
    {
        public DALResponseObject<PlayerDTO> UpdatePlayer();
    }
}
