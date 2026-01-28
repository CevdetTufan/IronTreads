using UnityEngine;

public class TankInputManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TankMover tankMover;
    [SerializeField] private TurretSystem turretSystem;
    [SerializeField] private WeaponSystem weaponSystem;

    private void Update()
    {
        HandleMovementInput();
        HandleTurretInput();
        HandleShootingInput();
    }

    // Methodları parçalayarak okunabilirliği artırdık (Clean Code)
    
    private void HandleMovementInput()
    {
        // Gövde İleri-Geri (W - S)
        if (Input.GetKey(KeyCode.W))
            tankMover.Move(1f);
        else if (Input.GetKey(KeyCode.S))
            tankMover.Move(-1f);

        // Gövde Dönüş (A - D)
        if (Input.GetKey(KeyCode.D))
            tankMover.Rotate(1f);
        else if (Input.GetKey(KeyCode.A))
            tankMover.Rotate(-1f);
    }

    private void HandleTurretInput()
    {
        // Kule Dönüş (Sağ Ok - Sol Ok)
        if (Input.GetKey(KeyCode.RightArrow))
            turretSystem.RotateTurret(1f);
        else if (Input.GetKey(KeyCode.LeftArrow))
            turretSystem.RotateTurret(-1f);

        // Namlu Eğim (Yukarı Ok - Aşağı Ok)
        // Yukarı basınca eksiye (yukarı) gitmesi için -1 ile çarptık
        if (Input.GetKey(KeyCode.UpArrow))
            turretSystem.TiltCannon(-1f); 
        else if (Input.GetKey(KeyCode.DownArrow))
            turretSystem.TiltCannon(1f);
    }

    private void HandleShootingInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            weaponSystem.Fire();
        }
    }
}