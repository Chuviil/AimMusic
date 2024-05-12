using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePosition;
    [SerializeField] private float fireCooldown = 0.5f;

    private bool _readyToFire = true;
    public void Fire()
    {
        if (_readyToFire)
        {
            _readyToFire = false;
            Instantiate(bulletPrefab, firePosition.position, transform.rotation);
            
            Invoke(nameof(ResetFire), fireCooldown);
        }
    }

    private void ResetFire()
    {
        _readyToFire = true;
    }
}