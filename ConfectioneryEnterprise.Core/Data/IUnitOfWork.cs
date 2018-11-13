using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryEnterprise.Domain;

namespace ConfectioneryEnterprise.Core.Data
{
    public interface IUnitOfWork
    {
        IRepository<Confectioner> ConfectionerRepository { get; }

        IRepository<Client> ClientRepository { get; }
    }
}
