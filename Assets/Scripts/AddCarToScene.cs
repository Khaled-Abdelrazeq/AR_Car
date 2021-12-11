using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AddCarToScene : MonoBehaviour
{
    [SerializeField] private ARSessionOrigin origin;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    [SerializeField] private GameObject CarModel;
    private GameObject instantiatedCar;
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            bool collision = origin.GetComponent<ARRaycastManager>().Raycast(
                Input.mousePosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);

            if (collision)
            {
                if (instantiatedCar == null)
                {
                    instantiatedCar = Instantiate(CarModel);

                    foreach (var plane in origin.GetComponent<ARPlaneManager>().trackables)
                        plane.gameObject.SetActive(false);

                    origin.GetComponent<ARPlaneManager>().enabled = false;
                }

                instantiatedCar.transform.position = hits[0].pose.position;
            }
        }
    }
}
