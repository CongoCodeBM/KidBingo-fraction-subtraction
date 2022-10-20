using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambFeeding : MonoBehaviour
{

    [SerializeField] AudioSource petSound = new AudioSource();
    private Animator animate;

    private void Start()
    {
        animate = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        animate.Play("PetAteFood");
        Destroy(this.gameObject, 1.2f);// destroys the game object that this script is attached to
        petSound.PlayDelayed(2.0f);
    }
}
