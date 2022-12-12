using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class C : MonoBehaviour

{
    public AudioSource _1;
    public AudioSource _2;
    public void OnCollisionEnter(Collision collision)

    {

        if (collision.gameObject.name == "A")

        {

            _1.Play();

        }

        else if (collision.gameObject.name == "B")

        {

            _2.Play();

        }

    }
}
