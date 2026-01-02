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

TaskOperations taskOperations = new TaskOperations();
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
            taskOperations.Create(readResult);
        }
        else if(readResult.Contains("update"))
        {
            taskOperations.Update(readResult);
        }    
        else if(readResult.Contains("delete"))
        {
            taskOperations.Delete(readResult);           
        }

        else if(readResult.Contains("mark-in-progress"))
        {
            taskOperations.MarkInProgress(readResult);
        }

        else if(readResult.Contains("mark-done"))
        {
            taskOperations.MarkDone(readResult);
        }
    
        else if (readResult.Contains("list"))
        {
            taskOperations.List(readResult);
        }

        else if (readResult.Contains("quit"))
        {
            Console.WriteLine("Bye!");
            valid = false;
        }
        
        else
        {
            Console.WriteLine("Error, Command not found. Type 'commands' to see all commands");
        }
    }   
        
                
}



