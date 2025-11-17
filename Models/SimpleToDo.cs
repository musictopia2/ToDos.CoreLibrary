namespace ToDos.CoreLibrary.Models;
public abstract class SimpleToDo : IMappable
{
    public int ID { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Needs Title")]
    [CommonField]
    public string Title { get; set; } = "";
    [CommonField]
    public string Notes { get; set; } = "";
    //looks like there is an attribute for fulldate (not sure why).
    //maybe not needed since blazor can convert as needed anyways.
    public DateTime DateModified { get; set; }
    [CommonField]
    public bool IsCompleted { get; set; }
}