// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using models;

bool valid = true;
var toDo = new ToDoTask();
string[] Commands = {"add", "update", "delete", "list", "mark-in-progress", "mark-done", "commands"};


while(valid == true)
{
    Console.WriteLine("--------Task-Tracker--------");
    string? readResult = Console.ReadLine().ToLower();

    if (readResult != null)
    {
        if(Commands.Contains(readResult))
        {
            switch (readResult)
            {
                case "add":

                    using (var db = new AppDbContext())
                    {
                        var NewTask = new ToDoTask
                        {
                        Description = readResult.Replace("add",""),
                        };

                        db.items.Add(NewTask);
                        db.SaveChanges();
                        Console.WriteLine("Task Created!");
                    }
                    break;

                case "update":
                    break;

                case "delete":
                    break;

                case "list":
                    break;

                case "mark-in-progress":
                    break;

                case "mark-done":
                    break;
                
                case "commands":
                    break;
            }
        }   
        else
        {
            Console.WriteLine("Error, Command not found. Type 'commands' to see all commands");
        }
                
    }
}


