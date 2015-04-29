#include<iostream>
#include<string>
#include<vector>
#include<fstream>
#include<map>
using namespace std;

//Prototypes
void displayCodeTable();
void decompress();
void checkCodeTable(int);
void findErrors();
void getCompressionRatio();

map<int, string> codeTable;
map<int, string> codeTableDecomp;
map<int, string>::iterator myIter;
ofstream outfileDecomp;

int main()
{
	ifstream infile;
	infile.open("Text_To_Encode.txt");
	ofstream outfile;
    outfile.open("LZW_Compressed.txt");
	char tempChar, c;
	string str, tempStr, t, buffer;
	int i = 1, codeIndex = 0;
	bool inTable = false;
	int codeSize;

	cout << "Compressing..." << endl;

	for (int k = 1; k < 128; k++)
	{
		t = static_cast<char>(k);
		
		codeTable.insert(pair<int, string>(k, static_cast<string>(t)));
		codeTableDecomp.insert(pair<int, string>(k, static_cast<string>(t)));
	}

	while (!infile.eof())
	{
		infile >> noskipws >> tempChar;
		str += tempChar;
	}
	
	buffer = str[0];

	while (i < str.length())
	{
		c = str[i];
		tempStr = buffer + c;
		for (myIter = codeTable.begin(); myIter != codeTable.end(); myIter++)
		{
			if (myIter->second == tempStr)
			{
				inTable = true;
			}
		}
		if (inTable)
		{
			buffer = tempStr;
			inTable = false;
		}
		else
		{
			//send code associate with buffer
			for (myIter = codeTable.begin(); myIter != codeTable.end(); myIter++)
			{
				if (myIter->second == buffer)
				{
					outfile << myIter->first << " ";
					//Assign code to tempStr
					codeSize = codeTable.size() + 1;
					//tempStr = myIter->second;
					break;
				}
			}
			//Store both in codeTable
			codeTable.insert(pair<int, string>(codeSize, tempStr));
			buffer = c;
		}
		i++;
	}
	//Send code associate with buffer
	for (myIter = codeTable.begin(); myIter != codeTable.end(); myIter++)
	{
		if (myIter->second == buffer)
		{
			outfile << myIter->first;
			break;
		}
	}
	outfile.close();
	infile.close();
	
	displayCodeTable();
	cout << "Done compressing!" << endl;
	decompress();
	findErrors();
	getCompressionRatio();
	system("pause");
	return 0;
}

void displayCodeTable()
{
	ofstream outfile;
    outfile.open("LZW Code Table.txt");
	for (myIter = codeTable.begin(); myIter != codeTable.end(); myIter++)
	{
		outfile << myIter->first << "   " << myIter->second << endl;
	}
	outfile.close();
}

void decompress()
{
	ifstream infile;
	infile.open("LZW_Compressed.txt");
	outfileDecomp.open("LZW_Decompressed.txt");
	int prior, current, codeSize;
	char c;
	string tempStr, tempc;
	bool inTable = false;

	cout << "Decompressing..." << endl;
	infile >> prior;
	//Print string associated with prior
	for (myIter = codeTableDecomp.begin(); myIter != codeTableDecomp.end(); myIter++)
	{
		if (myIter->first == prior)
		{
			outfileDecomp << myIter->second;
			break;
		}
	}
	while (true)
	{	
		if (!infile.eof())
			infile >> current;
		else
			break;
		for (myIter = codeTableDecomp.begin(); myIter != codeTableDecomp.end(); myIter++)
		{
			if (myIter->first == current)
			{
				inTable = true;
				break;
			}
		}
		if (infile.eof()) { break; }
		
		if (!inTable)
		{
			for (myIter = codeTableDecomp.begin(); myIter != codeTableDecomp.end(); myIter++)
			{
				if (myIter->first == prior)
				{
					//c = first char of string associated with with prior
					c = myIter->second[0];
					tempStr = myIter->second + c;
					//Assign a code to tempStr
					codeSize = codeTable.size() + 1;
					break;
				}
			}
			//Store both in codeTable
			codeTableDecomp.insert(pair<int, string>(codeSize, tempStr));
			outfileDecomp << tempStr;
		}
		else
		{
			for (myIter = codeTableDecomp.begin(); myIter != codeTableDecomp.end(); myIter++)
			{
				if (myIter->first == current)
				{
					//c = first char of string associated with with current
					tempc = myIter->second;
					c = tempc[0];
					break;
				}
			}
			for (myIter = codeTableDecomp.begin(); myIter != codeTableDecomp.end(); myIter++)
			{
				if (myIter->first == prior)
				{
					tempStr = myIter->second + c;
					//Assign a code to tempStr
					codeSize = codeTableDecomp.size() + 1;	
					break;
				}
			}
			//Store both in codeTable
			codeTableDecomp.insert(pair<int, string>(codeSize, tempStr));
			for (myIter = codeTableDecomp.begin(); myIter != codeTableDecomp.end(); myIter++)
			{
				if (myIter->first == current)
				{
					outfileDecomp << myIter->second;
					break;
				}
			}
		}
		prior = current;
	}
	outfileDecomp.close();
	cout << "Done decompressing!" << endl;
}

void checkCodeTable(int code)
{
	for (myIter = codeTable.begin(); myIter != codeTable.end(); myIter++)
	{
		if (myIter->first == code)
		{
			outfileDecomp << myIter->second;
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
	infile2.open("LZW_Decompressed.txt");
	
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
	infile2.open("LZW_Compressed.txt");
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
	compressedLength *= 8;
	
	cout << "Size of \"Text_To_Encode.txt\": " << originalLength << " bits" << endl;
	cout << "Size of \"LZW_Compressed.txt\": " << compressedLength << " bits" << endl;
	cout << "Compression Ratio: " << static_cast<double>(compressedLength) / originalLength << endl << endl;
}