using ProfileApp.DataAccess.Context;
using ProfileApp.DataAccess.Interfaces;
using ProfileApp.DataAccess.Repositories;
using ProfileApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly UserAppContext _context;

        public Uow(UserAppContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);

        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
