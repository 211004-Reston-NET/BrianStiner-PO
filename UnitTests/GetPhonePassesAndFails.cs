using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Models;
 
namespace UnitTests
 {
    [TestClass]
    class GetPhonePassesAndFails
        {
            public void tester(string[] args)
            {
                Console.WriteLine("What's your name?");
                var name = Console.ReadLine();
                Console.WriteLine(string.Format("Hello {0}!!", name));
            }

            [TestMethod]
            public void TestPhone()
            {
                var output = new StringWriter();
                Console.SetOut(output);

                var input = new StringReader("Somebody");
                Console.SetIn(input);

                this.tester(new string[] { });

                Assert.AreEqual("What's your name?", output.ToString().Trim());
                Assert.AreEqual("Hello Somebody!!", output.ToString().Trim());
                
            }
        }
 }