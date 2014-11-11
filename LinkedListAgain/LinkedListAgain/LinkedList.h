#pragma once
#include <iostream>

using namespace std;
class LinkedList
{
public:
	LinkedList();
	~LinkedList();
	struct node{
		int data;
		node* next;
	};
	node* head;
	void InsertatEnd(int data);
	void DisplayList();
	void DeleteFromEnd();
	void DeleteUsingData(int data);
	void Reverse();
};

