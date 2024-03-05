using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Results{
    // ゲームの結果
    // 0: yet, 1: win, 2: lose, 3: draw, -1: now
    public int[] value = new int[6] { 0, 0, 0, 0, 0, 0 };
    public string[] names = new string[6] { "Hiroppe", "Siba", "Keichan", "Tukkun", "Wattah", "Ron" };
    public string[] namesJp = new string[6] { "ひろっぺ", "しば", "けいちゃん", "つっくん", "わったー", "ろん" };
}

[System.Serializable]
public class GraduateMembers
{
    // 卒業生の参加状況
    // false：不参加, true：参加
    public bool[] value = new bool[5] { false, false, false, false, false };
    public string[] names = new string[5] { "Hiroppe", "Siba", "Keichan", "Tukkun", "Wattah" };
    public string[] namesJp = new string[5] { "ひろっぺ", "しば", "けいちゃん", "つっくん", "わったー" };
}

[System.Serializable]
public class NormalMembers
{
    // 一般メンバーの参加回数
    // -1：不参加：, 0以上：ゲーム参加回数
    public int[] value = new int[19] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    public string[] names = new string[19] { "Ron", "Riry", "Kirari", "Ebityan", "Bikky", "Kawasan", "Yuripen", "Sotoumi", "Ke-sho", "Ti-zu", "Tomo", "Kisumi", "Mattu", "Mosyu", "Syake", "Ponyo", "Daodao", "Hori", "Kisshy"};
    public string[] namesJp = new string[19] { "ろん", "りりー", "きらり", "えびちゃん", "びっきー", "かわさん", "ゆりぺん", "そとうみ", "けーしょー", "ちーず", "とも", "きすみ", "まっつー", "もしゅ", "しゃけ", "ぽにょ", "だおだお", "ほりー","きっしー"};
}

[System.Serializable]
public class SaveData
{
    public Results results = new Results();
    public GraduateMembers graduateMembers = new GraduateMembers();
    public NormalMembers normalMembers = new NormalMembers();
}
