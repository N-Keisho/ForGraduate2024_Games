using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mojiMove : MonoBehaviour
{
    float countup = 0;
    float timeLimit = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 forceDirection = new Vector3(Random.Range(-1, 6), Random.Range(-1, 4), Random.Range(-5, -1));
        int forceStrength = Random.Range(20, 50);
        rb.AddForce(forceDirection * forceStrength);
    }

    // Update is called once per frame
    void Update()
    {
        countup += Time.deltaTime;

        if (countup >= timeLimit)
        {
            Destroy(this.gameObject);
        }

    }
}
