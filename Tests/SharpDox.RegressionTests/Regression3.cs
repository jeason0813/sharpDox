﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharpDox.Sdk.Build;
using SharpDox.Sdk.Config;
using System.Reflection;
using System.IO;
using SharpDox.Build.Context;
using SharpDox.Sdk.Exporter;
using System.Collections.Generic;
using SharpDox.Build;

namespace SharpDox.RegressionTests
{
    [TestClass]
    public class Regression3
    {
        [TestMethod]
        public void SyntaxShouldContainStaticKeyword()
        {
            // Arrange
            var steps = TestConfig.GetSteps();
               
            // Act
            var solution = steps.LoadStep.LoadSolution();
            var repository = steps.ParseStep.ParseSolution(solution, new List<string>());
            var type = repository.GetTypeByIdentifier("SharpDox.TestProject.Regression3");

            // Assert            
            Assert.IsTrue(type.Methods[0].Syntax.Contains("static"));
        }
    }
}
