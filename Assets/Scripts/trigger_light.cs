using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_light : MonoBehaviour
{
    public Light Light;
    public Light Light2;
    public Material LightMaterial;

    // Start is called before the first frame update
    void Start()
    {
        LightMaterial.DisableKeyword("_EMISSION");
        Light.enabled = false;
        Light2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log("Triggered");
    	if(Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.JoystickButton4)){
            if (Light.enabled == true) 
             {
                 LightMaterial.DisableKeyword("_EMISSION");
                 Light.enabled = false;
                 Light2.enabled = false;
             } else if(Light.enabled == false)
             {
                LightMaterial.EnableKeyword("_EMISSION");
                Light.enabled = true;
                Light2.enabled = true;
             }
        }
    }
}
