using System.Collections;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class PlayerCameraControll : MonoBehaviour
{
    public static int shakeIntensity;
    [SerializeField]
    private int shakeFrequency;

    CinemachineVirtualCamera vc;
    CinemachineFramingTransposer frameTransposCam;

    [SerializeField]
    float xOffsetMax;
    [SerializeField]
    float yOffsetMax;

    Coroutine shakeCoroutine;
    float shakeTimer = 0;

    float originalCameraDistance;

    bool shouldShake;

    private void Awake()
    {
        vc = GetComponent<CinemachineVirtualCamera>();
        frameTransposCam = vc.GetCinemachineComponent(CinemachineCore.Stage.Body) as CinemachineFramingTransposer;
        if (frameTransposCam)
        {
            originalCameraDistance = frameTransposCam.m_CameraDistance;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            frameTransposCam.m_CameraDistance = 0.9f * originalCameraDistance;
            shouldShake = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            frameTransposCam.m_CameraDistance = originalCameraDistance;
            shouldShake = false;
        }
        //SetCameraShake(shouldShake);
        SetCameraOffset();
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

    }

    public void ShakeCamera(float duration, float intensity = 0.3f, float frequency = 200f)
    {
        if (shakeCoroutine != null)
        {
            shakeTimer += duration;
        }
        CinemachineBasicMultiChannelPerlin perlin = vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlin.m_AmplitudeGain = intensity;
        perlin.m_FrequencyGain = frequency;
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
