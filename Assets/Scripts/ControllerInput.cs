using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    [SerializeField] private GunManager leftGun;
    [SerializeField] private GunManager rightGun;
    
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
            rightGun.Fire();
        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
            leftGun.Fire();
    }
}