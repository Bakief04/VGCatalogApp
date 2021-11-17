using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using VGCatalogApp.Models;

namespace VGCatalogTest
{
    [TestClass]
    public class VGSystemTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConsoleNullOrEmpty_UsingAttributes()
        {
             VGSystem fp = new VGSystem();

            fp.FileExists("");
        }
    }
}
