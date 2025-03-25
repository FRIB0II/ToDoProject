using MongoDB.Driver;
using ToDo.Domain.Entities;
using ToDo.Infra.Services;
using ToDo.WebApi.Interfaces;

namespace ToDo.WebApi.Repositorys
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly IMongoCollection<ToDoEntity>? _todo;

        public ToDoRepository(MongoDbService mongoDbService)
        {
            _todo = mongoDbService.Database?.GetCollection<ToDoEntity>("todoentity");
        }

        public async Task<ToDoEntity> Create(ToDoEntity todoEntity)
        {
            await _todo.InsertOneAsync(todoEntity);
            return todoEntity;
        }

        public async Task<IEnumerable<ToDoEntity>> GetAll()
        {
            return await _todo.Find(FilterDefinition<ToDoEntity>.Empty).ToListAsync();
        }

        public async Task<ToDoEntity> GetById(string id)
        {
            var filter = Builders<ToDoEntity>.Filter.Eq(x => x.Id, id);
            var costumer = await _todo.Find(filter).FirstOrDefaultAsync();
            return costumer is not null ? costumer : null;
        }

        public async Task<ToDoEntity> Update(ToDoEntity entity)
        {
            var filter = Builders<ToDoEntity>.Filter.Eq(x => x.Id, entity.Id);
            await _todo.ReplaceOneAsync(filter, entity);
            return entity;
        }

        public async Task<bool> Delete(string id)
        {
            var filter = Builders<ToDoEntity>.Filter.Eq(x => x.Id, id);
            await _todo.DeleteOneAsync(filter);
            return true;
        }
    }
}