using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class SudokuContext:DbContext
    {
        public SudokuContext(DbContextOptions<SudokuContext> options):base(options)
        {

        }

        public DbSet <Sudoku> Sudokus { get; set; }
    }
}
