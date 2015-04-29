#include<string>
#include<iostream>
#include<fstream>
#include<vector>
using namespace std;

struct node
{
	char letter;
	int frequency;
	string code;
	node *left;
	node *right;
};

//Prototypes
void loadData();
void addToFrequencyTable(char);
void printCodeTable();
void getCode();
void traverse(node*, string);
node getTree();
node getMin();
void displayEncodedText();
void decompress();
void checkCodeTable(string&);
void findErrors();
void getCompressionRatio();

vector<node>myTable;
vector<node>codeTable;
ofstream outfileDecomp;

int main()
{
	loadData();
	getCode();
	printCodeTable();
	displayEncodedText();
	decompress();
	findErrors();
	getCompressionRatio();
	system("pause");
	return 0;
}

void loadData()
{
	char ch;
	ifstream infile;
	infile.open("Text_To_Encode.txt");
	while (!infile.eof())
	{
		infile >> noskipws >> ch;		//includes whitespaces for formatting purposes
		addToFrequencyTable(ch);
	}
	infile.close();
}

void addToFrequencyTable(char inputChar)
{
	bool success = false;
	vector<node>::iterator myIter;
	if (myTable.size() == 0)
	{
		node *temp = new node;
		temp->letter = inputChar;
		temp->frequency = 1;
		temp->left = NULL;
		temp->right = NULL;
		myTable.push_back(*temp);				//Add letter to the frequency table
	}
	else
	{
		for (myIter = myTable.begin(); myIter != myTable.end(); myIter++)
		{
			if ((*myIter).letter == inputChar)			//Compare each letter in the frequency table to the new letter in the file
			{
				(*myIter).frequency++;					//Increment the letter's frequency
				success = true;
			}
		}
		if (!success)
		{
			node *temp = new node;
			temp->letter = inputChar;
			temp->frequency = 1;
			temp->left = NULL;
			temp->right = NULL;
			myTable.push_back(*temp);				//Add letter to the frequency table
		}
	}
}

void getCode()
{
	cout << "Compressing..." << endl;
	node root = getTree();
	traverse(&root, "");
}

void traverse(node *root, string str)
{
	node *temp = new node;
	node *temp2 = new node;
	root->code = str;

	if (root == NULL)
	{
	}
	else if (root->left != NULL || root->right != NULL)
	{
		str += "0";
		root->left->code = str;
		str.erase(str.end() - 1);

		str += "1";
		root->right->code = str;
		str.erase(str.end() - 1);

		traverse(root->left, str.append("0"));
		str.erase(str.end() - 1);
		traverse(root->right, str.append("1"));
		str.erase(str.end() - 1);
		
		temp->letter = root->left->letter;
		temp->frequency = root->left->frequency;
		temp->code = root->left->code;
		codeTable.push_back(*temp);
		temp2->letter = root->right->letter;
		temp2->frequency = root->right->frequency;
		temp2->code = root->right->code;
		codeTable.push_back(*temp2);
	}
}

node getTree()
{
	while (!myTable.empty())
	{
		node *tempCombo = new node;
		node *tempLeft = new node;
		node *tempRight = new node;

		*tempLeft = getMin();
		*tempRight = getMin();

		tempCombo->left = tempLeft;
		tempCombo->right = tempRight;
		tempCombo->frequency = tempLeft->frequency + tempRight->frequency;
		myTable.push_back(*tempCombo);

		if (myTable.size() == 1)
		{ break; }
	}
	return myTable[0];
}

void printCodeTable()
{
	ofstream outfileCode;
	outfileCode.open("Huffman Code Table.txt");

	vector<node>::iterator myIter;

	outfileCode << "Letter\tFrequency\tCode" << endl;
	outfileCode << "------\t---------\t----" << endl;
	for (myIter = codeTable.begin(); myIter != codeTable.end(); myIter++)
	{
		if (myIter->letter != 'Í')
			outfileCode << myIter->letter << "\t" << myIter->frequency << "\t\t" << myIter->code << endl;
	}
	outfileCode.close();
}

void displayEncodedText()
{
	char ch;
	ifstream infile;
	infile.open("Text_To_Encode.txt");
	ofstream outfile;
	outfile.open("Huffman_Compressed.txt");
	vector<node>::iterator myIter;

	while (!infile.eof())
	{
		infile >> noskipws >> ch;		//includes whitespaces for formatting purposes
		for (myIter = codeTable.begin(); myIter != codeTable.end(); myIter++)
		{
			if (myIter->letter == ch)
			{
				outfile << myIter->code;
				break;
			}
		}
	}
	infile.close();
	outfile.close();
	cout << "Done compressing!" << endl;
}

node getMin()
{
	double tempNum = 99999;
	vector<node>::iterator myIter, index;
	for (myIter = myTable.begin(); myIter != myTable.end(); myIter++)
	{
		if (tempNum > (*myIter).frequency)
		{
			index = myIter;
			tempNum = (*myIter).frequency;
		}
	}
	node tempNode = *index;
	myTable.erase(index);

	return tempNode;
}

void decompress()
{
	char ch;
	string str = "";
	ifstream infile;
	infile.open("Huffman_Compressed.txt");
	outfileDecomp.open("Huffman_Decompressed.txt");	

	cout << "Decompressing..." << endl;
	while (!infile.eof())
	{
		infile >> ch;
		if (infile.eof()) { break; }
		str += ch;
		checkCodeTable(str);
	}
	outfileDecomp.close();
	cout << "Done decompressing!" << endl;
}

void checkCodeTable(string &str)
{
	vector<node>::iterator myIter;

	for (myIter = codeTable.begin(); myIter != codeTable.end(); myIter++)
	{
		if (str == myIter->code && myIter->letter != 'Í')
		{
			outfileDecomp << myIter->letter;
			str = "";
			break;
		}
	}
}

void findErrors()
{
	char ch1;
	char ch2;
	bool found = false;
	ifstream infile1;
	infile1.open("Text_To_Encode.txt");
	ifstream infile2;
	infile2.open("Huffman_Decompressed.txt");
	
	cout << endl << "Error List" << endl;
	cout << "----------" << endl;
	while (!infile1.eof())
	{
		infile1 >> noskipws >> ch1;
		infile2 >> noskipws >> ch2;
		if (ch1 != ch2)
		{
			cout << ch2 << " should be " << ch1 << endl;
			found = true;
		}
	}
	if (!found)
		cout << "No errors found!" << endl << endl;
	infile1.close();
	infile2.close();
}

void getCompressionRatio()
{
	ifstream infile1;
	infile1.open("Text_To_Encode.txt");
	ifstream infile2;
	infile2.open("Huffman_Compressed.txt");
	int originalLength = 0;
	int compressedLength = 0;
	char ch;

	while (!infile1.eof())
	{
		infile1 >> ch;
		originalLength++;
	}
	while (!infile2.eof())
	{
		infile2 >> ch;
		compressedLength++;
	}
	originalLength *= 8;
	
	
	cout << "Size of \"Text_To_Encode.txt\": " << originalLength << " bits" << endl;
	cout << "Size of \"Huffman_Compressed.txt\": " << compressedLength << " bits" << endl;
	cout << "Compression Ratio: " << static_cast<double>(compressedLength) / originalLength << endl << endl;
}