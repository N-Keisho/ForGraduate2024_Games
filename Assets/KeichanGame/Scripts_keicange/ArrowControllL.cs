using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControllL : MonoBehaviour
{
    GameController gameController;
    public float startPos;
    public bool enemy;
    public bool hpChange;

    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        transform.position = new Vector3(startPos, -6.0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, gameController.noteSpeed * Time.deltaTime, 0);

        if (transform.position.y >= 8)
        {
            Destroy(this.gameObject);
            //transform.position = new Vector3(startPos, -6.0f, 0);
            hpChange = true;
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            //Debug.Log(key);
            if (transform.position.y >= 4.5f && transform.position.y <= 5.5f)
            {
                //Debug.Log("Great");
                GameObject effects = Instantiate(effect) as GameObject;
                effects.transform.position = new Vector3(startPos, 5, 0);
                Destroy(effects , 0.2f);
                Destroy(this.gameObject);
            }
            else if (transform.position.y >= 3.7f && transform.position.y <= 6.3f)
            {
                //Debug.Log("Good");
                Destroy(this.gameObject);
            }
            else if (transform.position.y >= 3.2 && transform.position.y <= 6.8f)
            {
                //Debug.Log("miss");
                Destroy(this.gameObject);
                hpChange = true;
            }
            
        }

        if (hpChange)
        {
            hpChange = false;
            if (enemy)
            {
                gameController.hp -= 1;
            }
            else
            {
                gameController.hp += 1;
            }
        }


        
    }
}
