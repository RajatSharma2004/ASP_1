using TodoApp.Models;

namespace TodoApp.Services
{
  public interface Iservices
  {
    Task<List<TodoItems>> GetAll();
    Task<TodoItems> GetById(int id);
    Task<TodoItems> Add(TodoItems item);
    Task<TodoItems> Update(TodoItems item);
    Task<TodoItems> Delete(int id);
    Task<TodoItems> DeleteAll();
  }
}