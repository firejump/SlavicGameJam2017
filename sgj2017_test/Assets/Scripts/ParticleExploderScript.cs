using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleExploderScript : MonoBehaviour {


    private static int particles = 100;
    private static float particleScale = 0.15f;

    public static void Explode(GameObject particleBase, Vector3 position) {
        GameObject particleTemplate = Instantiate(particleBase);
        stripObject(particleTemplate);
        if (!particleTemplate.GetComponent<Rigidbody>())
        {
            particleTemplate.AddComponent<Rigidbody>();
        }
        particleTemplate.GetComponent<Rigidbody>().isKinematic = false;
        particleTemplate.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
        particleTemplate.GetComponent<Rigidbody>().useGravity = true;
        particleTemplate.GetComponent<Transform>().localScale = new Vector3(particleScale, particleScale, particleScale);
        for (int i = 0; i < particles; i++) {
            float xf = Random.Range(-0.2f, 0.2f);
            float yf = Random.Range(-0.2f, 0.2f);
            float zf = Random.Range(-0.2f, 0.2f);
            GameObject particle = GameObject.Instantiate(particleTemplate);
            particle.GetComponent<Transform>().position = position + new Vector3(xf, yf, zf);
            particle.GetComponent<Transform>().localScale = new Vector3(particleScale, particleScale, particleScale);
            
            particle.GetComponent<Rigidbody>().mass = Random.Range(0.7f, 1.3f);
            particle.GetComponent<Rigidbody>().AddExplosionForce(200f, position, 2);
        }
    }

    private static void stripObject(GameObject o)
    {
        o.GetComponentInChildren<Light>().enabled = false;
    }

}