using Microsoft.AspNetCore.Mvc;
using MvcProject.Models;

public class LabController : Controller
{
    public IActionResult Info()
    {
        var model = new LabInfoModel
        {
            LabNumber = "����������� �1",
            Topic = "����� �� ASP.NET Core",
            Goal = "������������ � ��������� ���������� ������ .NET, ��������� ������������� ���������� �������� �� ������������� �������� ����������," +
            " ������ ������� ��������� ����� �� ������� ����� ����," +
            " ������ ������� ������� ������ � ������������� middleware.",
            StudentName = "�� �������"
        };
        return View(model);
    }
}
