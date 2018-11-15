using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryEnterprise.Domain;

namespace ConfectioneryEnterprise.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<Confectioner> _confectionerRepository;
        private IRepository<Client> _clientRepository;

        public IRepository<Confectioner> ConfectionerRepository => 
            _confectionerRepository ?? (_confectionerRepository = new Repository<Confectioner>("Confectioners"));

        public IRepository<Client> ClientRepository => 
            _clientRepository ?? (_clientRepository = new Repository<Client>("Clients"));
    }
}
