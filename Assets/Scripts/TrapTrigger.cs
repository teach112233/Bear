using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public float slowDownAmount = 2f; // ��t�{��
    public float slowDownDuration = 2f; // ��t����ɶ�

    private void OnTriggerEnter(Collider other)
    {
        // �p�G���aĲ�o����
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                StartCoroutine(SlowDownPlayer(playerMovement));
            }
        }

        // �p�G�º�Ĳ�o����
        if (other.CompareTag("BlackBear"))
        {
            BearFollow bearFollow = other.GetComponent<BearFollow>();
            if (bearFollow != null)
            {
                StartCoroutine(SlowDownBear(bearFollow));
            }
        }
    }

    // ��w���a�����ʳt��
    private IEnumerator SlowDownPlayer(PlayerMovement playerMovement)
    {
        playerMovement.moveSpeed /= slowDownAmount; // ��t
        yield return new WaitForSeconds(slowDownDuration); // ���ݴ�t�ɶ�����
        playerMovement.moveSpeed *= slowDownAmount; // ��_�t��
    }

    // ��w�º������H�t��
    private IEnumerator SlowDownBear(BearFollow bearFollow)
    {
        bearFollow.followSpeed /= slowDownAmount; // ��t
        yield return new WaitForSeconds(slowDownDuration); // ���ݴ�t�ɶ�����
        bearFollow.followSpeed *= slowDownAmount; // ��_�t��
    }
}
