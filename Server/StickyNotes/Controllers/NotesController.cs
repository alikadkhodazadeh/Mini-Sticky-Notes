using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StickyNotes.Models;
using Dapper;
using System.Data.SqlClient;
using System.Diagnostics;
using StickyNotes.Helper;

namespace StickyNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly IDatabaseConnection _connection;

        public NotesController(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        [HttpGet]
        public IActionResult Get()
        {
            string sql = "SELECT * FROM Notes";
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var notes = new List<Note>();
                using (var db = new SqlConnection(_connection.SqlServerConnection))
                {
                    notes = db.Query<Note>(sql).ToList();
                }
                stopwatch.Stop();
                return Ok($"{stopwatch.ElapsedMilliseconds}ms");
            }
            catch (Exception)
            {
                return Ok("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Note note)
        {
            string sql = "INSERT INTO Notes (Title, Description, CreationDate) VALUES (@Title, @Description, @CreationDate)";
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                using (var db = new SqlConnection(_connection.SqlServerConnection))
                {
                    await db.ExecuteAsync(sql, note);
                }
                stopwatch.Stop();
                return Ok($"Success - {stopwatch.ElapsedMilliseconds}ms");
            }
            catch (Exception)
            {
                return Ok("Error");
            }
        }
    }
}
