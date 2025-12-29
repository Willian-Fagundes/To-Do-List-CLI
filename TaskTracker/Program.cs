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
var toDo = new ToDoTask();
string[] Commands = {"add", "update", "delete", "list", "mark-in-progress", "mark-done", "commands"};


while(valid == true)
{
    Console.WriteLine("--------Task-Tracker--------");
    string? readResult = Console.ReadLine().ToLower();
    

    if (readResult != null)
    {
        if(readResult.Contains("add"))
        {
            string Padrao = @"""([^""]*)""";
            using (var db = new AppDbContext())
            {
                var NewTask = new ToDoTask
                {
                    Description = Regex.Match(readResult, Padrao).Groups[1].Value
                };

                db.items.Add(NewTask);
                db.SaveChanges();
                Console.WriteLine("Task Created!");
            }
        }
        else if(readResult.Contains("update"))
        {
            string Padrao = @"update\s+(?<id>\d+)\s+""(?<txt>[^""]*)""";
            using (var db = new AppDbContext())
            {
                var UpdateTask = new ToDoTask
                {
                    Description = Regex.Match(readResult, Padrao).Groups["txt"].Value,
                    Id = Convert.ToInt32(Regex.Match(readResult, Padrao).Groups["id"].Value)
                };
                db.Update(UpdateTask);
                db.SaveChanges();
                Console.WriteLine("Task Updated!");
            };
        }    
        else if(readResult.Contains("delete"))
        {
            string Padrao = @"\bdelete\s+(?<id>\d+)";
            using (var db = new AppDbContext())
            {
                var DeleteTask = new ToDoTask
                {
                    Id = Convert.ToInt32(Regex.Match(readResult, Padrao).Groups["id"].Value)
                };
                db.Remove(DeleteTask);
                db.SaveChanges();
                Console.WriteLine("Task Deleted!");
            };           
        }

    }   
    else
    {
        Console.WriteLine("Error, Command not found. Type 'commands' to see all commands");
    }
                
}



