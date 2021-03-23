using System;
using System.Collections.Generic;
using System.Text;

//выбором и вставкой работает быстро mergesort быстрее
//пузырек и прямого выбора медленно
//следить при изменении длины, чтобы рут и тэйл имели ссылки на что-то
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
        //public LinkedList(int[] values)
        //{
        //    if(values is null)
        //    {
        //        throw new NullReferenceException();
        //    }
        //    Length = values.Length;
        //    if(values.Length != 0)
        //    {
        //        _root = new Node(values[0]);
        //        _tail = _root;
        //        for(int i = 1; i<values.Length;i++)
        //        {
        //            _tail.Next = new Node(values[i]);
        //            _tail = _tail.Next;
        //        }
        //    }
        //    else
        //    {
        //        _root = null;
        //        _tail = null;
        //    }
        //}
        public LinkedList(int[] values)
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
                Node current = _root;
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }
                Node tmp = new Node(value);
                tmp.Next = current.Next;
                current.Next = tmp;
                Length++;
            }
            if (index == 0)
            {
                AddToBeginning(value);
            }
            if (index == Length)
            {
                Add(value);
            }
        }
        public void AddByIndex2(int value, int index)
        {
            if(index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index != 0 && index != Length)
            {
                Node newNode = new Node(value);
                newNode.Next = GetNodeByIndex(index);
                GetNodeByIndex(index - 1).Next = newNode;
                Length++;
            }
            if (index == 0)
            {
                AddToBeginning(value);
            }
            if (index == Length)
            {
                Add(value);
            } 
        }
        public void AddLinkedList(LinkedList linkedList)
        {
            //создавать новые ноды с копированием значения value
            _tail.Next = linkedList._root;
            _tail = linkedList._tail;
            Length += linkedList.Length;
        }
        public void AddLinkedListToTheBegining(LinkedList linkedList)
        {
            linkedList._tail.Next = _root;
            _root = linkedList._root;
            Length += linkedList.Length;
        }
        public void AddLinkedListByIndex(LinkedList linkedList, int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index != 0 && index != Length)
            {
                linkedList._tail.Next = GetNodeByIndex(index);
                GetNodeByIndex(index - 1).Next = linkedList._root;
                Length += linkedList.Length;
            }
            if (index == 0)
            {
                AddLinkedListToTheBegining(linkedList);
            }
            if (index == Length)
            {
                AddLinkedList(linkedList);
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
            if(index == Length)
            {
                Remove();
            }
            if (index != 0 && index != Length)
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
            if (Length != 1)
            {
                GetNodeByIndex(Length - 1 - numberOfElements).Next = null;
                Length -= numberOfElements;
            }
            else
            {
                Empty();
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
        private Node GetNodeByIndex(int index)
        {
            if(index < 0 || index > Length)
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
