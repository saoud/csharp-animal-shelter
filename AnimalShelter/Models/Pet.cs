using System.Collections.Generic;

namespace AnimalShelter.Models
{
  public class Pet
  {
    public string Description { get; set; }
    public int Id { get; }
    private static List<Pet> _instances = new List<Pet> { };

    public Pet(string description)
    {
      Description = description;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Pet> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Pet Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}