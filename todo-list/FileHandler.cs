using Task;
using System;
using System.Text.Json;

public class FileHandler
{
    public static void Savejson(List<ToDoTask> todoList) 
    {
        string json = JsonSerializer.Serialize(todoList, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("todoList.json", json);
    }


    public static void LoadJson(ref List<ToDoTask> todoList) 
    {
        if (File.Exists("todoList.json")) {
            string json = File.ReadAllText("todoList.json");
            todoList = JsonSerializer.Deserialize<List<ToDoTask>>(json) ?? new List<ToDoTask>();
        }
    }

}