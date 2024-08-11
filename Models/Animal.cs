using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetProject.Models
{
    public class Animal
    {
        #region AnimalId
        public int AnimalId { get; set; }
        #endregion

        #region Name
        [Display(Name = "Name:")]
        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(30, ErrorMessage = "You have reached the maximum length of characters (30)")]
        public string? Name { get; set; }
        #endregion

        #region Age
        [Display(Name = "Age:")]
        [Required(ErrorMessage = "Please enter age")]
        [Range(0, 100, ErrorMessage = "Please enter a valid age between 0 and 100")]
        public int? Age { get; set; }
        #endregion

        #region PictureName
        [Display(Name = "Picture:")]
        [StringLength(255, ErrorMessage = "The picture name cannot exceed 255 characters")]
        [RegularExpression("^.*\\.(jpg|jpeg|png)$", ErrorMessage = "The picture name must end with .jpg, .jpeg, or .png.")]
        public string? PictureName { get; set; }
        #endregion

        #region Description
        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(500, ErrorMessage = "The description cannot exceed 500 characters")]
        public string? Description { get; set; }
        #endregion

        #region CategoryId
        [ForeignKey("Category")]
        [Required(ErrorMessage = "Please select a category.")]
        [Display(Name = "Category:")]
        public int? CategoryId { get; set; }
        #endregion

        #region Navigation Properties
        public Category? Category { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        #endregion
    }
}
