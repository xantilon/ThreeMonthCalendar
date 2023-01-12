using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;
using ThreeMonthCalendar.Models;

namespace ThreeMonthCalendar.Pages.Components.ThreeMonth
{
    public class ThreeMonthViewComponent : ViewComponent
    {
        public string? CssMonthBorder(int day) { return day == 1 ? "month-border" : null; }
        public string? CssWeekend(DayOfWeek wday) { return DayOfWeek.Sunday == wday || DayOfWeek.Saturday == wday ? "cal-weekend" : "cal-weekday"; }


        public async Task<IViewComponentResult> InvokeAsync(DateTime startDate, List<Urlaub> urlaubs)
        {
            ViewData["startDate"] = startDate;
            // Todo sothing here
            return await Task.FromResult(View("Default",urlaubs));
        }


    }
}