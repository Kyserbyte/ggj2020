using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;
    
    // How long the object should shake for.
    public float shakeDuration = 0f;
    
    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    
    Vector3 originalPos;
    bool shake = false;
    
    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }
    
    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0 && shake)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = false;
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }

    public void Shake(float duration = 1f)
    {
        shakeDuration = duration;
        originalPos = camTransform.localPosition;
        shake = true;
    }
}