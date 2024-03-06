using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public float speed = 2; //　移動スピード
    public float moveY = 5; // 移動値
    private Vector3 pos; //　初期位置


    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<RectTransform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){
        Vector3 p = GetComponent<RectTransform>().position;
        GetComponent<RectTransform>().position = new Vector3(p.x, pos.y + Mathf.Sin(Time.time * speed) * moveY, p.z);
    }
}
