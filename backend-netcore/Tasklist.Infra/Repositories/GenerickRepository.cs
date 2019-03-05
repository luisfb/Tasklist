using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Tasklist.Domain.Entities;
using Tasklist.Domain.Interfaces;
using Tasklist.Domain.Validations;

namespace Tasklist.Infra.Repositories
{
    public abstract class GenerickRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly DbContext _context;

        protected GenerickRepository(DbContext context)
        {
            _context = context;
        }

        public long SaveOrUpdate(TEntity entity)
        {
            if (!entity.IsValid())
            {
                //_context.Database.RollbackTransaction(); //sem suporte a transações no in-memory database
                throw new EntityValidationException(entity.ValidationErrors);
            }

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                if (entity.Id == 0)
                    _context.Set<TEntity>().Add(entity);
                else
                {
                    _context.Set<TEntity>().Attach(entity);
                    _context.Entry(entity).State = EntityState.Modified;
                }
            }

            _context.SaveChanges();
            return entity.Id;
        }

        public bool Delete(TEntity entity)
        {
            _context.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(long id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public IQueryable<TEntity> Query()
        {
            return _context.Set<TEntity>();
        }

        public TEntity GetById(long id)
        {
            return _context.Find<TEntity>(id);
        }

        public IQueryable<TEntity> QueryAsNoTracking()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }
    }
}
