using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notebook2.ViewModel;
using Notebook2.Models;

namespace Notebook2.Data
{
    public class Notebook2Context : DbContext
    {
        public Notebook2Context (DbContextOptions<Notebook2Context> options)
            : base(options)
        {
        }
        //public DbSet<NoteBook> NoteBook { get; set; }
        public DbSet<Notebook2.ViewModel.notes> notes { get; set; } = default!;
    }
}
