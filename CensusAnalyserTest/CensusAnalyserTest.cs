using CensusAnalyser;
using NUnit.Framework;

namespace CensusAnalyserTest
{
    public class CensusAnalyserTest
    { 
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CsvFiles\IndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CsvFiles\IndiaData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\Dell\source\repos\CensusAnalyser\CsvFiles\IndiaStateCensusData.txt";
        static string indianStateCodeFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CsvFiles\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\Dell\source\repos\CensusAnalyser\CsvFiles\IndiaStateCode.txt";

        CensusAnalyser.CensusAnalyser censusAnalyser;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser.CensusAnalyser();
        }

        [Test]
        public void givenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            string[] totalRecord= censusAnalyser.loadCensusData(indianStateCensusFilePath,indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Length);
        }

        [Test]
        public void givenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            try
            {
                 censusAnalyser.loadCensusData(wrongIndianStateCensusFilePath,indianStateCensusHeaders);
            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, ce.eType);
            }
        }

        [Test]
        public void givenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            try
            {
                censusAnalyser.loadCensusData(wrongIndianStateCensusFileType,indianStateCensusHeaders);
            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, ce.eType);
            }
        }

        [Test]
        public void givenIndianCensusDataFile_WhenNotProper_ShouldReturnException()
        {
            try
            {
                censusAnalyser.loadCensusData(indianStateCensusFilePath,indianStateCensusHeaders);
            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, ce.eType);
            }
        }

        [Test]
        public void givenIndianCensusDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            try
            {
                censusAnalyser.loadCensusData(indianStateCensusFilePath,indianStateCensusHeaders);
            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, ce.eType);
            }
        }

        [Test]
        public void givenIndianStateCodeDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            string[] totalRecord = censusAnalyser.loadCensusData(indianStateCodeFilePath,indianStateCodeHeaders);
            Assert.AreEqual(37, totalRecord.Length);
        }

        [Test]
        public void givenWrongIndianStateCodeDataFile_WhenReaded_ShouldReturnCustomException()
        {
            try
            {
                censusAnalyser.loadCensusData(wrongIndianStateCensusFilePath,indianStateCodeHeaders);
            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, ce.eType);
            }
        }

        [Test]
        public void givenWrongIndianStateCodeFileType_WhenReaded_ShouldReturnCustomException()
        {
            try
            {
                censusAnalyser.loadCensusData(wrongIndianStateCodeFileType,indianStateCodeHeaders);
            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, ce.eType);
            }
        }

        [Test]
        public void givenIndianStateCodeDataFile_WhenNotProper_ShouldReturnException()
        {
            try
            {
                censusAnalyser.loadCensusData(indianStateCodeFilePath,indianStateCodeHeaders);
            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, ce.eType);
            }
        }

        [Test]
        public void givenIndianStateCodeDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            try
            {
                censusAnalyser.loadCensusData(indianStateCodeFilePath,indianStateCodeHeaders);
            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, ce.eType);
            }
        }
    }
}