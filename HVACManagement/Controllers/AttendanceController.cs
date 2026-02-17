using HVACManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HVACManagement.Controllers;

[Authorize]
public class AttendanceController : Controller
{
    private readonly IAttendanceService _attendanceService;

    public AttendanceController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }

    public IActionResult Index() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CheckIn(int employeeId)
    {
        await _attendanceService.CheckInAsync(employeeId);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CheckOut(int employeeId)
    {
        await _attendanceService.CheckOutAsync(employeeId);
        return RedirectToAction(nameof(Index));
    }
}
