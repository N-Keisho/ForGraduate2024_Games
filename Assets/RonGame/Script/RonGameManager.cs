using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RonGameManager : MonoBehaviour
{
    // ひろっぺ，しば，けいちゃん，つっくん，わったー，ろん
    [SerializeField] GameObject[] characters = new GameObject[6];
    [SerializeField] private GameObject _QuestionManager_;
    [SerializeField] private GameObject _HPManager_;
    private QuestionManager questionManager;
    private HPManager hPManager;
    private Animator[] animators = new Animator[6];
    private CharaAnimation[] charaAnimations = new CharaAnimation[6];
    private GameObject[] cameras = new GameObject[6];
    public bool[] questionEnd = new bool[7] { false, false, false, false, false, false, false };

    void Start()
    {
        questionManager = _QuestionManager_.GetComponent<QuestionManager>();
        hPManager = _HPManager_.GetComponent<HPManager>();

        for (int i = 0; i < characters.Length; i++)
        {
            animators[i] = characters[i].GetComponent<Animator>();
            charaAnimations[i] = characters[i].GetComponent<CharaAnimation>();
            if (i != 5)
                cameras[i] = characters[i].transform.Find("Camera").gameObject;
        }

        StartCoroutine(Play());

    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.D)){
        //     StartCoroutine(RonQuestion());
        // }
        // if(Input.GetKeyDown(KeyCode.Alpha0)){
        //     StartCoroutine(RonAttack(0));
        // }
        // if(Input.GetKeyDown(KeyCode.Alpha1)){
        //     StartCoroutine(CharaAttack(1));
        // }
        // if(Input.GetKeyDown(KeyCode.Alpha2)){
        //     StartCoroutine(CharaAttack(2));
        // }
        // if(Input.GetKeyDown(KeyCode.Alpha3)){
        //     StartCoroutine(CharaAttack(3));
        // }
        // if(Input.GetKeyDown(KeyCode.Alpha4)){
        //     StartCoroutine(CharaAttack(4));
        // }
    }

    IEnumerator Play()
    {
        for (int i = 0; i < 7; i++)
        {
            Debug.Log(i);
            yield return new WaitUntil(() => questionEnd[i]);
            yield return new WaitForSeconds(2.0f);
            StartCoroutine(RonQuestion());
        }
    }

    IEnumerator RonQuestion()
    {
        animators[5].SetBool("Question", true);
        yield return new WaitForSeconds(1.0f);
        questionManager.NextQuestion();
        animators[5].SetBool("Question", false);
    }

    IEnumerator CharaAttack(int number)
    {
        animators[number].SetBool("Attack", true);
        animators[5].SetBool("Damaged", true);
        cameras[number].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        animators[number].SetBool("Attack", false);
        for (int i = 0; i < 100; i++)
        {
            hPManager.HPs[5]--;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.1f);
        cameras[number].SetActive(false);
        yield return new WaitForSeconds(0.4f);
        animators[5].SetBool("Damaged", false);
    }

    IEnumerator RonAttack(int number)
    {
        animators[5].SetBool("Attack", true);
        // animators[number].SetBool("Damaged", true);
        // cameras[number].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        animators[5].SetBool("Attack", false);
        for (int i = 0; i < 25; i++)
        {
            hPManager.HPs[number]--;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.1f);
        // cameras[number].SetActive(false);
        yield return new WaitForSeconds(0.4f);
        // animators[5].SetBool("Damaged", false);
    }
}
