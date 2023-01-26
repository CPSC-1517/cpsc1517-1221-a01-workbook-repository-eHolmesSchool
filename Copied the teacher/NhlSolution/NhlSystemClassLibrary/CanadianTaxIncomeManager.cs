using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystemClassLibrary
{
    public class CanadianTaxIncomeManager
    {

        public List<CanadianIncomeTaxData> ConvertToCanadianIncomeTax(List<string> lines)
        {
            List<CanadianIncomeTaxData> dataList = new List<CanadianIncomeTaxData>();
            //Iterate through each element in the list
            foreach (string currentLine in lines)
            {
                string[] tokens = currentLine.Split(',');
                CanadianIncomeTaxData data = new CanadianIncomeTaxData();
                data.RegionAbbreviation = tokens[0];
                data.RegionName = tokens[1];
                data.TaxYear = int.Parse(tokens[2]);
                data.StartingIncome = decimal.Parse( tokens[4]);
                data.EndingIncome = decimal.Parse(tokens[5]);
                data.TaxRate = double.Parse(tokens[6]);
                data.BaseTaxAmount = decimal.Parse(tokens[7]);

                dataList.Add(data);

            }
            return dataList;
        }

        public List<string> LoadFromCsvFile(string csvFilePath)
        {
            List<string> allLines = new List<string>();
            //using (StreamReader reader = new StreamReader(csvFilePath))
            //{
            //    string currentLine;
            //    // Read and display lines from the file until the end of
            //    // the file is reached.
            //    while ((currentLine = reader.ReadLine()) != null)
            //    {
            //        Console.WriteLine(currentLine);
            //    }

            //}

            string[] lineArray = File.ReadAllLines(csvFilePath);

            //foreach (string currentLine in lineArray)
            //{
            //    allLines.Add(currentLine);
            //}

            for (int index = 1; index < lineArray.Length; index++)
            {
                allLines.Add((string)lineArray[index]);
            }

            return allLines;
        }
    }
}
