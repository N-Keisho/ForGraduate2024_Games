using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class WinLoseHiroppe : MonoBehaviour
{
    public GameObject p1_screen_hiroppe;
    public GameObject p1_win_hiroppe;
    public GameObject p1_lose_hiroppe;
    public GameObject p2_screen_hiroppe;
    public GameObject p2_win_hiroppe;
    public GameObject p2_lose_hiroppe;
    public GameObject p1_retry_hiroppe;
    public GameObject p1_next_hiroppe;

    // Start is called before the first frame update
    void Start()
    {
        p1_screen_hiroppe.SetActive(false);
        p1_win_hiroppe.SetActive(false);
        p1_lose_hiroppe.SetActive(false);
        p2_screen_hiroppe.SetActive(false);
        p2_win_hiroppe.SetActive(false);
        p2_lose_hiroppe.SetActive(false);
        p1_retry_hiroppe.SetActive(false);
        p1_next_hiroppe.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Player1_Hiroppe p1HPhiroppe = GameObject.Find("Player1_Hiroppe").GetComponent<Player1_Hiroppe>();
        Player2_Hiroppe p2HPhiroppe = GameObject.Find("Player2_Hiroppe").GetComponent<Player2_Hiroppe>();

        if (p1HPhiroppe.HP_hiroppe1 <= 0)
        {
            p1_screen_hiroppe.SetActive(true);
            p2_screen_hiroppe.SetActive(true);
            p1_lose_hiroppe.SetActive(true);
            p2_win_hiroppe.SetActive(true);
            p1_retry_hiroppe.SetActive(true);
        }

        if (p2HPhiroppe.HP_hiroppe2 <= 0)
        {
            p1_screen_hiroppe.SetActive(true);
            p2_screen_hiroppe.SetActive(true);
            p1_win_hiroppe.SetActive(true);
            p2_lose_hiroppe.SetActive(true);
            p1_next_hiroppe.SetActive(true);
        }
    }
}
