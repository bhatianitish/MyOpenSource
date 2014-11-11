#include "LinkedList.h"


LinkedList::LinkedList()
{
	node* head = NULL;
}


LinkedList::~LinkedList()
{
}

void LinkedList::InsertatEnd(int data)
{
	node* newnode = new node;
	newnode->data = data;
	newnode->next = NULL;
	if (head== NULL)
		head = newnode;
	else
	{
		node* temp=head;
		while (temp->next!= NULL)
		{
			cout << temp->data << endl;
			temp = temp->next;
		}
		temp->next = newnode;
	}
}

void LinkedList::DisplayList()
{
	if (head == NULL)
	{
		cout << "List is empty!"<<endl;
		return;
	}
	node* temp = head;
	while (temp != NULL)
	{
		cout << temp->data << "	" << endl;
		temp = temp->next;
	}
}
void LinkedList::DeleteFromEnd()
{
	if (head == NULL)
	{
		cout << "List is empty!" << endl;
		return;
	}
	node* temp=head;
	while (temp->next->next != NULL)
	{
		temp = temp->next;
	}
	cout << "Deleted Elemment: " << temp->next->data << endl;
	temp->next = NULL;
	
}
void LinkedList::DeleteUsingData(int data) //does not includes case when number is not found!
{
	if (head == NULL)
	{
		cout << "List is empty!" << endl;
		return;
	}
	node* temp = head;
	if (temp->data == data)
	{
		head = temp->next;
		return;
	}
	while (temp->next->data != data)
	{
		temp = temp->next;
	}
	temp->next = temp->next->next;
}
void LinkedList::Reverse()
{
	if (head == NULL)
	{
		cout << "List is empty!" << endl;
		return;
	}
	node* currentnode = head;
	node* prev = NULL;
	node* next;
	while (currentnode != NULL)
	{
		next = currentnode->next;
		currentnode->next = prev;
		prev = currentnode;
		currentnode = next;
	}
	head = prev;
}


int main()
{
	LinkedList obj;
	int x = 0,data;
	cout << "1. Insert Data" << endl << "2. Display" << endl << "3. Delete from End"<<endl<<"4. Delete using Data"<<endl<<"5. Reverse"<<endl<<"6. Exit";
	while (x != 6)
	{
		switch (x)
		{
		case(1) : cout << "you choose insert, enter data" << endl;
			cin >> data;
			obj.InsertatEnd(data);
			break;
		case(2) : cout << "display func" << endl;
			obj.DisplayList();
			break;
		case(3) : cout << "Delete from End" << endl;
			obj.DeleteFromEnd();
			break;
		case(4) : cout << "Delete using data, enter data to delete" << endl;
			cin >> data;
			obj.DeleteUsingData(data);
			break;
		case(5) : cout << "Reverse" << endl;
			obj.Reverse();
			break;

		}
		cout << "enter choice:: ";
		cin >> x;

	}
}