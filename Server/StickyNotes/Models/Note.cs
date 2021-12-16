using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace StickyNotes.Models
{
    public class Note
    {
        public Note()
        {
            IsDelete = true;
        }

        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        [DisplayFormat(DataFormatString = "yyyy/MM/dd HH:mm")]
        public DateTime? CreationDate { get; set; }

        [DisplayFormat(DataFormatString = "yyyy/MM/dd HH:mm")]
        public DateTime? LastModifyDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool IsDelete { get; set; } = true;
    }
}
