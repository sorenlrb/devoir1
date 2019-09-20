using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelObjet;

namespace ProjetDeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        public void ValiderTest()
        {
            // Le nombre de jours d'achat est < à 30 jours
            Assert.AreEqual(true, Condition.Valider(12));
            

            // Le nombre de jours d'achat est > à 30 jours
            Assert.AreEqual(false, Condition.Valider(35));
        }

        [TestMethod()]
        public void CalculerMontantMaxTest()
        {
            // Pour la catégorie livre
            Assert.AreEqual(30, Condition.CalculerMontantMax("Livres"));

            // Pour la catégorie jouet
            Assert.AreEqual(50, Condition.CalculerMontantMax("Jouets"));

            // Pour la catégorie informatique
            Assert.AreEqual(1000, Condition.CalculerMontantMax("Informatique"));
        }

        [TestMethod()]
        public void CalculerMontantRembourseTest()
        {
            // Un livre achété 24 euros depuis 15 jours avec un état "Très abimé" en étant non membre
            Assert.AreEqual(12, Condition.CalculerMontantRembourse(15, "Livres", false, "Très abimé", 24));
            // Un livre achété 24 euros depuis 15 jours avec un état "Bon" en étant membre
            Assert.AreEqual(21.6, Condition.CalculerMontantRembourse(15, "Livres", true, "Bon", 24));
        }

        [TestMethod()]
        public void CalculerReductionMembreTest()
        {

            // Il est membre
            Assert.AreEqual(0, Condition.CalculerReductionMembre(true));

            // Il n'est pas membre
            Assert.AreEqual(0.2, Condition.CalculerReductionMembre(false));
        }

        [TestMethod()]
        public void CalculerReductionTest()
        {
        // Pour un état "bon"
        Assert.AreEqual(0.1, Condition.CalculerReduction("bon"));

        // Pour un état "abimé"
        Assert.AreEqual(0.3, Condition.CalculerReduction("Abimé"));
        Assert.AreEqual(0.3, Condition.CalculerReduction("Très abimé"));

        }
    }
}
