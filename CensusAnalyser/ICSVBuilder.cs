using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public interface ICSVBuilder
    {
        object loadCensusData(string csvFilePath, string dataHeaders);
    }
}
