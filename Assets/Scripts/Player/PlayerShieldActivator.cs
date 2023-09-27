using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldActivator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Shield shield;
    public void ActivateShield()
    {
        if (!shield.gameObject.activeSelf)
        {
            shield.gameObject.SetActive(true);
        }
        else
        {
            shield.RepairShield();
        }
    }
}
