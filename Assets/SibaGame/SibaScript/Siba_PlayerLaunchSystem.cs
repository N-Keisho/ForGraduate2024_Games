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
            GameObject sakura = Instantiate(ShibaSakuraPrefab) as GameObject;
            sakura.transform.position = ShibaMuzzle.transform.position;
            Vector3 force = new Vector3(0.0f, 5.0f, 50.0f);
            sakura.GetComponent<Rigidbody> ().AddForce (force, ForceMode.Impulse);
            ShibaGM.ShibaisAttackTrigger1 = false;
        }
        if(ShibaGM.ShibaBarrageGaugeValue1 > 90)
        {
            GameObject heart = Instantiate(ShibaHeartPrefab) as GameObject;
            heart.transform.position = ShibaMuzzle.transform.position;
            Vector3 force = new Vector3(0.0f, 5.0f, 50.0f);
            heart.GetComponent<Rigidbody> ().AddForce (force, ForceMode.Impulse);
            ShibaGM.ShibaisAttackTrigger1 = false;
        }
    }
}