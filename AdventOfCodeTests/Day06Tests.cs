﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using AdventOfCodeTests;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class Day06Tests
    {
        string inputDay06;
        string inputDay06Example1;

        [TestInitialize]
        public void TestInitialize()
        {
            inputDay06 = InputData.ResourceManager.GetObject("D06_Puzzle").ToString();
            inputDay06Example1 = InputData.ResourceManager.GetObject("D06_E1").ToString();
        }

        [TestMethod]
        public void Puzzle1ExampleTest()
        {
            Assert.AreEqual(17, Day06.Puzzle1(inputDay06Example1));
        }

        // Runtime on Surface Book 2 i7: 53 ms
        [TestMethod]
        public void Puzzle1Test()
        {
            Assert.AreEqual(5365, Day06.Puzzle1(inputDay06));
        }

        [TestMethod]
        public void Puzzle2ExampleTest()
        {
            Assert.AreEqual(16, Day06.Puzzle2(inputDay06Example1, 32));
        }

        // Runtime on Surface Book 2 i7: 38 ms
        [TestMethod]
        public void Puzzle2Test()
        {
            Assert.AreEqual(42513, Day06.Puzzle2(inputDay06, 10000));
        }
    }
}