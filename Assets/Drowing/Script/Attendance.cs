using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attendance : MonoBehaviour
{
    [SerializeField] Toggle[] graduateToggles;
    [SerializeField] Toggle[] normalToggles;

    private DataManager dataManager;
    private GraduateMembers graduateMembers;
    private NormalMembers normalMembers;

    void Awake()
    {
        this.gameObject.SetActive(false);
    }

    void Start()
    {
        dataManager = GameObject.Find("_DataManager_").GetComponent<DataManager>();
        graduateMembers = dataManager.GetGraduateMembers();
        normalMembers = dataManager.GetNormalMembers();

        for (int i = 0; i < graduateToggles.Length; i++)
        {
            graduateToggles[i].isOn = graduateMembers.value[i];
        }

        for (int i = 0; i < normalToggles.Length; i++)
        {
            normalToggles[i].isOn = normalMembers.value[i] >= 0;
        }
    }

    public void OnClickSaveButton()
    {
        for (int i = 0; i < graduateToggles.Length; i++)
        {
            graduateMembers.value[i] = graduateToggles[i].isOn;
        }

        for (int i = 0; i < normalToggles.Length; i++)
        {
            normalMembers.value[i] = normalToggles[i].isOn ? 0 : -1;
        }

        dataManager.SetGraduateMembers(graduateMembers);
        dataManager.SetNormalMembers(normalMembers);
    }

    public void OnClickOpenButton()
    {
        this.gameObject.SetActive(true);
    }

    public void OnClickCloseButton(){
        this.gameObject.SetActive(false);
    }
}
