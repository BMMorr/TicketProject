using System.ComponentModel.DataAnnotations;

namespace TicketProject.Models
{
    public class TicketEntry
    {
        [Key]
        public int TicketEntryID { get; set; }
        public int TicketSystemCategoryTypeID { get; set; }
        public virtual TicketSystemCategoryType? TicketSystemCategoryType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
