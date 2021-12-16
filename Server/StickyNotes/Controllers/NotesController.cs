using Microsoft.AspNetCore.Mvc;
using StickyNotes.Models;
using Dapper;
using System.Data.SqlClient;
using StickyNotes.Helper;
using StickyNotes.DTOs;

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
            string sql = "SELECT * FROM Notes WHERE IsDelete = 'True'";
            try
            {
                var notes = new List<Note>();
                using var db = new SqlConnection(_connection.SqlServerConnection);
                notes = db.Query<Note>(sql).ToList();
                return Ok(notes);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid? id)
        {
            string sql = "SELECT * FROM dbo.Notes WHERE Id = @Id";
            try
            {
                Note note;
                using var db = new SqlConnection(_connection.SqlServerConnection);
                var param = new { Id = id };
                note = db.QueryFirstOrDefault<Note>(sql, param);
                if (note is null)
                    return NotFound();
                else
                    return Ok(note);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNoteDto note)
        {
            try
            {
                string sql = "INSERT INTO Notes (Id, Title, Description, CreationDate, IsDelete) VALUES (@Id, @Title, @Description, @CreationDate, @IsDelete)";
                using var db = new SqlConnection(_connection.SqlServerConnection);
                var res = await db.ExecuteAsync(sql, note);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            string sql = "UPDATE Notes SET IsDelete = 'False' WHERE Id = @Id";
            try
            {
                using var db = new SqlConnection(_connection.SqlServerConnection);
                await db.ExecuteAsync(sql,new { Id = id });
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update(Guid? id, UpdateNoteDto note)
        {
            try
            {
                note.Id = id;
                string sql = "UPDATE Notes SET Title=@Title, Description=@Description, LastModifyDate=@LastModifyDate WHERE Id = @Id";
                using var db = new SqlConnection(_connection.SqlServerConnection);
                await db.ExecuteAsync(sql, note);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
