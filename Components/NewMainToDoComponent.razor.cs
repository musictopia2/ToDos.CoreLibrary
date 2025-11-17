namespace ToDos.CoreLibrary.Components;
public partial class NewMainToDoComponent
{
    private readonly ToDoMainModel _model = new();
    [Inject]
    private ICompleteDataAccess? CompleteAccess { get; set; }
    [Parameter]
    public EventCallback<ToDoMainModel> OnNewToDoCreated { get; set; }
    private async Task SaveAsync()
    {
        await CompleteAccess!.CreateNewMainToDoAsync(_model);
        if (_model.ID == 0)
        {
            throw new CustomBasicException("The ID cannot be 0 on a new todo item");
        }
        await OnNewToDoCreated.InvokeAsync(_model);
    }
}