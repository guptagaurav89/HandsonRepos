using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF4Concepts
{
    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public void TestMethod1()
        {
            Class1 c = new Class1();
            c.GetDepartmentDetails();

            c.GetDepartmentDetails(2);       }

    }
}
