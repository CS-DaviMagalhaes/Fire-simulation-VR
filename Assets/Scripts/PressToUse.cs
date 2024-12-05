using UnityEngine;

public class TriggerParticleController : MonoBehaviour
{
    public ParticleSystem particles; 
    public GameObject hand; 

    void Update()
    {
        // Get the right trigger value
        float rightTriggerValue = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);

        // Check if the trigger is pressed enough
        if (rightTriggerValue > 0.1f)
        {
            if (!particles.isPlaying) // Avoid restarting the particle system
            {
                particles.transform.position = hand.transform.position;
                particles.transform.rotation = hand.transform.rotation; // Optional: Align with hand rotation
                particles.Play();

            }
        }
        else
        {
            if (particles.isPlaying)
            {
                particles.Stop();
            }
        }
    }
}
