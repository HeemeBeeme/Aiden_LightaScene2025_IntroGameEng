using UnityEngine;
using UnityEngine.EventSystems;

public class Flashlight : MonoBehaviour
{

    [SerializeField]
    float raycastDistance;
    [SerializeField]
    float dimTime = 0.5f;
    [SerializeField]
    Light flashlight;

    void Start()
    {
        flashlight = GetComponent<Light>();
    }
    void Update()
    {
        RaycastHit hit;
        Ray raycast = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(raycast, out hit))
        {
            raycastDistance = hit.distance;

            if(raycastDistance > 2)
            {
                raycastDistance = 2;
            }
            else if(raycastDistance < 0.5)
            {
                raycastDistance = 2;
            }

            flashlight.intensity = Mathf.Lerp(flashlight.intensity, raycastDistance, dimTime);
        }
    }
}
