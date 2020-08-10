using CensusAnalyser;
using NUnit.Framework;
using System.Collections.Generic;
using static CensusAnalyser.CensusAnalyser;

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
        
        CSVFactory csvFactory;
        CSVData csvData;
        List<string> totalRecord;

        [SetUp]
        public void Setup()
        {
            csvFactory = new CSVFactory();
            totalRecord = new List<string>();
        }

        [Test]
        public void givenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser=(CensusAnalyser.CensusAnalyser)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyser.loadCensusData);
            totalRecord= (List<string>)csvData(indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        [Test]
        public void givenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyser.loadCensusData);
            var ex = Assert.Throws<CensusAnalyserException>(() => csvData(wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, ex.eType);
        }

        [Test]
        public void givenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyser.loadCensusData);
            var ex = Assert.Throws<CensusAnalyserException>(() => csvData(wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, ex.eType);
        }

        [Test]
        public void givenIndianCensusDataFile_WhenNotProper_ShouldReturnException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyser.loadCensusData);
            var ex = Assert.Throws<CensusAnalyserException>(() => csvData(delimiterIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, ex.eType);
        }

        [Test]
        public void givenIndianCensusDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyser.loadCensusData);
            var ex = Assert.Throws<CensusAnalyserException>(() => csvData(wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, ex.eType);
        }

        [Test]
        public void givenIndianStateCodeDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            CensusAnalyser.CensusAnalyser censusAnalyser = (CensusAnalyser.CensusAnalyser)csvFactory.getClassObject();
            csvData = new CSVData(censusAnalyser.loadCensusData);
            totalRecord = (List<string>)csvData(indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, totalRecord.Count);
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
    }
}