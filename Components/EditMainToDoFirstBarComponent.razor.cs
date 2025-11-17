namespace ToDos.CoreLibrary.Components;
public partial class EditMainToDoFirstBarComponent
{
    [Parameter]
    [EditorRequired]
    public EditMainToDoFirstViewModel? DataContext { get; set; }
    [Parameter]
    public EventCallback OnReloadFull { get; set; }
    [Parameter]
    public EventCallback OnEditMainNotes { get; set; }
    [Parameter]
    public EventCallback OnCreateNewSubItem { get; set; }
    [Parameter]
    public EventCallback OnEditSubNotes { get; set; }
    private async Task CompleteItemAsync()
    {
        await DataContext!.CompleteItemAsync();
        await OnReloadFull.InvokeAsync();
    }
}