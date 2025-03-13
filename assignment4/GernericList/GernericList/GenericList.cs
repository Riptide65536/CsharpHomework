using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GernericList
{
    class GenericList<T>
    {
        public Node<T>? Head { get; set; }
        private Node<T>? tail;
        public GenericList()
        {
            tail = Head = null;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if(tail == null)
            {
                Head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            Node<T>? p = Head;
            while(p != null)
            {
                action(p.Data);
                p = p.Next;
            }
        }
    }
}
