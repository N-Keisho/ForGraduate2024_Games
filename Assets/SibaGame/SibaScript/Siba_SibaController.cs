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
    // Start is called before the first frame update
    void Start()
    {
        Siba_sibaAnim = GetComponent<Animator>();
        SibaHPText.text = SibaEnemyHP.ToString("f0");
    }

    // Update is called once per frame
    void Update()
    {
        if(!ShibaGM.ShibaisBarrageTimerQuit1){
            if (Input.GetKey(KeyCode.A)){
                Siba_sibaAnim.SetBool("isSibaWalking", false);
                Siba_sibaAnim.SetBool("isFighting", true);
            }
        }
        else {
            Siba_sibaAnim.SetBool("isFighting", false);

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                Siba_sibaAnim.SetBool("isSibaWalking",true);
            }
            else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                Siba_sibaAnim.SetBool("isSibaWalking", false);
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.position += transform.TransformDirection(Vector3.forward * moveSpeed * Time.deltaTime);// 前へ進む
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                transform.position += transform.TransformDirection(Vector3.forward * moveSpeed * Time.deltaTime);// 後ろへ進む
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
                transform.position += transform.TransformDirection(Vector3.forward * moveSpeed * Time.deltaTime);// 左へ進む
            }
            if (Input.GetKey(KeyCode.D))// もしDキーがおされたら
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
                transform.position += transform.TransformDirection(Vector3.forward * moveSpeed * Time.deltaTime);// 右へ進む
            }
        }
        SibaHPGauge.value = SibaEnemyHP;
        SibaHPText.text = SibaEnemyHP.ToString("f0");
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
