using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControll : MonoBehaviour
{
    GameController gameController;
    public KeyCode key;
    public float startPos;
    public bool enemy;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, gameController.noteSpeed * Time.deltaTime, 0);

        if (transform.position.y >= 8)
        {
            //Destroy(this.gameObject);
            transform.position = new Vector3(startPos, -6.0f, 0);
            gameController.hp -= 1;
        }

        if (Input.GetKeyDown(key))
        {
            if (transform.position.y >= 4.5f && transform.position.y <= 5.5f)
            {
                Debug.Log("Great");
            }
            else if (transform.position.y >= 4.0f && transform.position.y <= 6.0f)
            {
                Debug.Log("Good");
            }
            else if (transform.position.y >= 3.0 && transform.position.y <= 7.0f)
            {
                Debug.Log("miss");
            }
            Destroy(this.gameObject);
        }


        
    }
}
