using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour{

    // Building to place
    public GameObject building;

    // Materials for Building
    public Material validMaterial;
    public Material invalidMaterial;

    // Parent for building gameobject
    public Transform parent;

    // Building material
    Renderer buildingMaterial;

    // Mouse Position
    Vector3 mousePos;
    Vector3 normal;

    // Currently attached gameobject
    GameObject selectedBuilding;

    // Building script
    Building selectedBuildingScript;

    // Flag if a building is currently selected
    bool selected;

    // Flag if can place
    bool canPlace;

    // Update is called once per frame
    void Update(){
        // On click
        if (Input.GetMouseButton(0) && !selected) {
            SpawnBuilding();
        }

        // Every frame if building is selected
        if (selected) {
            UpdateMousePosition();
            FollowMouse();

            // Check if can place
            if (selectedBuildingScript.canPlace && !canPlace) {
                ValidSelection();
                canPlace = true;
            }
            else if(!selectedBuildingScript.canPlace && canPlace) {
                InvalidSelection();
                canPlace = false;
            }
        }
    }

    // Toggle Validity
    void ValidSelection() {
        buildingMaterial.material = validMaterial;
        Debug.Log("Valid!");
    }
    void InvalidSelection() {
        buildingMaterial.material = invalidMaterial;
        Debug.Log("Invalid!");
    }

    // Update Mouse Position
    void UpdateMousePosition() {
        // Cast ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Check if hit
        int layerMask = LayerMask.GetMask("Ground");
        if (Physics.Raycast(ray, out RaycastHit hit, 300, layerMask)) {
            // Update if hit is ground
            mousePos = hit.point;
            normal = hit.normal;
        }
    }

    // Make building follow mouse
    void FollowMouse() {
        if(selectedBuilding != null) {
            selectedBuilding.transform.position = mousePos;
            selectedBuilding.transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);
        }
    }

    // Spawn Building
    void SpawnBuilding() {
        UpdateMousePosition();
        selectedBuilding = Instantiate(building, mousePos, Quaternion.FromToRotation(Vector3.up, normal), parent);
        buildingMaterial = selectedBuilding.transform.Find("Model").GetComponent<MeshRenderer>();
        buildingMaterial.material = invalidMaterial;
        selectedBuildingScript = selectedBuilding.GetComponent<Building>();
        selected = true;
        canPlace = selectedBuildingScript.canPlace;
    }
}
