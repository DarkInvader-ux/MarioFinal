using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundActivate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("frog"))
        {
            AudioManager.Instance.PlaySound(Sounds.Level_2_background, transform.position);
        }
    }
}
