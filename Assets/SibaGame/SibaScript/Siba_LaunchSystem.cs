using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siba_LaunchSystem : MonoBehaviour
{
    [SerializeField] GameObject ShibaPlayerGun;
    [SerializeField] GameObject ShibaSakura;
    [SerializeField] bool ShibaPlayerAttackTrigger;
    public Siba_GameManager ShibaGM;

    void Update()
    {
        if (ShibaGM.ShibaisLimitTimerQuit1)
        {
            if (ShibaPlayerAttackTrigger)
            {
                LaunchSystem();
                ShibaPlayerAttackTrigger = false;
            }
        }
        else
        {
            ResetSystem();
        }
    }

    void LaunchSystem()
    {
        Rigidbody rb = ShibaPlayerGun.GetComponent<Rigidbody>();
        Vector3 force = new Vector3(0.0f, ShibaGM.ShibaGaugeValue1, ShibaGM.ShibaGaugeValue1 * 4.0f);
        rb.AddForce(force, ForceMode.Impulse);
    }
    void ResetSystem()
    {
        ShibaPlayerAttackTrigger = true;
    }
}
