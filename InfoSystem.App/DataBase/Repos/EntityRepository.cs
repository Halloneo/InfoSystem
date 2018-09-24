using System.Collections.Generic;
using InfoSystem.App.DataBase.Context;
using InfoSystem.App.DataBase.ReposInterfaces;
using InfoSystem.Infrastructure.Entities;
using InfoSystem.Infrastructure.UnitOfWork;

namespace InfoSystem.App.DataBase.Repos
{
    public class EntityRepository : IEntityRepository
    {
        private readonly InfoSystemDbContext _context;
        
        public EntityRepository(InfoSystemDbContext dbContext)
        {
            _context = dbContext;
        }
        
        public void Add(Entity receivedObj)
        {
            _context.Entities.AddAsync(receivedObj);
        }

        public void Delete(int id)
        {
            _context.Entities.Remove(_context.Entities.Find(id));
        }

        public IEnumerable<Entity> Get()
        {
            return _context.Entities;
        }

        public Entity Get(int id)
        {
            return _context.Entities.Find(id);
        }
    }
}