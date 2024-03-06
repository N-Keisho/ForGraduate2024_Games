using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressW2 : MonoBehaviour
{
    [SerializeField] GameObject text;
    [SerializeField] GameObject text1;
    [SerializeField] GameObject text2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine("Defalt");
        }
    }
    IEnumerator Defalt()
    {
        text.SetActive(true);
        text1.SetActive(true);
        text2.SetActive(true);
        return Defalt();
    }
}
