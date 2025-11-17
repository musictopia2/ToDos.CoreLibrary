namespace ToDos.CoreLibrary.Components;
public partial class EditMainToDoNotesComponent
{
    [Parameter]
    public ToDoMainModel? MainToDo { get; set; }
    [Parameter]
    public EventCallback OnSavedNotes { get; set; }
    [Inject]
    private ICompleteDataAccess? DataAccess { get; set; }
    private string _notes = "";
    protected override void OnInitialized()
    {
        _notes = MainToDo!.Notes;
        base.OnInitialized();
    }
    private async Task SaveAsync()
    {
        MainToDo!.Notes = _notes; //only set once i decide to save.
        await DataAccess!.UpdateMainNotesAsync(MainToDo!);
        await OnSavedNotes.InvokeAsync();
    }
}