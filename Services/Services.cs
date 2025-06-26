using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.Features;
using TodoApp.Models;
namespace TodoApp.Services
{
  public class Service : Iservices
  {
    private List<TodoItems> Itm = new();
    private int nxtId = 1;

    public async Task<List<TodoItems>> GetAll() => await Task.FromResult(Itm);


    public async Task<TodoItems> GetById(int id) => await Task.FromResult(Itm.FirstOrDefault(x => x.Id == id));

    public async Task Add(TodoItems item)
    {
      item.Id = nxtId++;
      item.CreatedAt = DateTime.UtcNow;
      Itm.Add(item);
      await Task.CompletedTask;

    }

    public async Task Update(TodoItems item)
    {
      var existing = Itm.FirstOrDefault(x => x.Id == item.Id);
      if (existing != null)
      {
        existing.Title = item.Title;
        existing.Completed = item.Completed;

      }
      await Task.CompletedTask;
    }

    public async Task Delete(int id)
    {
      var item = Itm.FirstOrDefault(x => x.Id == id);
      if (item != null)
      {
        Itm.Remove(item);

      }
      await Task.CompletedTask;
    }

    public async Task DeleteAll()
    {
      Itm.Clear();
      await Task.CompletedTask;
    }

    Task<TodoItems> Iservices.Add(TodoItems item)
    {
      throw new NotImplementedException();
    }

    Task<TodoItems> Iservices.Update(TodoItems item)
    {
      throw new NotImplementedException();
    }

    Task<TodoItems> Iservices.Delete(int id)
    {
      throw new NotImplementedException();
    }

    Task<TodoItems> Iservices.DeleteAll()
    {
      throw new NotImplementedException();
    }
  }
}