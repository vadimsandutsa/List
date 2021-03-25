using System;
using System.Collections.Generic;
using System.Text;

//выбором и вставкой работает быстро mergesort быстрее
//пузырек и прямого выбора медленно
//следить при изменении длины, чтобы рут и тэйл имели ссылки на что-то
//мерджсофт круто для линкед круто, для эррэй нет, бинари тоже
namespace List
{
    public class LinkedList
    {
        public int Length { get; private set; }
        public int this[int index]
        {
            get
            {
                //Node current = _root;
                //for (int i = 1; i <= index; i++)
                //{
                //    current = current.Next;
                //}
                return GetNodeByIndex(index).Value;
            }
            set
            {
                //Node current = _root;
                //for (int i = 1; i <= index; i++)
                //{
                //    current = current.Next;
                //}
                GetNodeByIndex(index).Value = value;
            }
        }

        private Node _root;
        private Node _tail;

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }
        public LinkedList(int value)
        {
            AddFirstInEmptyLinkedList(value);
        }
        public LinkedList(int[] values)
        {
            if (values is null)
            {
                throw new NullReferenceException();
            }
            Length = values.Length;
            if (values.Length != 0)
            {
                _root = new Node(values[0]);
                _tail = _root;
                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new Node(values[i]);
                    _tail = _tail.Next;
                }
            }
            else
            {
                _root = null;
                _tail = null;
            }
        }
        //public LinkedList(int[] values)
        //{
        //    if (values is null)
        //    {
        //        throw new NullReferenceException();
        //    }
        //    if (values.Length != 0)
        //    {
        //        Length = 1;
        //        _root = new Node(values[0]);
        //        _tail = _root;
        //        for (int i = 1; i < values.Length; i++)
        //        {
        //            Add(values[i]);
        //        }
        //    }
        //    else
        //    {
        //        _root = null;
        //        _tail = null;
        //    }
        //}
        public Node GetNodeByIndex(int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            Node current = _root;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current;
        }
        public void Add(int value)
        {
            if (Length != 0)
            {
                Length++;
                _tail.Next = new Node(value);
                _tail = _tail.Next;
            }
            else
            {
                AddFirstInEmptyLinkedList(value);
            }    
        }
        public void AddToBeginning(int value)
        {
            Length++;
            Node first = new Node(value);
            first.Next = _root;
            _root = first;
        }
        public void AddByIndex(int value, int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index != 0 && index != Length)
            {
                Node current = GetNodeByIndex(index - 1);
                Node tmp = new Node(value);
                tmp.Next = current.Next;
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
        public void AddLinkedList(LinkedList linkedList)
        {
            //создавать новые ноды с копированием значения value
            for(int i = 0; i < linkedList.Length; i++)
            {
                Add(linkedList[i]);
            }
        }
        public void AddLinkedListToTheBegining(LinkedList linkedList)
        {
            for(int i = linkedList.Length - 1; i >= 0; i--)
            {
                AddToBeginning(linkedList[i]);
            }
        }
        public void AddLinkedListByIndex(LinkedList linkedList, int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
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
                    AddLinkedListToTheBegining(linkedList);
                }
                if (index == Length)
                {
                    AddLinkedList(linkedList);
                }
            }
        }
        public void Remove()
        {
            if(Length != 1)
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
                Length--;
            }
            else
            {
                Empty();
            }
        }
        public void RemoveByIndex(int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if(index == 0)
            {
                RemoveFirst();
            }
            else if(index == Length)
            {
                Remove();
            }
            else if (index != 0 && index != Length)
            {
                Node current = _root;

                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;

                Length--;
            }
        }
        public void RemoveElements(int numberOfElements)
        {
            if (numberOfElements > Length || numberOfElements < 0)
            {
                throw new IndexOutOfRangeException();
            }
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
            if (numberOfElements > Length || numberOfElements < 0)
            {
                throw new IndexOutOfRangeException();
            }
            Node current = GetNodeByIndex(numberOfElements);
            _root = current;
            Length -= numberOfElements;
        }
        public void RemoveElementsByIndex(int numberOfElements, int index)
        {
            if (numberOfElements > Length || numberOfElements < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index != 0)
            {
                Node current = GetNodeByIndex(index - 1);
                Node tmp = current;
                for(int i = 0; i <= numberOfElements; i ++)
                {
                    current = current.Next;
                }
                tmp.Next = current;
                Length = Length - numberOfElements;
            }
            else
            {
                RemoveFirstElements(numberOfElements);
            }
        }
        public int GetValueByIndex(int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            return GetNodeByIndex(index).Value;
        }
        public int GetIndexByValue(int value)
        {
            int index = -1;
            Node current = _root;
            for(int i = 0; i < Length; i++)
            {
                if(value == current.Value)
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
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            Node current = GetNodeByIndex(index);
            current.Value = value;
        }
        public void Reverse()
        {
            Node prev = _root;
            Node next = null;
            _tail = _root;
            while (prev != null)
            {
                Node tmp = prev.Next;
                prev.Next = next;
                next = prev;
                prev = tmp;
            }
            _root = next;
        }
        public void Reverse3()
        {
            Node next = null;
            _tail = _root;
            while (_root != null)
            {
                Node tmp = _root.Next;
                _root.Next = next;
                next = _root;
                _root = tmp;
            }
            _root = next;
        }
        public LinkedList Reverse2()
        {
            LinkedList newList = new LinkedList(new int[] {});
            while (Length != 0)
                newList.Add((Pop().Value));
            return newList;
        }
        public Node Pop()
        {
            Node ret = _tail;
            Length--;
            if(Length > 1)
            {
                _tail = GetNodeByIndex(Length - 1);
            }
            else if(Length == 1)
            {
                _tail = _root;
            }
            else
            {
                _tail = null;
                _root = null;
                Length = 0;
            }
            return ret;
        }
        public int GetMaxValue()
        {
            int max = _root.Value;
            Node tmp = _root.Next;
            for(int i = 1; i < Length; i++)
            {
                if(max < tmp.Value)
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
            if(value == _root.Value)
            {
                index = 0;
                _root = _root.Next;
                Length--;
                return index;
            }
            for (int i = 0; i < Length-1; i++)
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
                            if(!(tmp.Next is null))
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
        public LinkedList SortUp()
        {
            LinkedList newList = new LinkedList(new int[] { });
            int l = Length;
            while (l > 0)
            {
                newList.AddToBeginning((GetMaxValue()));
                RemoveByIndex(GetIndexOfMaxValue());
                l--;
            }
            return newList;
        }
        public LinkedList SortDown()
        {
            LinkedList newList = new LinkedList(new int[] { });
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
            LinkedList list = (LinkedList)obj;
            if(this.Length != list.Length)
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
                if(currentThis.Value != currentList.Value)
                {
                    return false;
                }
                currentThis = currentThis.Next;
                currentList = currentList.Next;
            }
            if(currentList.Value != currentList.Value)
            {
                return false;
            }    

            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        private void AddFirstInEmptyLinkedList(int value)
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
    }
}
