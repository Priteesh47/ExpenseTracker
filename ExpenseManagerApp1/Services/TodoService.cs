using ExpenseManagerApp1.Services;
using System.Text.Json;
using ExpenseManagerApp1.Model;


public static class TodosService
{
    private static void SaveAll(int userId, List<Transaction> todos)
    {
        string appDataDirectoryPath = Utils.GetAppDirectoryPath();
        string todosFilePath = Utils.GetTodosFilePath(userId);

        if (!Directory.Exists(appDataDirectoryPath))
        {
            Directory.CreateDirectory(appDataDirectoryPath);
        }

        var json = JsonSerializer.Serialize(todos);
        File.WriteAllText(todosFilePath, json);
    }

    public static List<Transaction> GetAll(int userId)
    {
        string todosFilePath = Utils.GetTodosFilePath(userId);

        if (!File.Exists(todosFilePath))
        {
            return new List<Transaction>();
        }

        var json = File.ReadAllText(todosFilePath);

        if (json != null) {
            return JsonSerializer.Deserialize<List<Transaction>>(json);
        }
        else
        {
            return new List<Transaction>();
        }
         
    }

    public static List<Transaction> Create(int userId, Transaction transaction)
    {
       
        List<Transaction> todos = GetAll(userId);
        
        todos.Add(transaction);

        SaveAll(userId, todos);
        return todos;
    }

    public static List<Transaction> Delete(int userId, int id)
    {
        List<Transaction> todos = GetAll(userId);
        Transaction todo = todos.FirstOrDefault(x => x.Id == id);

        if (todo == null)
        {
            throw new Exception("Todo not found.");
        }

        todos.Remove(todo);
        SaveAll(userId, todos);
        return todos;
    }

    public static void DeleteByUserId(int userId)
    {
        string todosFilePath = Utils.GetTodosFilePath(userId);
        if (File.Exists(todosFilePath))
        {
            File.Delete(todosFilePath);
        }
    }

    public static List<Transaction> Update(int userId, int id, string taskName, DateTime dueDate, bool isDone)
    {
        List<Transaction> todos = GetAll(userId);
        Transaction todoToUpdate = todos.FirstOrDefault(x => x.Id == id);

        if (todoToUpdate == null)
        {
            throw new Exception("Todo not found.");
        }

      
        SaveAll(userId, todos);
        return todos;
    }
}
