using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearFollow : MonoBehaviour
{
    public Transform player;  // ���a��m
    public float followSpeed = 3f;  // �º����H�t��
    public float stopDistance = 2f; // ���H����Z���A�קK�L��

    private void Update()
    {
        // �p��º��P���a�������Z��
        float distance = Vector3.Distance(transform.position, player.position);

        // �p�G�º��P���a���Z���j�󰱤�Z���A�º��|���H���a
        if (distance > stopDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * followSpeed * Time.deltaTime;

            // �϶º��¦V���a
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * followSpeed);
        }
    }
}
