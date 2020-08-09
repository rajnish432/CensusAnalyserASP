using System;
using System.IO;
using System.Linq;

namespace CensusAnalyser
{
    public class CensusAnalyser
    {
        public delegate object CSVData();
        string csvFilePath;
        string dataHeaders;

        public CensusAnalyser(string csvFilePath, string dataHeaders)
        {
            this.csvFilePath = csvFilePath;
            this.dataHeaders = dataHeaders;
        }

        public object loadCensusData()
        {
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            string[] censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyserException("Incorrect header in Data", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            foreach (string data in censusData)
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File Contains Wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
            }
            return censusData.Skip(1).ToArray();
        }
    }
}