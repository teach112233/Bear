using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearFollow : MonoBehaviour
{
    public Transform player;  // 玩家位置
    public float followSpeed = 3f;  // 黑熊跟隨速度
    public float stopDistance = 2f; // 跟隨停止距離，避免過近

    private void Update()
    {
        // 計算黑熊與玩家之間的距離
        float distance = Vector3.Distance(transform.position, player.position);

        // 如果黑熊與玩家的距離大於停止距離，黑熊會跟隨玩家
        if (distance > stopDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * followSpeed * Time.deltaTime;

            // 使黑熊朝向玩家
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * followSpeed);
        }
    }
}
