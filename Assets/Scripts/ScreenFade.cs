using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public Image blackPanel; // Reference to the Image component of the panel

    private Timer timer; // Reference to the Timer script

    void Start()
    {
        timer = FindObjectOfType<Timer>(); // Locate the Timer script
    }

    void Update()
    {
        if (timer != null)
        {
            // Calculate alpha based on remaining time
            float alpha = 1 - Mathf.Clamp01(timer.timeLeft / 10); // 10 is the initial time
            blackPanel.color = new Color(0, 0, 0, alpha);
        }
    }
}
