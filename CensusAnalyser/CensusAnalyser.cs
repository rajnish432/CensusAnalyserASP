using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CensusAnalyser.POCO;
using Newtonsoft.Json;

namespace CensusAnalyser
{
    public class CensusAnalyser: ICSVBuilder
    {
        string[] censusData;
        Dictionary<string, CensusDTO> dataMap;
        public delegate object CSVData(string csvFilePath,string dataHeaders);

        public object loadCensusData(string csvFilePath,string dataHeaders)
        {
            dataMap = new Dictionary<string, CensusDTO>();
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
            foreach (string data in censusData.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File Contains Wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
                string[] column = data.Split(",");
                if (csvFilePath.Contains("IndiaStateCode.csv"))
                    dataMap.Add(column[1], new CensusDTO(new StateCodeDAO(column[0], column[1], column[2], column[3])));
                if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                    dataMap.Add(column[0], new CensusDTO(new CensusDataDAO(column[0], column[1], column[2], column[3])));
            }
            return dataMap.ToDictionary (p => p.Key, p => p.Value);
        }

        public object getSortedStateCodeDataInJsonFormat(string csvFilePath,string dataheaders,string sortField,SortOrder.SortBy sortBy)
        {
            var censusData = (Dictionary<string, CensusDTO>)loadCensusData(csvFilePath, dataheaders);
            List<CensusDTO> lines = censusData.Values.ToList();
            List<CensusDTO> lists = getDataSorted (sortField,lines);
            if(sortBy.Equals(SortOrder.SortBy.DESC))
                lists.Reverse();
            return JsonConvert.SerializeObject(lists);
        }

        public List<CensusDTO> getDataSorted(string sortfield,List<CensusDTO> lines) 
        {
            switch (sortfield)
            {
                case "stateName": return lines.OrderBy(x => x.stateName).ToList();
                case "stateCode": return lines.OrderBy(x => x.stateCode).ToList();
                case "state": return lines.OrderBy(x => x.state).ToList();
                case "area": return lines.OrderBy(x => x.area).ToList();
                case "density": return lines.OrderBy(x => x.density).ToList();
                case "population": return lines.OrderBy(x => x.population).ToList();
                default: return lines.OrderBy(x => x.tin).ToList();
            }    
        }

        public object loadUSCensusData(string csvFilePath, string dataHeaders)
        {
            dataMap = new Dictionary<string, CensusDTO>();
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            censusData = File.ReadAllLines(csvFilePath);
            foreach (string data in censusData.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File Contains Wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
                string[] column = data.Split(",");
                dataMap.Add(column[1], new CensusDTO(new USCensusDAO(column[0], column[1], column[2], column[3],column[4],column[5],column[6],column[7],column[8])));
            }
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyserException("Incorrect header in Data", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            return dataMap.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}