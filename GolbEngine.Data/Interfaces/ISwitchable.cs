using GolbEngine.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GolbEngine.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
