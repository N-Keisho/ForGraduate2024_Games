using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Siba_SibaController : MonoBehaviour
{
    [SerializeField] Siba_GameManager ShibaGM;
    private Animator Siba_sibaAnim;
    [SerializeField] float moveSpeed;
    [SerializeField] public float SibaEnemyHP = 100;//しばのHP
    [SerializeField] TextMeshProUGUI SibaHPText; //しばHPの文字
    [SerializeField] Slider SibaHPGauge;// しばHPのスライダー
    public float SibaEnemyHP1{ get{ return SibaEnemyHP;}}
    [SerializeField] GameObject ClearImage;
    [SerializeField] GameObject NextButtun;
    [SerializeField] bool ShibaGameTimerStop;// ゲームクリアのときゲーム時間を終了する
    public bool ShibaGameTimerStop1 { get{ return ShibaGameTimerStop;}}
    // Start is called before the first frame update
    void Start()
    {
        Siba_sibaAnim = GetComponent<Animator>();
        SibaHPText.text = SibaEnemyHP.ToString("f0");
        ShibaGameTimerStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!ShibaGM.ShibaisBarrageTimerQuit1)
        {
            if (Input.GetKey(KeyCode.Joystick2Button2))
            {
                Siba_sibaAnim.SetBool("isSibaWalking", false);
                Siba_sibaAnim.SetBool("isFighting", true);
            }
        }
        else 
        {
            Siba_sibaAnim.SetBool("isFighting", false);
            // Joyconのスティックの入力を取得
            float horizontal_2 = Input.GetAxis("Horizontal_4");
            float vertical_2 = Input.GetAxis("Vertical_4");
            // メモ$は、文字列中に変数の値を埋め込むための簡単な方法
            Debug.Log($"Horizontal_2: {horizontal_2}, Vertical_2: {vertical_2}");

            // スティックの入力があるかどうかを判断
            if (Mathf.Abs(horizontal_2) > 0.1f || Mathf.Abs(vertical_2) > 0.1f)
            {
                Siba_sibaAnim.SetBool("isSibaWalking", true);
            }
            else
            {
                Siba_sibaAnim.SetBool("isSibaWalking", false);
            }

            // ここでスティックの入力に基づいて移動などを制御する
            // ベクトル化
            Vector3 moveDirection = new Vector3(-horizontal_2, 0, -vertical_2).normalized;
            if (moveDirection.magnitude > 0.1f)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * 500);
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            } 
        }
        SibaHPGauge.value = SibaEnemyHP;
        SibaHPText.text = SibaEnemyHP.ToString("f0");
        if(SibaEnemyHP <= 0)
        {
            ClearImage.SetActive(true);
            ShibaGameTimerStop = true;
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "heart"){
            Siba_sibaAnim.SetBool("isAttacked", true);
            SibaEnemyHP -= 20f;
            Destroy(other.gameObject);//当たったハートのプレファブを消す
            StartCoroutine("isAttackedStop");
        }
        if(other.gameObject.tag == "Item"){
            Siba_sibaAnim.SetBool("isAttacked", true);
            SibaEnemyHP -= 10f;
            Destroy(other.gameObject);//当たったさくらのプレファブを消す
            StartCoroutine("isAttackedStop");
        }
    }
    IEnumerator isAttackedStop(){
        yield return new WaitForSeconds(1.7f);
        Siba_sibaAnim.SetBool("isAttacked", false);
    }
}
