namespace ToDos.CoreLibrary.Components;
public partial class EditSubToDoNotesComponent
{
    private string _status = "Have Not Saved Yet";
    [Parameter]
    public ToDoDetailModel? SubToDo { get; set; }
    [Parameter]
    public ToDoMainModel? MainToDo { get; set; }
    [Parameter]
    public EventCallback OnComplete { get; set; }
    [Inject]
    private ICompleteDataAccess? DataAccess { get; set; }
    [Inject]
    private IToast? Toast { get; set; }
    private async Task SaveAsync()
    {
        await PrivateSaveAsync();
        _status = $"Saved On {DateTime.Now}";
    }
    private async Task CompleteAsync()
    {
        await PrivateSaveAsync();
        await DataAccess!.CompleteSubToDoAsync(SubToDo!);
        await OnComplete.InvokeAsync();
    }
    private async Task ToMasterAsync()
    {
        await PrivateSaveAsync();
        await DataAccess!.PutSingleSubToMasterAsync(SubToDo!);
        Toast!.ShowSuccessToast("Put To Master");
    }
    private async Task PrivateSaveAsync() => await DataAccess!.SaveSubDetailNotesAsync(SubToDo!);
}