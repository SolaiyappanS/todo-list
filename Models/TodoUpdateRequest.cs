namespace todo_list.Models
{
    public class TodoUpdateRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
