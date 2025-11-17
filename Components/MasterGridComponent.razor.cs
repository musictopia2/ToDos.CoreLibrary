namespace ToDos.CoreLibrary.Components;
public partial class MasterGridComponent
{
    private readonly BasicList<string> _headers =
    [
        "Priority",
        "Title",
        "Category",
        "Notes",
        "Modified Date"
    ];

    [Inject]
    private MasterShellViewModel? DataContext { get; set; }
    //protected override void OnInitialized() => GlobalEventHelpers.StateHasChanged = () => StateHasChanged();
    protected override async Task OnInitializedAsync() => await DataContext!.RefreshMasterListAsync();
    [Parameter]
    public EventCallback OnChangedItem { get; set; }
    private void ChangeItem(MasterToDoModel? item)
    {
        DataContext!.SelectedItem = item;
        OnChangedItem.InvokeAsync();
    }
}