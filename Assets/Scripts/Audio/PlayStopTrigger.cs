using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStopTrigger : MonoBehaviour
{
    public bool startStop;
    public AudioType audioType;

    private void OnTriggerEnter(Collider other)
    {
        if (!AudioManager.Instance.bankLoaded)
            return;

        if (other.gameObject == Player.Instance.gameObject)
        {
            if (startStop)
            {
                AudioManager.Instance.PlayMusic(audioType);
            }
            else
            {
                AudioManager.Instance.StopMusic(audioType);
            }
        }
    }
}
