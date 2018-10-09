using System;
using System.Collections.Generic;
using System.Text;

namespace GolbEngine.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
