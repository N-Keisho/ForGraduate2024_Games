using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeichanHPSliderController : MonoBehaviour
{
    Slider hpSlider;
    GameController gameController;
    void Start()
    {
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        hpSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = gameController.hp;
    }
}
