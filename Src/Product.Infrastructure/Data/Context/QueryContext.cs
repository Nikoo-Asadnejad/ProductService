using Microsoft.EntityFrameworkCore;

namespace Product.Infrastructure.Data.Context;

public class QueryContext : DbContext
{
    public QueryContext(DbContextOptions<QueryContext> options) : base(options)
    {
        
    }
    
}