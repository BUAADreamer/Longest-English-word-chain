#include <bits/stdc++.h>

using namespace std;

bool check(int idx) {
    if (idx == 0) {
        int cnt1 = 0, cnt2 = 0;
        FILE *fp1 = fopen("me.txt", "r");
        fscanf(fp1, "%d", &cnt1);
        fclose(fp1);
        FILE *fp2 = fopen("solution.txt", "r");
        fscanf(fp2, "%d", &cnt2);
        fclose(fp2);
        return cnt1 == cnt2;
    } else if (idx == 1 || idx == 3) {
        int cnt1 = 0, cnt2 = 0;
        char s1[100], s2[100];
        FILE *fp2 = fopen("solution.txt", "r");
        while (~fscanf(fp2, "%s", s2)) {
            cnt2++;
            if (s2[0] == '\n') {
                cnt2--;
            }
        }
        fclose(fp2);
        FILE *fp1 = fopen("me.txt", "r");
        while (~fscanf(fp1, "%s", s1)) {
            cnt1++;
            if (s1[0] == '\n') {
                cnt1--;
            }
        }
        fclose(fp1);
        return cnt1 == cnt2;
    } else {
        int cnt1 = 0, cnt2 = 0;
        FILE *fp1 = fopen("me.txt", "r");
        char s1[100], s2[100];
        while (~fscanf(fp1, "%s", s1)) {
            cnt1 += strlen(s1);
            if (s1[0] == '\n') {
                cnt1--;
            }
        }
        FILE *fp2 = fopen("solution.txt", "r");
        while (~fscanf(fp2, "%s", s2)) {
            cnt2 += strlen(s2);
            if (s2[0] == '\n') {
                cnt2--;
            }
        }
        fclose(stdin);
        return cnt1 == cnt2;
    } 
}

int main() {
    srand(time(NULL));
    string args[10] = {"-n", "-m", "-c", "-w", "-r", "-h", "-t"};
    system("g++ create.cpp -o create.exe");
    int cnt = 0;
    while (true) {
        string arg;
        int idx = rand() % 4; 
        arg += args[idx];
		if (idx == 2 || idx == 3) {
			int a = rand(), b = rand();
			if (a > b) {
				arg += " -r ";
			}
		}
		if (idx > 1) {
			int a = rand(), b = rand();
			if (a > b) {
				arg += " -h ";
				arg += ('a' + rand() % 26);
				arg += " ";
			}
			a = rand();
			b = rand();
			if (a > b) {
				arg += " -t ";
				arg += ('a' + rand() % 26);
				arg += "";
			}
		}
        arg += " ";
        arg += ".\\in.txt ";
        string arg1 = ".\\me.exe " + arg + "> me.txt";
        string arg2 = ".\\other.exe " + arg;
        system(".\\create.exe > in.txt");
        system(arg2.c_str());
        system(arg1.c_str());
        
        cout << "command: " << arg << endl;
        if (!check(idx)) {
            cout << "fuck" << endl;
            system("pause");
			break;
        } else {
            cout << "test" + to_string(cnt) + " pass" << endl;
            cnt++;
        }
    }
    return 0;
}
