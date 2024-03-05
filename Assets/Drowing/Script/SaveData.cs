using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Results
{
    // 0: yet, 1: win, 2: lose, 3: draw, -1: now
	public int Hiroppe;
    public int Siba;
    public int Keichan;
    public int Tukkun;
    public int Wattah;
    public int Ron;
}

[System.Serializable]
public class GraduateMembers
{
    // false：不参加, true：参加
    public bool Hiroppe;
    public bool Siba;
    public bool Keichan;
    public bool Tukkun;
    public bool Wattah;
}

[System.Serializable]
public class NormalMembers
{
    // -1：不参加：, 0以上：ゲーム参加回数
    public int Ron;
    public int Riry;
    public int Kirari;
    public int Ebityan;
    public int Bikky;
    public int Kawasan;
    public int Yuripen;
    public int Sotoumi;
    public int Ke_sho_;
    public int Ti_zu;
    public int Tomo;
    public int Kisumi;
    public int Mattu;
    public int Mosyu;
    public int Syake;
    public int Ponyo;
    public int Daodao;
}


[System.Serializable]
public class SaveData
{
    // ゲームの結果
    public Results results = new Results(){
        // 0: yet, 1: win, 2: lose, 3: draw, -1: now
        Hiroppe = 0,
        Siba = 0,
        Keichan = 0,
        Tukkun = 0,
        Wattah = 0,
        Ron = 0,
    
    };

    // 卒業メンターの参加状況
    public GraduateMembers graduateMembers = new GraduateMembers(){
        // false：不参加, true：参加
        Hiroppe = false,
        Siba = false,
        Keichan = false,
        Tukkun = false,
        Wattah = false,
    };

    // 通常メンターの参加回数
    public NormalMembers normalMembers = new NormalMembers(){
        // -1：不参加：, 0以上：ゲーム参加回数
        Ron = -1,
        Riry = -1,
        Kirari = -1,
        Ebityan = -1,
        Bikky = -1,
        Kawasan = -1,
        Yuripen = -1,
        Sotoumi = -1,
        Ke_sho_ = -1,
        Ti_zu = -1,
        Tomo = -1,
        Kisumi = -1,
        Mattu = -1,
        Mosyu = -1,
        Syake = -1,
        Ponyo = -1,
        Daodao = -1,
    };
}
