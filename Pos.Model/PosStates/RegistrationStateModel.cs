using Pos.Entities.Receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Entities.PosStates
{
    public class RegistrationStateModel
    {
        public ReceiptModel Receipt { get; set; }
        public string Status { get; set; }
        public string InputValue { get; set; }
        public int CurrentPosition { get; set; }
        public bool ErrorOccured { get; set; }

        public void DecrementPosition()
        {
            if (CurrentPosition > 0)
            {
                CurrentPosition--;
            }
        }

        public void IncrementPosition()
        {
            if (CurrentPosition < Receipt.ReceiptSpecRecords.Count - 1)
            {
                CurrentPosition++;
            }
        }
    }
}
