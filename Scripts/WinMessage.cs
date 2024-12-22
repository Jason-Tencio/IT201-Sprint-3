using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text winText;
    private int rockCount;

    void Start()
    {
        rockCount = 0;
        winText.text = ""; // Make sure the win text is empty initially.
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            other.gameObject.SetActive(false);
            rockCount++;

            if (rockCount >= 4)
            {
                winText.text = "You're Free!";
            }
        }
    }
}
