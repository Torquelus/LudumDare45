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

    // Rotation speed
    public float rotationSpeed = 100f;

    // Building renderers
    Renderer[] buildingRenderers;

    // Original Building Materials
    Material[] originalMaterials;

    // Mouse Position
    Vector3 mousePos;
    Vector3 normal;

    // Currently attached gameobject
    GameObject selectedBuilding;

    // Rotator of gameobject
    Transform rotator;

    // Building script
    Building selectedBuildingScript;

    // Flag if a building is currently selected
    bool selected;

    // Flag if can place
    bool canPlace;

    // Update is called once per frame
    void Update(){
        // On click
        if (Input.GetKeyDown(KeyCode.Alpha1) && !selected) {
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

            // If click
            if (Input.GetMouseButton(0)) {
                PlaceBuilding();
            }
            if (Input.GetMouseButton(1)) {
                CancelBuilding();
            }
            if (Input.GetKey(KeyCode.E)) {
                RotateRight();
            }
            if (Input.GetKey(KeyCode.Q)) {
                RotateLeft();
            }
        }
    }

    // Rotate Right
    void RotateRight() {
        rotator.RotateAround(rotator.position, rotator.up, Time.deltaTime * rotationSpeed);
    }

    // Rotate Left
    void RotateLeft() {
        rotator.RotateAround(rotator.position, rotator.up, -Time.deltaTime * rotationSpeed);
    }

    // Cancel building
    void CancelBuilding() {
        selected = false;
        Destroy(selectedBuilding);
        selectedBuilding = null;
    }

    // Toggle Validity
    void ValidSelection() {
        foreach (Renderer renderer in buildingRenderers) {
            renderer.material = validMaterial;
        }
        Debug.Log("Valid!");
    }
    void InvalidSelection() {
        foreach (Renderer renderer in buildingRenderers) {
            renderer.material = invalidMaterial;
        }
        Debug.Log("Invalid!");
    }

    // Place Building
    void PlaceBuilding() {
        if (canPlace && selected) {
            selected = false;
            for (int i = 0; i < buildingRenderers.Length; i++) {
                buildingRenderers[i].material = originalMaterials[i];
            }
            selectedBuilding = null;
        }
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
        // Update Mouse Pos
        UpdateMousePosition();

        // Instantiate building
        selectedBuilding = Instantiate(building, mousePos, Quaternion.FromToRotation(Vector3.up, normal), parent);

        // Get rotator
        rotator = selectedBuilding.transform.Find("Rotator").transform;

        // Get all renderers
        buildingRenderers = selectedBuilding.GetComponentsInChildren<Renderer>();

        // Make new array
        originalMaterials = new Material[buildingRenderers.Length];

        // Get all materials
        for (int i = 0; i < buildingRenderers.Length; i++) {
            originalMaterials[i] = buildingRenderers[i].material;
        }

        foreach (Renderer renderer in buildingRenderers) {
            renderer.material = validMaterial;
        }

        // Set flags
        selectedBuildingScript = selectedBuilding.GetComponentInChildren<Building>();
        selected = true;
        canPlace = selectedBuildingScript.canPlace;
    }
}
