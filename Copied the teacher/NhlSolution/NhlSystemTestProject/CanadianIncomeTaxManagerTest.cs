using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystemTestProject
{
    [TestClass]
    public class CanadianIncomeTaxManagerTest
    {
        [TestMethod]
        [DataRow(@"..\..\..\data\CanadianPersonalIncomeTaxRates.csv", 439)]
        public void LoadFromCsvFile_RowCount_CorrectCount(string csvFilePath, int expectedCount)
        {
            // Arrange - create an object to test
            var dataManager = new CanadianIncomeTaxManager();
            // Act - peform some task with the object
            //List<string> allLinesFromFile = dataManager.LoadFromCsvFile(
            //    @"C:\Users\swu\Downloads\CanadianPersonalIncomeTaxRates.csv");
            List<string> allLinesFromFile = dataManager.LoadFromCsvFile(csvFilePath);

            // Assert - call an Assert method
            Assert.AreEqual(expectedCount, allLinesFromFile.Count);
        }

        [TestMethod]
        [DataRow(@"..\..\..\data\CanadianPersonalIncomeTaxRates.csv", 439)]
        public void ConvertToCanadianIncomeTax_CorrectConversion_ExpectedResults(string csvFilePath, int expectedCount)
        {
            // Arrange
            var dataManager = new CanadianIncomeTaxManager();
            List<string> allLinesFromFile = dataManager.LoadFromCsvFile(csvFilePath);
            // Act
            List<CanadianIncomeTaxData> incomeTaxData = dataManager.ConvertToCanadianIncomeTax(allLinesFromFile);
            // Assert
            Assert.AreEqual(expectedCount, incomeTaxData.Count);
            // Check the content of the first element and the last element
            int firstIndex = 0;
            int lastIndex = incomeTaxData.Count - 1;
            Assert.AreEqual("CAN", incomeTaxData[firstIndex].RegionAbbreviation);
            Assert.AreEqual(2023, incomeTaxData[firstIndex].TaxYear);
            Assert.AreEqual("NU", incomeTaxData[lastIndex].RegionAbbreviation);
            Assert.AreEqual(2015, incomeTaxData[lastIndex].TaxYear);

        }

    }
}
