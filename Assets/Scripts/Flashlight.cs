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

            if(raycastDistance > 5)
            {
                raycastDistance = 5;
            }

            flashlight.intensity = Mathf.Lerp(flashlight.intensity, raycastDistance, dimTime);
        }
    }
}
