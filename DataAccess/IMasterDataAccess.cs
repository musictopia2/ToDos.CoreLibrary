namespace ToDos.CoreLibrary.DataAccess;
public interface IMasterDataAccess
{
    Task<BasicList<MasterToDoModel>> GetMasterToDosAsync();
    Task SavePrioritiesAsync(BasicList<MasterToDoModel> todos);
    Task CompleteToDoItemAsync(MasterToDoModel master, string notes);
    Task SaveNotesAsync(MasterToDoModel master, string notes);
    Task TakeOffMasterAsync(MasterToDoModel master, string notes);
    /// <summary>
    /// the purpose of this method is to make sure that if an item is no longer on the todo main or detail, then will be taken off the list
    /// think about stored procedure.  that could be good for stored procedure.
    /// </summary>
    /// <returns></returns>

}
