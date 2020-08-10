using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace CensusAnalyser
{
    public class CensusAnalyser: ICSVBuilder
    {
        string[] censusData;
        int keyCounter = 0;
        Dictionary<int, string> censusDataMap;
        public delegate object CSVData(string csvFilePath,string dataHeaders);

        public object loadCensusData(string csvFilePath,string dataHeaders)
        {
            censusDataMap = new Dictionary<int, string>();
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyserException("Incorrect header in Data", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            foreach (string data in censusData)
            {
                keyCounter++;
                censusDataMap.Add(keyCounter, data);
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File Contains Wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
            }
            return censusDataMap.Skip(1).ToDictionary(p=>p.Key,p=>p.Value);
        }

        public object getSortedDataInJsonFormat(string csvFilePath,string dataheaders,int sortField)
        {
            Dictionary<int,string> censusData = (Dictionary<int,string>)loadCensusData(csvFilePath,dataheaders);
            string[] lines = censusData.Values.ToArray();
            var data = lines;
            var sorted =
                from line in data
                let x = line.Split(',')
                orderby x[sortField]
                select line;
            List<string> sortedData = sorted.ToList();
            return JsonConvert.SerializeObject(sortedData);
        }
    }
}