using Microsoft.AspNetCore.Mvc;
using JobBoard.Models;
using System.Collections.Generic;

namespace JobBoard.Controllers
{
  public class JobsController : Controller
  {

    [HttpGet("/categories/{categoryId}/jobs/new")]
    public ActionResult New(int categoryId)
    {
      Category category = Category.Find(categoryId);
      return View(category);
    }

    [HttpGet("/categories/{categoryId}/jobs/{jobId}")]
    public ActionResult Show(int categoryId, int jobId)
    {
      Jobs job = Jobs.Find(jobId);
      Category category = Category.Find(categoryId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("job", job);
      model.Add("category", category);
      return View(model);
    }

    [HttpPost("/jobs/delete")]
    public ActionResult DeleteAll()
    {
      Jobs.ClearAll();
      return View();
    }

  }
}