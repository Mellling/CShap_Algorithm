using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LinkedList
{
    internal class Node
    {
        /**************************************************************
         * 노드 (Node)
         * 
         * 여저 자료구조에서 사용하는 기본단위
         * 데이터와 다른 노드를 참조하는 값을 가짐
         * 다른 노드의 참조를 연결하는 방식을 따라 여러 자료구조를 구현 가능
         **************************************************************/

        // 노드 구현
        // 노드에 데이터와 다른 노드를 참조하는 값을 구성하여 구현
        // 연결된 노드를 가지는

        public class LinkedListNode<T>
        {
            public T value;

            public LinkedListNode<T> prev;
            public LinkedListNode<T> next;

            private T item;
        }

        // 연결된 노드를 가지는 List를 통해 유돟적인 연결구조 가짐
        // 연결구조가 일정하지 않는 트리/ 그래프에서 사용
    }
}
