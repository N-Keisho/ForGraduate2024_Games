using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Siba_PlayerLaunchSystem : MonoBehaviour
{
    [SerializeField] Slider ShibaHPSlider;
    public Siba_GameManager ShibaGM;
    [SerializeField] private GameObject ShibaSakuraPrefab;
    [SerializeField] private GameObject ShibaHartPrefab;
    [SerializeField] private GameObject ShibaMuzzle;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerAttack();
        }
    }
    void PlayerAttack()
    {
        GameObject sakura = Instantiate(ShibaSakuraPrefab) as GameObject;
        sakura.transform.position = ShibaMuzzle.transform.position;
        Vector3 force = new Vector3(0.0f, 5.0f, 50.0f);
        sakura.GetComponent<Rigidbody> ().AddForce (force, ForceMode.Impulse);  
    }
}