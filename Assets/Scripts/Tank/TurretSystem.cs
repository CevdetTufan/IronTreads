using UnityEngine;

public class TurretSystem : MonoBehaviour
{
    [Header("Turret Settings")]
    [SerializeField] private Transform turretTransform;
    [SerializeField] private float turretRotateSpeed = 80f;

    [Header("Cannon Settings")]
    [SerializeField] private Transform cannonTransform;
    [SerializeField] private float cannonTiltSpeed = 40f;
    [SerializeField] private float maxUpAngle = -20f;
    [SerializeField] private float maxDownAngle = 10f;

    private float _currentCannonAngle = 0f;
    private float _startCannonX = 0f;

    private void Start()
    {
        if (cannonTransform != null)
            _startCannonX = cannonTransform.localEulerAngles.x;
    }

    // Kuleyi döndüren method
    public void RotateTurret(float direction)
    {
        float amount = direction * turretRotateSpeed * Time.deltaTime;
        turretTransform.Rotate(0, amount, 0);
    }

    // Namluyu kaldırıp indiren method
    public void TiltCannon(float direction)
    {
        _currentCannonAngle += direction * cannonTiltSpeed * Time.deltaTime;
        _currentCannonAngle = Mathf.Clamp(_currentCannonAngle, maxUpAngle, maxDownAngle);

        // 90 derecelik başlangıç farkını koruyarak uygula
        cannonTransform.localRotation = Quaternion.Euler(_startCannonX + _currentCannonAngle, 0, 0);
    }
}