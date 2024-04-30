using Microsoft.EntityFrameworkCore;
using todo_list.Context;
using todo_list.Interfaces;
using todo_list.Models;

namespace todo_list.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoContext _todoContext;
        public TodoService(TodoContext todoContext) {
            _todoContext = todoContext;
        }
        public async Task<IEnumerable<Todo>> GetAllTasks()
        {
            var tasks = await _todoContext.TaskItems.ToListAsync();
            return tasks;
        }
        public async Task<Todo> GetTaskById(string id)
        {
            try
            {
                var task = await _todoContext.TaskItems.FirstOrDefaultAsync(t => t.Id.ToString().Equals(id));
                return task;
            }
            catch
            {
                return null;
            }
        }
        public async Task<IEnumerable<Todo>> AddNewTask(TodoAddRequest newTodoRequest)
        {
            Todo newTodo = new()
            {
                Title = newTodoRequest.Title,
                Description = newTodoRequest.Description,
                CreatedDate = DateTime.UtcNow
            };
            _todoContext.TaskItems.Add(newTodo);
            await _todoContext.SaveChangesAsync();

            var result = await GetAllTasks();

            return result;
        }
        public async Task<Todo> UpdateExistingTask(TodoUpdateRequest updatedTodo, string id)
        {
            try
            {
                var task = await _todoContext.TaskItems.FirstOrDefaultAsync(t => t.Id.ToString().Equals(id));
                task.Title = updatedTodo.Title;
                task.Description = updatedTodo.Description;
                task.UpdatedDate = DateTime.UtcNow;
                task.IsCompleted = updatedTodo.IsCompleted;

                _todoContext.TaskItems.Update(task);
                await _todoContext.SaveChangesAsync();

                var result = await GetTaskById(id);

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<IEnumerable<Todo>> DeleteTaskById(string id)
        {
            try
            {
                var task = await _todoContext.TaskItems.FirstOrDefaultAsync(t => t.Id.ToString().Equals(id));
                _todoContext.TaskItems.Remove(task);
                await _todoContext.SaveChangesAsync();
                var result = await GetAllTasks();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
