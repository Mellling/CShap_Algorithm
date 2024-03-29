﻿using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace _05.BinarySearchTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 이진트리탐색 기반으로 SortedSet 자료구조
            // 중복이 없는 정렬을 보장하는 저장소
            SortedSet<int> sortedSet = new SortedSet<int>();

            // 삽입
            // 특정위치에 내가 원하는 거 집어넣기 불가능
            sortedSet.Add(1);
            sortedSet.Add(3);
            sortedSet.Add(5);
            sortedSet.Add(4);
            sortedSet.Add(6);
            sortedSet.Add(3);   // 이미 들어있는 것을 넣으면 무시함. (중복추가 무시)

            // 삭제
            sortedSet.Remove(4);

            // 제거
            bool sucess = sortedSet.Contains(1);
            bool fail = sortedSet.Contains(2);

            // 순서대로 출력시 정렬된 결과 확인
            foreach (int val in sortedSet)
            {
                Console.WriteLine(val);
            }

            // 이진탐색트리 기반의 SortedDictionary 자료구조
            // 중복을 허용하지 않는 key를 기준으로 정렬을 보장한 value 저장소
            // 중복일 경우 error 발생. SortedSet처럼 무시하는 것이 아닌 예외 발생
            SortedDictionary<string, Item> sortedDictionary = new SortedDictionary<string, Item>(); // 탐색 기준이 string

            // 삽입
            sortedDictionary.Add("포션", new Item("포션", 3));
            sortedDictionary.Add("소드", new Item("소드", 10));
            sortedDictionary.Add("방패", new Item("빙패", 1));
            sortedDictionary.Add("신발", new Item("신발", 100));
            sortedDictionary.Add("롱소드", new Item("롱소드", 20));
            sortedDictionary.Add("망토", new Item("망토", 30));

            // 삭제
            sortedDictionary.Remove("롱소드");

            // 탐색
            sortedDictionary.ContainsKey("방패");
            Item item = sortedDictionary["방패"]; // 인덱서[key]를 통해 배열처럼 탐색. 없으면 error
            sortedDictionary.TryGetValue("방패", out Item item1); // 예외처리까지 감안하여 key 가지고 value 탐색

            // 순서대로 출력시 정렬된 결과 확인
            foreach (string name in sortedDictionary.Keys)
            {
                Console.WriteLine(name);
            }

            foreach (Item item2 in sortedDictionary.Values)
            {
                Console.WriteLine($"{item2.name}, {item2.value}");
            }

            // <이진탐색트리 주의점>
            // 이진탐색트리는 최악의 상황에 노드들이 한쪽 자식으로만 추가되는 불균형 현상이 발생 가능
            // 이 경우 탐색영역이 절반으로 줄여지지 않기 때문에 시간복잡도 증가
            //
            //           5
            //         ┌─┘
            //         4
            //       ┌─┘
            //       3
            //     ┌─┘
            //     2
            //   ┌─┘
            //   1
            //
            // 이러한 현상을 막기 위해 자가균형기능을 추가한 트리의 사용이 일반적
            // 자가균형트리는 회전을 이용하여 불균형이 있는 상황을 해결
            //
            //       8                        5
            //    ┌──┴──┐   -- 우회전 ->   ┌──┴──┐
            //    5     9                  3     8
            //  ┌─┴─┐       <- 좌회전 --       ┌─┴─┐      
            //  3   6                          6   9 
            //
            // 대표적인 방식으로 Red-Black Tree, AVL Tree 등을 통해 불균형상황을 파악


        }

        public class Item
        {
            public string name;
            public int value;

            public Item(string name, int value)
            {
                this.name = name;
                this.value = value;
            }
        }

        /******************************************************
		 * 이진탐색트리 (BinarySearchTree)
		 * 
		 * 이진속성과 탐색속성을 적용한 트리
		 * 이진탐색을 통한 탐색영역을 절반으로 줄여가며 탐색 가능
		 * 이진 : 부모노드는 최대 2개의 자식노드들을 가질 수 있음
		 * 탐색 : 자신의 노드보다 작은 값들은 왼쪽, 큰 값들은 오른쪽에 위치
		 ******************************************************/

        // 이진 탐색 < 정렬된 데이터에서만 쓸 수 있는 방식
        // 순차 탐색 < 상관 없음

        // <이진탐색트리의 시간복잡도>
        // 접근			탐색			삽입			삭제
        // O(logN)		O(logN)	    O(logN)	    O(logN)

        // <이진탐색트리의 주의점>
        // 이진탐색트리의 노드들이 한쪽 자식으로만 추가되는 불균형 발생 가능
        // 이 경우 탐색영역이 절반으로 줄여지지 않기 때문에 시간복잡도 증가
        // 이러한 현상을 막기 위해 자가균형기능을 추가한 트리의 사용이 일반적
        // 대표적인 방식으로 Red-Black Tree, AVL Tree 등을 통해 불균형상황을 파악
        // 자가균형트리는 회전을 이용하여 불균형이 있는 상황을 해결

        // <트리순회>
        // 트리는 비선형 자료구조로 반복자의 순서에 대해 정의하는데 규칙을 선정해야 함
        // 순회의 방식은 크게 전위, 중위, 후위 순회가 있음
        // 전위순회 : 노드, 왼쪽, 오른쪽
        // 중위순회 : 왼쪽, 노드, 오른쪽   <- 이진탐색트리에서 중위순회시 오름차순으로 데이터를 순회가능
        // 후위순회 : 왼쪽, 오른쪽, 노드

        // <이진탐색트리 구현>
        // 이진탐색트리는 모든 노드들이 최대 2개의 자식노드를 가질 수 있으며
        // 자신의 노드보다 작은 값들은 왼쪽, 큰 값들은 오른쪽에 위치시킴
        //
        //             23
        //      ┌──────┴──────┐
        //      11            38
        //   ┌──┴──┐       ┌──┴──┐
        //   3     19      31    65
        //   └─┐ ┌─┴─┐   ┌─┘     └─┐
        //     6 17  22  24        87


        // <이진탐색트리 탐색>
        // 아래의 이진탐색트리에서 17 탐색
        // 루트 노드부터 시작하여 탐색하는 값과 비교하여,
        // 작은 경우 왼쪽자식노드로, 큰 경우 오른쪽자식노드를 탐색
        //
        //             23(↙)
        //      ┌──────┴──────┐
        //      11(↘)         38
        //   ┌──┴──┐       ┌──┴──┐
        //   3     19(↙)   31    65
        //   └┐  ┌─┴─┐   ┌─┘
        //    6 (17)  22  24


        // <이진탐색트리 삽입>
        // 아래의 이진탐색트리에서 35 삽입
        // 루트 노드부터 시작하여 삽입하는 값과 비교하여,
        // 작은 경우 왼쪽자식노드로, 큰 경우 오른쪽자식노드로 하강
        // 만약 빈공간이라면 빈공간에 삽입
        //
        //             23(↘)                          23
        //      ┌──────┴──────┐                ┌──────┴──────┐
        //      11            38(↙)            11            38
        //   ┌──┴──┐       ┌──┴──┐      =>  ┌──┴──┐       ┌──┴──┐ 
        //   3     19      31(↘) 65         3     19      31    65
        //   └─┐ ┌─┴─┐   ┌─┘                └─┐ ┌─┴─┐   ┌─┴─┐
        //     6 17  22  24                   6 17  22  24 (35)


        // <이진탐색트리 삭제>
        // 1. 자식이 0개인 노드의 삭제 : 단순 삭제 진행
        // 아래의 이진탐색트리에서 22 삭제
        //
        //             23                             23
        //      ┌──────┴──────┐                ┌──────┴──────┐
        //      11            38               11            38
        //   ┌──┴──┐       ┌──┴──┐    =>    ┌──┴──┐       ┌──┴──┐
        //   3     19      31    65         3     19      31    65
        //   └─┐ ┌─┴─┐   ┌─┘                └─┐ ┌─┘     ┌─┴─┐
        //     6 17 (22) 24                   6 17      24  35
        //
        // 2. 자식이 1개인 노드의 삭제 : 삭제하는 노드의 부모와 자식을 연결 후 삭제
        // 아래의 이진탐색트리에서 38 삭제
        //
        //            23                              23
        //     ┌──────┴──────┐                 ┌──────┴──────┐
        //     11            (38)              11            31
        //  ┌──┴──┐       ┌──┘        =>    ┌──┴──┐       ┌──┴──┐ 
        //  3     19      31                3     19      24    35
        //  └─┐ ┌─┴─┐   ┌─┴─┐               └─┐ ┌─┴─┐
        //    6 17  22  24  35                6 17  22
        //
        // 3. 자식이 2개인 노드의 삭제 : 삭제하는 노드를 기준으로 오른쪽자식 중 가장 작은 값 노드와 교체 후 삭제
        // 아래의 이진탐색트리에서 23 삭제
        //
        //           (23)                             24                              24
        //     ┌──────┴──────┐                 ┌──────┴──────┐                 ┌──────┴──────┐
        //     11            38                11            38                11            38
        //  ┌──┴──┐       ┌──┴──┐     =>    ┌──┴──┐       ┌──┴──┐     =>    ┌──┴──┐       ┌──┴──┐ 
        //  3     19      24    49          3     19     (23)   49          3     19      35   49
        //  └─┐ ┌─┴─┐     └─┐               └─┐ ┌─┴─┐     └─┐               └─┐ ┌─┴─┐
        //    6 17  22      35                6 17  22      35                6 17  22


    }
}
