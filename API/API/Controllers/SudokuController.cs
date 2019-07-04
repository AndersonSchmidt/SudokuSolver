using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SudokuController : ControllerBase
    {
        private readonly SudokuContext _context;

        public SudokuController(SudokuContext context)
        {
            _context = context;
        }

        // GET: api/Sudoku
        [HttpGet]
        public IEnumerable<Sudoku> GetSudokus()
        {
            return _context.Sudokus;
        }

        // GET: api/Sudoku/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSudoku([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sudoku = await _context.Sudokus.FindAsync(id);

            if (sudoku == null)
            {
                return NotFound();
            }

            return Ok(sudoku);
        }

        // PUT: api/Sudoku/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSudoku([FromRoute] int id, [FromBody] Sudoku sudoku)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sudoku.Id)
            {
                return BadRequest();
            }

            _context.Entry(sudoku).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SudokuExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sudoku
        [HttpPost]
        public async Task<IActionResult> PostSudoku([FromBody] Sudoku sudoku)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ////////////////////////////////////
           
            string[][] board = new string[9][];

            int cont = 0;
            for (var i=0; i<9; i++)
            {
                board[i] = new string[9];
                for (var j=0; j<9; j++)
                {
                    board[i][j] = sudoku.Board[cont].ToString();
                    cont++;
                }
            }

            bool solve(string[][] bo)
            {
                var empty = findEmpty(bo);
                int row;
                int col;

                if (empty.Length == 0)
                {
                    return true;
                }
                else
                {
                    row = empty[0];
                    col = empty[1];
                }

                for (var i = 1; i <= 9; i++)
                {
                    if (valid(bo, i.ToString(), row, col))
                    {
                        bo[row][col] = i.ToString();

                        if (solve(bo))
                        {
                            return true;
                        }

                        bo[row][col] = "0";
                    }
                }

                return false;
            }


            bool valid(string[][]bo, string num, int roww, int coll)
            {
                // Check row
                for (var i = 0; i < bo[0].Length; i++)
                {
                    if (bo[roww][i] == num && i != coll) //Checking if (i != coll) is necessery just because of the checkBoard function
                    {
                        return false;
                    }
                }

                // Check column
                for (var i = 0; i < bo.Length; i++)
                {
                    if (bo[i][coll] == num && i != roww) //Checking if (i != roww) is necessery just because of the checkBoard function
                    {
                        return false;
                    }
                }

                // Check box
                int boxX = coll / 3;
                int boxY = roww / 3;


                for (var i = boxY * 3; i < (boxY * 3 + 3); i++)
                {
                    for (var j = boxX * 3; j < (boxX * 3 + 3); j++)
                    {
                        if (bo[i][j] == num && i != roww && j != coll) //Checking if (i != roww && j != coll) is necessery just because of the checkBoard function
                        {
                            return false;
                        }
                    }
                }

                return true;
            }


            void printBoard(string[][]bo)
            {
                for (var i = 0; i < bo.Length; i++)
                {
                    if (i % 3 == 0 && i != 0)
                    {
                        Console.WriteLine("-----------------------");
                    }

                    for (var j = 0; j < bo[0].Length; j++)
                    {
                        if (j % 3 == 0 && j != 0)
                        {
                            Console.Write(" | ");
                        }

                        if (j == 8)
                        {
                            Console.WriteLine(bo[i][j]);
                        }
                        else
                        {
                            Console.Write(bo[i][j] + " ");
                        }
                    }
                }
            }

            int[] findEmpty(string[][] bo)
            {
                for (var i = 0; i < bo.Length; i++)
                {
                    for (var j = 0; j < bo[0].Length; j++)
                    {
                        if (bo[i][j] == "0")
                        {
                            return new int[] { i, j };
                        }
                    }
                }
                return new int[0];
            }

            bool checkBoard(string[][] bo)
            {
                var isValid = true;
                for (var i = 0; i < bo[0].Length; i++)
                {
                    for (var j = 0; j < bo.Length; j++)
                    {
                        if (bo[i][j] != "0")
                        {
                            if (!valid(bo, bo[i][j], i, j))
                            {
                                isValid = false;
                            }
                        }
                    }
                }

                return isValid;
            }

            if (checkBoard(board))
            {
                printBoard(board);
                Console.WriteLine("_______________________");
                solve(board);
                printBoard(board);
            }
            else
            {
                Console.WriteLine("Invalid Board");
            }



            for (var i=0; i<9; i++)
            {
                for(var j=0; j<9; j++)
                {
                    sudoku.SolvedBoard += board[i][j];
                }
            }

            ////////////////////////////////////////////

            _context.Sudokus.Add(sudoku);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSudoku", new { id = sudoku.Id }, sudoku);
        }

        // DELETE: api/Sudoku/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSudoku([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sudoku = await _context.Sudokus.FindAsync(id);
            if (sudoku == null)
            {
                return NotFound();
            }

            _context.Sudokus.Remove(sudoku);
            await _context.SaveChangesAsync();

            return Ok(sudoku);
        }

        private bool SudokuExists(int id)
        {
            return _context.Sudokus.Any(e => e.Id == id);
        }
    }
}