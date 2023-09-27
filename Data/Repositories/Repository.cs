using VirtualBusinessCard.Domain.Configuration;
using VirtualBusinessCard.Data.IRepositories;
using VirtualBusinessCard.Domain.Entities;
using VirtualBusinessCard.Domain.Commans;
using Newtonsoft.Json;

namespace VirtualBusinessCard.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
    {
        private readonly string Path;

        public Repository()
        {
            if (typeof(TEntity) == typeof(User))
            {
                Path = DatabasePath.UserDb;
            }
            else if (typeof(TEntity) == typeof(BusinessCard))
            {
                Path = DatabasePath.BusinessCardDb;
            }
            else
            {
                Path = DatabasePath.ContactDb;
            }
            string str = File.ReadAllText(Path);
            if (string.IsNullOrEmpty(str))
                File.WriteAllText(Path, "[]");
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entities = await SelectAllAsync();
            var entity = entities.FirstOrDefault(u => u.Id == id);
            entities.Remove(entity);
            var str = JsonConvert.SerializeObject(entities, Formatting.Indented);
            await File.WriteAllTextAsync(Path, str);

            return true;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            string str = await File.ReadAllTextAsync(Path);
            List<TEntity> entities = JsonConvert.DeserializeObject<List<TEntity>>(str);
            entities.Add(entity);
            var result = JsonConvert.SerializeObject(entities, Formatting.Indented);
            await File.WriteAllTextAsync(Path, result);

            return entity;
        }

        public async Task<List<TEntity>> SelectAllAsync()
        {
            var str = await File.ReadAllTextAsync(Path);
            var entities = JsonConvert.DeserializeObject<List<TEntity>>(str);
            return entities;
        }

        public async Task<TEntity> SelectByIdAsync(long id)
        {
            return (await SelectAllAsync()).FirstOrDefault(e => e.Id == id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entities = await SelectAllAsync();
            await File.WriteAllTextAsync(Path, "[]");
            foreach (var data in entities)
            {
                if (data.Id == entity.Id)
                {
                    await InsertAsync(entity);
                    await DeleteAsync(data.Id);
                }
                await InsertAsync(data);
            }

            return entity;
        }
    }
}
