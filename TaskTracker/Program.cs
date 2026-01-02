// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using models;
using System.Text.RegularExpressions;
using System.Data.Common;

bool valid = true;

while(valid == true)
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write("task-cli ");
    Console.ResetColor();
    string? readResult = Console.ReadLine().ToLower();
    

    if (readResult != null)
    {
        if(readResult.Contains("add"))
        {
            string Padrao = @"""(?<txt>[^""]*)""";
            using (var db = new AppDbContext())
            {
                var NewTask = new ToDoTask
                {
                    Description = Regex.Match(readResult, Padrao).Groups["txt"].Value
                };

                db.items.Add(NewTask);
                db.SaveChanges();
                Console.WriteLine("Task Created!");
            }
        }
        else if(readResult.Contains("update"))
        {
            string Padrao = @"update\s+(?<id>\d+)\s+""(?<txt>[^""]*)""";
            int id = Convert.ToInt32(Regex.Match(readResult, Padrao).Groups["id"].Value); 
            using (var db = new AppDbContext())
            {
                var UpdateTask = new ToDoTask
                {
                    Id = id,
                    Description = Regex.Match(readResult, Padrao).Groups["txt"].Value,
                    UpdatedAt = DateTime.UtcNow
                };

                db.items.Attach(UpdateTask);
                db.Entry(UpdateTask).Property(t => t.Description).IsModified = true;
                db.Entry(UpdateTask).Property(t => t.UpdatedAt).IsModified = true;

                db.SaveChanges();
                Console.WriteLine("Task Updated!");
            };
        }    
        else if(readResult.Contains("delete"))
        {
            string Padrao = @"\bdelete\s+(?<id>\d+)";
            int id = Convert.ToInt32(Regex.Match(readResult, Padrao).Groups["id"].Value); 
            using (var db = new AppDbContext())
            {
                var DeleteTask = new ToDoTask
                {
                    Id = id
                };
                db.Remove(DeleteTask);
                db.SaveChanges();
                Console.WriteLine("Task Deleted!");
            };           
        }

        else if(readResult.Contains("mark-in-progress"))
        {
            string Padrao = @"\bmark-in-progress\s+(?<id>\d+)";
            int id = Convert.ToInt32(Regex.Match(readResult, Padrao).Groups["id"].Value);
            using (var db = new AppDbContext())
            {
                var UpdateStatus = new ToDoTask
                {
                    Id = id,
                    Status = "in-progress",
                    UpdatedAt = DateTime.UtcNow                  
                };
                db.items.Attach(UpdateStatus);
                db.Entry(UpdateStatus).Property(t => t.Status).IsModified = true;
                db.Entry(UpdateStatus).Property(t => t.UpdatedAt).IsModified = true;

                db.SaveChanges();
                Console.WriteLine("Status Updated!");
            }
        }

        else if(readResult.Contains("mark-done"))
        {
            string Padrao = @"\bmark-done\s+(?<id>\d+)";
            int id = Convert.ToInt32(Regex.Match(readResult, Padrao).Groups["id"].Value);
            using (var db = new AppDbContext())
            {
                var UpdateStatus = new ToDoTask
                {
                    Id = id,
                    Status = "done",
                    UpdatedAt = DateTime.UtcNow                  
                };
                db.items.Attach(UpdateStatus);
                db.Entry(UpdateStatus).Property(t => t.Status).IsModified = true;
                db.Entry(UpdateStatus).Property(t => t.UpdatedAt).IsModified = true;

                db.SaveChanges();
                Console.WriteLine("Status Updated!");
            }
        }
    
    else if (readResult.Contains("list"))
        {
            string padrao = @"(?<=list\s).*";
            Match match = Regex.Match(readResult, padrao);

            if(match.Success&&!string.IsNullOrWhiteSpace(match.Value))
            {
                string status = match.Value.Trim();
                
                using (var db = new AppDbContext())
                {
                    var filteredItem = db.items.Where(i => i.Status == status).ToList();
                    foreach (var i in filteredItem)
                    {
                        Console.WriteLine($"id = {i.Id} | Description = {i.Description} | Status = {i.Status} | Created-At = {i.CreatedAt} | Upadated-At {i.UpdatedAt}");
                    }
                }
                
            }   
            else
            {
                using (var db = new AppDbContext())
                {
                    var allItems = db.items.ToList();
                    foreach(var i in allItems)
                    {
                        Console.WriteLine($"id = {i.Id} | Description = {i.Description} | Status = {i.Status} | Created-At = {i.CreatedAt} | Updated-At = {i.UpdatedAt}");
                    };
                }
            }
        }
    

    else if (readResult.Contains("quit"))
        {
            Console.WriteLine("Bye!");
            valid = false;
        }

    }   
    else
    {
        Console.WriteLine("Error, Command not found. Type 'commands' to see all commands");
    }
                
}



