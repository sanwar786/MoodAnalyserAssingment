﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MoodAnalyserUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private object MoodAnalyserReflector;

        [TestMethod]
        [TestCategory("Happy Mood")]
        public void TestMethod1()
        {
            ///Follow AAA strategy
            ///Arrange, Act and in last Assert
            AnalyzeMood mood = new AnalyzeMood("I am in Happy Mood");
            string excepted = "happy";
            var actual = mood.Mood();
            Assert.AreEqual(excepted, actual);
        }
        [TestMethod]
        [TestCategory("SAD Mood")]
        public void GivenMessageShouldReturnSad()
        {
            ///Follow AAA strategy
            ///Arrange , Act and in last Assert
            AnalyzeMood mood = new AnalyzeMood("I am in SAD Mood");
            string excepted = "sad";
            var actual = mood.Mood();
            Assert.AreEqual(excepted, actual);
        }
        [TestMethod]
        [TestCategory("Null Exception")]
        public void GivenNullShouldReturnCustomException()
        {

            ///Follow AAA strategy
            ///Arrange , Act and in last Assert
            string message = null;
            string excepted = "Message cann't be null";
            try
            {
                AnalyzeMood mood = new AnalyzeMood(message);
                string actual = (string)mood.Mood();
            }
            catch (MoodAnalyserException ex)
            {
                Console.WriteLine("Custom Exception :" + ex);
                Assert.AreEqual(excepted, ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Worst Case Exception :" + ex);
            }
        }
        [TestMethod]
        [TestCategory("Empty Exception")]
        public void GivenEmptyShouldReturnCustomException()
        {
            ///Follow AAA strategy
            ///Arrange , Act and in last Assert
            string message = "";
            string excepted = "Message cann't be Empty";
            try
            {
                AnalyzeMood mood = new AnalyzeMood(message);
                string actual = (string)mood.Mood();
            }
            catch (MoodAnalyserException ex)
            {
                Console.WriteLine("Custom Exception :" + ex);
                Assert.AreEqual(excepted, ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Worst Case Exception :" + ex);
            }
        }
        /// <summary>
        /// TC-4.1 Returns the mood analyser object
        /// </summary>
        [TestMethod]
        [TestCategory("Reflection")]
        public void GivenMoodAnalyserReflection_ShouldReturnObject()
        {
            object expected = new AnalyzeMood();
            object actual = MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyser.AnalyzeMood", "AnalyzeMood");
            expected.Equals(actual);
        }
        /// <summary>
        /// TC-4.2 should throw NO_SUCH_CLASS exception.
        /// </summary>
        [TestMethod]
        [TestCategory("Reflection")]
        public void GivenClassNameImproper_ShouldReturnMoodAnalysisException()
        {
            string expected = "Class not found";
            try
            {
                object actual = MoodAnalyserReflector.MoodAnalyse("Mood.AnalyzeMood", "AnalyzeMood");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// TC-4.3 should throw NO_SUCH_CONTRUCTOR exception.
        /// </summary>
        [TestMethod]
        [TestCategory("Reflection")]
        public void GivenConstructorNameImproper_ShouldReturnMoodAnalysisException()
        {
            string expected = "Constructor not found";
            try
            {
                object actual = MoodAnalyserReflector.MoodAnalyse("MoodAnalyzer.AnalyzeMood", "MoodAnalyzer");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// TC-5.1 Returns the mood analyser object with parameterized constructor.
        /// </summary>
        [TestMethod]
        [TestCategory("Reflection")]
        public void GivenMoodAnalyserParameterizedConstructor_ShouldReturnObject()
        {
            object expected = new AnalyzeMood("I am Parameter constructor");
            object actual = MoodAnalyserReflector.CreateMoodAnalyserParameterizedConstructor("MoodAnalyzer.AnalyzeMood", "AnalyzeMood", "I am Parameter constructor");
            expected.Equals(actual);
        }
        /// <summary>
        /// TC-5.2 should throw NO_SUCH_CLASS exception with parameterized constructor.
        /// </summary>
        [TestMethod]
        [TestCategory("Reflection")]
        public void GivenClassNameImproperParameterizedConstructor_ShouldReturnMoodAnalysisException()
        {
            string expected = "Class not found";
            try
            {
                object actual = MoodAnalyserReflector.CreateMoodAnalyserParameterizedConstructor("MoodAnalyser.AnalyzeMood", "AnalyzeMood", "I am Parameter constructor");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// TC-5.3 should throw NO_SUCH_CONSTRUCTOR exception with parameterized constructor.
        /// </summary>
        [TestMethod]
        [TestCategory("Reflection")]
        public void GivenImproperParameterizedConstructorName_ShouldReturnMoodAnalysisException()
        {
            string expected = "Constructor not found";
            try
            {
                object actual = MoodAnalyserReflector.CreateMoodAnalyserParameterizedConstructor("MoodAnalyzer.AnalyzeMood", "AnalyzeMod", "I am Parameter constructor");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// UC5-Refactor dry principle
        /// </summary>
        [TestMethod]
        [TestCategory("Reflection")]
        public void GivenMoodAnalyserOptionalVarible_ShouldReturnObject()
        {
            object expected = new AnalyzeMood("I am Parameter constructor");
            object actual = MoodAnalyserReflector.CreateMoodAnalyserOptionalVariable("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser", "I am Parameter constructor");
            expected.Equals(actual);
        }
        /// <summary>
        /// TC-6.1 Invokes the method using reflection and should return happy
        /// </summary>
        [TestMethod]
        [TestCategory("Reflection")]
        public void InvokeMethodReflection_ShouldRetunHappy()
        {
            string expected = "happy";
            string actual = MoodAnalyserReflector.InvokeAnalyseMood("I am happy", "Mood");
            expected.Equals(actual);
        }
        /// <summary>
        /// TC-6.2  should throw method not found exception.
        /// </summary>
        [TestMethod]
        [TestCategory("Reflection")]
        public void GivenMethodnameImproper_ShouldReturnMoodAnalysisException()
        {
            string expected = "No method found";
            try
            {
                string actual = MoodAnalyserReflector.InvokeAnalyseMood("I am happy", "MoodAnalyse");
                expected.Equals(actual);
            }
            catch (MoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        /// <summary>
        /// TC-7.1-Change mood dynamically.
        /// </summary>
        [TestMethod]
        [TestCategory("Reflection")]
        public void GivenSetMoodDynamically_ShouldReturnHappy()
        {
            string expected = "Happy";
            string actual = MoodAnalyserReflector.SetFieldDynamic("Happy", "message");
            expected.Equals(actual);
        }
        /// <summary>
        /// TC-7.2 Given field name improper should return exception
        /// </summary>
        [TestMethod]
        [TestCategory("Reflection")]
        public void GivenFieldNameImproper_ShouldReturnMoodAnaysisException()
        {
            string expected = "Field not found";
            try
            {
                string actual = MoodAnalyserReflector.SetFieldDynamic("Happy", "msg");
                expected.Equals(actual);
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// TC-7.3 Change message dynamically
        /// </summary>
        [TestMethod]
        [TestCategory("Reflection")]
        public void ChangeMeassageDynamically_ShouldReturnMessage()
        {
            string expected = "Message should not be null";
            try
            {
                string actual = MoodAnalyserReflector.SetFieldDynamic(null, "message");
                expected.Equals(actual);
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
    }
}