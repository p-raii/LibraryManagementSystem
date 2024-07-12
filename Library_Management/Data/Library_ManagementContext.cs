using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Library_Management.Models;

namespace Library_Management.Data
{
    public class Library_ManagementContext : DbContext
    {
        public Library_ManagementContext (DbContextOptions<Library_ManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Library_Management.Models.User> User { get; set; } = default!;
        public DbSet<Library_Management.Models.Book> Book { get; set; } = default!;
        public DbSet<Library_Management.Models.Category> Category { get; set; } = default!;
        public DbSet<Library_Management.Models.Student> Student { get; set; } = default!;
    }
}
