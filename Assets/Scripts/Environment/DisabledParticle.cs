using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabledParticle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ParticleSystem particleSystem))
        {
            particleSystem.Stop();
        }
    }
}
