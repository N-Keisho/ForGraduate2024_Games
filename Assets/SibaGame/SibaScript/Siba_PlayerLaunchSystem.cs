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
    [SerializeField] private Transform muzzle;

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
        sakura.transform.position = this.transform.position;
        
    }
}