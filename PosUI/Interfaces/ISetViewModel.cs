using Pos.Entities;
using Pos.Entities.PosStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosUI.Interfaces
{
    internal interface ISetViewModel
    {
        PosStateEnum PosStateEnum { get; }

        void SetViewModel(TransferModel model);
    }
}
