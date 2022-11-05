using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAlgorithm;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestForSorting
    {
        [TestMethod]
        public void TestMethod1()
        {
            int expected = 1;
            int actual = TextParserHelper.GetTimeSpanDoubleValue("1d");
            Assert.AreEqual(expected, actual,  "Error in parsing");

            expected = 7;
            actual = TextParserHelper.GetTimeSpanDoubleValue("1w");
            Assert.AreEqual(expected, actual, "Error in parsing");


            expected =30;
            actual = TextParserHelper.GetTimeSpanDoubleValue("1m");
            Assert.AreEqual(expected, actual, "Error in parsing");

            expected = 365;
            actual = TextParserHelper.GetTimeSpanDoubleValue("1y");
            Assert.AreEqual(expected, actual, "Error in parsing");


            expected = 8;
            actual = TextParserHelper.GetTimeSpanDoubleValue("1w1d");
            Assert.AreEqual(expected, actual, "Error in parsing");


            expected = 31;
            actual = TextParserHelper.GetTimeSpanDoubleValue("1m1d");
            Assert.AreEqual(expected, actual, "Error in parsing");

            expected = 366;
            actual = TextParserHelper.GetTimeSpanDoubleValue("1y1d");
            Assert.AreEqual(expected, actual, "Error in parsing");

            expected = 396;
            actual = TextParserHelper.GetTimeSpanDoubleValue("1y1m1d");
            Assert.AreEqual(expected, actual, "Error in parsing");


            expected = 403;
            actual = TextParserHelper.GetTimeSpanDoubleValue("1y1m1w1d");
            Assert.AreEqual(expected, actual, "Error in parsing");

        }


        [TestMethod]
        public void TestMethod2()
        {
            string expected = "1d";
            string actual = TextParserHelper.GetTimeSpanStringValueFromIntValue(1);
            Assert.AreEqual(expected, actual, "Error in parsing");

            expected = "1w";
            actual = TextParserHelper.GetTimeSpanStringValueFromIntValue(7);
            Assert.AreEqual(expected, actual, "Error in parsing");


            expected = "1m";
            actual = TextParserHelper.GetTimeSpanStringValueFromIntValue(30);
            Assert.AreEqual(expected, actual, "Error in parsing");

            expected = "1y";
            actual = TextParserHelper.GetTimeSpanStringValueFromIntValue(365);
            Assert.AreEqual(expected, actual, "Error in parsing");


            expected = "1w1d";
            actual = TextParserHelper.GetTimeSpanStringValueFromIntValue(8);
            Assert.AreEqual(expected, actual, "Error in parsing");


            expected = "1m1d";
            actual = TextParserHelper.GetTimeSpanStringValueFromIntValue(31);
            Assert.AreEqual(expected, actual, "Error in parsing");

            expected = "1y1d";
            actual = TextParserHelper.GetTimeSpanStringValueFromIntValue(366);
            Assert.AreEqual(expected, actual, "Error in parsing");

            expected = "1y1m1d";
            actual = TextParserHelper.GetTimeSpanStringValueFromIntValue(396);
            Assert.AreEqual(expected, actual, "Error in parsing");


            expected = "1y1m1w1d";
            actual = TextParserHelper.GetTimeSpanStringValueFromIntValue(403);
            Assert.AreEqual(expected, actual, "Error in parsing");
        }


        [TestMethod]
        public void TestMethod3()
        {
            List<string> lines = new List<string>() { "9m, 10, 30", "1d3m, 10, 20", "1y6m1w2d,11,150", "1d3m, 11, 120" };
            List<string> expected = new List<string>() { "3m1d,10,20", "3m1d,11,120", "9m,10,30", "1y6m1w2d,11,150" };
            Program program = new Program();


            List<int[]> newList = program.GetShortByDateDataSetValue(lines);

            var shortDatefirst = newList.OrderBy(x => x[0]).ThenBy(x => x[1]).ThenBy(x => x[2]).ToList();

            List<string> actual = program.GetShortByDateDataSetValueResult(shortDatefirst);

            Assert.AreEqual(actual[0], expected[0], "error");
            Assert.AreEqual(actual[1], expected[1], "error");
            Assert.AreEqual(actual[2], expected[2], "error");
            Assert.AreEqual(actual[3], expected[3], "error");
        }
    }
}

