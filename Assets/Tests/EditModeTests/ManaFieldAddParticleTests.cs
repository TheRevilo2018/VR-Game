using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tests
{
    public class ManaFieldAddParticleTests
    {
       /* [Test]
        public void ManaFieldAddParticle()
        {
            //arrange
            ManaField mainField = new ManaField();

            //act 
            mainField.AddParticle(ManaConstants.Energy.Force, 0, 0, 0);

            Assert.IsTrue(true);
        }

        [Test]
        public void ManaFieldAddFiveItems()
        {
            //arrange
            ManaField mainField = new ManaField();
            int expected = 5;
            int actual;
            mainField.AddParticle(ManaConstants.Energy.Force, 0, 0, 0);
            mainField.AddParticle(ManaConstants.Energy.Force, 1, 0, 0);
            mainField.AddParticle(ManaConstants.Energy.Force, 2, 0, 0);
            mainField.AddParticle(ManaConstants.Energy.Force, 3, 0, 0);
            mainField.AddParticle(ManaConstants.Energy.Force, 4, 0, 0);

            //act 
            actual = mainField.Total();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ManaFieldAddThreeParticles()
        {
            //arrange
            ManaField mainField = new ManaField();
            int count = 0;
            List<ManaParticle> testparticles;
            ManaParticle newParticle = new ManaParticle(0, 0, 0);
            mainField.AddParticle(newParticle);
            newParticle = new ManaParticle(1, 0, 0);
            mainField.AddParticle(newParticle);
            newParticle = new ManaParticle(2, 0, 0);
            mainField.AddParticle(newParticle);

            testparticles = mainField.GetParticleList();

            //assert
            Assert.AreEqual(3, testparticles.Count);
            foreach (ManaParticle particle in testparticles)
            {
                Assert.AreEqual(particle.xLoc, count);
                count++;
            }
        }

        [Test]
        public void ManaFieldAddListofParticles()
        {
            //arrange
            ManaField mainField = new ManaField();
            int count = 0;
            List<ManaParticle> testparticles = new List<ManaParticle>();
            for (int i = 0; i < 50; i++)
            {
                ManaParticle newParticle = new ManaParticle(i, 0, 0);
                testparticles.Add(newParticle);
            }

            mainField.AddParticle(testparticles);
            testparticles = mainField.GetParticleList();

            //assert
            Assert.AreEqual(50, testparticles.Count);
            foreach (ManaParticle particle in testparticles)
            {
                Assert.AreEqual(particle.xLoc, count);
                count++;
            }
        }

        [Test]
        public void ManaFieldAddParticleInMotion()
        {
            //arrange
            ManaField mainField = new ManaField();

            //act 
            mainField.AddParticle(0, 0, 0, 1, 1, 1);

            Assert.IsTrue(true);
        }

        [Test]
        public void ManaFieldAddThreeParticlesInMotion()
        {
            //arrange
            ManaField mainField = new ManaField();
            int count = 0;
            List<ManaParticle> testparticles;
            ManaParticle newParticle = new ManaParticle(0, 0, 0, 1, 1, 1);
            mainField.AddParticle(newParticle);
            newParticle = new ManaParticle(1, 0, 0, 1, 1, 1);
            mainField.AddParticle(newParticle);
            newParticle = new ManaParticle(2, 0, 0, 1, 1, 1);
            mainField.AddParticle(newParticle);

            testparticles = mainField.GetParticleList();

            //assert
            Assert.AreEqual(3, testparticles.Count);
            foreach (ManaParticle particle in testparticles)
            {
                Assert.AreEqual(particle.xLoc, count);
                Assert.AreEqual(particle.xSpeed, 1);
                count++;
            }
        }

        [Test]
        public void ManaFieldAddThreeTypedParticlesInMotion()
        {
            //arrange
            ManaField mainField = new ManaField();
            int count = 0;
            List<ManaParticle> testparticles;
            ManaParticle newParticle = new ManaParticle(0, 0, 0, 1, 1, 1, ManaConstants.Energy.Heat, 100);
            mainField.AddParticle(newParticle);
            newParticle = new ManaParticle(1, 0, 0, 1, 1, 1);
            mainField.AddParticle(newParticle);
            newParticle = new ManaParticle(2, 0, 0, 1, 1, 1);
            mainField.AddParticle(newParticle);

            testparticles = mainField.GetParticleList();

            //assert
            Assert.AreEqual(3, testparticles.Count);
            foreach (ManaParticle particle in testparticles)
            {
                Assert.AreEqual(particle.xLoc, count);
                Assert.AreEqual(particle.xSpeed, 1);
                count++;
            }
            Assert.AreEqual(ManaConstants.Energy.Heat, testparticles[0].type);
            Assert.AreEqual(100, testparticles[0].power);
        }

        [Test]
        public void ManaFieldAddListofMovingParticles()
        {
            //arrange
            ManaField mainField = new ManaField();
            int count = 0;
            List<ManaParticle> testparticles = new List<ManaParticle>();
            for (int i = 0; i < 50; i++)
            {
                ManaParticle newParticle = new ManaParticle(i, 0, 0, 0, i, 0);
                testparticles.Add(newParticle);
            }

            mainField.AddParticle(testparticles);
            testparticles = mainField.GetParticleList();

            //assert
            Assert.AreEqual(50, testparticles.Count);
            foreach (ManaParticle particle in testparticles)
            {
                Assert.AreEqual(particle.xLoc, count);
                Assert.AreEqual(particle.ySpeed, count);
                count++;
            }
        }

        [Test]
        public void ManaFieldAddNullListParticles()
        {
            //arrange
            ManaField mainField = new ManaField();
            List<ManaParticle> testparticles = null;

            mainField.AddParticle(testparticles);

            //assert
        }

        [Test]
        public void ManaFieldAddNullParticle()
        {
            //arrange
            ManaField mainField = new ManaField();
            ManaParticle testparticle = null;

            mainField.AddParticle(testparticle);

            //assert
        }*/
    }
}
