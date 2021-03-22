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
                //for(int i=1;i<=index;i++)
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
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }
        public LinkedList(int[] values)
        {
            if(values is null)
            {
                throw new NullReferenceException();
            }
            Length = values.Length;
            if(values.Length != 0)
            {
                _root = new Node(values[0]);
                _tail = _root;
                for(int i = 1; i<values.Length;i++)
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
        public void Add(int value)
        {
            Length++;
            _tail.Next = new Node(value);
            _tail = _tail.Next;
        }
        public void RemoveFirst()
        {
            _root = _root.Next;
        }
        public void RemoveByIndex(int index)
        {
            Node current = _root;

            for(int i = 1;i<index;i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;

            Length--;
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

            do
            {
                if(currentThis.Value != currentList.Value)
                {
                    return false;
                }
                currentThis = currentThis.Next;
                currentList = currentList.Next;
            }
            while (!(currentThis.Next is null));

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
            for (int i = 1; i < index; i++)
            {
                current = current.Next;
            }
            return current;
        }
    }
}
