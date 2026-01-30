using UnityEngine;

public class TankCamera : MonoBehaviour
{
    [Header("Target")]
    [Tooltip("Takip edilecek Tank objesi")]
    [SerializeField] private Transform target;

    [Header("Follow Settings")]
    [Tooltip("Takip yumuşaklığı (Düşük = Sıkı Takip)")]
    [SerializeField] private float smoothTime = 0.01f;

    [Header("Gravel Vibration")]
    [Range(0f, 1f)]
    [SerializeField] private float shakeIntensity = 0.01f; // Titreşim şiddeti
    [SerializeField] private float shakeFrequency = 45f;   // Titreşim hızı

    private Vector3 _offset;
    
    private Vector3 _currentVelocity;
    private Vector3 _lastTargetPosition;
    private bool _isMoving;
    private float _movementThreshold = 0.1f;

    private void Start()
    {
        if (target == null) return;

        _offset = transform.position - target.position;

        _lastTargetPosition = target.position;
    }

    private void LateUpdate()
    {
        if (target == null) return;

        CheckIfMoving();

        // 1. Hedef Pozisyon (Tankın yeri + Başta hesapladığımız o sabit mesafe)
        Vector3 targetPosition = target.position + _offset;
        
        // 2. Yumuşak Takip (SmoothDamp)
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);

        // 3. Titreşim Ekle (Sadece hareket ediyorsa)
        if (_isMoving)
        {
            smoothedPosition += Random.insideUnitSphere * shakeIntensity;
        }

        // 4. Uygula
        transform.position = smoothedPosition;
        
        _lastTargetPosition = target.position;
    }

    private void CheckIfMoving()
    {
        float distance = Vector3.Distance(target.position, _lastTargetPosition);
        _isMoving = distance > (_movementThreshold * Time.deltaTime);
    }
}