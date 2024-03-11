using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SubCharacterScript : MonoBehaviour
{
    public GameObject target;//追跡するターゲット
    private NavMeshAgent agent;//NavMeshAgentを使用するための変数
    private PlayerScript playerScript;

    public float followDistance = 5.0f;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();//agentにNavMeshAgentの値を入れる
        playerScript = GameObject.Find("Riry").GetComponent<PlayerScript>();
        agent.stoppingDistance = followDistance;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position - transform.forward * 1.5f;//agentの目的地をtargetの座標にする
        agent.speed = playerScript.speed;

        if(agent.remainingDistance < followDistance){
            agent.isStopped = true;
            rb.velocity = Vector3.zero;
        }else{
            agent.isStopped = false;
        }


        if(agent.remainingDistance > 20f){
            transform.position = target.transform.position + transform.forward * -5f;
            rb.velocity = Vector3.zero;
        }
    }
}

