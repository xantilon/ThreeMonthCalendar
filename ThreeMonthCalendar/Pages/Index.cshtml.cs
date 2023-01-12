using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;

namespace ThreeMonthCalendar.Pages
{
    public record Employee(string Name, List<Leave> Leaves);
    public record Leave(DateTime Day, eLeaveType LeaveType);
    public enum eLeaveType { Urlaub, Krank, Sonder };
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        public DateTime StartDate { get; set; }
        public List<Employee> Employees { get; set; }
        public string? CssMonthBorder(int day) { return (day == 1) ? "month-border" : null; }
        public string? CssWeekend(DayOfWeek wday) { return (DayOfWeek.Sunday == wday || DayOfWeek.Saturday == wday) ? "cal-weekend" : "cal-weekday"; }



        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            StartDate = new DateTime(2022, 12, 10);
        }

        public void OnGet()
        {
            DateTime wannGehtsLos = DateTime.Now.AddMonths(0);
            Employees = new List<Employee>
            {
                new Employee("Adrian", new List<Leave>
                {
                    new Leave(wannGehtsLos.AddDays(0), eLeaveType.Urlaub),
                    new Leave(wannGehtsLos.AddDays(4), eLeaveType.Urlaub)
                }),
                new Employee("Edgar", new List<Leave>
                {
                    new Leave(wannGehtsLos.AddDays(7), eLeaveType.Urlaub),
                    new Leave(wannGehtsLos.AddDays(8), eLeaveType.Urlaub)
                }),
                new Employee("Farshid", new List<Leave>
                {
                    new Leave(wannGehtsLos.AddDays(11), eLeaveType.Urlaub),
                    new Leave(wannGehtsLos.AddDays(12), eLeaveType.Sonder)
                }),
                new Employee("Marcus", new List<Leave>
                {
                    new Leave(wannGehtsLos.AddDays(30), eLeaveType.Urlaub),
                    new Leave(wannGehtsLos.AddDays(18), eLeaveType.Krank)
                })
            };
        }
    }
}