using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Sudoku
    {
        [Key]
        public int Id { get; set; }
        public string Board { get; set; }

        public string SolvedBoard { get; set; }
    }
}
