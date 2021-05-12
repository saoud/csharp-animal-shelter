using System.Collections.Generic;

namespace AnimalShelter.Models
{
  public class AnimalType
  {
    private static List<AnimalType> _instances = new List<AnimalType> {};
    public string Name { get; set; }
    public int Id { get; }
    public List<Pet> Pets { get; set; }

    public AnimalType(string animalTypeName)
    {
      Name = animalTypeName;
      _instances.Add(this);
      Id = _instances.Count;
      Pets = new List<Pet>{};
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static List<AnimalType> GetAll()
    {
      return _instances;
    }

    public static AnimalType Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public void AddPet(Pet pet)
    {
      Pets.Add(pet);
    }

  }
} 