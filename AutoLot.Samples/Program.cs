Console.WriteLine("fun with Entity Framework Core");

static void SampleSaveChanges()
{
    ApplicationDbContext context = new ApplicationDbContextFactory().CreateDbContext(null);

    context.SaveChanges();
}
