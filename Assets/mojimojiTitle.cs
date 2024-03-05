using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mojimojiTitle : MonoBehaviour
{
    [SerializeField] int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-8,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current = transform.position;
        Vector3 target = new Vector3(20*direction, 0, 0);
        float maxDistanceDelta = 5.0f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(current, target, maxDistanceDelta);

        if(transform.position.x > 15 || transform.position.x < -15)
        {
            direction = direction * -1;
            transform.Rotate(0, 180, 0);
        }
    }
}
