using System.Collections.Generic;

namespace JobBoard.Models
{
  public class Jobs
  {
    public string Title {get; set;}
    public string Description { get; set; }
    public string ContactInfo  { get; set; }
    public int Id { get; }
    private static List<Jobs> _instances = new List<Jobs> { };

    public Jobs(string title, string jobDescription, string contactInfo)
    {
      Title = title;
      Description = jobDescription;
      ContactInfo = contactInfo;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Jobs> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Jobs Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}