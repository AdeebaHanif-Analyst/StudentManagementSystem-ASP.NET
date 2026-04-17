using CRUDUsingAspnetWebApiCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CRUDUsingAspnetWebApiCore.Controllers
{
    public class StudentController : Controller
    {
        private readonly HttpClient client;
        private string url = "https://localhost:44355/api/StudentApi/";

        public StudentController()
        {
            client = new HttpClient();
        }

        // INDEX (FIXED)
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Student> students = new List<Student>();

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<Student>>(result);

                if (data != null)
                {
                    students = data;
                }
            }

            return View(students);
        }

        // CREATE GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public async Task<IActionResult> Create(Student stud)
        {
            string json = JsonConvert.SerializeObject(stud);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Insert_message"] = "Student Added!!";
                return RedirectToAction("Index");
            }

            return View();
        }

        // EDIT GET
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Student stud = new Student();

            HttpResponseMessage response = await client.GetAsync(url + id);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                stud = JsonConvert.DeserializeObject<Student>(result);
            }

            return View(stud);
        }

        // EDIT POST
        [HttpPost]
        public async Task<IActionResult> Edit(Student stud)
        {
            string json = JsonConvert.SerializeObject(stud);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(url + stud.id, content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Update_message"] = "Student Updated!!";
                return RedirectToAction("Index");
            }

            return View();
        }

        // DETAILS
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Student stud = new Student();

            HttpResponseMessage response = await client.GetAsync(url + id);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                stud = JsonConvert.DeserializeObject<Student>(result);
            }

            return View(stud);
        }

        // DELETE GET
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Student stud = new Student();

            HttpResponseMessage response = await client.GetAsync(url + id);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                stud = JsonConvert.DeserializeObject<Student>(result);
            }

            return View(stud);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(url + id);

            if (response.IsSuccessStatusCode)
            {
                TempData["Delete_message"] = "Student Record Deleted";
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}