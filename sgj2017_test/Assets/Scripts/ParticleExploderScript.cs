using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleExploderScript : MonoBehaviour {


    private static int particles = 200;
    private static float particleScale = 0.15f;

    public static void Explode(GameObject particleBase, Vector3 position) {
        for (int i = 0; i < particles; i++) {
            float xf = Random.Range(-0.2f, 0.2f);
            float yf = Random.Range(-0.2f, 0.2f);
            float zf = Random.Range(-0.2f, 0.2f);
            GameObject particle = Instantiate(particleBase);
            particle.GetComponent<Transform>().position = position + new Vector3(xf, yf, zf);
            particle.GetComponent<Transform>().localScale = new Vector3(particleScale, particleScale, particleScale);
            if (!particle.GetComponent<Rigidbody>())
            {
                particle.AddComponent<Rigidbody>();
            }
            particle.GetComponent<Rigidbody>().isKinematic = false;
            particle.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
            particle.GetComponent<Rigidbody>().useGravity = true;
            particle.GetComponent<Rigidbody>().mass = Random.Range(0.7f, 1.3f);
            particle.GetComponent<Rigidbody>().AddExplosionForce(200f, position, 2);
        }
    }

}