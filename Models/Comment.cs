using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetProject.Models
{
    public class Comment
    {
        #region CommentId
        public int CommentId { get; set; }
        #endregion

        #region CommentText
        [Required(ErrorMessage = "Content cannot be empty.")]
        [StringLength(200, ErrorMessage = "Content cannot be more than 200 characters long.")]
        public string? CommentText { get; set; }
        #endregion

        #region AnimalId
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
        #endregion

        #region Date
        public DateTime? Date { get; set; }
        #endregion

        #region Navigation Properties
        public virtual Animal? Animal { get; set; }
        #endregion
    }
}
