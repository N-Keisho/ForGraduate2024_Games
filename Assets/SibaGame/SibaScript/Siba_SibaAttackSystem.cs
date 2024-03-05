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
                                        Honobono2;
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
            for (int i = 0; i < 3; i++)
            {
                GameObject sakura = Instantiate(ShibaSakuraPrefab) as GameObject;
                sakura.transform.position = ShibaSakuraManager.transform.position;
                Vector3 force = new Vector3(0, 0, -30.0f);
                sakura.GetComponent<Rigidbody> ().AddForce (force, ForceMode.Impulse);
                Debug.Log("sibaattack");
            }
            ShibaGM.ShibaisAttackTrigger1 = false;
        }
        if(ShibaGM.ShibaBarrageGaugeValue1 <= 20)//ゲージが20以下ならほのぼのじいじいをオンにする
        {
            Honobono1.SetActive(true);
            Honobono2.SetActive(true);
            ShibaGM.ShibaisAttackTrigger1 = false;
        }
    }
}
