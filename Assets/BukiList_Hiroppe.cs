using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BukiList_Hiroppe : MonoBehaviour
{
    //名前とダメージはリストの順序と一致させる
    public List<string> nameList1_hiroppe = new List<string>()
    {
        {"beer1_hiroppe"},
        {"kora1_hiroppe"},
        {"tomato1_hiroppe"},
        {"sword1_hiroppe"},
    };

    public List<string> nameList2_hiroppe = new List<string>()
    {
        {"beer2_hiroppe"},
        {"kora2_hiroppe"},
        {"tomato2_hiroppe"},
        {"sword2_hiroppe"},
    };

    public List<int> damageList_hiroppe = new List<int>()
    {
        {-1},
        {-5},
        {+10},
        {-7},
    };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
