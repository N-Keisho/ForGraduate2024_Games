using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine("Default");
        }
    }
    IEnumerator Default()
    {
        yield return new WaitForSeconds(3f);
        text.SetActive(true);
    }
}
