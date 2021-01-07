using System;
using NUnit.Framework;
using Project.DataAccess.Context;
using Project.DataAccess.Models;

namespace Project.DataAccess.Tests.ContextTests
{
    [TestFixture]
    public class AddEntityTest
    {
        [Test]
        public void Add_Document_Test()
        {
            var context = new UDataBaseContext();
            var toAdd = new Document
            {
                InventoryName = "Stol",
                DurationOfUse = 2,
                DateUsedFrom = DateTime.Now,
                Reason = "I want it"
            };
            context.Documents.Add(toAdd);
            context.SaveChanges();
        }
    }
}