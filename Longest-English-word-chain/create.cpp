#include <bits/stdc++.h>

using namespace std;

const int N = 500;

int main() {
    string res;
    for (int i = 0; i < N; i++) {
        res += (char)(rand() % 96 + 31);
    } 
    cout << res << endl;
    return 0;
}