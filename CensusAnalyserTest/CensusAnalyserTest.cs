using CensusAnalyser;
using NUnit.Framework;

namespace CensusAnalyserTest
{
    public class CensusAnalyserTest
    {
        static string indianStateCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\IndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\IndiaData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\Dell\source\repos\CensusAnalyser\IndiaStateCensusData.pdf";
        static string indianStateCodeFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\Dell\source\repos\CensusAnalyser\IndiaStateCode.pdf";

        CensusAnalyser.CensusAnalyser censusAnalyser;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser.CensusAnalyser();
        }

        [Test]
        public void givenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            int totalRecord = censusAnalyser.loadIndiaStateCensusData(indianStateCensusFilePath);
            Assert.AreEqual(29, totalRecord);
        }

        [Test]
        public void givenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            try
            {
                int totalRecord = censusAnalyser.loadIndiaStateCensusData(wrongIndianStateCensusFilePath);
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
                int totalRecord = censusAnalyser.loadIndiaStateCensusData(wrongIndianStateCensusFileType);
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
                int totalRecord = censusAnalyser.loadIndiaStateCensusData(indianStateCensusFilePath);
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
                int totalRecord = censusAnalyser.loadIndiaStateCensusData(indianStateCensusFilePath);
            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, ce.eType);
            }
        }

        [Test]
        public void givenIndianStateCodeDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            int totalRecord = censusAnalyser.loadIndiaStateCodeData(indianStateCodeFilePath);
            Assert.AreEqual(37, totalRecord);
        }

        [Test]
        public void givenWrongIndianStateCodeDataFile_WhenReaded_ShouldReturnCustomException()
        {
            try
            {
                int totalRecord = censusAnalyser.loadIndiaStateCodeData(wrongIndianStateCensusFilePath);
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
                int totalRecord = censusAnalyser.loadIndiaStateCodeData(wrongIndianStateCodeFileType);
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
                int totalRecord = censusAnalyser.loadIndiaStateCodeData(indianStateCodeFilePath);
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
                int totalRecord = censusAnalyser.loadIndiaStateCodeData(indianStateCodeFilePath);
            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, ce.eType);
            }
        }
    }
}