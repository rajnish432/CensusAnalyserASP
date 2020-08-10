using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace CensusAnalyser
{
    public class CensusAnalyser: ICSVBuilder
    {
        List<string> censusData = new List<string>();
        public delegate object CSVData(string csvFilePath,string dataHeaders);

        public object loadCensusData(string csvFilePath,string dataHeaders)
        {
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            censusData = File.ReadAllLines(csvFilePath).ToList();
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
            return censusData.Skip(1).ToList();
        }

        public object getSortedDataInJsonFormat(string csvFilePath,string destinationFilePath)
        {
            string[] lines = File.ReadAllLines(csvFilePath);
            var data = lines.Skip(1);
            var sorted =
                from line in data
                let x = line.Split(',')
                orderby x[0]
                select line;
            File.WriteAllLines(destinationFilePath, lines.Take(1).Concat(sorted.ToArray()));
            List<string> sortedData = sorted.ToList<string>();
            return JsonConvert.SerializeObject(sortedData);
        }
    }
}