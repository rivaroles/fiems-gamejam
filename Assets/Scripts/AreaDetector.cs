using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDetector : MonoBehaviour
{
    [SerializeField] ProgressBar Fitness;
    [SerializeField] Animator PlayerAnimator;
    private bool timerAtivo = false;

    private void OnTriggerEnter(Collider collision) {
        if (collision.tag == "Player")
        {
            if (timerAtivo)
            return;
            PlayerAnimator.Play("Interacting");
            timerAtivo = true;
            Debug.Log("Player entrou na área da bola.");
            StartCoroutine(timerBola());
        }
    }

    private void OnTriggerExit(Collider collision) 
    {
         if (collision.tag == "Player")
        {
            PlayerAnimator.Play("Idle");
            timerAtivo = false;
            Debug.Log("Player deixou a área da bola.");
            StopCoroutine(timerBola());
        }
    }

    IEnumerator timerBola()
    {
        while (timerAtivo)
        {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        Fitness.current += 1;
        }

    }
}
