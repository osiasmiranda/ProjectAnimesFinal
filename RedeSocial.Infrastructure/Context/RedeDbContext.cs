using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RedeSocial.Domain.Entities;

namespace RedeSocial.Infrastructure.Context;

public class RedeDbContext : IdentityDbContext<ProfileEntity>
{
    public RedeDbContext(DbContextOptions<RedeDbContext> options) : base(options) { }

    public DbSet<PostEntity> Posts { get; set; }
    public DbSet<ProfileEntity> ProfilesUsers { get; set; }

}
