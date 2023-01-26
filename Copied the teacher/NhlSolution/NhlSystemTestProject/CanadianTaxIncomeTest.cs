using NhlSystemClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystemTestProject
{
    [TestClass]
    public class CanadianTaxIncomeTest
    {
        [TestMethod]
        [DataRow(@"..\..\..\Data\CanadianPersonalIncomeTaxRates.csv", 439)]

        public void LoadFromCsvFile_RowCount_CorrectCount(string csvFilePath, int expectedCount)//highlight this, right click, click Run Tests
        {
            var dataManager = new CanadianTaxIncomeManager();
            List<string> allLinesFromFile = dataManager.LoadFromCsvFile(csvFilePath);

            Assert.AreEqual(439, allLinesFromFile.Count); //We simply open the file from the downloads folder and count the lines. 
        }

        [TestMethod]
        [DataRow(@"..\..\..\Data\CanadianPersonalIncomeTaxRates.csv", 439)]
        public void ConvertToCanadianIncomeTax_CorrectConversion_ExpectedResults(string csvFilePath, int expectedCount)
        {
            var dataManager = new CanadianTaxIncomeManager();
            List<string> allLinesFromFile = dataManager.LoadFromCsvFile(csvFilePath);

            List<CanadianIncomeTaxData> incomeTaxData = dataManager.ConvertToCanadianIncomeTax(allLinesFromFile);

            Assert.AreEqual(expectedCount, allLinesFromFile.Count); //We simply open the file from the downloads folder and count the lines. 

            int firstIndex = 0;
            int lastIndex = incomeTaxData.Count - 1;

            Assert.AreEqual("CAN", incomeTaxData[lastIndex], RegionAbbreviation);
        }
    }
}