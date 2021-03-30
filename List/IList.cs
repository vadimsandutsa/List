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
        void AddRange(IList List);
        void AddRangeToTheBegining(IList List);
        void AddRangeByIndex(IList List, int index);
        void Remove();
        void RemoveFirst();
        void RemoveByIndex(int index);
        void RemoveElements(int numberOfElements);
        void RemoveFirstElements(int numberOfElements);
        void RemoveElementsByIndex(int numberOfElements, int index);
        int GetValueByIndex(int index);
        int GetIndexByValue(int value);
        void SetValueByIndex(int value, int index);
        void Reverse();
        int GetMaxValue();
        int GetMinValue();
        int GetIndexOfMaxValue();
        int GetIndexOfMinValue();
        int RemoveFirstByValue(int value);
        int RemoveAllByValue(int value);
        void AscendingSort();
        void DescendingSort();
        string ToString();
        bool Equals(object obj);
        int GetHashCode();
    }
}
