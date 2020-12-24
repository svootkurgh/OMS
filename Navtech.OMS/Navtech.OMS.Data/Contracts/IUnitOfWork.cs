using System;
using System.Data.Entity;

namespace Navtech.OMS.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Db { get; }
    }
}