using System.Linq.Expressions;
using System.Text.Json;
using Loan.Common;
using Loan.Data.EntityModel;

namespace Loan.Data;

public class JsonRepository<TEntity, TIdentifier> : IRepository<TEntity, TIdentifier>
    where TEntity : IEntity<TIdentifier>
    where TIdentifier : IEquatable<TIdentifier>
{
    public async Task<IEnumerable<TEntity>> GetEntities(Func<TEntity, bool>? filter = null)
    {
        List<TEntity> entities = await this.ReadFromFile();

        if (filter is not null)
        {
            return entities.Where(filter).ToList();
        }
        else
        {
            return entities;
        }
    }

    public async Task<TEntity> Insert(TEntity entity)
    {
        List<TEntity> entities = await this.ReadFromFile();
        
        entities.Add(entity);

        await this.SaveToFile(entities);

        return entity;
    }

    public async Task Delete(TIdentifier identifier)
    {
        if (identifier is null)
        {
            throw new ArgumentNullException();
        }
        
        List<TEntity> entities = await this.ReadFromFile();

        TEntity? toDelete = entities.FirstOrDefault(e => e.Identifier.Equals(identifier));

        if (toDelete is null)
        {
            throw new KeyNotFoundException($"Entity with {identifier} is not found.");
        }

        entities.Remove(toDelete);

        await this.SaveToFile(entities);
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException();
        }
        
        List<TEntity> entities = await this.ReadFromFile();

        TEntity? toUpdate = entities.FirstOrDefault(e => e.Identifier.Equals(entity.Identifier));

        if (toUpdate is null)
        {
            throw new KeyNotFoundException($"Entity with {entity.Identifier} is not found.");
        }

        entities.Remove(toUpdate);
        
        entities.Add(entity);

        await this.SaveToFile(entities);

        return entity;
    }

    private async Task<List<TEntity>> ReadFromFile()
    {
        using StreamReader streamReader = new(Constants.DBPath);
        
        string entitiesJson = await streamReader.ReadToEndAsync() ?? "[]";
        List<TEntity> entities = JsonSerializer.Deserialize<List<TEntity>>(entitiesJson, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        }) ?? new List<TEntity>();

        return entities;
    }
    
    private async Task SaveToFile(List<TEntity> entities)
    {
        await using StreamWriter streamWriter = new(Constants.DBPath);
        
        string updatedEntitiesJson = JsonSerializer.Serialize(entities, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        });

        await streamWriter.WriteAsync(updatedEntitiesJson);
    }
}