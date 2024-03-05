using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    public GameObject mojimoji;
    public Vector3 mojiPosition;
    void mojimagic()
    {
        for (int i = 0; i < 10; i++)
        {
            float angle = Random.Range(-50, -150);
            Instantiate(mojimoji, mojiPosition, Quaternion.Euler(0, angle, 0));
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
