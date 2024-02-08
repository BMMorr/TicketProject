using System.ComponentModel.DataAnnotations;

namespace TicketProject.Models
{
    public class TicketSystemCategoryType
    {
        [Key]
        public int TicketSystemCategoryTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
