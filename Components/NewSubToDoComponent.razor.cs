namespace ToDos.CoreLibrary.Components;
public partial class NewSubToDoComponent
{
    private readonly ToDoDetailModel _model = new();
    [Parameter]
    public ToDoMainModel? MainToDo { get; set; }
    [Parameter]
    public EventCallback OnCreatedSubToDo { get; set; }
    [Inject]
    private ICompleteDataAccess? DataAccess { get; set; }
    private async Task SaveAsync()
    {
        await DataAccess!.CreateSubToDoAsync(MainToDo!, _model);
        await OnCreatedSubToDo.InvokeAsync();
    }
}