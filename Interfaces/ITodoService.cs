using System.Globalization;
using todo_list.Models;

namespace todo_list.Interfaces
{
    public interface ITodoService
    { 
        Task<IEnumerable<Todo>> GetAllTasks();
        Task<Todo> GetTaskById(string id);
        Task<IEnumerable<Todo>> AddNewTask(TodoAddRequest newTodo);
        Task<Todo> UpdateExistingTask(TodoUpdateRequest updatedTodo, string id);
        Task<IEnumerable<Todo>> DeleteTaskById(string id);
    }
}
