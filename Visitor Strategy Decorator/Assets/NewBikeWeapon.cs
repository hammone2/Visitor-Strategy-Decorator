using UnityEngine;
using System.Collections;

public class NewBikeWeapon : MonoBehaviour
{
    public WeaponConfig weaponConfig;
    public WeaponAttachment mainAttachment;
    public WeaponAttachment secondaryAttachment;

    private bool _isFiring;
    private IWeapon _weapon;
    private bool _isDecorated;

    void Start()
    {
        _weapon = new Weapon(weaponConfig);
    }

    void OnGUI()
    {
        GUI.color = Color.green;

        GUI.Label(
            new Rect(125, 50+25, 150, 100),
            "Range: " + _weapon.Range);

        GUI.Label(
            new Rect(125, 70 + 25, 150, 100),
            "Strength: " + _weapon.Strength);

        GUI.Label(
            new Rect(125, 90 + 25, 150, 100),
            "Cooldown: " + _weapon.Cooldown);

        GUI.Label(
            new Rect(125, 110 + 25, 150, 100),
            "Firing Rate: " + _weapon.Rate);

        GUI.Label(
            new Rect(125, 130 + 25, 150, 100),
            "Weapon Firing: " + _isFiring);

        if (mainAttachment && _isDecorated)
            GUI.Label(
                new Rect(125, 150 + 25, 150, 100),
                "Main Attachment: " + mainAttachment.name);

        if (secondaryAttachment && _isDecorated)
            GUI.Label(
                new Rect(125, 170 + 25, 200, 100),
                "Secondary Attachment: " + secondaryAttachment.name);
    }

    public void ToggleFire()
    {
        _isFiring = !_isFiring;

        if (_isFiring)
            StartCoroutine(FireWeapon());
    }

    IEnumerator FireWeapon()
    {
        float firingRate = 1.0f / _weapon.Rate;

        while (_isFiring)
        {
            yield return new WaitForSeconds(firingRate);
            Debug.Log("fire");
        }
    }

    public void Reset()
    {
        _weapon = new Weapon(weaponConfig);
        _isDecorated = !_isDecorated;
    }

    public void Decorate()
    {
        if (mainAttachment && !secondaryAttachment)
            _weapon =
                new WeaponDecorator(_weapon, mainAttachment);

        if (mainAttachment && secondaryAttachment)
            _weapon =
                new WeaponDecorator(
                    new WeaponDecorator(
                        _weapon, mainAttachment),
                                secondaryAttachment);

        _isDecorated = !_isDecorated;
    }
}