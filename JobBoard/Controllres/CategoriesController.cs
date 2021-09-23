using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using JobBoard.Models;

namespace JobBoard.Controllers
{
  public class CategoriesController : Controller
  {

    [HttpGet("/categories")]
    public ActionResult Index()
    {
      List<Category> allCategories = Category.GetAll();
      return View(allCategories);
    }

    [HttpGet("/categories/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/categories")]
    public ActionResult Create(string categoryName)
    {
      Category newCategory = new Category(categoryName);
      return RedirectToAction("Index");
    }

    [HttpGet("/categories/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category selectedCategory = Category.Find(id);
      List<Jobs> categoryJobs = selectedCategory.Jobs;
      model.Add("category", selectedCategory);
      model.Add("jobs", categoryJobs);
      return View(model);
    }

    // This one creates new Items within a given Category, not new Categories:
    [HttpPost("/categories/{categoryId}/jobs")]
    public ActionResult Create(int categoryId,string title, string jobDescription,string contactInfo)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category foundCategory = Category.Find(categoryId);
      Jobs newJob = new Jobs(title,jobDescription,contactInfo);
      foundCategory.AddJob(newJob);
      List<Jobs> categoryJobs = foundCategory.Jobs;
      model.Add("jobs", categoryJobs);
      model.Add("category", foundCategory);
      return View("Show", model);
    }

  }
}