using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    float lives;
    Text livesText;
    
    // Start is called before the first frame update
    void Start()
    {
        lives = baseLives - (PlayerPrefsController.GetDifficulty() - 1);
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void LoseLives(int amount)
    {
        lives -= amount;
        UpdateDisplay();
        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
