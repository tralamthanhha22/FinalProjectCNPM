using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEFinalProject_Winform;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void checkCreateImportID()
        {
            String importID = "";
            frmMainForm frm = new frmMainForm();
            Assert.IsNotNull(frm);

        }
    }
}
