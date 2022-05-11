using System;
using System.Collections.Generic;

namespace Tamagotchi.Models
{
	public class Pet
	{
		public string Name { get; }
		public int Food { get; set; }
		public int Mood { get; set; }
		public int Rest { get; set; }
		public bool Dead { get; set; }
		public int Id { get; }

		private static List<Pet> _pets = new List<Pet>();

		public Pet(string name)
		{
			Name = name;
			Food = 100;
			Mood = 100;
			Rest = 100;
			Id = _pets.Count;
			_pets.Add(this);
		}

		public void Feed()
		{
			Food += 15;
			if (Food > 100)
			{ 
				Food = 100;
			}
		}

		public void Play()
		{
			Mood += 50;
			if (Mood > 100)
			{ 
				Mood = 100;
			}
		}

		public void Sleep()
		{
			Rest = 100;
		}

		public static void PassTime()
		{
			foreach (Pet pet in _pets)
			{
				if (!pet.Dead)
				{
					pet.Food -= 1;
					pet.Mood -= 10;
					pet.Rest -= 5;
				}
			}
		}

		public static void CheckIfDead()
		{
			foreach (Pet pet in _pets)
			{
				if (pet.Food <= 0 || pet.Mood <= 0 || pet.Rest <= 0)
				{
					pet.Dead = true;
				}
			}
		}

		public static List<Pet> GetAll()
		{
			return _pets;
		}

		public static Pet Find(int id)
		{
			return _pets[id];
		}
	}
}
