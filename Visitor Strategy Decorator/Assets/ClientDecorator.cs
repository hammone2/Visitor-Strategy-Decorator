using UnityEngine;

public class ClientDecorator : MonoBehaviour
{
    private NewBikeWeapon _bikeWeapon;
    private bool _isWeaponDecorated;

    void Start()
    {
        _bikeWeapon =
            (NewBikeWeapon)
            FindFirstObjectByType(typeof(NewBikeWeapon));
    }

    void OnGUI()
    {
        GUILayout.Space(75);

        if (!_isWeaponDecorated)
            if (GUILayout.Button("Decorate Weapon"))
            {
                _bikeWeapon.Decorate();
                _isWeaponDecorated = !_isWeaponDecorated;
            }

        if (_isWeaponDecorated)
            if (GUILayout.Button("Reset Weapon"))
            {
                _bikeWeapon.Reset();
                _isWeaponDecorated = !_isWeaponDecorated;
            }

        if (GUILayout.Button("Toggle Fire"))
            _bikeWeapon.ToggleFire();
    }
}

