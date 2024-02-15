using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Siba_PlayerLaunchSystem : MonoBehaviour
{
    [SerializeField] Slider ShibaHPSlider;
    public Siba_GameManager ShibaGM;

    void Update()
    {
        if (ShibaGM.ShibaisBarrageTimerQuit1)
        {
            if (ShibaGM.ShibaisPlayerMove1)
            {
                Debug.Log("発射");
                LaunchSystem();
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            ShibaHPSlider.value -= 10; 
            Debug.Log("プレイヤーの攻撃、10のダメージ");
            gameObject.SetActive(false);
            ResetSystem();
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Ground")
        {	
            gameObject.SetActive (false);
            ResetSystem();
        }
    }

    void LaunchSystem()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 force = new Vector3(0.0f, ShibaGM.ShibaBarrageGaugeValue1, ShibaGM.ShibaBarrageGaugeValue1 * 4.0f);
        rb.AddForce(force, ForceMode.Impulse);
    }
    void ResetSystem()
    {	
        transform.localPosition = new Vector3(0.0f, 0.7f, 0.0f);
        gameObject.SetActive (true);
    }
}
