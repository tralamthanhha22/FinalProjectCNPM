using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEFinalProject_Winform;
using SEFinalProject_WinformTests;



namespace SEFinalProject_WinformTests
{
    [TestClass]
    public class UnitTestWinform
    {
        [TestMethod]
        public void checkImportForm()
        {
            String importID = new frmNhapHang("AC001").createImportID();
            //importID = frmNhapHangTest.createImportID();
            Console.WriteLine(importID);
            Assert.AreEqual("I0013", importID);
        }
    }
}
