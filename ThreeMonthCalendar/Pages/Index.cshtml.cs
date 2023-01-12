using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ThreeMonthCalendar.Pages
{
    public record Employee(string Name, List<Leave> Leaves);
    public record Leave(DateTime Day, eLeaveType LeaveType);
    public enum eLeaveType { Urlaub, Krank, Sonder };
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); ;
            ViewData["startDate"] = startDate;
            ViewData["employees"] = new List<Employee>
            {
                new Employee("Adrian", new List<Leave>
                {
                    new Leave(startDate.AddDays(0), eLeaveType.Urlaub),
                    new Leave(startDate.AddDays(4), eLeaveType.Urlaub)
                }),
                new Employee("Edgar", new List<Leave>
                {
                    new Leave(startDate.AddDays(7), eLeaveType.Urlaub),
                    new Leave(startDate.AddDays(8), eLeaveType.Urlaub)
                }),
                new Employee("Farshid", new List<Leave>
                {
                    new Leave(startDate.AddDays(11), eLeaveType.Urlaub),
                    new Leave(startDate.AddDays(12), eLeaveType.Sonder)
                }),
                new Employee("Marcus", new List<Leave>
                {
                    new Leave(startDate.AddDays(30), eLeaveType.Urlaub),
                    new Leave(startDate.AddDays(18), eLeaveType.Krank)
                })
            };
        }
    }
}