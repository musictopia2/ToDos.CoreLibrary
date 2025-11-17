namespace ToDos.CoreLibrary.Models;
public interface IMasterToDoModel : IMappable
{
    int ID { get; set; }
    int? MainToDoID { get; set; }
    int? DetailToDoID { get; set; }
    int? Priority { get; set; }
    int? Previous { get; set; }
    EnumEnterStatus EnterStatus { get; set; }
    //SimpleToDo? TodoItem { get; }
    //string Title { get; }
    //string Category { get; }
    //DateTime DateModified { get; set; }
    //string Notes { get; set; }
}