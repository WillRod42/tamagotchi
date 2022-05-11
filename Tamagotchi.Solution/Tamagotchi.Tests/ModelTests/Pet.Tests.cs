using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tamagotchi.Models;
using System;
using System.Collections.Generic;

namespace Tamagotchi.Tests
{
	[TestClass]
	public class Tests
	{
		[TestMethod]
		public void Pet_CreateNewInstanceOfClass_NewPet()
		{
			Pet newPet = new Pet();
			Assert.AreEqual(typeof(Pet),  newPet.GetType());
		}
	}
}
