using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDetector : MonoBehaviour
{
    [SerializeField] ProgressBar Progress;
    [SerializeField] Collider Area;
    private bool timerAtivo = false;

    private void OnTriggerEnter(Collider collision) {
        if (collision.tag == "Player")
        {
            if (timerAtivo)
            return;
            timerAtivo = true;
            Debug.Log("Player entrou na área.");
            StartCoroutine(timerProgresso());
        }
    }

    private void OnTriggerExit(Collider collision) 
    {
         if (collision.tag == "Player")
        {
            timerAtivo = false;
            Debug.Log("Player deixou a área.");
            StopCoroutine(timerProgresso());
        }
    }

    IEnumerator timerProgresso()
    {
        while (timerAtivo)
        {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        Progress.current += 5;

        }

    }
}
