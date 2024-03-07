using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RonGameManager : MonoBehaviour
{
    [SerializeField] string NextSceneName = "Ending";
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
    private int[][] answerer = new int[6][]{
        new int[]{0, 3},        // りりーさん
        new int[]{1, 2, 4},     // カントリーマアム
        new int[]{3, 2},        // パパパパパイン
        new int[]{1, 0},     // メンター数
        new int[]{4, 2, 3},        // 入社順
        new int[]{0, 1, 4}      // 入社日
    };

    private string[] answererName = new string[]{
        "<color #499EFF>ひろっぺ</color>", 
        "<color #FF5DC6>しば</color>", 
        "<color #84FF7B>けいちゃん</color>", 
        "<color #FFF337>つっくん</color>", 
        "<color #944DFF>わったー</color>"
    };

    [SerializeField] private TMP_Text[] ansewererText = new TMP_Text[6];

    [SerializeField] private GameObject QuestionNumberText;
    private TMP_Text questionNumberText;

    private bool death = false;
    [SerializeField] private float speed = 1;

    void Start()
    {
        questionManager = _QuestionManager_.GetComponent<QuestionManager>();
        hPManager = _HPManager_.GetComponent<HPManager>();
        questionNumberText = QuestionNumberText.GetComponent<TMP_Text>();
        QuestionNumberText.SetActive(false);

        for (int i = 0; i < characters.Length; i++)
        {
            animators[i] = characters[i].GetComponent<Animator>();
            charaAnimations[i] = characters[i].GetComponent<CharaAnimation>();
            if (i != 5)
                cameras[i] = characters[i].transform.Find("Camera").gameObject;
        }

        for (int i = 0; i < ansewererText.Length; i++)
        {
            string text = "";
            for (int j = 0; j < answerer[i].Length; j++)
            { 
                text += answererName[answerer[i][j]] + "\n";
            }
            ansewererText[i].text = text;
        }

        StartCoroutine(Play());

    }

    // Update is called once per frame
    void Update()
    {
        if(death){
            if(characters[5].transform.rotation.y > 0){
                characters[5].transform.Rotate(new Vector3(-1 * speed * Time.deltaTime, 0, 0));
            }
            else{
                SceneManager.LoadScene(NextSceneName);
                // return;
            }
                
        }
        if(Input.GetKeyDown(KeyCode.T)) death = true;
    }

    IEnumerator Play()
    {
        for (int i = 0; i < 7; i++)
        {
            // Debug.Log(i);
            yield return new WaitUntil(() => questionEnd[i]);
            yield return new WaitForSeconds(1.0f);

            if (i != 0)
            {
                if (questionManager.correct[i - 1])
                {
                    // Debug.Log(answerer[i-1].Length);
                    for (int j = 0; j < answerer[i - 1].Length; j++)
                    {
                        StartCoroutine(CharaAttack(answerer[i - 1][j]));
                        yield return new WaitForSeconds(2.5f);
                    }
                }
                else
                {
                    StartCoroutine(RonAttack(answerer[i - 1]));
                    yield return new WaitForSeconds(2f);
                }
            }
            yield return new WaitForSeconds(0.1f);

            if(i != 6){
                questionNumberText.text = "問" + (i+1);
                QuestionNumberText.SetActive(true);
                yield return new WaitForSeconds(2.0f);
                QuestionNumberText.SetActive(false);
            
                StartCoroutine(RonQuestion());
            }
            
        }

        Fin();
    }

    void Fin(){
        animators[5].SetBool("Damaged", true);
        death = true;
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

    IEnumerator RonAttack(int[] number)
    {
        animators[5].SetBool("Attack", true);
        // animators[number].SetBool("Damaged", true);
        // cameras[number].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        animators[5].SetBool("Attack", false);
        for (int i = 0; i < 25; i++)
        {
            for (int j = 0; j < number.Length; j++)
            {
                hPManager.HPs[number[j]]--;
            }
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.1f);
        // cameras[number].SetActive(false);
        yield return new WaitForSeconds(0.4f);
        // animators[5].SetBool("Damaged", false);
    }
}
