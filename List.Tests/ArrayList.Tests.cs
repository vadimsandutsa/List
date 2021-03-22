using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace List.Tests
{
    public class Tests
    {
        [TestCase(4, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(5, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 5 })]
        [TestCase(44, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 44 })]
        public void AddTest(int value, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.Add(value);
            Assert.AreEqual(actual, expected);
        }
        [TestCase(4, new int[] { 1, 2, 3 }, new int[] { 4, 1, 2, 3 })]
        [TestCase(5, new int[] { 1, 2, 3 }, new int[] { 5, 1, 2, 3 })]
        [TestCase(44, new int[] { 1, 2, 3 }, new int[] { 44, 1, 2, 3 })]
        public void AddToBeginningTest(int value, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.AddToBeginning(value);
            Assert.AreEqual(actual, expected);
        }
        [TestCase(4, 0, new int[] { 1, 2, 3 }, new int[] { 4, 1, 2, 3 })]
        [TestCase(5, 2, new int[] { 1, 2, 3 }, new int[] { 1, 2, 5, 3 })]
        [TestCase(44, 3, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 44 })]
        public void AddAtIndexTest(int value, int index, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.AddAtIndex(value, index);
            Assert.AreEqual(actual, expected);
        }
        [TestCase(44, 4, new int[] { 1, 2, 3 })]
        public void AddAtIndex_WhenIndexOutOfRange_IndexOutOfRangeExpection(int value, int index, int[] actualArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.AddAtIndex(value, index));
        }
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 1, 2, 3 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        [TestCase(new int[] { 44, 55, 0, 66 }, new int[] { 1, 2, 3 }, new int[] { 44, 55, 0, 66 , 1, 2, 3 })]
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 6, 6, 53 }, new int[] { 4, 5, 6, 6, 6, 53 })]
        public void AddArrayListAtTheEndTest(int[] actualArray, int[] addingArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList adding = new ArrayList(addingArray);
            actual.AddArrayListAtTheEnd(adding);
            ArrayList expected = new ArrayList(expectedArray);
            Assert.AreEqual(actual, expected);

        }
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 44, 55, 0, 66 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 44, 55, 0, 66 })]
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 6, 6, 53 }, new int[] { 6, 6, 53, 4, 5, 6 })]
        public void AddArrayListAtTheBeginingTest(int[] actualArray, int[] addingArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList adding = new ArrayList(addingArray);
            actual.AddArrayListAtTheBegining(adding);
            ArrayList expected = new ArrayList(expectedArray);
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, 1, new int[] { 1, 4, 5, 6, 2, 3})]
        [TestCase(new int[] { 44, 55, 0, 66 }, new int[] { 1, 2, 3 }, 2, new int[] { 44, 55, 1, 2, 3, 0, 66 })]
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 6, 6, 53 }, 3, new int[] { 4, 5, 6, 6, 6, 53 })]
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 6, 6, 53 }, 0, new int[] { 6, 6, 53, 4, 5, 6})]
        public void AddArrayListByIndexTest(int [] actualArray, int[] addingArray, int index, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList adding = new ArrayList(addingArray);
            actual.AddArrayListByIndex(adding, index);
            ArrayList expected = new ArrayList(expectedArray);
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, -1)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, 6)]
        public void AddArrayListByIndex_WhenIndexOutOfRange_IndexOutOfRangeExpection(int[] actualArray, int[] addingArray, int index)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList adding = new ArrayList(addingArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.AddArrayListByIndex(adding, index));
        }
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, 1, new int[] { 1, 4, 5, 6, 2, 3 })]
        [TestCase(new int[] { 44, 55, 0, 66 }, new int[] { 1, 2, 3 }, 2, new int[] { 44, 55, 1, 2, 3, 0, 66 })]
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 6, 6, 53 }, 3, new int[] { 4, 5, 6, 6, 6, 53 })]
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 6, 6, 53 }, 0, new int[] { 6, 6, 53, 4, 5, 6 })]
        public void AddArrayListByIndexTest2(int[] actualArray, int[] addingArray, int index, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList adding = new ArrayList(addingArray);
            actual.AddArrayListByIndex2(adding, index);
            ArrayList expected = new ArrayList(expectedArray);
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, -1)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, 6)]
        public void AddArrayListByIndex2_WhenIndexOutOfRange_IndexOutOfRangeExpection(int[] actualArray, int[] addingArray, int index)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList adding = new ArrayList(addingArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.AddArrayListByIndex2(adding, index));
        }
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 44, 55, 0, 66 }, new int[] { 44, 55, 0 })]
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 4, 5 })]
        public void RemoveLastTest(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.RemoveLast();
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 44, 55, 0, 66 }, new int[] { 55, 0, 66 })]
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 5, 6 })]
        public void RemoveFirstTest(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.RemoveFirst();
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 1, 2 })]
        [TestCase(new int[] { 44, 55, 0, 66 }, 0, new int[] { 55, 0, 66 })]
        [TestCase(new int[] { 4, 5, 6 }, 1, new int[] { 4, 6 })]
        public void RemoveByIndexTest(int[] actualArray, int index, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.RemoveByIndex(index);
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 2, 3 }, -1)]
        [TestCase(new int[] { 1, 2, 3 }, 444)]
        public void RemoveByIndex_WhenIndexOutOfRange_IndexOutOfRangeExpection(int[] actualArray, int index)
        {
            ArrayList actual = new ArrayList(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveByIndex(index));
        }
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 1, 2 })]
        [TestCase(new int[] { 44, 55, 0, 66 }, 2, new int[] { 44, 55 })]
        [TestCase(new int[] { 4, 5, 6, 7, 8, 9, 123123, 5432, 9 }, 6, new int[] { 4, 5, 6 })]
        public void RemoveLastNTest(int[] actualArray, int numberOfElements, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.RemoveLastN(numberOfElements);
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 2, 3 }, -1)]
        [TestCase(new int[] { 1, 2, 3 }, 444)]
        public void RemoveLastN_WhenNumberOfElementsGreaterOrLessThenIndex_IndexOutOfRangeExpection(int[] actualArray, int numberOfElements)
        {
            ArrayList actual = new ArrayList(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveLastN(numberOfElements));
        }
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 2, 3 })]
        [TestCase(new int[] { 44, 55, 0, 66 }, 2, new int[] { 0, 66 })]
        [TestCase(new int[] { 4, 5, 6, 7, 8, 9, 123123, 5432, 9 }, 6, new int[] { 123123, 5432, 9 })]
        public void RemoveFirstNTest(int[] actualArray, int numberOfElements, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.RemoveFirstN(numberOfElements);
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 2, 3 }, -1)]
        [TestCase(new int[] { 1, 2, 3 }, 444)]
        public void RemoveFirstN_WhenNumberOfElementsGreaterOrLessThenIndex_IndexOutOfRangeExpection(int[] actualArray, int numberOfElements)
        {
            ArrayList actual = new ArrayList(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveFirstN(numberOfElements));
        }
        [TestCase(new int[] { 1, 2, 3 }, 1, 1, new int[] { 1, 3 })]
        [TestCase(new int[] { 44, 55, 0, 66 }, 2, 2, new int[] { 44, 55 })]
        [TestCase(new int[] { 4, 5, 6, 7, 8, 9, 123123, 5432, 9 }, 4, 2, new int[] { 4, 5, 123123, 5432, 9 })]
        public void RemoveElementsByIndexTest(int [] actualArray, int numberOfElements, int index, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.RemoveElementsByIndex(numberOfElements, index);
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 2, 3 }, 1, -2)]
        [TestCase(new int[] { 44, 55, 0, 66 }, 2, 1234)]
        public void RemoveElementsByIndex_IndexOutOfRange_IndexOutOfRangeExpection(int[] actualArray, int numberOfElements, int index)
        {
            ArrayList actual = new ArrayList(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveElementsByIndex(numberOfElements, index));
        }
        [TestCase(new int[] { 1, 2, 3 }, 11, 1)]
        [TestCase(new int[] { 44, 55, 0, 66 }, -1, 2)]
        public void RemoveElementsByIndex_NumberOfElementsGreaterThenLengthOrLessThenZero_IndexOutOfRangeExpection(int[] actualArray, int numberOfElements, int index)
        {
            ArrayList actual = new ArrayList(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveElementsByIndex(numberOfElements, index));
        }
        [TestCase(new int[] {1, 3, 5, 64}, 2, 5)]
        [TestCase(new int[] { 1, 3, 5, 64 }, 3, 64)]
        [TestCase(new int[] { 1, 41, 5, 64 }, 1, 41)]
        public void GetValueAtIndexTest(int[] actualArray, int index, int expected)
        {
            ArrayList actualArr = new ArrayList(actualArray);
            int actual = actualArr.GetValueAtIndex(index);
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, 22)]
        [TestCase(new int[] { 1, 3, 5, 64 }, -3)]
        public void GetValueAtIndex_WhenIndexOutOfRange_IndexOutOfRangeExpection(int[] actualArray, int index)
        {
            ArrayList actualArr = new ArrayList(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actualArr.GetValueAtIndex(index));
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, 2, 5)]
        [TestCase(new int[] { 1, 3, 5, 64 }, 3, 64)]
        [TestCase(new int[] { 1, 41, 5, 64 }, 1, 41)]
        public void GetIndexByValueTest(int[] actualArray, int value, int expected)
        {
            ArrayList actualArr = new ArrayList(actualArray);
            int actual = actualArr.GetIndexByValue(value);
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, 22, 1, new int[] { 1, 22, 5, 64 })]
        [TestCase(new int[] { 1, 3, 5, 64 }, 33, 3, new int[] { 1, 3, 5, 33 })]
        [TestCase(new int[] { 1, 41, 5, 64 }, 11, 0, new int[] { 11, 41, 5, 64 })]
        public void SetValueAtIndexTest(int[] actualArray, int value, int index, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.SetValueAtIndex(value, index);
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, 3, 22)]
        [TestCase(new int[] { 1, 3, 5, 64 }, 1, -3)]
        public void SetValueAtIndex_WhenIndexOutOfRange_IndexOutOfRangeExpection(int[] actualArray, int value, int index)
        {
            ArrayList actualArr = new ArrayList(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actualArr.SetValueAtIndex(value, index));
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, new int[] { 64, 5, 3, 1 })]
        [TestCase(new int[] { 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2 })]
        [TestCase(new int[] { 32, 31, 43 }, new int[] { 43, 31, 32 })]
        public void ReverseTest(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.Reverse();
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, 64)]
        [TestCase(new int[] { 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 32, 31, 43 }, 43)]
        public void GetMaxValueTest(int[] actualArray,  int expected)
        {
            ArrayList actualArr = new ArrayList(actualArray);
            int actual = actualArr.GetMaxValue();
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, 1)]
        [TestCase(new int[] { 2, 3, 4, 5 }, 2)]
        [TestCase(new int[] { 32, 31, 43 }, 31)]
        public void GetMinValueTest(int[] actualArray, int expected)
        {
            ArrayList actualArr = new ArrayList(actualArray);
            int actual = actualArr.GetMinValue();
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, 3)]
        [TestCase(new int[] { 2, 3, 7, 5 }, 2)]
        [TestCase(new int[] { 32, 31, 43 }, 2)]
        public void GetIndexOfMaxValueTest(int[] actualArray, int expected)
        {
            ArrayList actualArr = new ArrayList(actualArray);
            int actual = actualArr.GetIndexOfMaxValue();
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, 0)]
        [TestCase(new int[] { 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { 32, 31, 43 }, 1)]
        public void GetIndexOfMinValueTest(int[] actualArray, int expected)
        {
            ArrayList actualArr = new ArrayList(actualArray);
            int actual = actualArr.GetIndexOfMinValue();
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, 1, new int[] { 3, 5, 64 })]
        [TestCase(new int[] { 1, 3, 5, 64 }, 5, new int[] { 1, 3, 64 })]
        [TestCase(new int[] { 1, 41, 5, 64 }, 64, new int[] { 1, 41, 5 })]
        public void RemoveFirstByValueTest(int[] actualArray, int value, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.RemoveFirstByValue(value);
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 2, 3, 3, 3, 4 }, 3, new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 1, 64, 5, 64 }, 64, new int[] { 1, 5 })]
        [TestCase(new int[] { 1, 41, 5, 3, 41 }, 41, new int[] { 1, 5, 3 })]
        public void RemoveAllByValueTest(int[] actualArray, int value, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            int b = actual.RemoveAllByValue(value);
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 7, 3, 8, 3, 4 }, new int[] { 1, 3, 3, 4, 7, 8 })]
        [TestCase(new int[] { 1, 64, 5, 63 }, new int[] { 1, 5, 63, 64 })]
        [TestCase(new int[] { 1, 42, 5, 3, 41 }, new int[] { 1, 3, 5, 41, 42 })]
        public void SortUpTest(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.SortUp();
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 7, 3, 8, 3, 4 }, new int[] { 8, 7, 4, 3, 3, 1 })]
        [TestCase(new int[] { 1, 64, 5, 63 }, new int[] { 64, 63, 5, 1 })]
        [TestCase(new int[] { 1, 42, 5, 3, 41 }, new int[] { 42, 41, 5, 3, 1 })]
        public void SortDownTest(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);
            actual.SortDown();
            Assert.AreEqual(actual, expected);
        }
    }
}