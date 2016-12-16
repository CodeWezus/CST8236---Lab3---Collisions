using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallCollisions : MonoBehaviour {

    private ParticleSystem Destruction;

    void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.name.Equals("Ball"))
            return;

        AudioSource objSound = this.gameObject.GetComponent<AudioSource>();
        if (objSound != null)
        {
            objSound.Play();
        }

        Destruction = col.gameObject.GetComponent<ParticleSystem>();
        if (Destruction == null)
            return;
        Destruction.Play();

    }
}
