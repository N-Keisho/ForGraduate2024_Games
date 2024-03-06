using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ParamsSOhiroppe : ScriptableObject
{
    //参考動画：https://www.youtube.com/watch?v=TDigH2y6p44

    public GameObject item_hiroppe;
    public int damage_hiroppe;

    ////MyScriptableObjectが保存してある場所のパス
    //public const string PATH = "ParamsSOhiroppe";

    ////MyScriptableObjectの実体
    //private static ParamsSOhiroppe _entity;
    //public static ParamsSOhiroppe Entity
    //{
    //    get
    //    {
    //        //初アクセス時にロードする
    //        if (_entity == null)
    //        {
    //            _entity = Resources.Load<ParamsSOhiroppe>(PATH);

    //            //ロード出来なかった場合はエラーログを表示
    //            if (_entity == null)
    //            {
    //                Debug.LogError(PATH + " not found");
    //            }
    //        }

    //        return _entity;
    //    }
    //}

    //保存されているデータ
    //public int IntData = 10;
}
