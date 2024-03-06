using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Siba_PlayerLaunchSystem : MonoBehaviour
{
    public Siba_GameManager ShibaGM;
    [SerializeField] private GameObject ShibaSakuraPrefab;
    [SerializeField] private GameObject ShibaHeartPrefab;
    [SerializeField] private GameObject ShibaMuzzle;
    [SerializeField] private GameObject ShibaObject;

    void Update()
    {
        if(ShibaGM.ShibaisAttackTrigger1 && ShibaGM.ShibaBarrageGaugeValue1 > 60)
        {
            PlayerAttack();
        }
    }
    void PlayerAttack()
    {
        if(ShibaGM.ShibaBarrageGaugeValue1 <= 90)
        {
            GameObject Item = Instantiate(ShibaSakuraPrefab) as GameObject;
            Item.transform.position = ShibaMuzzle.transform.position;
            // Itemをしばの方向に向けるベクトル
            Vector3 targetDirection = ShibaObject.transform.position - Item.transform.position;
            targetDirection.Normalize(); // 方向ベクトルを正規化

            float forceMagnitude = 50.0f; 
            Vector3 force = targetDirection * forceMagnitude;
            Item.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            ShibaGM.ShibaisAttackTrigger1 = false;
        }
        if(ShibaGM.ShibaBarrageGaugeValue1 > 90)
        {
            GameObject heart = Instantiate(ShibaHeartPrefab) as GameObject;
            heart.transform.position = ShibaMuzzle.transform.position;

            // sakuraをしばの方向に向けるベクトル
            Vector3 targetDirection = ShibaObject.transform.position - heart.transform.position;
            targetDirection.Normalize(); // 方向ベクトルを正規化

            float forceMagnitude = 50.0f; 
            Vector3 force = targetDirection * forceMagnitude;
            heart.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            ShibaGM.ShibaisAttackTrigger1 = false;
        }
    }
}