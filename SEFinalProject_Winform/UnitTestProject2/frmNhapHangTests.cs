using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEFinalProject_Winform;
using System;

namespace UnitTestProject2
{
    [TestClass()]
    public class frmNhapHangTests
    {
        [TestMethod()]
        public void createImportIDTest()
        {
            String importID = null;
            frmNhapHang frmNhapHang = new frmNhapHang();
            importID = frmNhapHang.createImportID();
            Assert.IsNotNull(importID);
        }
    }
}