using Employees.Models;
using Employees.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeRepository employeeRepository;

        public HomeController(NHibernate.ISession session) => employeeRepository = new EmployeeRepository(session);

        public IActionResult Index()
        {
            return View(employeeRepository.GetAll());
        }

        public async Task<IActionResult> Details(int id)
        {
            var employee = await employeeRepository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        public IActionResult Create()
        {

        return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
        [Bind("Name,Age,Salary")] Employee employee)
        {

                if (ModelState.IsValid)
                {
                    await employeeRepository.Add(employee);
                    return RedirectToAction(nameof(Index));
                }

            return View(employee);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await employeeRepository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
        [Bind("Id,Name,Age,Salary")] Employee employee)
        {

            if (ModelState.IsValid)
            {
                await employeeRepository.Update(employee);
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await employeeRepository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await employeeRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
