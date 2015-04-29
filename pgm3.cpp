//Adam Young
//Program 3
//10/23/2013
//This program encrypts a message and allows the user to find clues to revealing the hidden message.

#include <iostream>
#include <iomanip>
#include <list>
#include <string>
#include <algorithm>
#include <cstdlib>
#include <ctime>
using namespace std;

//Prototypes
int clue1(list<string> listClue1);	//Returns a char where "Linky" was found
int clue2(list<char> listClue2, char c1);	//Returns an int where the char from clue 1 was returned
int clue3(list<int> listClue3, int index);	//Returns an int from the bottom of the list using the int from clue 2 that was returned
unsigned long clue4 (list<unsigned long> listClue4, int index2);	//Returns the saftey deposit combination from the int from clue 3 that was returned

int main()
{
	list<string>listClue1;
	list<char>listClue2;
	list<int>listClue3;
	list<unsigned long>listClue4;
	list<string>::iterator iterStr;
	list<char>::iterator iterChar;
	list<int>:: iterator iterInt;
	list<unsigned long>:: iterator iterLong;

	char name[] = {'l', 'i', 'n', 'k', 'y'};
	char c1;
	int index = 0;
	int index2;
	unsigned long code;
	
	int randPos;
	string message[] = {"Search", "the", "lists", "for", "clues", "to", "the", "deposit", "box", "combination"};
	
	srand(time(NULL));
	randPos = rand()%10;
	message[randPos] = name;

	//Fill the list for Clue 1
	for(int i = 0; i < 10; i++)
	{
		int sub = 0;
		sub = rand()%10;
		listClue1.push_back(message[sub]);
	}	

	//Output menu for Clue 1
	cout << "##------------------------------##" << endl;
	cout << "        Clue 1 List" << endl;
	cout << "##------------------------------##" << endl;

	int i;
	//Display list for Clue 1
	for (iterStr = listClue1.begin(); iterStr != listClue1.end(); iterStr++)
	{
		cout << "  " << i << setw(20) << *iterStr << endl;
		i++;
	}

	cout << "----------------------------------" << endl;

	//Call Clue 1 finder function
	index = clue1(listClue1);

	if (index >= 5)
		c1 = name[index % 5];
	else
		c1 = name[index];

	cout << "Clue 1 - 'Linky' found in location " << index << " in the first list." << endl;

	cout << "##------------------------------##" << endl << endl;

	//Fill list for Clue 2
	for(int i = 0; i < 10; i++)
	{
		int sub = 0;
		sub = rand() % 5;
		listClue2.push_back(name[sub]);
	}

	//Output menu for Clue 2
	cout << "##------------------------------##" << endl;
	cout << "        Clue 2 List" << endl;
	cout << "##------------------------------##" << endl;

	i = 0;

	//Display list for Clue 2
	for (iterChar = listClue2.begin(); iterChar != listClue2.end(); iterChar++)
	{
		cout << "  " << i << setw(20) << *iterChar << endl;
		i++;
	}

	cout << "----------------------------------" << endl;

	//Call Clue 2 finder function
	index = clue2(listClue2, c1);
	cout << "Clue 2 - letter '" << c1 << "' found in position " << index << endl;

	cout << "##------------------------------##" << endl << endl;

	//Fill list for Clue 3
	for (int i = 0; i < 10; i++)
	{
		int sub = 0;
		sub = rand() % 25;
		listClue3.push_back(sub);
	}

	//Output menu for Clue 3
	cout << "##------------------------------##" << endl;
	cout << "        Clue 3 List" << endl;
	cout << "##------------------------------##" << endl;

	i = 0;

	//Display list for Clue 3
	for (iterInt = listClue3.begin(); iterInt != listClue3.end(); iterInt++)
	{
		cout << "  " << i << setw(20) << *iterInt << endl;
		i++;
	}

	cout << "----------------------------------" << endl;

	//Call Clue 3 finder function
	index2 = clue3(listClue3, index);
	cout << "Clue 3 - number found is " << index2 << endl;

	cout << "##------------------------------##" << endl << endl;


	//Fill list for Clue 4
	for (int i = 0; i < 25; i++)
	{
		unsigned long sub = 0;
		sub = (unsigned long)rand() * 123456789 + 100000000;
		listClue4.push_back(sub);
	}

	//Output menu for Clue 4
	cout << "##------------------------------##" << endl;
	cout << "        Clue 4 List" << endl;
	cout << "##------------------------------##" << endl;

	i = 0;

	//Sort list from highest to lowest
	listClue4.sort();
	listClue4.reverse();

	//Display list for Clue 4
	for (iterLong = listClue4.begin(); iterLong != listClue4.end(); iterLong++)
	{
		if (i < 10)
		{
			cout << "  " << i << setw(20) << fixed << right << *iterLong << endl;
			i++;
		}
		else
		{
			cout << "  " << i << setw(19) << fixed << right << *iterLong << endl;
			i++;
		}
	}

	cout << "----------------------------------" << endl;

	//Call Clue 4 finder function
	code = clue4(listClue4, index2);
	cout << "Clue 4 - the " << index2 << " largest number and combination " << endl;
	cout << "for the safe deposit box is " << code << endl;

	cout << "##------------------------------##" << endl << endl;

	system("pause");
	return 0;
}

int clue1(list<string> listClue1) 
{
	list<string>::reverse_iterator rit;
	int index = 9;

	for (rit = listClue1.rbegin() ; rit != listClue1.rend(); ++rit)
	{
		if (*rit == "linky")
			return index;
		index--;
	}
}

int clue2(list<char> listClue2, char c1)
{
	list<char>::reverse_iterator rit;
	int index = 9;

	for (rit = listClue2.rbegin() ; rit != listClue2.rend(); ++rit)
	{
		if (*rit == c1)
			return index;
		index--;
	}
}

int clue3(list<int> listClue3, int index)
{
	list<int>::reverse_iterator rit;
	int index2 = 9;

	for (rit = listClue3.rbegin() ; rit != listClue3.rend(); ++rit)
	{
		if (index2 == 9 - index)
			return *rit;
		index2--;
	}
}

unsigned long clue4(list<unsigned long> listClue4, int index2)
{
	list<unsigned long>::iterator iter;
	int index3 = 0;

	for (iter = listClue4.begin(); iter != listClue4.end(); iter++)
	{
		if(index3 == index2 - 1)
			return *iter;
		index3++;
	}
}