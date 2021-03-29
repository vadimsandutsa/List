using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class DoubleLinkedList
    {
        public int Length { get; private set; }

        private Node _root;
        private Node _tail;
        //private Node _previous;

        public int this[int index]
        {
            get
            {
                return GetNodeByIndex(index).Value;
            }
            set
            {
                GetNodeByIndex(index).Value = value;
            }
        }
        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tail = _root;
            //_previous = _tail;
        }
        public DoubleLinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
            //_previous = _tail;
        }
        public DoubleLinkedList(int[] values)
        {
            if (values is null)
            {
                throw new NullReferenceException();
            }
            if (values.Length != 0)
            {
                Length = 1;
                _root = new Node(values[0]);
                _tail = _root;
                for (int i = 1; i < values.Length; i++)
                {
                    Add(values[i]);
                }
            }
            else
            {
                _root = null;
                _tail = null;
            }
        }
        //public Node GetNodeByIndex(int index)
        //{
        //    CheckExceptionIndex(index);
        //    Node current = _root;
        //    for (int i = 0; i < index; i++)
        //    {
        //        current = current.Next;
        //    }
        //    return current;
        //}
        private Node GetNodeByIndex(int index)
        {
            if ((index < 0) || (index > Length))
            {
                throw new IndexOutOfRangeException("Индекс вне множества.");
            }

            Node root = _root;
            Node tail = _tail;

            if (index < Length / 2)
            {
                for (int i = 0; i < index; i++)
                {
                    root = root.Next;
                }

                return root;
            }
            else
            {
                for (int i = Length - 1; i >= index; i--)
                {
                    tail = tail.Previous;
                }

                return tail.Next; // добавил .Next
            }

        }
        public void Add(int value)
        {
            if (Length != 0)
            {
                Length++;
                //tmp.Previous = _previous;
                _tail.Next = new Node(value);
                _tail.Next.Previous = _tail;
                _tail = _tail.Next;
                //_previous = _tail;
            }
            else
            {
                AddFirstInEmptyDoubleLinkedList(value);
            }
        }
        public void AddToBeginning(int value)
        {
            Length++;
            Node first = new Node(value);
            first.Next = _root;
            _root = first;
            if(!(_root.Next is null))
            {
                _root.Next.Previous = _root;
            }
        }
        public void AddByIndex(int value, int index)
        {
            CheckExceptionIndex(index);
            if (index != 0 && index != Length)
            {
                Node current = GetNodeByIndex(index - 1);
                Node tmp = new Node(value);
                tmp.Next = current.Next;
                tmp.Previous = current;
                current.Next = tmp;
                Length++;
            }
            else
            {
                if (index == 0)
                {
                    AddToBeginning(value);
                }
                if (index == Length)
                {
                    Add(value);
                }
            }
        }
        public void AddDoubledLinkedList(DoubleLinkedList linkedList)
        {
            //создавать новые ноды с копированием значения value
            for (int i = 0; i < linkedList.Length; i++)
            {
                Add(linkedList[i]);
            }
        }
        public void AddDoubledLinkedListToTheBegining(DoubleLinkedList linkedList)
        {
            for (int i = linkedList.Length - 1; i >= 0; i--)
            {
                AddToBeginning(linkedList[i]);
            }
        }
        public void AddDoubledLinkedListByIndex(DoubleLinkedList linkedList, int index)
        {
            CheckExceptionIndex(index);
            if (index != 0 && index != Length)
            {
                for (int i = linkedList.Length - 1; i >= 0; i--)
                {
                    AddByIndex(linkedList[i], index);
                }
            }
            else
            {
                if (index == 0)
                {
                    AddDoubledLinkedListToTheBegining(linkedList);
                }
                if (index == Length)
                {
                    AddDoubledLinkedList(linkedList);
                }
            }
        }
        public void Remove()
        {
            if (Length != 1)
            {
                Node current = GetNodeByIndex(Length - 2);
                current.Next = null;
                _tail = current;
                Length--;
            }
            else
            {
                Empty();
            }
        }
        public void RemoveFirst()
        {
            if (Length != 1)
            {
                _root = _root.Next;
                _root.Previous = null;
                Length--;
            }
            else
            {
                Empty();
            }
        }
        public void RemoveByIndex(int index)
        {
            CheckExceptionIndex(index);
            if (index != 0 && index != Length)
            {
                Node current = _root;

                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
                if(!(current.Next is null))
                current.Next.Previous = current;

                Length--;
            }
            else if (index == 0)
            {
                RemoveFirst();
            }
            else if (index == Length)
            {
                Remove();
            }
        }
        public void RemoveElements(int numberOfElements)
        {
            CheckNumberOfElements(numberOfElements);
            if (Length != 1 && Length != numberOfElements)
            {
                GetNodeByIndex(Length - 1 - numberOfElements).Next = null;
                Length -= numberOfElements;
            }
            else
            {
                if (Length == numberOfElements)
                {
                    Empty();
                }
            }
        }
        public void RemoveFirstElements(int numberOfElements)
        {
            CheckNumberOfElements(numberOfElements);
            Node current = GetNodeByIndex(numberOfElements);
            _root = current;
            if(!(_root is null))
            {
                _root.Previous = null;
            }
            Length -= numberOfElements;
        }
        public void RemoveElementsByIndex(int numberOfElements, int index)
        {
            CheckExceptionIndex(index);
            CheckNumberOfElements(numberOfElements);
            if (numberOfElements > Length - index)
            {
                throw new IndexOutOfRangeException();
            }
            if (index != 0 && index != Length - 1)
            {
                Node current = GetNodeByIndex(index - 1);
                Node tmp = current;
                for (int i = 0; i <= numberOfElements; i++)
                {
                    current = current.Next;
                }
                tmp.Next = current;
                if(!(current is null))
                { 
                    current.Previous = tmp;
                }
                Length = Length - numberOfElements;
            }
            else if(index == Length - 1 )
            {
                Remove();
            }
            else
            {
                RemoveFirstElements(numberOfElements);
            }
        }
        public int GetValueByIndex(int index)
        {
            CheckExceptionIndex(index);
            return GetNodeByIndex(index).Value;
        }
        public int GetIndexByValue(int value)
        {
            int index = -1;
            Node current = _root;
            for (int i = 0; i < Length; i++)
            {
                if (value == current.Value)
                {
                    index = i;
                    break;
                }
                current = current.Next;
            }
            return index;
        }
        public void SetValueByIndex(int value, int index)
        {
            CheckExceptionIndex(index);
            GetNodeByIndex(index).Value = value;
        }
        public void Reverse()
        {
            Node temp = null;
            Node current = _root;
            _tail = current;
            for (int i = 0; i < Length; i++)
            {
                temp = current.Previous;
                current.Previous = current.Next;
                current.Next = temp;
                current = current.Previous;
            }
            _tail.Previous.Next = _tail;// добавил воот это
            if (temp != null)
            {
                _root = temp.Previous;
            }
        }
        public int GetMaxValue()
        {
            int max = _root.Value;
            Node tmp = _root.Next;
            for (int i = 1; i < Length; i++)
            {
                if (max < tmp.Value)
                {
                    max = tmp.Value;
                }
                tmp = tmp.Next;
            }
            return max;
        }
        public int GetMinValue()
        {
            int min = _root.Value;
            Node tmp = _root.Next;
            for (int i = 1; i < Length; i++)
            {
                if (min > tmp.Value)
                {
                    min = tmp.Value;
                }
                tmp = tmp.Next;
            }
            return min;
        }
        public int GetIndexOfMaxValue()
        {
            int max = _root.Value;
            int index = 0;
            Node tmp = _root.Next;
            for (int i = 1; i < Length; i++)
            {
                if (max < tmp.Value)
                {
                    max = tmp.Value;
                    index = i;
                }
                tmp = tmp.Next;
            }
            return index;
        }
        public int GetIndexOfMinValue()
        {
            int min = _root.Value;
            int index = 0;
            Node tmp = _root.Next;
            for (int i = 1; i < Length; i++)
            {
                if (min > tmp.Value)
                {
                    min = tmp.Value;
                    index = i;
                }
                tmp = tmp.Next;
            }
            return index;
        }
        public int RemoveFirstByValue(int value)
        {
            int index = -1;
            Node current = _root;
            if (value == _root.Value)
            {
                index = 0;
                _root = _root.Next;
                Length--;
                return index;
            }
            for (int i = 0; i < Length - 1; i++)
            {
                if (value == current.Next.Value)
                {
                    current.Next = current.Next.Next;
                    index = i + 1;
                    Length--;
                    break;
                }
                current = current.Next;
            }

            return index;
        }
        //********************************************************
        public int RemoveAllByValue(int value, int count = 0)
        {
            Node current = _root;
            if (value == _root.Value)
            {
                if (!(current.Next is null))
                {
                    while (value == current.Next.Value)
                    {
                        if (!(current.Next is null))
                        {
                            current = current.Next;
                            count++;
                            Length--;
                        }
                    }
                }
                count++;
                _root = current.Next;
                Length--;
                current = _root;
            }
            for (int i = 0; i < Length - 1; i++)
            {
                if (value == current.Next.Value)
                {
                    Node tmp = current.Next;
                    if (!(tmp.Next is null))
                    {
                        while (value == tmp.Next.Value)
                        {
                            if (!(tmp.Next is null))
                            {
                                tmp = tmp.Next;
                                count++;
                                Length--;
                            }
                        }
                    }
                    current.Next = tmp.Next;
                    count++;
                    Length--;
                }
                current = current.Next;
            }
            return count;
        }
        //********************************************************
        public int RemoveAllByValue2(int value)
        {
            int count = 0;
            int index = GetIndexByValue(value);
            while (index != -1)
            {
                RemoveByIndex(index);
                index = GetIndexByValue(value);
                count++;
            }
            return count;
        }
        //********************************************
        public override string ToString()
        {
            if (Length != 0)
            {
                Node current = _root;
                string s = current.Value + " ";
                while (!(current.Next is null))
                {
                    current = current.Next;
                    s += current.Value + " ";
                }
                return s;
            }
            else
            {
                return String.Empty;
            }
        }
        public void AscendingSort()
        {
            Node iNode = _root;
            int tmp;
            for (int i = 0; i < Length; i++)
            {
                Node jNode = iNode.Next;
                for (int j = i + 1; j < Length; j++)
                {
                    if (iNode.Value > jNode.Value)
                    {
                        tmp = iNode.Value;
                        iNode.Value = jNode.Value;
                        jNode.Value = tmp;
                    }
                    jNode = jNode.Next;
                }
                iNode = iNode.Next;
            }
        }
        public void DescendingSort()
        {
            Node iNode = _root;
            int tmp;
            for (int i = 0; i < Length; i++)
            {
                Node jNode = iNode.Next;
                for (int j = i + 1; j < Length; j++)
                {
                    if (iNode.Value < jNode.Value)
                    {
                        tmp = iNode.Value;
                        iNode.Value = jNode.Value;
                        jNode.Value = tmp;
                    }
                    jNode = jNode.Next;
                }
                iNode = iNode.Next;
            }
        }
        public DoubleLinkedList SortUp()
        {
            DoubleLinkedList newList = new DoubleLinkedList(new int[] { });
            int l = Length;
            while (l > 0)
            {
                newList.AddToBeginning((GetMaxValue()));
                RemoveByIndex(GetIndexOfMaxValue());
                l--;
            }
            return newList;
        }
        public DoubleLinkedList SortDown()
        {
            DoubleLinkedList newList = new DoubleLinkedList(new int[] { });
            int l = Length;
            while (l > 0)
            {
                newList.AddToBeginning((GetMinValue()));
                RemoveByIndex(GetIndexOfMinValue());
                l--;
            }
            return newList;
        }
        public override bool Equals(object obj)
        {
            DoubleLinkedList list = (DoubleLinkedList)obj;
            if (this.Length != list.Length)
            {
                return false;
            }
            Node currentThis = _root;
            Node currentList = list._root;
            if (currentList is null && currentThis is null)
            {
                return true;
            }

            while (!(currentThis.Next is null))
            {
                if (currentThis.Value != currentList.Value)
                {
                    return false;
                }
                currentThis = currentThis.Next;
                currentList = currentList.Next;
            }
            if (currentThis.Value != currentList.Value)
            {
                return false;
            }

            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        private void AddFirstInEmptyDoubleLinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }
        private void Empty()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }
        private void CheckExceptionIndex(int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
        }
        private void CheckNumberOfElements(int numberOfElements)
        {
            if (numberOfElements > Length || numberOfElements < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
