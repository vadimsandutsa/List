using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    //первый индекс по значению возвращаем -1 если нет
    //самая быстрая сортировка это бинарная Binary Sort
    //изначально массив равен 10, если задаем длину сами, то сразу длина + 33 процента
    //XCriticalSoftware
    public class ArrayList
    {
        private int[] _array;
        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                if(index < 0 || index > Length - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[index];
            }
            set
            {
                if (index < 0 || index > Length - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                _array[index] = value;
            }
        }
        public ArrayList()
        {
            Length = 0;

            _array = new int[10];
            UpSize();
        }
        public ArrayList(int length)
        {
            if(length < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Length = 0;

            _array = new int[length];
            UpSize();
        }

        public ArrayList(int[] value)
        {
            Length = value.Length;

            _array = value;
            UpSize();
        }

        public void Add(int value)
        {
            if (Length >= _array.Length)
            {
                UpSize();
            }

            _array[Length] = value;

            Length++;
        }
        public void AddToBeginning(int value)
        {
            if (Length >= _array.Length)
            {
                UpSize();
            }

            for (int i = Length; i > 0; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[0] = value;

            Length++;
        }
        public void AddByIndex(int value, int index)
        {
            if (Length >= _array.Length)
            {
                UpSize();
            }

            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = Length; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[index] = value;

            Length++;
        }
        public void AddArrayListToTheEnd(ArrayList arrList)
        {
            int[] tmpArray = new int[(_array.Length + arrList._array.Length)];
            for(int i = 0; i < Length; i++)
            {
                tmpArray[i] = _array[i];
            }
            int tmp = arrList.Length + Length;
            for (int i = Length; i < tmp; i++)
            {
                tmpArray[i] = arrList[i - Length];
            }
            Length += (arrList.Length);
            _array = tmpArray;
            UpSize();
        }
        public void AddArrayListToTheBegining(ArrayList arrList)
        {
            int[] tmpArray = new int[(_array.Length + arrList._array.Length)];
            for (int i = 0; i < arrList.Length; i++)
            {
                tmpArray[i] = arrList[i];
            }
            int tmp = arrList.Length + Length;
            for (int i = arrList.Length; i < tmp; i++)
            {
                tmpArray[i] = _array[i - arrList.Length];
            }
            Length += arrList.Length;
            _array = tmpArray;
            UpSize();
        }
        public void AddArrayListByIndex(ArrayList arrList, int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            int tmp1 = arrList.Length + index;
            int tmp2 = arrList.Length + Length;
            int[] tmpArray = new int[(_array.Length + arrList._array.Length)];
            for (int i = 0; i < index; i++)
            {
                tmpArray[i] = _array[i];
            }
            for (int i = index; i < tmp1; i++)
            {
                tmpArray[i] = arrList[i - index];
            }
            for (int i = tmp1; i < tmp2; i++)
            {
                tmpArray[i] = _array[i - arrList.Length];
            }
            Length += arrList.Length;
            _array = tmpArray;
            UpSize();
        }
        public void AddArrayListByIndex2(ArrayList list, int index)
        {
            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            int newLength = Length + list.Length;
            UpSize(newLength);
            int tmp = index + list.Length;
            for (int i = newLength - 1; i >= tmp; i--)
            {
                _array[i] = _array[i - list.Length];
            }
            for (int i = index; i < tmp; i++)
            {
                _array[i] = list._array[i - index];
            }
            Length = newLength;
        }
        public void Remove()
        {
            Length--;
            if (Length < _array.Length / 2 - 1 && Length > 0)
            {
                DownSize();
            }
        }
        public void RemoveFirst()
        {
            for (int i = 0; i < Length; i++)
            {
                _array[i] = _array[i + 1];
            }
            Length--;
            if (Length < _array.Length / 2 - 1 && Length > 1)
            {
                DownSize();
            }
        }
        public void RemoveByIndex(int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < Length - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            Length--;
            if (Length < _array.Length / 2 - 1 && Length > 1)
            {
                DownSize();
            }
        }
        public void RemoveElements(int numberOfElements)
        {
            if (numberOfElements > Length || numberOfElements < 0)
            {
                throw new IndexOutOfRangeException();
            }

            Length -= numberOfElements;
            if (Length < _array.Length / 2 - 1 && Length > 1)
            {
                DownSize();
            }
        }
        public void RemoveFirstElements(int numberOfElements)
        {
            if (Length < numberOfElements || numberOfElements < 0)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = 0; i < Length - numberOfElements; i++)
            {
                _array[i] = _array[i + numberOfElements];
            }

            Length -= numberOfElements;
            if (Length < _array.Length / 2 - 1 && Length > 1)
            {
                DownSize();
            }
        }
        public void RemoveElementsByIndex(int numberOfElements, int index)
        {
            if (Length < numberOfElements || numberOfElements < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < Length - numberOfElements; i++)
            {
                _array[i] = _array[i + numberOfElements];
            }
            Length -= numberOfElements;
            if (Length < _array.Length / 2 - 1 && Length > 1)
            {
                DownSize();
            }
        }
        public int GetValueByIndex(int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            return _array[index];
        }
        public int GetIndexByValue(int value)
        {
            int index = -1;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    index = i;
                }
            }
            return index;
        }
        public void SetValueByIndex(int value, int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            _array[index] = value;
        }
        public void Reverse()
        {
            int [] tmpArray = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                tmpArray[i] = _array[Length - 1 - i];
            }
            _array = tmpArray;
        }
        public int GetMaxValue()
        {
            int max = _array[0];
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                }
            }
            return max;
        }
        public int GetMinValue()
        {
            int min = _array[0];
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                }
            }
            return min;
        }
        public int GetIndexOfMaxValue()
        {
            int max = 0;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > _array[max])
                {
                    max = i;
                }
            }
            return max;
        }
        public int GetIndexOfMinValue()
        {
            int min = _array[0];
            int minIndex = 0;
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }
        public int RemoveFirstByValue(int value)
        {
            int result = -1;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    result = i;
                    break;
                }
            }
            if (result != -1)
            {
                for (int i = result; i < Length - 1; i++)
                {
                    _array[i] = _array[i + 1];
                }
                Length--;
            }
            if (Length < _array.Length / 2 - 1 && Length > 1)
            {
                DownSize();
            }
            return result;
        }
        public int RemoveAllByValue(int value)
        {
            int count = 0;
            for (int i = Length - 1; i >= 0; i--)
            {
                if (_array[i] == value)
                {
                    count++;
                    for (int j = i; j < Length - 1; j++)
                    {
                        _array[j] = _array[j + 1];
                    }
                    Length--;
                }
            }
            if (Length < _array.Length / 2 - 1 && Length > 1)
            {
                DownSize();
            }
            return count;
        }
        public void SortUp()
        {
            //Сортировка пузырьком
            for (int i = 1; i < Length; i++)
            {
                for (int j = 0; j < Length - i; j++)
                {
                    if (_array[j] > _array[j + 1])
                    {
                        Swap(ref _array[j], ref _array[j + 1]);
                        /*int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;*/
                    }
                }
            }
        }
        public void SortDown()
        {
            //Сортировка выбором
            for (int i = 0; i < Length - 1; i++)
            {
                int indexOfMax = i;
                for (int j = i; j < Length; j++)
                {
                    if (_array[indexOfMax] < _array[j])
                    {
                        indexOfMax = j;
                    }
                }
                Swap(ref _array[i], ref _array[indexOfMax]);
                /*int tmp = arr[i];
                arr[i] = arr[indexOfMax];
                arr[indexOfMax] = tmp;*/
            }
        }
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Length != arrayList.Length)
            {
                return false;
            }
            for (int i = 0; i < Length; i++)
            {
                if(_array[i] != arrayList._array[i])
                {
                    return false;
                }
            }
            return true;
        }
        public override string ToString()
        {
            string value = "";
            for (int i = 0; i < Length; i++)
            {
                value += $"{_array[i]} ";
            }
            return value;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        private void UpSize()
        {
            int newLength = (int)(_array.Length * 1.33d + 1);

            int[] tmpArray = new int[newLength];

            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }
        private void UpSize(int length)
        {
            int newLength = (int)(length * 1.33d + 1);

            int[] tmpArray = new int[newLength];

            for (int i = 0; i < Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }
        //How much multiply?
        private void DownSize()
        {
            int newLength = (int)(_array.Length * 0.67d + 1);

            int[] tmpArray = new int[newLength];

            for (int i = 0; i < tmpArray.Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }
    }
}
