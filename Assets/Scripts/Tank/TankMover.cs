using UnityEngine;

public class TankMover : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float turnSpeed = 100f;

    // Hareket işlemini dışarıdan tetiklenebilir methodlara böldük
    public void Move(float direction) // 1 (ileri) veya -1 (geri) alır
    {
        float moveAmount = direction * moveSpeed * Time.deltaTime;
        transform.Translate(0, 0, moveAmount);
    }

    public void Rotate(float direction) // 1 (sağ) veya -1 (sol) alır
    {
        float turnAmount = direction * turnSpeed * Time.deltaTime;
        transform.Rotate(0, turnAmount, 0);
    }
}