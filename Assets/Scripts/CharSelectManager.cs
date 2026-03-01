using UnityEngine;

public class CharSelectManager : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject dinoSprite;
    [SerializeField] GameObject frogSprite;
    [SerializeField] GameObject mobileControlsPanel;

    void Start()
    {
        Time.timeScale = 0;
        scoreCanvas.SetActive(false);
        mobileControlsPanel.SetActive(false);
    }

    void BeginGame()
    {
        Time.timeScale = 1;
        scoreCanvas.SetActive(true);
        mobileControlsPanel.SetActive(Screen.height > Screen.width);
        gameObject.SetActive(false);
    }

    public void ChooseDino()
    {
        dinoSprite.SetActive(true);
        BeginGame();
    }

    public void ChooseFrog()
    {
        frogSprite.SetActive(true);
        BeginGame();
    }
}
