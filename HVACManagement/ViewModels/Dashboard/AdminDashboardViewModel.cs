namespace HVACManagement.ViewModels.Dashboard;

public class AdminDashboardViewModel
{
    public int ActiveEmployees { get; set; }
    public int ActiveProjects { get; set; }
    public int ProjectsNearDeadline { get; set; }
    public int DelayedProjects { get; set; }
}
