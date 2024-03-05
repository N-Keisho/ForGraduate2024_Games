using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [HideInInspector] private SaveData data;     // json変換するデータのクラス
    string filepath;                            // jsonファイルのパス
    string fileName = "Data.json";              // jsonファイル名

    //-------------------------------------------------------------------
    // 開始時にファイルチェック、読み込み
    void Awake()
    {
        // パス名取得
        filepath = Application.dataPath + "/Drowing/Script/" + fileName;

        // ファイルがないとき、ファイル作成
        if (!File.Exists(filepath))
        {
            data = new SaveData();
            Debug.Log("ファイルがないので作成しました。");
            Save();
        }

        // ファイルを読み込んでdataに格納
        data = Load(filepath);
    }

    //-------------------------------------------------------------------
    // jsonとしてデータを保存
    public void Save()
    {
        string json = JsonUtility.ToJson(data);                 // jsonとして変換
        StreamWriter wr = new StreamWriter(filepath, false);    // ファイル書き込み指定
        wr.WriteLine(json);                                     // json変換した情報を書き込み
        wr.Close();                                             // ファイル閉じる
    }

    // jsonファイル読み込み
    SaveData Load(string path)
    {
        StreamReader rd = new StreamReader(path);               // ファイル読み込み指定
        string json = rd.ReadToEnd();                           // ファイル内容全て読み込む
        rd.Close();                                             // ファイル閉じる

        return JsonUtility.FromJson<SaveData>(json);            // jsonファイルを型に戻して返す
    }

    //-------------------------------------------------------------------
    // ゲーム終了時に保存
    void OnDestroy()
    {
        Save();
    }


    // 外部参照用関数群
    //--------------------------------------------------------------------

    /// <summary>
    /// ゲームの結果をセットする．指定がない場合は結果を変更しない．
    /// </summary>
    public void SetResults(int hiroppe = 0, int siba = 0, int keichan = 0, int tukkun = 0, int wattah = 0, int ron = 0)
    {
        if (hiroppe != 0) data.results.value[0] = hiroppe;
        if (siba != 0) data.results.value[1] = siba;
        if (keichan != 0) data.results.value[2] = keichan;
        if (tukkun != 0) data.results.value[3] = tukkun;
        if (wattah != 0) data.results.value[4] = wattah;
        if (ron != 0) data.results.value[5] = ron;
    }

    //--------------------------------------------------------------------

    /// <summary>
    /// 卒業生のメンバーの出席状況をセットする．指定がない場合は変更しない．
    /// </summary>
    public void SetGraduateMembers(GraduateMembers graduateMembers)
    {
        data.graduateMembers = graduateMembers;
        Save();
    }

    //--------------------------------------------------------------------

    /// <summary>
    /// // 通常生のメンバーの出席状況とゲーム参加回数をセットする．指定がない場合は変更しない．
    /// </summary>
    public void SetNormalMembers(NormalMembers normalMembers)
    {
        data.normalMembers = normalMembers;
        Save();
    }

    //--------------------------------------------------------------------

    /// <summary>
    /// 通常生のメンバーのゲーム参加回数を加算する
    /// </summary>
    /// <param name="index">int</param>
    public void AddNormalMembers(int index)
    {
        data.normalMembers.value[index]++;
    }

    //--------------------------------------------------------------------

    /// <summary>
    /// 通常メンバーのゲーム参加回数を減産する
    /// </summary>
    /// <param name="index">int</param>
    public void SubNormalMembers(int index)
    {
        data.normalMembers.value[index]--;
    }

    //--------------------------------------------------------------------

    /// <summary>
    ///  ゲームの結果を取得
    /// </summary>
    public Results GetResults()
    {
        return data.results;
    }

    //--------------------------------------------------------------------

    /// <summary>
    /// 卒業生のメンバーの出席状況を取得
    /// </summary>
    public GraduateMembers GetGraduateMembers()
    {
        return data.graduateMembers;
    }

    //--------------------------------------------------------------------

    /// <summary>
    /// 通常生のメンバーの出席状況とゲーム参加回数を取得
    /// </summary>
    public NormalMembers GetNormalMembers()
    {
        return data.normalMembers;
    }
}
