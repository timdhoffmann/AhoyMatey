using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : NetworkBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    private Vector3 movementInput;
    private Camera localCam;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        movementInput.x = CrossPlatformInputManager.GetAxis("Horizontal");
        movementInput.y = 0f;
        movementInput.z = CrossPlatformInputManager.GetAxis("Vertical");
        transform.Translate(movementInput);
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        // Enable only the local player's camera component (disabled in prefab).
        // The camera gameObject has to be enabled to find the component.
        localCam = GetComponentInChildren<Camera>();
        localCam.enabled = true;
    }
}
