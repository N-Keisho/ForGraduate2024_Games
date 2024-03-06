using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mojiChange : MonoBehaviour
{
    [SerializeField] Sprite Sprite1;
    [SerializeField] Sprite Sprite2;
    private Image image;
    bool spriteBool = true;
    [SerializeField] float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(DelayCoroutine());
    }

    private IEnumerator DelayCoroutine()
    {
        if (spriteBool)
        {
            image.sprite = Sprite1;
            spriteBool = false;
        }
        else
        {
            image.sprite = Sprite2;
            spriteBool = true;
        }

        yield return new WaitForSeconds(waitTime);
        StartCoroutine(DelayCoroutine());
    }
    // Update is called once per frame
    void Update()
    {

 
    }
}
