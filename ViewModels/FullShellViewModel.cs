namespace ToDos.CoreLibrary.ViewModels;
public class FullShellViewModel(ICompleteDataAccess completeDataAccess)
{
    public bool Loaded { get; private set; } //i like this idea.
    public BasicList<ToDoMainModel> FullToDos { get; private set; } = [];
    public ToDoMainModel? SelectedMainToDo { get; set; }
    public async Task LoadCompleteListAsync()
    {
        FullToDos = await completeDataAccess.GetCompleteToDoListsAsync();
        SelectedMainToDo = null;
        Loaded = true;
    }
}