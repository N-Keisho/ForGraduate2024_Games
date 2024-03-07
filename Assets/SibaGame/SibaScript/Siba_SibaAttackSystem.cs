using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Siba_SibaAttackSystem : MonoBehaviour
{
    public Siba_GameManager ShibaGM;
    [SerializeField] private GameObject ShibaSakuraManager,
                                        ShibaSakuraPrefab,
                                        Honobono1,
                                        Honobono2,
                                        ShibaPlayer;
    // Start is called before the first frame update
    void Update()
    {
        if(ShibaGM.ShibaisAttackTrigger1)
        {
            SibaAttack();
        }
    }

    void SibaAttack()
    {
        if(ShibaGM.ShibaBarrageGaugeValue1 > 20 && ShibaGM.ShibaBarrageGaugeValue1 <= 60)
        {
            StartCoroutine("AttackSystem");
        }   
        if(ShibaGM.ShibaBarrageGaugeValue1 <= 20)//ゲージが20以下ならほのぼのじいじいをオンにする
        {
            Honobono1.SetActive(true);
            Honobono2.SetActive(true);
            ShibaGM.ShibaisAttackTrigger1 = false;
        }
    }

    IEnumerator AttackSystem()
    {
        for (int i = 0; i < 3; i++)
        {
        GameObject sakura = Instantiate(ShibaSakuraPrefab) as GameObject;
        sakura.transform.position = ShibaSakuraManager.transform.position;
        // sakuraをプレイヤーの方向に向けるベクトル
        Vector3 targetDirection = ShibaPlayer.transform.position - sakura.transform.position;
        targetDirection.Normalize(); // 方向ベクトルを正規化

        float forceMagnitude = 80.0f; 
        Vector3 force = targetDirection * forceMagnitude;
        sakura.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        ShibaGM.ShibaisAttackTrigger1 = false;
        //Vector3 force = new Vector3(0, 0, -30.0f);
        //sakura.GetComponent<Rigidbody> ().AddForce (force, ForceMode.Impulse);
        Debug.Log("sibaattack");
        yield return new WaitForSeconds(0.5f);
        }
        ShibaGM.ShibaisAttackTrigger1 = false;
    }
}
