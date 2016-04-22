using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Breeze.Models
{
    [Table("Games")]
    public class Game
    {
        public Game()
        {
            this.Comments = new HashSet<Comment>();
        }
        [Key]
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}