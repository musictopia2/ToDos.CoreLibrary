namespace ToDos.CoreLibrary.ViewModels;
public class MasterShellViewModel(IMasterDataAccess masterDataAccess)
{
    public bool Loaded { get; private set; }
    public BasicList<MasterToDoModel> MasterList { get; private set; } = [];
    public MasterToDoModel? SelectedItem { get; set; } //hopefully this simple (?)
    public async Task SavePrioritiesAsync()
    {
        await masterDataAccess.SavePrioritiesAsync(MasterList); //hopefully that works.
        await RefreshMasterListAsync();
    }
    public async Task RefreshMasterListAsync()
    {
        Loaded = false; //redo again.
        MasterList = await masterDataAccess.GetMasterToDosAsync(); //hopefully its that simple.
        SelectedItem = null; //hopefully this will make it null.
        Loaded = true;
    }
}