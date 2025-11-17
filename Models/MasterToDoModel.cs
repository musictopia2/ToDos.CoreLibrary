namespace ToDos.CoreLibrary.Models;
public class MasterToDoModel : IComparable<MasterToDoModel>, IMasterToDoModel
{
    public int ID { get; set; }
    public int? MainToDoID { get; set; }
    public int? DetailToDoID { get; set; }
    public int? Priority { get; set; } //since its only 2, not worth doing the change tracker for this one.
    public int? Previous { get; set; }
    public EnumEnterStatus EnterStatus { get; set; }
    public SimpleToDo? TodoItem { get; set; } //needs to be allowed to be set now i think.
    public string Title { get; set; } = "";
    public string Category { get; set; } = "";
    public DateTime DateModified { get; set; }
    public string Notes { get; set; } = "";
    int IComparable<MasterToDoModel>.CompareTo(MasterToDoModel? other)
    {
        if (other!.Priority.HasValue == false)
        {
            return -1; //i like the idea that the ones that are unknowns are last.  i can decide from there how it will be prioritized.
        }
        if (Priority.HasValue == false)
        {
            return 1;
        }
        if (Priority!.Value == other.Priority!.Value)
        {
            return EnterStatus.CompareTo(other.EnterStatus);
        }
        return Priority.Value.CompareTo(other.Priority.Value);
    }
}