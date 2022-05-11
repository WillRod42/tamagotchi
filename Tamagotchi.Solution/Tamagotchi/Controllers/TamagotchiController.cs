using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;

namespace Tamagotchi.Controllers
{
	public class TamagotchiController : Controller
	{
		[HttpGet("/tamagotchi")]
		public ActionResult Index()
		{
			return View(Pet.GetAll());
		}

		[HttpGet("/tamagotchi/{id}")]
		public ActionResult Show(int id)
		{
			return View(Pet.FindPet(id));
		}

		[HttpGet("/tamagotchi/new")]
		public ActionResult New()
		{
			return View();
		}

		[HttpPost("/tamagotchi")]
		public ActionResult Create(string name)
		{
			new Pet(name);
			return RedirectToAction("Index");
		}

		[HttpPost("/tamagotchi/{id}")]
		public ActionResult Patch(int id, string action)
		{
			Pet.PassTime();
			Pet pet = Pet.FindPet(id);
			switch (action)
			{
				case "Feed": pet.Feed(); break;
				case "Play": pet.Play(); break;
				case "Sleep": pet.Sleep(); break;
			}
			Pet.CheckIfDead();

			return RedirectToAction("Show", id);
		}

		[HttpPost("/tamagotchi/{id}/delete")]
		public ActionResult Delete(int id)
		{
			Pet.RemovePet(id);
			return RedirectToAction("Index");
		}
	}
}
