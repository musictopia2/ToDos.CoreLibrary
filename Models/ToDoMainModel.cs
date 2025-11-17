namespace ToDos.CoreLibrary.Models;
public class ToDoMainModel : SimpleToDo
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Needs Category")]
    public string Category { get; set; } = "";
    public DateTime DateEntered { get; set; } //hopefully its okay without custom attribute (?)
}