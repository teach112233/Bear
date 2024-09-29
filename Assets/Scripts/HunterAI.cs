using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // 使用NavMesh來處理AI路徑尋找

public class HunterAI : MonoBehaviour
{
    public Transform player;  // 玩家位置
    public Transform blackBear;  // 黑熊位置
    public float chaseRange = 10f;  // 追擊範圍
    public float attackRange = 2f;  // 攻擊範圍
    public float moveSpeed = 3.5f;  // 移動速度
    private NavMeshAgent agent;

    private Transform target;  // 當前目標
    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
    }

    void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, player.position);
        float bearDistance = Vector3.Distance(transform.position, blackBear.position);

        // 選擇最近的目標進行追擊
        if (playerDistance < chaseRange && playerDistance < bearDistance)
        {
            target = player;
            isChasing = true;
        }
        else if (bearDistance < chaseRange)
        {
            target = blackBear;
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing && target != null)
        {
            // 追蹤目標
            agent.SetDestination(target.position);

            // 如果靠近到攻擊範圍，暫停追蹤（這裡可以進一步實現攻擊行為）
            if (Vector3.Distance(transform.position, target.position) < attackRange)
            {
                // 進行攻擊行為（目前可以只暫停或發出警告）
                agent.isStopped = true;
                // 這裡可以添加攻擊動畫或扣血等邏輯
            }
            else
            {
                agent.isStopped = false;
            }
        }
    }
}
