using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;

namespace AnimalShelter.Controllers
{
  public class PetsController : Controller
  {

    [HttpGet("/animalType/{AnimalTypeId}/pets/new")]
    public ActionResult New(int animalTypeId)
    {
      AnimalType animalType = AnimalType.Find(animalTypeId);
      return View(animalType);
    }

    [HttpPost("/pets/delete")]
    public ActionResult DeleteAll()
    {
      Pet.ClearAll();
      return View();
    }

    [HttpGet("/animalType/{animalTypeId}/pets/{petId}")]
    public ActionResult Show(int animalTypeId, int petId)
    {
      Pet pet = Pet.Find(petId);
      AnimalType animalType = AnimalType.Find(animalTypeId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("pet", pet);
      model.Add("animalType", animalType);
      return View(model);
    }
  }
} 