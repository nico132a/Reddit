using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.Design;

namespace shared.model
{
    public class Comment
    {
        public long CommentId { get; set; }
        public string? UserName { get; set; }
        public string? Text { get; set; }
        public int Value { get; set; }
        public DateTime CreatedAt1 { get; set; }
        public DateTime? UpdatedAt1 { get; set; }

        public Comment(long commentId, string? userName, string? text, int value, DateTime createdAt1, DateTime? updatedAt1)
        {
            this.CommentId = commentId;
            this.UserName = userName;
            this.Text = text;
            this.Value = value;
            this.CreatedAt1 = createdAt1;
            this.UpdatedAt1 = updatedAt1;
        }

        public Comment() { }
    }
}