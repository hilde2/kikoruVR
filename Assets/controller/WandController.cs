using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour {

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObject.index);}}
    private SteamVR_TrackedObject trackedObject;

    private GameObject pickup;

	// Use this for initialization
	void Start () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if(controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        if (controller.GetPressDown(gripButton) && pickup !=null)
        {
            pickup.transform.parent = this.transform;
        }

        if (controller.GetPressUp(gripButton) && pickup != null)
        {
            pickup.transform.parent = null;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entedred");
        pickup = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exit");
        pickup = null;
    }
}
