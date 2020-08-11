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

        CSVFactory csvFactory;
        CSVData csvData;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            csvFactory = new CSVFactory();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void givenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser=(CensusAnalyser.CensusAnalyser)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyser.loadCensusData);
            totalRecord= (Dictionary<string,CensusDTO>)csvData(indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = (Dictionary<string, CensusDTO>)csvData(indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }

        [Test]
        public void givenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyser.loadCensusData);
            var censusException = Assert.Throws<CensusAnalyserException>(() => csvData(wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            var stateException= Assert.Throws<CensusAnalyserException>(() => csvData(wrongIndianStateCensusFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        [Test]
        public void givenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyser.loadCensusData);
            var censusException = Assert.Throws<CensusAnalyserException>(() => csvData(wrongIndianStateCensusFileType, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => csvData(wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }

        [Test]
        public void givenIndianCensusDataFile_WhenNotProper_ShouldReturnException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyser.loadCensusData);
            var censusException = Assert.Throws<CensusAnalyserException>(() => csvData(delimiterIndianCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => csvData(delimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }

        [Test]
        public void givenIndianCensusDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyser.loadCensusData);
            var censusException = Assert.Throws<CensusAnalyserException>(() => csvData(wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => csvData(wrongHeaderStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }

        [Test]
        public void givenIndianStateCodeDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyser.loadCensusData);
            stateRecord = (Dictionary<string,CensusDTO>)csvData(indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }

        [Test]
        public void givenWrongIndianStateCodeDataFile_WhenReaded_ShouldReturnCustomException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyser.loadCensusData);
            var ex = Assert.Throws<CensusAnalyserException>(() => csvData(wrongIndianStateCensusFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, ex.eType);
        }

        [Test]
        public void givenWrongIndianStateCodeFileType_WhenReaded_ShouldReturnCustomException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyser.loadCensusData);
            var ex = Assert.Throws<CensusAnalyserException>(() => csvData(wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, ex.eType);
        }

        [Test]
        public void givenIndianStateCodeDataFile_WhenNotProper_ShouldReturnException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyser.loadCensusData);
            var ex = Assert.Throws<CensusAnalyserException>(() => csvData(delimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, ex.eType);
        }

        [Test]
        public void givenIndianStateCodeDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyser.loadCensusData);
            var ex = Assert.Throws<CensusAnalyserException>(() => csvData(wrongHeaderStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, ex.eType);
        }

        [Test]
        public void givenIndianStateCensusFile_WhenProper_ShouldReturnSortedData()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = new CensusAnalyser.CensusAnalyser();
            string sortedData=censusAnalyser.getSortedStateCodeDataInJsonFormat(indianStateCensusFilePath,indianStateCensusHeaders,"state", SortOrder.SortBy.ASC).ToString();
            CensusDataDAO[] sortedIndianData = JsonConvert.DeserializeObject<CensusDataDAO[]>(sortedData);
            Assert.AreEqual("Andhra Pradesh", sortedIndianData[0].state);
        }

        [Test]
        public void givenIndianStateCensusFile_WhenSorted_ShouldReturnLastSortedData()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = new CensusAnalyser.CensusAnalyser();
            string sortedData = censusAnalyser.getSortedStateCodeDataInJsonFormat(indianStateCensusFilePath,indianStateCensusHeaders, "state", SortOrder.SortBy.ASC).ToString();
            CensusDataDAO[] sortedIndianData = JsonConvert.DeserializeObject<CensusDataDAO[]>(sortedData);
            Assert.AreEqual("West Bengal", sortedIndianData[28].state);
        }

        [Test]
        public void givenIndianStateCodeFile_WhenProper_ShouldReturnSortedData()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = new CensusAnalyser.CensusAnalyser();
            string sortedData = censusAnalyser.getSortedStateCodeDataInJsonFormat(indianStateCodeFilePath,indianStateCodeHeaders, "stateCode", SortOrder.SortBy.ASC).ToString();
            StateCodeDAO[] sortedIndianData = JsonConvert.DeserializeObject<StateCodeDAO[]>(sortedData);
            Assert.AreEqual("AD", sortedIndianData[0].stateCode);
        }

        [Test]
        public void givenIndianStateCodeFile_WhenSorted_ShouldReturnLastSortedData()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = new CensusAnalyser.CensusAnalyser();
            string sortedData = censusAnalyser.getSortedStateCodeDataInJsonFormat(indianStateCodeFilePath,indianStateCodeHeaders, "stateCode",SortOrder.SortBy.ASC).ToString();
            StateCodeDAO[] sortedIndianData = JsonConvert.DeserializeObject<StateCodeDAO[]>(sortedData);
            Assert.AreEqual("WB", sortedIndianData[36].stateCode);
        }

        [Test]
        public void givenIndianStateCensusFile_WhenProper_ShouldReturnMostPopulousState()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = new CensusAnalyser.CensusAnalyser();
            string sortedData = censusAnalyser.getSortedStateCodeDataInJsonFormat(indianStateCensusFilePath, indianStateCensusHeaders, "population", SortOrder.SortBy.DESC).ToString();
            CensusDataDAO[] sortedIndianData = JsonConvert.DeserializeObject<CensusDataDAO[]>(sortedData);
            Assert.AreEqual("Uttar Pradesh", sortedIndianData[0].state);
        }

        [Test]
        public void givenWrongIndianStateCensusFile_WhenNotProper_ShouldReturnFileNotFound()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = new CensusAnalyser.CensusAnalyser();
            var sortedData = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.getSortedStateCodeDataInJsonFormat(wrongIndianStateCensusFilePath, indianStateCensusHeaders, "population", SortOrder.SortBy.DESC).ToString());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, sortedData.eType);
        }

        [Test]
        public void givenWrongIndianStateCensusHeaderFile_WhenNotProper_ShouldReturnHeaderException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = new CensusAnalyser.CensusAnalyser();
            var sortedData = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.getSortedStateCodeDataInJsonFormat(wrongHeaderIndianCensusFilePath, indianStateCensusHeaders, "population", SortOrder.SortBy.DESC).ToString());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, sortedData.eType);
        }

        [Test]
        public void givenIndianStateCensusFile_WhenProper_ShouldReturnMostDensityState()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = new CensusAnalyser.CensusAnalyser();
            string sortedData = censusAnalyser.getSortedStateCodeDataInJsonFormat(indianStateCensusFilePath, indianStateCensusHeaders, "density", SortOrder.SortBy.DESC).ToString();
            CensusDataDAO[] sortedIndianData = JsonConvert.DeserializeObject<CensusDataDAO[]>(sortedData);
            Assert.AreEqual("Bihar", sortedIndianData[0].state);
        }

        [Test]
        public void givenIndianStateCensusFile_WhenProper_ShouldReturnMostLargeAreaState()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = new CensusAnalyser.CensusAnalyser();
            string sortedData = censusAnalyser.getSortedStateCodeDataInJsonFormat(indianStateCensusFilePath, indianStateCensusHeaders, "area", SortOrder.SortBy.DESC).ToString();
            CensusDataDAO[] sortedIndianData = JsonConvert.DeserializeObject<CensusDataDAO[]>(sortedData);
            Assert.AreEqual("Rajasthan", sortedIndianData[0].state);
        }
    }
}