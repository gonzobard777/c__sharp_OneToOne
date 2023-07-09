namespace Persistence.Repository;

public class Repo
{
    private AppDbContext DbContext { get; }
    
    public Repo(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }
}