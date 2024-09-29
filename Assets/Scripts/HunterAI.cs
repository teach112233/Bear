using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // �ϥ�NavMesh�ӳB�zAI���|�M��

public class HunterAI : MonoBehaviour
{
    public Transform player;  // ���a��m
    public Transform blackBear;  // �º���m
    public float chaseRange = 10f;  // �l���d��
    public float attackRange = 2f;  // �����d��
    public float moveSpeed = 3.5f;  // ���ʳt��
    private NavMeshAgent agent;

    private Transform target;  // ��e�ؼ�
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

        // ��̪ܳ񪺥ؼжi��l��
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
            // �l�ܥؼ�
            agent.SetDestination(target.position);

            // �p�G�a�������d��A�Ȱ��l�ܡ]�o�̥i�H�i�@�B��{�����欰�^
            if (Vector3.Distance(transform.position, target.position) < attackRange)
            {
                // �i������欰�]�ثe�i�H�u�Ȱ��εo�Xĵ�i�^
                agent.isStopped = true;
                // �o�̥i�H�K�[�����ʵe�Φ��嵥�޿�
            }
            else
            {
                agent.isStopped = false;
            }
        }
    }
}
