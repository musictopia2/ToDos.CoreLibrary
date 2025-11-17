namespace ToDos.CoreLibrary.Components;
public partial class FullMainBarComponent
{
    [Parameter]
    public EventCallback EditSelectedItem { get; set; }
    [Parameter]
    [EditorRequired]
    public FullShellViewModel? DataContext { get; set; }
    [Parameter]
    public EventCallback OnNewToDoClick { get; set; }
}