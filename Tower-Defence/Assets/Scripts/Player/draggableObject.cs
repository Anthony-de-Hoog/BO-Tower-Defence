using UnityEngine;
public class draggableObject : MonoBehaviour
{
    private GameObject towerControll;
    private TowerButton TB;
    private bool isDraggable = true;

    private void Start()
    {
        towerControll = GameObject.Find("TowerButton"); // Searches for the TowerButton Game Object
        TB = towerControll.GetComponent<TowerButton>(); // Gets the component from the TowerButton script
    }

    void Update()
    {
        // Makes the tower draggable when the button is clicked
        if (isDraggable)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
    }
    // Makes the towers placable
    private void OnMouseDown()
    {
        if (Input.mousePosition.x > 350 || Input.mousePosition.y > 250) { isDraggable = false; TB.mouseHasTower = false; }
    }
}