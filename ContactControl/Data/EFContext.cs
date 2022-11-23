using ContactControl.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace ContactControl.Data;
public class EFContext : DbContext
{
    // configurando o contexto do EF
    public EFContext(DbContextOptions<EFContext> options) : base(options)
    { }
    
    public DbSet<ContactModel> Contacts { get; set; }


}

