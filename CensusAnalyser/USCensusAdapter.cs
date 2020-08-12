using CensusAnalyser.POCO;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyser
{
    public class USCensusAdapter:CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadUSCensusData(string csvFilePath, string dataHeaders)
        {
            censusData = GetCensusData(csvFilePath, dataHeaders);
            dataMap = new Dictionary<string, CensusDTO>();
            foreach (string data in censusData.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File Contains Wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
                string[] column = data.Split(",");
                dataMap.Add(column[1], new CensusDTO(new USCensusDAO(column[0], column[1], column[2], column[3], column[4], column[5], column[6], column[7], column[8])));
            }
            return dataMap.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
