namespace ToDos.CoreLibrary.Components;
public partial class EditMainToDoFirstMainComponent
{
    private readonly BasicList<string> _headers = new()
    {
        "Created Date",
        "Title",
        "Notes",
        "Modified Date"
    };

    [Parameter]
    public ToDoMainModel? MainToDo { get; set; }
    [Parameter]
    public EventCallback OnRefresh { get; set; }
    [Inject]
    private EditMainToDoFirstViewModel? DataContext { get; set; }
    protected override async Task OnInitializedAsync() => await DataContext!.RefreshListsAsync();
    private async Task RefreshAsync()
    {
        await OnRefresh.InvokeAsync();
        //GlobalEventHelpers.StateHasChanged?.Invoke();
    }
}