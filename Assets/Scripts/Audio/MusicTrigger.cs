using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    public bool inOrOut;
    public AudioType audioType;

    private void OnTriggerEnter(Collider other)
    {
        if (!AudioManager.Instance.bankLoaded)
            return;

        if (other.gameObject == Player.Instance.gameObject)
        {
            if (inOrOut)
            {
                AudioManager.Instance.StartFade(audioType, true);
            }
            else
            {
                AudioManager.Instance.StartFade(audioType, false);
            }
        }
    }
}
