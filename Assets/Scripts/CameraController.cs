using UnityEngine;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float landscapeSize = 12f;
    [SerializeField] float portraitSize = 18f;

    CinemachineCamera cmCamera;
    bool wasPortrait;

    void Start()
    {
        cmCamera = FindFirstObjectByType<CinemachineCamera>();
        ApplyCameraSize();
        wasPortrait = IsPortrait();
    }

    void Update()
    {
        bool isPortrait = IsPortrait();
        if (isPortrait != wasPortrait)
        {
            ApplyCameraSize();
            wasPortrait = isPortrait;
        }
    }

    bool IsPortrait() => Screen.height > Screen.width;

    void ApplyCameraSize()
    {
        cmCamera.Lens.OrthographicSize = IsPortrait() ? portraitSize : landscapeSize;
    }
}
