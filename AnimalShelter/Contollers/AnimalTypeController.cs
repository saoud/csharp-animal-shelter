using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
  public class AnimalTypeController : Controller
  {

    [HttpGet("/animalType")]
    public ActionResult Index()
    {
      List<AnimalType> allAnimalTypes = AnimalType.GetAll();
      return View(allAnimalTypes);
    }

    [HttpGet("/animalType/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/animalType")]
    public ActionResult Create(string animalTypeName)
    {
      AnimalType newAnimalType = new AnimalType(animalTypeName);
      return RedirectToAction("Index");
    }

    [HttpGet("/animalType/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      AnimalType selectedAnimalType = AnimalType.Find(id);
      List<Pet> animalTypePets = selectedAnimalType.Pets;
      model.Add("animalType", selectedAnimalType);
      model.Add("pets", animalTypePets);
      return View(model);
    }


    // This one creates new Items within a given animalType, not new Categories:

    [HttpPost("/animalType/{animalTypeId}/pets")]
    public ActionResult Create(int animalTypeId, string petDescription)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      AnimalType foundAnimalType = AnimalType.Find(animalTypeId);
      Pet newPet = new Pet(petDescription);
      foundAnimalType.AddPet(newPet);
      List<Pet> animalTypePets = foundAnimalType.Pets;
      model.Add("pets", animalTypePets);
      model.Add("animalType", foundAnimalType);
      return View("Show", model);
    }

  }
} 