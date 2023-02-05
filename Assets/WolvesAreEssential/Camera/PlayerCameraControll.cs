using System.Collections;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class PlayerCameraControll : MonoBehaviour
{
    [Header("Shaking Config")]
    public float shakeIntensity;
    public float shakeFrequency;
 

    [Header("Movement Config")]
    [SerializeField]
    float xOffsetMax;
    [SerializeField]
    float yOffsetMax;
    [Header("Zoom Config")]
    [SerializeField]
    float zoomPercent;
    [SerializeField]
    float zoomSpeed;
    float targetCamDistance;

    CinemachineVirtualCamera vc;
    CinemachineFramingTransposer frameTransposCam;
    CinemachineCameraOffset vcCameraOffset;


    Coroutine shakeCoroutine;
    float shakeTimer = 0;

    float originalCameraDistance;

    bool shouldShake;

    private void Awake()
    {
        vc = GetComponent<CinemachineVirtualCamera>();
        frameTransposCam = vc.GetCinemachineComponent(CinemachineCore.Stage.Body) as CinemachineFramingTransposer;
        vcCameraOffset = GetComponent<CinemachineCameraOffset>();
        if (!frameTransposCam || !vcCameraOffset)
        {
            Debug.LogError("PlayerCameraControll: Cannot find FrameTransposer or CameraOffset component!");
        }
        originalCameraDistance = frameTransposCam.m_CameraDistance;
        targetCamDistance = originalCameraDistance;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetCamDistance = (1 - zoomPercent) * originalCameraDistance;
        }
        if (Input.GetMouseButtonUp(0))
        {
            targetCamDistance = originalCameraDistance;
        }
        AdjustCamDistance();
        SetCameraOffset();
    }

    private void AdjustCamDistance()
    {
        float currentCamDist = frameTransposCam.m_CameraDistance;
        Debug.Log($"Current Cam Dist: {currentCamDist}, Target: {targetCamDistance}");
        if (Mathf.Abs(currentCamDist - targetCamDistance) > 0.001f)
        {
            int sign = targetCamDistance - currentCamDist > 0 ? 1 : -1;
            frameTransposCam.m_CameraDistance = Mathf.Clamp(currentCamDist + sign * zoomSpeed * Time.deltaTime, zoomPercent * originalCameraDistance, originalCameraDistance);
        }
    }

    private void SetCameraShake(bool shake)
    {
        CinemachineBasicMultiChannelPerlin perlin = vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        if (shake)
        {
            perlin.m_AmplitudeGain = shakeIntensity;
            perlin.m_FrequencyGain = shakeFrequency;
        }
        else
        {
            perlin.m_AmplitudeGain = 0;
            perlin.m_FrequencyGain = 0;
        }
    }

    // x, z offset based on mouse pos
    private void SetCameraOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        float mouseX = mousePos.x;
        float mouseY = mousePos.y;

        mouseX = Mathf.Clamp(mouseX, 0, Screen.width);
        mouseY = Mathf.Clamp(mouseY, 0, Screen.height);

        float screenMidX = Screen.width / 2.0f;
        float screenMidY = Screen.height / 2.0f;


        float offsetX = (mouseX - screenMidX) / screenMidX;
        float offsetY = (mouseY - screenMidY) / screenMidY;
        vcCameraOffset.m_Offset.x = offsetX * xOffsetMax;
        vcCameraOffset.m_Offset.y = offsetY * yOffsetMax;

    }

    public void ShakeCamera(float duration)
    {
        if (shakeCoroutine != null)
        {
            shakeTimer += duration;
        }
        CinemachineBasicMultiChannelPerlin perlin = vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlin.m_AmplitudeGain = shakeIntensity;
        perlin.m_FrequencyGain = shakeFrequency;
        shakeTimer = duration;
        shakeCoroutine = StartCoroutine(ShakeCR());
    }

    IEnumerator ShakeCR()
    {
        while (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        CinemachineBasicMultiChannelPerlin perlin = vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlin.m_AmplitudeGain = 0;
        perlin.m_FrequencyGain = 0;
        shakeCoroutine = null;
    }
}
