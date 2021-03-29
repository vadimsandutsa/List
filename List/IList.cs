using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public interface IList
    {
        void Add(int value);
        void AddToBeginning(int value);
        void AddByIndex(int value, int index);
        public void AddRange(IList List);
        public void AddRangeToTheBegining(IList List);
        public void AddRangeByIndex(IList List, int index);
        public void Remove();
        public void RemoveFirst();
        public void RemoveByIndex(int index);
        public void RemoveElements(int numberOfElements);
        public void RemoveFirstElements(int numberOfElements);
        public void RemoveElementsByIndex(int numberOfElements, int index);
        public int GetValueByIndex(int index);
        public int GetIndexByValue(int value);
        public void SetValueByIndex(int value, int index);
        public void Reverse();
        public int GetMaxValue();
        public int GetMinValue();
        public int GetIndexOfMaxValue();
        public int GetIndexOfMinValue();
        public int RemoveFirstByValue(int value);
        public int RemoveAllByValue(int value);
        public void AscendingSort();
        public void DescendingSort();
        public string ToString();
        public bool Equals(object obj);
        public int GetHashCode();
    }
}
