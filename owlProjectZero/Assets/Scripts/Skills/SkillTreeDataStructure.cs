using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeDataStructure
{
    // Re-evaluate if a struct is needed or not
    struct Node
    {
        LinkedList<LinkedList<int>> dataLinkedList;
        string dataName;

        Node* left, mid, right;
    };

    Node* newNode(LinkedList<LinkedList<int>> data)
    {
        // Attempting to create a node which its value
        // is a linked list of int-typed linked lists
        LinkedListNode<LinkedList<LinkedList<int>>>* node = new 
            LinkedListNode<LinkedList<LinkedList<int>>>(new LinkedList<LinkedList<int>>());
        string dataName = "Category"; 
        node->Value = data;
        node->Next = null;
        node->Prevous = null;

        return node;

    }

}
