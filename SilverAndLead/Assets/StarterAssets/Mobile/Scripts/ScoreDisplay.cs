using UnityEngine;
using TMPro;
using StarterAssets;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    float score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {FirstPersonController.score}";
        }
    }
}
