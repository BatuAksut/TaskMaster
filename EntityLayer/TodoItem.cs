using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class TodoItem: IEntity
    {
        [Key]
        public int TodoId { get; set; }
        public string TodoName { get; set; }
        public string TodoDescription { get; set; }
        public bool IsCompleted { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

    }
}
