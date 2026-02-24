using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowParticles;

    void OnCollisionEnter2D(Collision2D other) {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (other.gameObject.layer == layerIndex) {
            snowParticles.Play();
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (other.gameObject.layer == layerIndex) {
            snowParticles.Stop();
        }
    }
}
