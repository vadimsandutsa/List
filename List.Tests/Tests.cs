using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace List.Tests
{
    [TestFixture("LinkedList")]
    [TestFixture("ArrayList")]
    [TestFixture("DoubleLinkedList")]
    public class Tests
    {
        IList actual;
        IList expected;
        IList adding;

        string s = "";

        public Tests(string type)
        {
            s = type;
        }

        public void Setup(int[] array, int[] expectedArray)
        {
            switch (s)
            {
                case "LinkedList":
                    actual = new LinkedList(array);
                    expected = new LinkedList(expectedArray);
                    break;

                case "ArrayList":
                    actual = new ArrayList(array);
                    expected = new ArrayList(expectedArray);
                    break;

                case "DoubleLinkedList":
                    actual = new DoubleLinkedList(array);
                    expected = new DoubleLinkedList(expectedArray);
                    break;
            }
        }
        public void Setup(int[] array)
        {
            switch (s)
            {
                case "LinkedList":
                    actual = new LinkedList(array);
                    break;

                case "ArrayList":
                    actual = new ArrayList(array);
                    break;

                case "DoubleLinkedList":
                    actual = new DoubleLinkedList(array);
                    break;
            }
        }
        public void Setup(int[] array, int[] expectedArray, int[] addingArray)
        {
            switch (s)
            {
                case "LinkedList":
                    actual = new LinkedList(array);
                    expected = new LinkedList(expectedArray);
                    adding = new LinkedList(addingArray);
                    break;

                case "ArrayList":
                    actual = new ArrayList(array);
                    expected = new ArrayList(expectedArray);
                    adding = new ArrayList(addingArray);
                    break;

                case "DoubleLinkedList":
                    actual = new DoubleLinkedList(array);
                    expected = new DoubleLinkedList(expectedArray);
                    adding = new DoubleLinkedList(addingArray);
                    break;
            }
        }
        [TestCase(4, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(0, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 0 })]
        [TestCase(4, new int[] { 1, 2 }, new int[] { 1, 2, 4 })]
        public void AddTest(int value, int[] array, int[] expectedArray)
        {
            Setup(array, expectedArray);
            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(4, new int[] { 1, 2, 3 }, new int[] { 4, 1, 2, 3 })]
        [TestCase(5, new int[] { 1, 2, 3 }, new int[] { 5, 1, 2, 3 })]
        [TestCase(44, new int[] { 1, 2, 3 }, new int[] { 44, 1, 2, 3 })]
        public void AddToBeginningTest(int value, int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.AddToBeginning(value);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(4, 0, new int[] { 1, 2, 3 }, new int[] { 4, 1, 2, 3 })]
        [TestCase(5, 2, new int[] { 1, 2, 3 }, new int[] { 1, 2, 5, 3 })]
        [TestCase(44, 3, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 44 })]
        public void AddByIndexTest(int value, int index, int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.AddByIndex(value, index);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(44, 4, new int[] { 1, 2, 3 })]
        public void AddByIndex_WhenIndexOutOfRange_IndexOutOfRangeExpection(int value, int index, int[] actualArray)
        {
            Setup(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(value, index));
        }
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 1, 2, 3 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        [TestCase(new int[] { 44, 55, 0, 66 }, new int[] { 1, 2, 3 }, new int[] { 44, 55, 0, 66, 1, 2, 3 })]
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 6, 6, 53 }, new int[] { 4, 5, 6, 6, 6, 53 })]
        [TestCase(new int[] { 4, 5, 6 }, new int[] { }, new int[] { 4, 5, 6 })]
        public void AddRangeTest(int[] actualArray, int[] addingArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray, addingArray);
            actual.AddRange(adding);
            Assert.AreEqual(expected, actual);

        }
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 44, 55, 0, 66 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 44, 55, 0, 66 })]
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 6, 6, 53 }, new int[] { 6, 6, 53, 4, 5, 6 })]
        public void AddRangeToTheBeginingTest(int[] actualArray, int[] addingArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray, addingArray);
            actual.AddRangeToTheBegining(adding);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, 1, new int[] { 1, 4, 5, 6, 2, 3 })]
        [TestCase(new int[] { 44, 55, 0, 66 }, new int[] { 1, 2, 3 }, 2, new int[] { 44, 55, 1, 2, 3, 0, 66 })]
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 6, 6, 53 }, 3, new int[] { 4, 5, 6, 6, 6, 53 })]
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 6, 6, 53 }, 0, new int[] { 6, 6, 53, 4, 5, 6 })]
        public void AddRangeByIndexTest(int[] actualArray, int[] addingArray, int index, int[] expectedArray)
        {
            Setup(actualArray, expectedArray, addingArray);
            actual.AddRangeByIndex(adding, index);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, -1)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, 6)]
        public void AddRangeByIndex_WhenIndexOutOfRange_IndexOutOfRangeExpection(int[] actualArray, int[] addingArray, int index)
        {
            Setup(actualArray, addingArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.AddRangeByIndex(expected, index));
        }
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 44, 55, 0, 66 }, new int[] { 44, 55, 0 })]
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 4, 5 })]
        [TestCase(new int[] { 4, 5 }, new int[] { 4 })]
        [TestCase(new int[] { 4 }, new int[] { })]
        public void RemoveTest(int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.Remove();
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 44, 55, 0, 66 }, new int[] { 55, 0, 66 })]
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 5, 6 })]
        [TestCase(new int[] { 4, 5 }, new int[] { 5 })]
        [TestCase(new int[] { 4 }, new int[] { })]
        public void RemoveFirstTest(int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.RemoveFirst();
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 1, 2 })]
        [TestCase(new int[] { 44, 55, 0, 66 }, 0, new int[] { 55, 0, 66 })]
        [TestCase(new int[] { 4, 5, 6 }, 1, new int[] { 4, 6 })]
        [TestCase(new int[] { 4, 5 }, 1, new int[] { 4 })]
        public void RemoveByIndexTest(int[] actualArray, int index, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.RemoveByIndex(index);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3 }, -1)]
        [TestCase(new int[] { 1, 2, 3 }, 444)]
        public void RemoveByIndex_WhenIndexOutOfRange_IndexOutOfRangeExpection(int[] actualArray, int index)
        {
            Setup(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveByIndex(index));
        }
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 1, 2 })]
        [TestCase(new int[] { 44, 55, 0, 66 }, 2, new int[] { 44, 55 })]
        [TestCase(new int[] { 4, 5, 6, 7, 8, 9, 123123, 5432, 9 }, 6, new int[] { 4, 5, 6 })]
        [TestCase(new int[] { 1, 2 }, 1, new int[] { 1 })]
        [TestCase(new int[] { 44, 55, 0, 66 }, 4, new int[] { })]
        [TestCase(new int[] { 1 }, 1, new int[] { })]
        public void RemoveElementsTest(int[] actualArray, int numberOfElements, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.RemoveElements(numberOfElements);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3 }, -1)]
        [TestCase(new int[] { 1, 2, 3 }, 444)]
        public void RemoveElements_WhenNumberOfElementsGreaterOrLessThenIndex_IndexOutOfRangeExpection(int[] actualArray, int numberOfElements)
        {
            Setup(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveElements(numberOfElements));
        }
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 2, 3 })]
        [TestCase(new int[] { 44, 55, 0, 66 }, 2, new int[] { 0, 66 })]
        [TestCase(new int[] { 4, 5, 6, 7, 8, 9, 123123, 5432, 9 }, 6, new int[] { 123123, 5432, 9 })]
        [TestCase(new int[] { 1, 2 }, 1, new int[] { 2 })]
        [TestCase(new int[] { 44, 55, 0, 66 }, 4, new int[] { })]
        [TestCase(new int[] { 1 }, 1, new int[] { })]
        public void RemoveFirstElements(int[] actualArray, int numberOfElements, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.RemoveFirstElements(numberOfElements);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3 }, -1)]
        [TestCase(new int[] { 1, 2, 3 }, 444)]
        public void RemoveFirstElements_WhenNumberOfElementsGreaterOrLessThenIndex_IndexOutOfRangeExpection(int[] actualArray, int numberOfElements)
        {
            Setup(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveFirstElements(numberOfElements));
        }
        [TestCase(new int[] { 1, 2, 3 }, 1, 1, new int[] { 1, 3 })]
        [TestCase(new int[] { 44, 55, 0, 66 }, 2, 2, new int[] { 44, 55 })]
        [TestCase(new int[] { 4, 5, 6, 7, 8, 9, 123123, 5432, 9 }, 4, 2, new int[] { 4, 5, 123123, 5432, 9 })]
        [TestCase(new int[] { 4, 5, 6, 7, 8, 9, 123123, 5432, 9 }, 9, 0, new int[] { })]
        public void RemoveElementsByIndexTest(int[] actualArray, int numberOfElements, int index, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.RemoveElementsByIndex(numberOfElements, index);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3 }, 1, -2)]
        [TestCase(new int[] { 44, 55, 0, 66 }, 2, 1234)]
        public void RemoveElementsByIndex_IndexOutOfRange_IndexOutOfRangeExpection(int[] actualArray, int numberOfElements, int index)
        {
            Setup(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveElementsByIndex(numberOfElements, index));
        }
        [TestCase(new int[] { 1, 2, 3 }, 11, 1)]
        [TestCase(new int[] { 44, 55, 0, 66 }, -1, 2)]
        public void RemoveElementsByIndex_NumberOfElementsGreaterThenLengthOrLessThenZero_IndexOutOfRangeExpection(int[] actualArray, int numberOfElements, int index)
        {
            Setup(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveElementsByIndex(numberOfElements, index));
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, 2, 5)]
        [TestCase(new int[] { 1, 3, 5, 64 }, 3, 64)]
        [TestCase(new int[] { 1, 41, 5, 64 }, 1, 41)]
        public void GetValueByIndexTest(int[] actualArray, int index, int expected)
        {
            Setup(actualArray);
            int actualInt = actual.GetValueByIndex(index);
            Assert.AreEqual(expected, actualInt);
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, 22)]
        [TestCase(new int[] { 1, 3, 5, 64 }, -3)]
        public void GetValueByIndex_WhenIndexOutOfRange_IndexOutOfRangeExpection(int[] actualArray, int index)
        {
            Setup(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.GetValueByIndex(index));
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, 5, 2)]
        [TestCase(new int[] { 1, 3, 5, 64 }, 64, 3)]
        [TestCase(new int[] { 1, 41, 5, 64 }, 41, 1)]
        [TestCase(new int[] { 1, 41, 5, 64 }, 421, -1)]
        public void GetIndexByValueTest(int[] actualArray, int value, int expected)
        {
            Setup(actualArray);
            int actualInt = actual.GetIndexByValue(value);
            Assert.AreEqual(expected, actualInt);
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, 22, 1, new int[] { 1, 22, 5, 64 })]
        [TestCase(new int[] { 1, 3, 5, 64 }, 33, 3, new int[] { 1, 3, 5, 33 })]
        [TestCase(new int[] { 1, 41, 5, 64 }, 11, 0, new int[] { 11, 41, 5, 64 })]
        public void SetValueByIndexTest(int[] actualArray, int value, int index, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.SetValueByIndex(value, index);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, 3, 22)]
        [TestCase(new int[] { 1, 3, 5, 64 }, 1, -3)]
        public void SetValueByIndex_WhenIndexOutOfRange_IndexOutOfRangeExpection(int[] actualArray, int value, int index)
        {
            Setup(actualArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.SetValueByIndex(value, index));
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, new int[] { 64, 5, 3, 1 })]
        [TestCase(new int[] { 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2 })]
        [TestCase(new int[] { 32, 31, 43 }, new int[] { 43, 31, 32 })]
        public void ReverseTest(int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.Reverse();
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, 64)]
        [TestCase(new int[] { 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 44, 31, 43 }, 44)]
        public void GetMaxValueTest(int[] actualArray, int expected)
        {
            Setup(actualArray);
            int actualInt = actual.GetMaxValue();
            Assert.AreEqual(expected, actualInt);
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, 1)]
        [TestCase(new int[] { 2, 3, 4, 5 }, 2)]
        [TestCase(new int[] { 32, 31, 43 }, 31)]
        public void GetMinValueTest(int[] actualArray, int expected)
        {
            Setup(actualArray);
            int actualInt = actual.GetMinValue();
            Assert.AreEqual(expected, actualInt);
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, 3)]
        [TestCase(new int[] { 2, 3, 7, 5 }, 2)]
        [TestCase(new int[] { 32, 31, 43 }, 2)]
        public void GetIndexOfMaxValueTest(int[] actualArray, int expected)
        {
            Setup(actualArray);
            int actualInt = actual.GetIndexOfMaxValue();
            Assert.AreEqual(expected, actualInt);
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, 0)]
        [TestCase(new int[] { 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { 32, 31, 43 }, 1)]
        public void GetIndexOfMinValueTest(int[] actualArray, int expected)
        {
            Setup(actualArray);
            int actualInt = actual.GetIndexOfMinValue();
            Assert.AreEqual(expected, actualInt);
        }
        [TestCase(new int[] { 1, 3, 5, 64 }, 1, 0, new int[] { 3, 5, 64 })]
        [TestCase(new int[] { 1, 3, 5, 64 }, 5, 2, new int[] { 1, 3, 64 })]
        [TestCase(new int[] { 1, 41, 5, 64 }, 64, 3, new int[] { 1, 41, 5 })]
        public void RemoveFirstByValueTest(int[] actualArray, int value, int index, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            int actualIndex = actual.RemoveFirstByValue(value);
            Assert.AreEqual(actualIndex, index);
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 2, 3, 3, 4, 3 }, 3, 3, new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 1, 64, 5, 64 }, 64, 2, new int[] { 1, 5 })]
        [TestCase(new int[] { 1, 41, 5, 3, 41 }, 41, 2, new int[] { 1, 5, 3 })]
        [TestCase(new int[] { 41, 41, 5, 3, 1 }, 1, 1, new int[] { 41, 41, 5, 3 })]
        [TestCase(new int[] { 0, -1, 0, 3 }, 0, 2, new int[] { -1, 3 })]
        [TestCase(new int[] { 1, 41, 5, 3, 1 }, 111, 0, new int[] { 1, 41, 5, 3, 1 })]
        [TestCase(new int[] { 111, 111, 111, 3, 1 }, 111, 3, new int[] { 3, 1 })]
        public void RemoveAllByValueTest(int[] actualArray, int value, int count, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            int actualCount = actual.RemoveAllByValue(value);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(count, actualCount);
        }
        [TestCase(new int[] { 1, 7, 3, 8, 3, 4 }, new int[] { 1, 3, 3, 4, 7, 8 })]
        [TestCase(new int[] { 1, 64, 5, 63 }, new int[] { 1, 5, 63, 64 })]
        [TestCase(new int[] { 1, 42, 5, 3, 41 }, new int[] { 1, 3, 5, 41, 42 })]
        [TestCase(new int[] { }, new int[] { })]
        public void AscendingSortTest(int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.AscendingSort();
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 1, 7, 3, 8, 3, 4 }, new int[] { 8, 7, 4, 3, 3, 1 })]
        [TestCase(new int[] { 1, 64, 5, 63 }, new int[] { 64, 63, 5, 1 })]
        [TestCase(new int[] { 1, 42, 5, 3, 41 }, new int[] { 42, 41, 5, 3, 1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void DescendingSortTest(int[] actualArray, int[] expectedArray)
        {
            Setup(actualArray, expectedArray);
            actual.DescendingSort();
            Assert.AreEqual(actual, expected);
        }
    }
}
