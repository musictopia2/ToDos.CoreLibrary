namespace ToDos.CoreLibrary.Components;
public partial class MasterMainBarComponent
{
    [Parameter] //trying with parameter
    [EditorRequired]
    public MasterShellViewModel? DataContext { get; set; }
    [Parameter]
    public EventCallback EditSelectedItem { get; set; }
    [Parameter]
    public EventCallback Refresh { get; set; }
    private async Task SavePriorities()
    {
        await DataContext!.SavePrioritiesAsync();
        await Refresh.InvokeAsync();
        //GlobalEventHelpers.StateHasChanged?.Invoke();
    }
    private async Task RefreshMasterList()
    {
        await DataContext!.RefreshMasterListAsync();
        await Refresh.InvokeAsync();
        //GlobalEventHelpers.StateHasChanged?.Invoke();
    }
}