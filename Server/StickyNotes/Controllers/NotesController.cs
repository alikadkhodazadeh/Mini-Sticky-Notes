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
                var notes = new List<Note>();
                using (var db = new SqlConnection(_connection.SqlServerConnection))
                {
                    notes = db.Query<Note>(sql).ToList();
                }
                return Ok(notes);
            }
            catch (Exception)
            {
                return Ok("Error");
            }
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            string sql = "SELECT * FROM dbo.Notes WHERE Id = @Id";
            try
            {
                Note note;
                using (var db = new SqlConnection(_connection.SqlServerConnection))
                {
                    var param = new { Id = id };
                    note = db.QueryFirstOrDefault<Note>(sql,param);
                }
                if(note is null)
                    return NotFound();
                else
                    return Ok(note);
            }
            catch (Exception)
            {
                return Ok("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Note note)
        {
            try
            {
                string sql = "INSERT INTO Notes (Title, Description, CreationDate, IsDelete) VALUES (@Title, @Description, @CreationDate, @IsDelete)";
                using (var db = new SqlConnection(_connection.SqlServerConnection))
                {
                    note.CreationDate = DateTime.Now;
                    await db.ExecuteAsync(sql, note);
                }
                return Ok($"Success");
            }
            catch (Exception)
            {
                return Ok("Error");
            }
        }
    }
}
