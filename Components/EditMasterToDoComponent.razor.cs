namespace ToDos.CoreLibrary.Components;
public partial class EditMasterToDoComponent
{
    private string _status = "Have Not Saved Yet";
    private MasterToDoModel MasterToDoItem => DataContext!.SelectedItem!;
    [Inject]
    private IMasterDataAccess? DataAccess { get; set; }
    [Inject]
    private MasterShellViewModel? DataContext { get; set; }
    [Parameter]
    public EventCallback OnRefresh { get; set; }
    private async Task SaveNotesAsync()
    {
        await DataAccess!.SaveNotesAsync(DataContext!.SelectedItem!, DataContext!.SelectedItem!.Notes);
        _status = $"Saved Notes On {DateTime.Now}";
    }
    private async Task CompleteToDoItemAsync()
    {
        await DataAccess!.CompleteToDoItemAsync(DataContext!.SelectedItem!, DataContext!.SelectedItem!.Notes);
        PrivateRefresh();
    }
    private void PrivateRefresh()
    {
        DataContext!.SelectedItem = null;
        OnRefresh.InvokeAsync();
    }
    private async Task RemoveFromListAsync()
    {
        await DataAccess!.TakeOffMasterAsync(DataContext!.SelectedItem!, DataContext!.SelectedItem!.Notes);
        PrivateRefresh();
    }
}