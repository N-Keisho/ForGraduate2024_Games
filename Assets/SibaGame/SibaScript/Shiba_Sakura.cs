using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiba_Sakura : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("SakuraDestroy");
    }
    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Ground"){
            this.gameObject.tag = "Item";//タグがsakuraからItemになって、ダメージ0になる
        }
    }
    IEnumerator SakuraDestroy(){
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
