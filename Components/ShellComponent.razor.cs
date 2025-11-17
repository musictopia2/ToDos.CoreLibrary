namespace ToDos.CoreLibrary.Components;
public partial class ShellComponent
{
    private EnumEditStage _editStage;
    private EnumToDoStage _mainStage;
    [Inject]
    private MasterShellViewModel? MasterShellDataContext { get; set; }
    [Inject]
    private FullShellViewModel? FullShellDataContext { get; set; }
    [Inject]
    private EditMainToDoFirstViewModel? EditMainToDoEditDataContext { get; set; }
    private void EditSelectedItem()
    {
        _mainStage = EnumToDoStage.Editing;
        _editStage = EnumEditStage.None;
        if (FullShellDataContext!.SelectedMainToDo is null)
        {
            return;
        }
        EditMainToDoEditDataContext!.MainToDo = FullShellDataContext.SelectedMainToDo;
    }
    private void StartEditSubNotes() => _editStage = EnumEditStage.SubNotes;
    private void StartCreatingSubItem() => _editStage = EnumEditStage.NewSubItem;
    private void StartEditMainNotes() => _editStage = EnumEditStage.MainNotes;
    private void CompleteSubItem() => _editStage = EnumEditStage.None;
    private void StageChanged(EnumToDoStage stage)
    {
        _mainStage = stage;
        MasterShellDataContext!.SelectedItem = null;
        FullShellDataContext!.SelectedMainToDo = null;
        EditMainToDoEditDataContext!.MainToDo = null;
    }
    private void CreateNewItem(ToDoMainModel item)
    {
        FullShellDataContext!.SelectedMainToDo = item;
        EditMainToDoEditDataContext!.MainToDo = item;
        _mainStage = EnumToDoStage.Editing;
        _editStage = EnumEditStage.None;
    }
    private void StartEditItem()
    {
        StateHasChanged();
    }
    private void UpdatedMaster()
    {
        _editStage = EnumEditStage.None;
        _mainStage = EnumToDoStage.Master;
    }
    private void UpdatedFull()
    {
        _mainStage = EnumToDoStage.Full;
        _editStage = EnumEditStage.None;
    }
    private void StartNewMainToDoItem()
    {
        _mainStage = EnumToDoStage.NewMainToDo;
        _editStage = EnumEditStage.None;
    }
    private async Task RefreshAsync()
    {
        await InvokeAsync(StateHasChanged);
    }
    private bool IsEditingMasterItem => _mainStage == EnumToDoStage.Editing && MasterShellDataContext!.SelectedItem != null;
    private bool IsEditingFirstMainItem => _mainStage == EnumToDoStage.Editing && FullShellDataContext!.SelectedMainToDo != null && _editStage == EnumEditStage.None;
}