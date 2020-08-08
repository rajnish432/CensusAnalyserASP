using System;
using System.IO;

namespace CensusAnalyser
{
    public class CensusAnalyser
    {
        public int loadIndiaStateCensusData(string csvFilePath)
        {
            if (!csvFilePath.Contains("IndiaStateCensusData"))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (!csvFilePath.Contains(".csv"))
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            string[] censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != "State,Population,AreaInSqKm,DensityPerSqKm")
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
            return censusData.Length - 1;
        }
    }
}