using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
   public  class EfEntityRepositoryBase<TEntity,Tcontext>:IEntityRepository<TEntity>
         where TEntity:class,IEntity,new ()
         where Tcontext:DbContext, new ()
    {

        public void Add(TEntity entity)
        {
            using (Tcontext context = new Tcontext())
            {
                var addedEntity = context.Entry(entity);
                // (Eklenen varlık) = veri kaynağındaki varlık a bağlan ve addet değişkneine ata

                addedEntity.State = EntityState.Added;
                // durumu ekleme olarak ayarla
                context.SaveChanges();

            }
        }

        public void Delete(TEntity entity)
        {
            using (Tcontext context = new Tcontext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (Tcontext context = new Tcontext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (Tcontext context = new Tcontext())
            {
                return filter == null ?
                    context.Set<TEntity>().ToList() :// Filtre null ise burası 
                    context.Set<TEntity>().Where(filter).ToList(); // Filtre null değilse burası 
            }
        }

        public void Update(TEntity entity)
        {
            using (Tcontext context = new Tcontext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }



    }
}
