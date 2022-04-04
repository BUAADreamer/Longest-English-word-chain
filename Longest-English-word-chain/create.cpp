#include <bits/stdc++.h>

using namespace std;

const int N = 25;
const int LEN = 5;

int main() {
    string res;
	srand(time(NULL));
    for (int i = 0; i < N; i++) {
		int len = rand() % LEN + 1;
    	string cur;
		cur += (i + 'a');
		for (int j = 0; j < len; j++) {
			cur += ('a' + (rand() % (25 - i)) + i);
		}
		cout << cur << endl;	
	} 
	return 0;
}
