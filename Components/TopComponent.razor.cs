namespace ToDos.CoreLibrary.Components;
public partial class TopComponent
{
    [Parameter]
    public bool CanGoBackToMainItem { get; set; }
    [Parameter]
    public EnumToDoStage Stage { get; set; }
    [Parameter]
    public EventCallback<EnumToDoStage> StageChanged { get; set; }
    [Parameter]
    public EventCallback OnBackToMainItem { get; set; }
    private bool MasterEnabled => Stage != EnumToDoStage.Master; //iffy.
    private bool FullEnabled => Stage != EnumToDoStage.Full;
    private void PrivateClick(EnumToDoStage stage)
    {
        if (stage == EnumToDoStage.Editing)
        {
            throw new CustomBasicException("Editing not supported");
        }
        StageChanged.InvokeAsync(stage);
    }
}