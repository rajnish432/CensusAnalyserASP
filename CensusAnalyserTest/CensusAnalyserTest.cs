using CensusAnalyser;
using NUnit.Framework;

namespace CensusAnalyserTest
{
    public class CensusAnalyserTest
    { 
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CsvFiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath= @"C:\Users\Dell\source\repos\CensusAnalyser\CsvFiles\WrongIndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CsvFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CsvFiles\IndiaData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\Dell\source\repos\CensusAnalyser\CsvFiles\IndiaStateCensusData.txt";
        static string indianStateCodeFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CsvFiles\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\Dell\source\repos\CensusAnalyser\CsvFiles\IndiaStateCode.txt";
        static string delimiterIndianStateCodeFilePath= @"C:\Users\Dell\source\repos\CensusAnalyser\CsvFiles\DelimiterIndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath= @"C:\Users\Dell\source\repos\CensusAnalyser\CsvFiles\WrongIndiaStateCode.csv";

        CensusAnalyser.CensusAnalyser censusAnalyser;
        CensusAnalyserException censusAnalyserException; 
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
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCensusData(wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, ex.eType);
        }

        [Test]
        public void givenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {  
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCensusData(wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, ex.eType);
        }

        [Test]
        public void givenIndianCensusDataFile_WhenNotProper_ShouldReturnException()
        { 
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCensusData(delimiterIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, ex.eType);
        }

        [Test]
        public void givenIndianCensusDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCensusData(wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, ex.eType);
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
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCensusData(wrongIndianStateCensusFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, ex.eType);
        }

        [Test]
        public void givenWrongIndianStateCodeFileType_WhenReaded_ShouldReturnCustomException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCensusData(wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, ex.eType);
        }

        [Test]
        public void givenIndianStateCodeDataFile_WhenNotProper_ShouldReturnException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCensusData(delimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, ex.eType);
        }

        [Test]
        public void givenIndianStateCodeDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCensusData(wrongHeaderStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, ex.eType);
        }
    }
}