
namespace ToDos.CoreLibrary.Models;
public class ToDoDetailModel : SimpleToDo
{
    public int ToDo { get; set; }
    public DateTime DateCreated { get; set; }
}