namespace ToDos.CoreLibrary.DataAccess;
public interface ICompleteDataAccess
{
    //this is for the complete todo system.
    Task<BasicList<ToDoMainModel>> GetCompleteToDoListsAsync();
    Task PutSelectedSubToMasterAsync(BasicList<ToDoDetailModel> details);
    Task<BasicList<ToDoDetailModel>> GetSubToDoListsAsync(ToDoMainModel main);
    Task CreateNewMainToDoAsync(ToDoMainModel main);

    Task UpdateMainNotesAsync(ToDoMainModel main);

    Task PutMainToMasterAsync(ToDoMainModel main);

    Task CompleteMainToDoAsync(ToDoMainModel main, BasicList<ToDoDetailModel> details); //i like the idea of details too.
    Task CreateSubToDoAsync(ToDoMainModel main, ToDoDetailModel sub);
    Task SaveSubDetailNotesAsync(ToDoDetailModel sub);
    Task PutSingleSubToMasterAsync(ToDoDetailModel sub); //maybe just that parameter.  if i need the other, will add.
    Task CompleteSubToDoAsync(ToDoDetailModel sub);
}
