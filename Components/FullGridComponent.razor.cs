namespace ToDos.CoreLibrary.Components;
public partial class FullGridComponent
{
    private readonly BasicList<string> _headers =
    [
        "Created Date",
        "Title",
        "Category",
        "Notes",
        "Modified Date"
    ];
    [Inject]
    private FullShellViewModel? DataContext { get; set; }
    [Parameter]
    public EventCallback OnChangedItem { get; set; }
    protected override async Task OnInitializedAsync() => await DataContext!.LoadCompleteListAsync();
    private void ChangeItem(ToDoMainModel? item)
    {
        DataContext!.SelectedMainToDo = item;
        OnChangedItem.InvokeAsync();
    }
}