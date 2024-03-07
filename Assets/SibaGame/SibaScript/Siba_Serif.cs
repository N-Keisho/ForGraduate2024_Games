using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siba_Serif : MonoBehaviour
{
    [SerializeField]GameObject SibaSerif;
    // Start is called before the first frame update
    void Start()
    {
        SibaSerif.SetActive(false);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Siba"){
            StartCoroutine("sibaSerif");
        }
    }
    IEnumerator sibaSerif(){
        SibaSerif.SetActive(true);
        yield return new WaitForSeconds(3);
        SibaSerif.SetActive(false);
    }
}
