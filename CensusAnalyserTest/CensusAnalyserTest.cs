using CensusAnalyser;
using  CensusAnalyser.POCO;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using static CensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class CensusAnalyserTest
    { 
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath= @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\WrongIndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\IndiaData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\IndiaStateCensusData.txt";
        static string indianStateCodeFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\IndiaStateCode.txt";
        static string delimiterIndianStateCodeFilePath= @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\DelimiterIndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\WrongIndiaStateCode.csv";

        //US Census FilePath
        static string usCensusHeaders = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";
        static string usCensusFilepath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USCensusData.csv";
        static string wrongUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USData.csv";
        static string wrongUSCensusFileType = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USCensusData.txt";
        static string wrongHeaderUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\WrongHeaderUSCensusData.csv";
        static string delimeterUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\DelimiterUSCensusData.csv";
        
        CensusAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord= censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }

        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            var stateException= Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }

        [Test]
        public void GivenIndianStateCodeDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }

        [Test]
        public void GivenWrongIndianStateCodeDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, ex.eType);
        }

        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenReaded_ShouldReturnCustomException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, ex.eType);
        }

        [Test]
        public void GivenIndianStateCodeDataFile_WhenNotProper_ShouldReturnException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, ex.eType);
        }

        [Test]
        public void givenIndianStateCodeDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, ex.eType);
        }

        [Test]
        public void GivenIndianStateCensusFile_WhenProper_ShouldReturnSortedData()
        {
            string sortedData=censusAnalyser.GetSortedStateCodeDataInJsonFormat(Country.INDIA,indianStateCensusFilePath,indianStateCensusHeaders,"state", SortOrder.SortBy.ASC).ToString();
            CensusDataDAO[] sortedIndianData = JsonConvert.DeserializeObject<CensusDataDAO[]>(sortedData);
            Assert.AreEqual("Andhra Pradesh", sortedIndianData[0].state);
        }

        [Test]
        public void GivenIndianStateCensusFile_WhenSorted_ShouldReturnLastSortedData()
        {
            string sortedData = censusAnalyser.GetSortedStateCodeDataInJsonFormat(Country.INDIA, indianStateCensusFilePath,indianStateCensusHeaders, "state", SortOrder.SortBy.ASC).ToString();
            CensusDataDAO[] sortedIndianData = JsonConvert.DeserializeObject<CensusDataDAO[]>(sortedData);
            Assert.AreEqual("West Bengal", sortedIndianData[28].state);
        }

        [Test]
        public void GivenIndianStateCodeFile_WhenProper_ShouldReturnSortedData()
        {
            string sortedData = censusAnalyser.GetSortedStateCodeDataInJsonFormat(Country.INDIA, indianStateCodeFilePath,indianStateCodeHeaders, "stateCode", SortOrder.SortBy.ASC).ToString();
            StateCodeDAO[] sortedIndianData = JsonConvert.DeserializeObject<StateCodeDAO[]>(sortedData);
            Assert.AreEqual("AD", sortedIndianData[0].stateCode);
        }

        [Test]
        public void GivenIndianStateCodeFile_WhenSorted_ShouldReturnLastSortedData()
        {
            string sortedData = censusAnalyser.GetSortedStateCodeDataInJsonFormat(Country.INDIA, indianStateCodeFilePath,indianStateCodeHeaders, "stateCode",SortOrder.SortBy.ASC).ToString();
            StateCodeDAO[] sortedIndianData = JsonConvert.DeserializeObject<StateCodeDAO[]>(sortedData);
            Assert.AreEqual("WB", sortedIndianData[36].stateCode);
        }

        [Test]
        public void GivenIndianStateCensusFile_WhenProper_ShouldReturnMostPopulousState()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = new CensusAnalyser.CensusAnalyser();
            string sortedData = censusAnalyser.GetSortedStateCodeDataInJsonFormat(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders, "population", SortOrder.SortBy.DESC).ToString();
            CensusDataDAO[] sortedIndianData = JsonConvert.DeserializeObject<CensusDataDAO[]>(sortedData);
            Assert.AreEqual("Uttar Pradesh", sortedIndianData[0].state);
        }

        [Test]
        public void GivenWrongIndianStateCensusFile_WhenNotProper_ShouldReturnFileNotFound()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = new CensusAnalyser.CensusAnalyser();
            var sortedData = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.GetSortedStateCodeDataInJsonFormat(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders, "population", SortOrder.SortBy.DESC).ToString());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, sortedData.eType);
        }

        [Test]
        public void GivenWrongIndianStateCensusHeaderFile_WhenNotProper_ShouldReturnHeaderException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = new CensusAnalyser.CensusAnalyser();
            var sortedData = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.GetSortedStateCodeDataInJsonFormat(Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders, "population", SortOrder.SortBy.DESC).ToString());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, sortedData.eType);
        }

        [Test]
        public void GivenIndianStateCensusFile_WhenProper_ShouldReturnMostDensityState()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = new CensusAnalyser.CensusAnalyser();
            string sortedData = censusAnalyser.GetSortedStateCodeDataInJsonFormat(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders, "density", SortOrder.SortBy.DESC).ToString();
            CensusDataDAO[] sortedIndianData = JsonConvert.DeserializeObject<CensusDataDAO[]>(sortedData);
            Assert.AreEqual("Bihar", sortedIndianData[0].state);
        }

        [Test]
        public void GivenIndianStateCensusFile_WhenProper_ShouldReturnMostLargeAreaState()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = new CensusAnalyser.CensusAnalyser();
            string sortedData = censusAnalyser.GetSortedStateCodeDataInJsonFormat(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders, "area", SortOrder.SortBy.DESC).ToString();
            CensusDataDAO[] sortedIndianData = JsonConvert.DeserializeObject<CensusDataDAO[]>(sortedData);
            Assert.AreEqual("Rajasthan", sortedIndianData[0].state);
        }

        [Test]
        public void GivenUSCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.US, usCensusFilepath, usCensusHeaders);
            Assert.AreEqual(51, stateRecord.Count);
        }

        [Test]
        public void GivenWrongUSCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.US, wrongUSCensusFilePath, usCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, ex.eType);
        }

        [Test]
        public void GivenWrongUsCensusFileType_WhenReaded_ShouldReturnCustomException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.US, wrongUSCensusFileType, usCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, ex.eType);
        }

        [Test]
        public void GivenUSCensusDataFile_WhenNotProper_ShouldReturnException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.US, delimeterUSCensusFilePath, usCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, ex.eType);
        }

        [Test]
        public void GivenUSCensusDataFile_WhenHeaderNotProper_ShouldReturnException()
        { 
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.US, wrongHeaderUSCensusFilePath, usCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, ex.eType);
        }

        [Test]
        public void GivenUSCensusDataFile_WhenCountryNotProper_ShouldReturnException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.BRAZIL, wrongHeaderUSCensusFilePath, usCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY, ex.eType);
        }

        [Test]
        public void GivenUSCensusFile_WhenProper_ShouldReturnMostPopulousState()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = new CensusAnalyser.CensusAnalyser();
            string sortedData = censusAnalyser.GetSortedStateCodeDataInJsonFormat(Country.US, usCensusFilepath, usCensusHeaders, "population", SortOrder.SortBy.DESC).ToString();
            USCensusDAO[] sortedIndianData = JsonConvert.DeserializeObject<USCensusDAO[]>(sortedData);
            Assert.AreEqual("California", sortedIndianData[0].stateName);
        }
    }
}