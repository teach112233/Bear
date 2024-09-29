using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public float slowDownAmount = 2f; // 減速程度
    public float slowDownDuration = 2f; // 減速持續時間

    private void OnTriggerEnter(Collider other)
    {
        // 如果玩家觸發陷阱
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                StartCoroutine(SlowDownPlayer(playerMovement));
            }
        }

        // 如果黑熊觸發陷阱
        if (other.CompareTag("BlackBear"))
        {
            BearFollow bearFollow = other.GetComponent<BearFollow>();
            if (bearFollow != null)
            {
                StartCoroutine(SlowDownBear(bearFollow));
            }
        }
    }

    // 減緩玩家的移動速度
    private IEnumerator SlowDownPlayer(PlayerMovement playerMovement)
    {
        playerMovement.moveSpeed /= slowDownAmount; // 減速
        yield return new WaitForSeconds(slowDownDuration); // 等待減速時間結束
        playerMovement.moveSpeed *= slowDownAmount; // 恢復速度
    }

    // 減緩黑熊的跟隨速度
    private IEnumerator SlowDownBear(BearFollow bearFollow)
    {
        bearFollow.followSpeed /= slowDownAmount; // 減速
        yield return new WaitForSeconds(slowDownDuration); // 等待減速時間結束
        bearFollow.followSpeed *= slowDownAmount; // 恢復速度
    }
}
