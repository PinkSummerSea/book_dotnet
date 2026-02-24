using System;
using AutoLot.Samples.Models;
using AutoLot.Samples.ViewModels;

namespace AutoLot.Samples;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        ChangeTracker.StateChanged+=ChangeTracker_StateChanged;
        ChangeTracker.Tracked+=ChangeTracker_Tracked;
    }

    public DbSet<Car> Cars {get;set;}
    public DbSet<Make> Makes {get;set;}
    public DbSet<Radio> Radios {get;set;}
    public DbSet<Driver> Driver {get;set;}
    public DbSet<CarDriver> CarsToDrivers {get;set;}
    public DbSet<CarMakeViewModel> CarMakeViewModels {get;set;}
    private void ChangeTracker_Tracked(object sender, EntityTrackedEventArgs e)
    {
        if (e.FromQuery)
        {
            Console.WriteLine($"an entity of type {e.Entry.Entity.GetType().Name} was loaded from the database");
        }
    }

    private void ChangeTracker_StateChanged(object sender, EntityStateChangedEventArgs e)
    {
        if (e.OldState==EntityState.Unchanged && e.NewState==EntityState.Modified)
        {
            Console.WriteLine($"an entity of type {e.Entry.Entity.GetType().Name} was changed");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // fluent api calls go here
        new CarConfiguration().Configure(modelBuilder.Entity<Car>());
        new RadioConfiguration().Configure(modelBuilder.Entity<Radio>());
        new DriverConfiguration().Configure(modelBuilder.Entity<Driver>());
        new CarMakeViewModelConfiguration().Configure(modelBuilder.Entity<CarMakeViewModel>());
    }

    
}
