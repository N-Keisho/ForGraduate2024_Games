using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Results{
    // ゲームの結果
    // 0: yet, 1: win, 2: lose, 3: draw, -1: now
    public int[] value = new int[6] { -1, 0, 0, 0, 0, 0 };
    public string[] names = new string[6] { "Hiroppe", "Siba", "Keichan", "Tukkun", "Wattah", "Ron" };
    public string[] namesJp = new string[6] { "ひろっぺ", "しば", "けいちゃん", "つっくん", "わったー", "ろん" };
}

[System.Serializable]
public class GraduateMembers
{
    // 卒業生の参加状況
    // false：不参加, true：参加
    public bool[] value = new bool[5] { true, true, true, true, true};
    public string[] names = new string[5] { "Hiroppe", "Siba", "Keichan", "Tukkun", "Wattah" };
    public string[] namesJp = new string[5] { "ひろっぺ", "しば", "けいちゃん", "つっくん", "わったー" };
}

[System.Serializable]
public class NormalMembers
{
    // 一般メンバーの参加回数
    // -1：不参加：, 0以上：ゲーム参加回数
    public int[] value = new int[22] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1};
    public string[] names = new string[22] { "Ron", "Riry", "Kirari", "Ebityan", "Bikky", "Kawasan", "Yuripen", "Sotoumi", "Ke-sho", "Ti-zu", "Tomo", "Kisumi", "Mattu", "Mosyu", "Syake", "Ponyo", "Daodao", "Anbeco","Hori", "Kisshy", "GuestA", "GuestB"};
    public string[] namesJp = new string[22] { "ろん", "りりー", "きらり", "えびちゃん", "びっきー", "かわさん", "ゆりぺん", "そとうみ", "けーしょー", "ちーず", "とも", "きすみ", "まっつー", "もしゅ", "しゃけ", "ぽにょ", "だおだお", "あんべこ", "ほりー", "きっしー", "ゲストA", "ゲストB"};
}

[System.Serializable]
public class SaveData
{
    public Results results = new Results();
    public GraduateMembers graduateMembers = new GraduateMembers();
    public NormalMembers normalMembers = new NormalMembers();
}
