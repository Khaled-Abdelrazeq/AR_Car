using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class AmbientLightEstimation : MonoBehaviour
{

    [SerializeField] private ARCameraManager cameraManager;
    [SerializeField] private Text warningText;

    private Light lightComponent;

    // Called when script is activated
    private void OnEnable()
    {
        lightComponent = GetComponent<Light>();
        cameraManager.frameReceived += OnCameraFrameRecieved;
    }

    private void OnCameraFrameRecieved(ARCameraFrameEventArgs cameraFrameEventArgs)
    {
        ARLightEstimationData lightEstimation = cameraFrameEventArgs.lightEstimation;

        if (lightEstimation.averageBrightness.HasValue)
        {
            lightComponent.intensity = lightEstimation.averageBrightness.Value;

            if (lightEstimation.averageBrightness.Value < 0.1f)
            {
                // Show warning text
                warningText.gameObject.SetActive(true);
            }
            else
                warningText.gameObject.SetActive(false);
        }

        if(lightEstimation.averageColorTemperature.HasValue)
            lightComponent.colorTemperature = lightEstimation.averageColorTemperature.Value;
    }

    private void OnDisable()
    {
        cameraManager.frameReceived -= OnCameraFrameRecieved;
    }
}
