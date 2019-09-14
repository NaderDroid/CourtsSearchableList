using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Courts_Searchable_Dropdown.Models
{
    public class Courts
    {
        [Required]
        [Display(Name = "Court Code")]
        public int Id { get; set; }

        // This property will hold a state, selected by user
        [Required]
        [Display(Name = "Court Name")]
        public string Name { get; set; }
        public IEnumerable<SelectListItem> CourtsListItems { get; set; }
    }
}