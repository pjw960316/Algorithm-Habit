#include <string>
#include <vector>
#include <map>
#include <iostream>
#include <cmath>
using namespace std;

map<string,vector<int>> m;
vector<int> solution(vector<int> fees, vector<string> records) 
{
    vector<int> answer;
    vector<int> v;
    for(auto str : records)
    {
        //시간 계산
        int hour = stoi(str.substr(0,2));
        int minute = stoi(str.substr(3,2));
        int time = hour * 60 + minute;
        
        //차번호
        string car_num = str.substr(6,4);
        
        if(m.find(car_num) == m.end())
        {
            v.clear(); //혹시 모르니
            m.insert({car_num , v});
            m[car_num].push_back(time);
        }
        else
        {
            m[car_num].push_back(time);
        }
    }
    for(auto& i : m)
    {
        if((i.second.size()) % 2 == 1)
        {
            i.second.push_back(23*60 + 59);
        }
    }
    
    /*for(auto i : m)
    {
        cout <<  "차번호 " << i.first << " : ";
        for(auto j : i.second)
        {
            cout << j << " ";
        }
        cout << "\n";
    }*/
    
    for(auto i : m)
    {
        int cnt = 0;
        int time = 0;
        int money = 0;
        for(auto j : i.second)
        {
            if(cnt % 2 == 0)
            {
                time -= j;                
            }
            else
            {
                time += j;
            }
            cnt++;            
        }
        
        //가격
        money = fees[1];
        //기본 요금
        if(time <= fees[0])
        {
            answer.push_back(money);
        }
        else
        {
            cout << time << " ";
            cout << ceil((float)(time - fees[0]) / (float)fees[2]) << "\n";
            money += ceil((float)(time - fees[0]) / (float)fees[2]) * fees[3];
            answer.push_back(money);
        }
    }
   
    return answer;
}