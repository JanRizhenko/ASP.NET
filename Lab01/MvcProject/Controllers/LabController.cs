using Microsoft.AspNetCore.Mvc;
using MvcProject.Models;

public class LabController : Controller
{
    public IActionResult Info()
    {
        var model = new LabInfoModel
        {
            LabNumber = "Лабораторна №1",
            Topic = "Вступ до ASP.NET Core",
            Goal = "Ознайомитися з основними принципами роботи .NET, навчитися налаштовувати середовище розробки та встановлювати необхідні компоненти," +
            " набути навичок створення рішень та проектів різних типів," +
            " набути навичок обробки запитів з використанням middleware.",
            StudentName = "Ян Риженко"
        };
        return View(model);
    }
}
