using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tests
{/*
    public class ManaFieldUpdateTests
    {
        [Test]
        public void ManaFieldUpdateOneParticle()
        {
            //arrange
            ManaField mainField = new ManaField();
            List<ManaParticle> testparticles;
            ManaParticle newParticle = new ManaParticle(2, 0, 0, -3, 1, 6);
            mainField.AddParticle(newParticle);

            //act
            mainField.Update();
            testparticles = mainField.GetParticleList();

            //assert
            Assert.AreEqual(testparticles[0].xLoc, -1);
            Assert.AreEqual(testparticles[0].yLoc, 1);
            Assert.AreEqual(testparticles[0].zLoc, 6);
            Assert.AreEqual(testparticles[0].xSpeed, -3);
            Assert.AreEqual(testparticles[0].ySpeed, 1);
            Assert.AreEqual(testparticles[0].zSpeed, 6);
        }

        [Test]
        public void ManaFieldUpdateParticleList()
        {
            //arrange
            ManaField mainField = new ManaField();
            List<ManaParticle> testparticles = new List<ManaParticle>();
            testparticles.Add(new ManaParticle(2, 0, 0, -3, 1, 6));
            testparticles.Add(new ManaParticle(2, 2, 0, -3, 1, 6));
            testparticles.Add(new ManaParticle(2, 4, 0, -3, 1, 6));
            mainField.AddParticle(testparticles);

            //act
            mainField.Update();
            testparticles = mainField.GetParticleList();

            //assert
            Assert.AreEqual(testparticles[0].xLoc, -1);
            Assert.AreEqual(testparticles[0].yLoc, 1);
            Assert.AreEqual(testparticles[0].zLoc, 6);
            Assert.AreEqual(testparticles[0].xSpeed, -3);
            Assert.AreEqual(testparticles[0].ySpeed, 1);
            Assert.AreEqual(testparticles[0].zSpeed, 6);

            Assert.AreEqual(testparticles[1].xLoc, -1);
            Assert.AreEqual(testparticles[1].yLoc, 3);
            Assert.AreEqual(testparticles[1].zLoc, 6);
            Assert.AreEqual(testparticles[1].xSpeed, -3);
            Assert.AreEqual(testparticles[1].ySpeed, 1);
            Assert.AreEqual(testparticles[1].zSpeed, 6);

            Assert.AreEqual(testparticles[2].xLoc, -1);
            Assert.AreEqual(testparticles[2].yLoc, 5);
            Assert.AreEqual(testparticles[2].zLoc, 6);
            Assert.AreEqual(testparticles[2].xSpeed, -3);
            Assert.AreEqual(testparticles[2].ySpeed, 1);
            Assert.AreEqual(testparticles[2].zSpeed, 6);
        }
    }*/
}