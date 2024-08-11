using System.ComponentModel.DataAnnotations;

namespace PetProject.Models
{
    public class Category
    {
        #region CategoryId
        public int CategoryId { get; set; }
        #endregion

        #region Name
        [Display(Name = "Category:")]
        public string? Name { get; set; }
        #endregion

        #region Navigation Properties
        public ICollection<Animal>? Animals { get; set; }
        #endregion 
    }
}
