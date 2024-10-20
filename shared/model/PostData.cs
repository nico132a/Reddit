using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.Design;
using System.Collections.Generic;

namespace shared.model
{
    public class PostData
    {
        [Key] 
        public long PostId { get; set; }
        public string? Name { get; set; }
        public string? Text { get; set; }
        public int Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Comment>? Comments { get; set; }

        public PostData(long postId, string? name, string? text, int value, DateTime createdAt, List<Comment>? comments)
        {
            this.PostId = postId;
            this.Name = name;
            this.Text = text;
            this.Value = value;
            this.CreatedAt = createdAt;
            this.Comments = comments;
        }

        public PostData() { }
    }
}
