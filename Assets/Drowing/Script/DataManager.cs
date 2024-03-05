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
        if (!File.Exists(filepath)) {
            data = new SaveData();
            Debug.Log("ファイルがないので作成しました。");
            Save(data);
        }

        // ファイルを読み込んでdataに格納
        data = Load(filepath);          
    }

    //-------------------------------------------------------------------
    // jsonとしてデータを保存
    void Save(SaveData data)
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
        Save(data);
    }


    // 外部参照用関数群
    //--------------------------------------------------------------------
    // Resultのセット
    public void SetResults(int hiroppe = 0, int siba = 0, int keichan = 0, int tukkun = 0, int wattah = 0, int ron = 0){
        if (hiroppe != 0) data.results.Hiroppe = hiroppe;
        if (siba != 0) data.results.Siba = siba;
        if (keichan != 0) data.results.Keichan = keichan;
        if (tukkun != 0) data.results.Tukkun = tukkun;
        if (wattah != 0) data.results.Wattah = wattah;
        if (ron != 0) data.results.Ron = ron;
    }

    //--------------------------------------------------------------------
    // GraduateMembersのセット
    public void SetGraduateMembers(bool hiroppe = false, bool siba = false, bool keichan = false, bool tukkun = false, bool wattah = false){
        if (hiroppe) data.graduateMembers.Hiroppe = hiroppe;
        if (siba) data.graduateMembers.Siba = siba;
        if (keichan) data.graduateMembers.Keichan = keichan;
        if (tukkun) data.graduateMembers.Tukkun = tukkun;
        if (wattah) data.graduateMembers.Wattah = wattah;
    }

    //--------------------------------------------------------------------
    // NormalMembersのセット
    public void SetNormalMembers(
                                    int Ron = -1,
                                    int Riry = -1,
                                    int Kirari = -1,
                                    int Ebityan = -1,
                                    int Bikky = -1,
                                    int Kawasan = -1,
                                    int Yuripen = -1,
                                    int Sotoumi = -1,
                                    int Ke_sho_ = -1,
                                    int Ti_zu = -1,
                                    int Tomo = -1,
                                    int Kisumi = -1,
                                    int Mattu = -1,
                                    int Mosyu = -1,
                                    int Syake = -1,
                                    int Ponyo = -1,
                                    int Daodao = -1
                                )
    {
        if (Ron != -1) data.normalMembers.Ron = Ron;
        if (Riry != -1) data.normalMembers.Riry = Riry;
        if (Kirari != -1) data.normalMembers.Kirari = Kirari;
        if (Ebityan != -1) data.normalMembers.Ebityan = Ebityan;
        if (Bikky != -1) data.normalMembers.Bikky = Bikky;
        if (Kawasan != -1) data.normalMembers.Kawasan = Kawasan;
        if (Yuripen != -1) data.normalMembers.Yuripen = Yuripen;
        if (Sotoumi != -1) data.normalMembers.Sotoumi = Sotoumi;
        if (Ke_sho_ != -1) data.normalMembers.Ke_sho_ = Ke_sho_;
        if (Ti_zu != -1) data.normalMembers.Ti_zu = Ti_zu;
        if (Tomo != -1) data.normalMembers.Tomo = Tomo;
        if (Kisumi != -1) data.normalMembers.Kisumi = Kisumi;
        if (Mattu != -1) data.normalMembers.Mattu = Mattu;
        if (Mosyu != -1) data.normalMembers.Mosyu = Mosyu;
        if (Syake != -1) data.normalMembers.Syake = Syake;
        if (Ponyo != -1) data.normalMembers.Ponyo = Ponyo;
        if (Daodao != -1) data.normalMembers.Daodao = Daodao;
    }

    //--------------------------------------------------------------------
    // Dataの取得
    public Results GetData(){
        return data.results;
    }

    //--------------------------------------------------------------------
    // GraduateMembersの取得
    public GraduateMembers GetGraduateMembers(){
        return data.graduateMembers;
    }

    //--------------------------------------------------------------------
    // NormalMembersの取得
    public NormalMembers GetNormalMembers(){
        return data.normalMembers;
    }
}
