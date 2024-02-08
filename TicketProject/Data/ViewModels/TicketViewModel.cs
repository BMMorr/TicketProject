using Microsoft.AspNetCore.Mvc.Rendering;

namespace TicketProject.Data.ViewModels
{
    public class TicketViewModel
    {
        public int TicketSystemCategoryTypeID { get; set; }
        public IEnumerable<SelectListItem> TicketCategories { get; set; }
    }
}
