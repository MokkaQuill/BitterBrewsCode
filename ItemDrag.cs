using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script sits on the item boxes for ingredients on the right hand side. It handles instantiating bigger versions of the ingredients which you can then drop into the cauldron.

public class ItemDrag : MonoBehaviour
{
    // References
    public GameObject bigItem;
    private GameObject instantiatedItem;
    private bool dragging;
    private Vector2 offset;

    private Vector3 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        // If the mouse is being dragged, instantiate a big version of the ingredient at the mouse position
        dragging = true;
        instantiatedItem = Instantiate(bigItem, Input.mousePosition, Quaternion.identity, transform);
        // Prevent new item from going under the UI
        instantiatedItem.transform.parent.GetComponent<Transform>().SetAsLastSibling();
        // Find the right image and set it
        instantiatedItem.GetComponent<Image>().sprite = GetComponent<IngredientIcons>().ingredient.bigArtwork;
    }

    private void OnMouseUp()
    {
        // Despawn the big instantiated item once the mouse is let go
        dragging = false;
        Destroy(instantiatedItem);
    }
    private void Update()
    {
        // Move the big ingredient with the mouse
        if (!dragging) return;
        var mousePosition = GetMousePos();
        instantiatedItem.transform.position = (Vector2)mousePosition - offset;

    }



}
