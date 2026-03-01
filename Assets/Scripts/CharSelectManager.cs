using UnityEngine;

public class CharSelectManager : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject dinoSprite;
    [SerializeField] GameObject frogSprite;
    [SerializeField] GameObject mobileControlsPanel;
    [SerializeField] GameObject landscapeInstructions;

    void Start()
    {
        Time.timeScale = 0;
        scoreCanvas.SetActive(false);
        mobileControlsPanel.SetActive(false);
        landscapeInstructions.SetActive(IsLandscape());
    }

    void Update()
    {
        landscapeInstructions.SetActive(IsLandscape());
    }

    bool IsLandscape()
    {
        return Screen.width > Screen.height;
    }

    void BeginGame()
    {
        Time.timeScale = 1;
        scoreCanvas.SetActive(true);
        mobileControlsPanel.SetActive(Screen.height > Screen.width);
        landscapeInstructions.SetActive(false);
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
