namespace ToDos.CoreLibrary.ViewModels;
public class EditMainToDoFirstViewModel(ICompleteDataAccess completeDataAccess)
{
    private static IToast? Toast => BlazorUIHelpers.Toast;
    public ToDoDetailModel? SelectedItem
    {
        get
        {
            if (MasterList.Count != 1)
            {
                return null;
            }
            return MasterList.Single();
        }
    }
    public BasicList<ToDoDetailModel> MasterList { get; private set; } = []; //get from master.  choosing one is like selecting item.
    public BasicList<ToDoDetailModel> SubList { get; private set; } = [];
    public ToDoMainModel? MainToDo { get; set; }
    public bool Loaded { get; private set; }
    public async Task RefreshListsAsync()
    {
        if (MainToDo is null)
        {
            throw new CustomBasicException("Must have a main todo in order to refresh lists");
        }
        MasterList.Clear(); //i think needs to clear the list everytime.
        Loaded = false;
        SubList = await completeDataAccess.GetSubToDoListsAsync(MainToDo);
        Loaded = true;
    }
    public async Task PutAllSubToMasterListAsync()
    {
        await completeDataAccess.PutSelectedSubToMasterAsync(SubList);
        Toast!.ShowSuccessToast("Put all the ones from the sub todo on the master list if not already there");
    }
    public async Task PutMainToMasterListAsync()
    {
        if (MainToDo is null)
        {
            throw new CustomBasicException("Must have a main todo in order to put main to master list");
        }
        await completeDataAccess.PutMainToMasterAsync(MainToDo);
        Toast!.ShowSuccessToast("Put the main todo item to master list if not already there");
    }
    public async Task PutSelectedSubToMasterListAsync()
    {
        if (MainToDo is null)
        {
            throw new CustomBasicException("Must have a main todo in order to put selected sub to master list");
        }
        await completeDataAccess.PutSelectedSubToMasterAsync(MasterList);
        MasterList.Clear();
        Toast!.ShowSuccessToast("Put the selected sub items to master list if not already there");
        //if something needs update, rethink.

    }
    public async Task CompleteItemAsync()
    {
        if (MainToDo is null)
        {
            throw new CustomBasicException("Must have a main todo in order to complete item");
        }
        await completeDataAccess.CompleteMainToDoAsync(MainToDo, SubList);
        Toast!.ShowSuccessToast("Completed the todo list.  Any sub ones would be completed too.");
    }
    public void ClearMasterAlone()
    {
        //for testing.
        MasterList.Clear();
        Toast!.ShowSuccessToast("If selected items not clear, rethink");
    }
}