using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    
    [SerializeField] private GameObject[] sliders;
    private List<Slider> hpSliders = new List<Slider>();
    public int[] HPs = new int[6]{100, 100, 100, 100, 100, 1000};
    // ひろっぺ，しば，けいちゃん，つっくん，わったー，ろん
    void Start()
    {
        for (int i = 0 ; i < sliders.Length; i++)
        {
            hpSliders.Add(sliders[i].GetComponent<Slider>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hpSliders.Count; i++)
        {
            hpSliders[i].value = HPs[i];
        }
    }

}
