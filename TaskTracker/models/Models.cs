using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using models;

namespace models;

public class ToDoTask
{
    public int Id{get;set;}
    public string Description{get;set;}
    public string Status{get;set;} = "todo";
    [DataType(DataType.Date)]
    public DateTime CreatedAt {get;set;} = DateTime.UtcNow;
    public DateTime UpdatedAt {get;set;} = DateTime.UtcNow;
}

public class AppDbContext : DbContext
{
    public DbSet<ToDoTask> items {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=tasks.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    
}



