using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrowManager : MonoBehaviour
{
    // Start is called before the first frame update
    private DataManager dataManager;
    public TextMeshProUGUI enemyNameText;
    public TextMeshProUGUI challengerNameText;

    public GameObject[] explainTexts;
    public bool isDrwoing = false;

    private int preIndex = -1;
    void Start()
    {
        dataManager = GameObject.Find("_DataManager_").GetComponent<DataManager>();
        Drowing();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDrwoing)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isDrwoing = true;
                ReDrowing();
            }
        }

    }

    void OnDestroy()
    {
        dataManager.Save();
    }

    void Drowing()
    {
        // int[] ints = new int[17] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        // dataManager.SetNormalMembers(ints);

        isDrwoing = true;

        for (int i = 0; i < explainTexts.Length; i++)
        {
            explainTexts[i].SetActive(false);
        }

        Results results = dataManager.GetResults();
        NormalMembers normalMembers = dataManager.GetNormalMembers();
        string enemyName = "";
        string challengerName = "";
        challengerNameText.fontSize = 100;

        // 現在の敵約を探す
        for (int i = 0; i < results.value.Length; i++)
        {
            if (results.value[i] == -1)
            {
                enemyName = results.namesJp[i];
                challengerName = results.namesJp[i];
                break;
            }
        }

        // 一般メンバーの参加回数を確認
        int min = 1000;
        List<int> Mins = new List<int>();
        /// 最小値を探す
        for (int i = 0; i < normalMembers.value.Length; i++)
        {
            if (normalMembers.value[i] != -1 && min > normalMembers.value[i])
            {
                min = normalMembers.value[i];
                Mins.Clear();
                Mins.Add(i);
            }
            else if (normalMembers.value[i] != -1 && min == normalMembers.value[i])
            {
                Mins.Add(i);
            }
        }
        /// 最小値の中からランダムで選ぶ
        /// ただし，前回選んだメンバーは選ばない
        /// また，選ばれたメンバーの参加回数を加算する
        while (true)
        {
            int index = Random.Range(0, Mins.Count);
            if (Mins[index] != preIndex)
            {
                challengerName = normalMembers.namesJp[Mins[index]];
                dataManager.AddNormalMembers(Mins[index]);
                preIndex = Mins[index];
                break;
            }
        }

        enemyNameText.text = enemyName;
        StartCoroutine(rouletteAnimation(challengerName));

    }

    public void ReDrowing()
    {
        dataManager.SubNormalMembers(preIndex);
        Drowing();
    }

    private IEnumerator rouletteAnimation(string name)
    {
        NormalMembers normalMembers = dataManager.GetNormalMembers();
        int pindex;
        for (int i = 0; i < 30; i++)
        {
            while (true)
            {
                int index = Random.Range(0, normalMembers.value.Length);
                if (index != preIndex && normalMembers.value[index] != -1)
                {
                    pindex = index;
                    challengerNameText.text = normalMembers.namesJp[index];
                    break;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
        challengerNameText.text = name;
        challengerNameText.fontSize = 130;
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < explainTexts.Length; i++)
        {
            explainTexts[i].SetActive(true);
        }
        isDrwoing = false;
    }
}
