using TodoApp.Models;

namespace TodoApp.Services
{
  public interface Iservices
  {
    Task<List<TodoItems>> GetAll();
    Task<TodoItems> GetById(int id);
    Task Add(TodoItems item);
    Task Update(TodoItems item);
    Task  Delete(int id);
    Task  DeleteAll();
  }
}