using System;
using System.Collections.Generic;
using System.Text;

namespace GolbEngine.Data.Interfaces
{
    public interface IHasOwner<T>
    {
        T OwnerId { set; get; }
    }
}
