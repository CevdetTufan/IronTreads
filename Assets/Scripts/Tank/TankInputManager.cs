using UnityEngine;
using UnityEngine.InputSystem;

public class TankInputManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TankMover tankMover;
    [SerializeField] private TurretSystem turretSystem;
    [SerializeField] private WeaponSystem weaponSystem;

    // DEĞİŞİKLİK 1: Sınıf adı dosya adıyla aynı olmalı
    private InputSystem_Actions _inputActions;

    private void Awake()
    {
        // DEĞİŞİKLİK 2: Burada da doğrusunu kullanıyoruz
        _inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void Update()
    {
        HandleMovementInput();
        HandleTurretInput();
        HandleShootingInput();
    }

    private void HandleMovementInput()
    {
        // ÖNEMLİ: InputSystem_Actions dosyasını açıp Action Map adının "Player"
        // ve Action adının "Move" olduğundan emin olmalısın.
        // Eğer dosya Unity'nin varsayılan dosyasıysa isimler genelde "Player", "Move", "Look", "Fire" olur.
        
        Vector2 moveVector = _inputActions.Player.TurretMove.ReadValue<Vector2>();

        tankMover.Move(moveVector.y);
        tankMover.Rotate(moveVector.x);
    }

    private void HandleTurretInput()
    {
        // "TurretMove" action'ını senin eklediğini varsayıyorum.
        // Eğer eklemediysen hata verir. InputSystem_Actions dosyasına çift tıklayıp
        // "Player" altına "TurretMove" (Ok tuşları) eklemeyi unutma.
        
        // Hata almamak için şimdilik varsayılan "Look" action'ını da kullanabilirsin test için:
        // Vector2 turretVector = _inputActions.Player.Look.ReadValue<Vector2>();
        
        Vector2 turretVector = _inputActions.Player.TurretMove.ReadValue<Vector2>();

        turretSystem.RotateTurret(turretVector.x);
        turretSystem.TiltCannon(-turretVector.y);
    }

    private void HandleShootingInput()
    {
        // Unity varsayılan dosyasında "Fire" yerine "Attack" olabilir, kontrol et.
        // Genelde "Fire" veya "Attack" olur.
        if (_inputActions.Player.Fire.WasPressedThisFrame())
        {
            weaponSystem.Fire();
        }
    }
}