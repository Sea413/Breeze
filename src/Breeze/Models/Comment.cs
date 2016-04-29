using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Breeze.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string UserName { get; set; }
        public string CommentDescription { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}