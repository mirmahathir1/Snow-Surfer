using UnityEngine;

public class MobileControlsVisibility : MonoBehaviour
{
    [SerializeField] GameObject mobileControlsPanel;

    bool wasPortrait;

    void Start()
    {
        wasPortrait = IsPortrait();
        mobileControlsPanel.SetActive(wasPortrait);
    }

    void Update()
    {
        bool portrait = IsPortrait();
        if (portrait != wasPortrait)
        {
            wasPortrait = portrait;
            mobileControlsPanel.SetActive(portrait);
        }
    }

    bool IsPortrait()
    {
        return Screen.height > Screen.width;
    }
}
