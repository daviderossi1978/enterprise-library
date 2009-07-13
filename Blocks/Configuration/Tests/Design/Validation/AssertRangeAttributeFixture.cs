﻿//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Core
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Configuration.Design.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.Configuration.Design.Validation.Tests
{
    [TestClass]
    public class AssertRangeAttributeFixture : ConfigurationDesignHost
    {
        MyTestClass rangeClass;
        PropertyInfo int32Info;
        PropertyInfo doubleInfo;
        PropertyInfo floatInfo;
        PropertyInfo charInfo;
        PropertyInfo stringInfo;
        PropertyInfo shortInfo;
        PropertyInfo byteInfo;
        PropertyInfo decimalInfo;

        protected override void InitializeCore()
        {
            rangeClass = new MyTestClass();
            int32Info = rangeClass.GetType().GetProperty("Int32Value");
            doubleInfo = rangeClass.GetType().GetProperty("DoubleValue");
            floatInfo = rangeClass.GetType().GetProperty("FloatValue");
            charInfo = rangeClass.GetType().GetProperty("CharValue");
            stringInfo = rangeClass.GetType().GetProperty("StringValue");
            shortInfo = rangeClass.GetType().GetProperty("ShortValue");
            byteInfo = rangeClass.GetType().GetProperty("ByteValue");
            decimalInfo = rangeClass.GetType().GetProperty("DecimalValue");
        }

        [TestMethod]
        public void Int32OutOfRangeTest()
        {
            AssertRangeAttribute assertRange = new AssertRangeAttribute(3, RangeBoundaryType.Inclusive, 43, RangeBoundaryType.Exclusive);
            rangeClass.Int32Value = 2;
            List<ValidationError> errors = new List<ValidationError>();
            assertRange.Validate(rangeClass, int32Info, errors, ServiceProvider);

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void Int32InRangeTest()
        {
            AssertRangeAttribute assertRange = new AssertRangeAttribute(3, RangeBoundaryType.Inclusive, 43, RangeBoundaryType.Exclusive);
            rangeClass.Int32Value = 25;
            List<ValidationError> errors = new List<ValidationError>();
            assertRange.Validate(rangeClass, int32Info, errors, ServiceProvider);

            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void DoubleOutOfRangeTest()
        {
            AssertRangeAttribute assertRange = new AssertRangeAttribute(3D, RangeBoundaryType.Inclusive, 43D, RangeBoundaryType.Exclusive);
            rangeClass.DoubleValue = 2;
            List<ValidationError> errors = new List<ValidationError>();
            assertRange.Validate(rangeClass, doubleInfo, errors, ServiceProvider);

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void DoubleInRangeTest()
        {
            AssertRangeAttribute assertRange = new AssertRangeAttribute(3D, RangeBoundaryType.Inclusive, 43D, RangeBoundaryType.Exclusive);
            rangeClass.DoubleValue = 25;
            List<ValidationError> errors = new List<ValidationError>();
            assertRange.Validate(rangeClass, doubleInfo, errors, ServiceProvider);

            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void FloatOutOfRangeTest()
        {
            AssertRangeAttribute assertRange = new AssertRangeAttribute(3f, RangeBoundaryType.Inclusive, 43f, RangeBoundaryType.Exclusive);
            rangeClass.FloatValue = 2;
            List<ValidationError> errors = new List<ValidationError>();
            assertRange.Validate(rangeClass, floatInfo, errors, ServiceProvider);

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void FloatInRangeTest()
        {
            AssertRangeAttribute assertRange = new AssertRangeAttribute(3f, RangeBoundaryType.Inclusive, 43f, RangeBoundaryType.Exclusive);
            rangeClass.FloatValue = 25;
            List<ValidationError> errors = new List<ValidationError>();
            assertRange.Validate(rangeClass, floatInfo, errors, ServiceProvider);

            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void ShortOutOfRangeTest()
        {
            AssertRangeAttribute assertRange = new AssertRangeAttribute((Int16)3, RangeBoundaryType.Inclusive, (Int16)43, RangeBoundaryType.Exclusive);
            rangeClass.ShortValue = 2;
            List<ValidationError> errors = new List<ValidationError>();
            assertRange.Validate(rangeClass, shortInfo, errors, ServiceProvider);

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void ShortInRangeTest()
        {
            AssertRangeAttribute assertRange = new AssertRangeAttribute((Int16)3, RangeBoundaryType.Inclusive, (Int16)43, RangeBoundaryType.Exclusive);
            rangeClass.ShortValue = 25;
            List<ValidationError> errors = new List<ValidationError>();
            assertRange.Validate(rangeClass, shortInfo, errors, ServiceProvider);

            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void ByteOutOfRangeTest()
        {
            AssertRangeAttribute assertRange = new AssertRangeAttribute((byte)3, RangeBoundaryType.Inclusive, (byte)43, RangeBoundaryType.Exclusive);
            rangeClass.ByteValue = 2;
            List<ValidationError> errors = new List<ValidationError>();
            assertRange.Validate(rangeClass, byteInfo, errors, ServiceProvider);

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void ByteInRangeTest()
        {
            AssertRangeAttribute assertRange = new AssertRangeAttribute((byte)3, RangeBoundaryType.Inclusive, (byte)43, RangeBoundaryType.Exclusive);
            rangeClass.ByteValue = 25;
            List<ValidationError> errors = new List<ValidationError>();
            assertRange.Validate(rangeClass, byteInfo, errors, ServiceProvider);

            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void DecimalOutOfRangeTest()
        {
            AssertRangeAttribute assertRange = new AssertRangeAttribute((decimal)3, RangeBoundaryType.Inclusive, (decimal)43, RangeBoundaryType.Exclusive);
            rangeClass.DecimalValue = 2;
            List<ValidationError> errors = new List<ValidationError>();
            assertRange.Validate(rangeClass, decimalInfo, errors, ServiceProvider);

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void DecimalInRangeTest()
        {
            AssertRangeAttribute assertRange = new AssertRangeAttribute((decimal)3, RangeBoundaryType.Inclusive, (decimal)43, RangeBoundaryType.Exclusive);
            rangeClass.DecimalValue = 25;
            List<ValidationError> errors = new List<ValidationError>();
            assertRange.Validate(rangeClass, decimalInfo, errors, ServiceProvider);

            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void CharOutOfRangeTest()
        {
            AssertRangeAttribute assertRange = new AssertRangeAttribute('a', RangeBoundaryType.Inclusive, 'd', RangeBoundaryType.Exclusive);
            rangeClass.CharValue = 'd';
            List<ValidationError> errors = new List<ValidationError>();
            assertRange.Validate(rangeClass, charInfo, errors, ServiceProvider);

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void CharInRangeTest()
        {
            AssertRangeAttribute assertRange = new AssertRangeAttribute('a', RangeBoundaryType.Inclusive, 'd', RangeBoundaryType.Exclusive);
            rangeClass.CharValue = 'c';
            List<ValidationError> errors = new List<ValidationError>();
            assertRange.Validate(rangeClass, charInfo, errors, ServiceProvider);

            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void StringOutOfRangeTest()
        {
            AssertRangeAttribute assertRange = new AssertRangeAttribute("Anna", RangeBoundaryType.Inclusive, "Scott", RangeBoundaryType.Exclusive);
            rangeClass.StringValue = "Zeek";
            List<ValidationError> errors = new List<ValidationError>();
            assertRange.Validate(rangeClass, stringInfo, errors, ServiceProvider);

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void StringInRangeTest()
        {
            AssertRangeAttribute assertRange = new AssertRangeAttribute("Anna", RangeBoundaryType.Inclusive, "Grace", RangeBoundaryType.Exclusive);
            rangeClass.StringValue = "Dee";
            List<ValidationError> errors = new List<ValidationError>();
            assertRange.Validate(rangeClass, stringInfo, errors, ServiceProvider);

            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LowerBoundHigherThanUpperBoundThrows()
        {
            AssertRangeAttribute assertRange = new AssertRangeAttribute(5, RangeBoundaryType.Inclusive, 3, RangeBoundaryType.Exclusive);
        }

        class MyTestClass : ConfigurationNode
        {
            byte byteValue;
            char charValue;
            decimal decimalValue;
            double doubleValue;
            float floatValue;
            int int32Value;
            short shortValue;
            string stringValue;

            public byte ByteValue
            {
                get { return byteValue; }
                set { byteValue = value; }
            }

            public char CharValue
            {
                get { return charValue; }
                set { charValue = value; }
            }

            public decimal DecimalValue
            {
                get { return decimalValue; }
                set { decimalValue = value; }
            }

            public double DoubleValue
            {
                get { return doubleValue; }
                set { doubleValue = value; }
            }

            public float FloatValue
            {
                get { return floatValue; }
                set { floatValue = value; }
            }

            public int Int32Value
            {
                get { return int32Value; }
                set { int32Value = value; }
            }

            public short ShortValue
            {
                get { return shortValue; }
                set { shortValue = value; }
            }

            public string StringValue
            {
                get { return stringValue; }
                set { stringValue = value; }
            }
        }
    }
}