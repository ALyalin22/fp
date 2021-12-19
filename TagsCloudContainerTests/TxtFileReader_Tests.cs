﻿using System.IO;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudContainer.FileReaders;

namespace TagsCloudContainerTests
{
    public class TxtFileReader_Tests
    {
        private TxtFileReader txtFileReader;
        private const string FileName = "TxtTestFile.txt";
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            txtFileReader = new TxtFileReader();
            File.WriteAllText(FileName, "firstWord\nsecondWord\nthirdWord");
        }
        
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            File.Delete(FileName);
        }
        
        [Test]
        public void ReadWordsFromFile_ReturnsFailResult_WhenFileDoesNotExist()
        {
            var result = txtFileReader.ReadWordsFromFile("fakeFile");
            
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("File doesn't exist fakeFile");
        }
        
        [Test]
        public void ReadWordsFromFile_WorksCorrectlyWithTxt()
        {
            var expectedWords = new[] { "firstWord", "secondWord", "thirdWord" };
            
            var words = txtFileReader.ReadWordsFromFile(FileName).GetValueOrThrow();

            words.Should().BeEquivalentTo(expectedWords);
        }
    }
}