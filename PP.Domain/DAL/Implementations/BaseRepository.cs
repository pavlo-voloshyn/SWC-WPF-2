using Newtonsoft.Json;
using PP.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Domain.DAL.Implementations;

public abstract class BaseRepository<T> where T : EntityBase
{
    protected string storagePath;
    protected IList<T> entities;

    public BaseRepository(string storagePath = @"D:\Study\3.1\SC\Lab02\Data\")
    {
        entities = new List<T>();
        this.storagePath = storagePath;
    }

    public virtual async Task<IList<T>> GetAll()
    {
        return entities;
    }

    public virtual async Task<T> Get(int id)
    {
        return entities.FirstOrDefault(x => x.Id == id);
    }

    public virtual async Task Update(T entity)
    {
        var result = entities.FirstOrDefault(x => x.Id == entity.Id);
        if (result != null)
        {
            entities[entities.IndexOf(result)] = entity;
        }
    }

    public virtual Task Delete(int id)
    {
        var entity = entities.FirstOrDefault(x => x.Id == id);
        if (entity != null)
        {
            entities.Remove(entity);
        }
        return Task.CompletedTask;
    }

    public virtual Task Create(T entity)
    {
        entities.Add(entity);
        return Task.CompletedTask;
    }

    public void SaveAll()
    {
        string data = JsonConvert.SerializeObject(entities, Formatting.Indented);

        if (!File.Exists(storagePath))
        {
            File.Create(storagePath);
        }
        File.WriteAllText(storagePath, data);
        
    }

    public void ReadAll()
    {
        entities = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(this.storagePath));
    }
}
