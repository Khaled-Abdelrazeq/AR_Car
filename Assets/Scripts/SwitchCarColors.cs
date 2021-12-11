using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCarColors : MonoBehaviour
{
    [SerializeField] private Material[] carMats;
    [SerializeField] private GameObject carBodyMaterial;
    [SerializeField] private GameObject materialsBar3D;
    [SerializeField] private GameObject materialsBar2D;

    private bool isMaterialBarShown = false;

    public void onViewMaterialsBar()
    {
        isMaterialBarShown = !isMaterialBarShown;
        materialsBar2D.gameObject.SetActive(isMaterialBarShown);
        materialsBar3D.gameObject.SetActive(isMaterialBarShown);
    }

    public void onRedButtonClicked()
    {
        carBodyMaterial.GetComponent<Renderer>().material = carMats[0];
    }

    public void onWhiteButtonClicked()
    {
        carBodyMaterial.GetComponent<Renderer>().material = carMats[1];
    }

    public void onBlueButtonClicked()
    {
        carBodyMaterial.GetComponent<Renderer>().material = carMats[2];
    }
}
