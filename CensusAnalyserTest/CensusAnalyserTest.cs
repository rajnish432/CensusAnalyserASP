using CensusAnalyser;
using NUnit.Framework;

namespace CensusAnalyserTest
{
    public class CensusAnalyserTest
    {
        static string indianStateCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\IndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\IndiaData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\Dell\source\repos\CensusAnalyser\IndiaStateCensusData.pdf";

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
    }
}