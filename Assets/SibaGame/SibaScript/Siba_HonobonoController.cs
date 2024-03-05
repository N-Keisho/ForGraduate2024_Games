using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siba_HonobonoController : MonoBehaviour
{
    [SerializeField]GameObject SibaObject;
    [SerializeField]GameObject SibaPlayer;
    [SerializeField]float HonobonoDistance;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Healing");
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(SibaObject.transform.position, Vector3.up, HonobonoDistance);
        transform.LookAt(SibaPlayer.transform);
    }
    IEnumerator Healing(){
        yield return new WaitForSeconds(1);
    }
}
