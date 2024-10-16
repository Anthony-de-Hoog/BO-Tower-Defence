using UnityEngine;

public class TowerButton : MonoBehaviour
{
    [SerializeField] private GameObject[] towers;
    private bool MouseHasTower = false;

    // Makes the MouseHasTower public for the scripts but keeps it private for the users
    public bool mouseHasTower
    {
        get { return MouseHasTower; }
        set { MouseHasTower = value; }
    }

    private void Tower(int towerNumber)
    {
        // Checks if the mouse has clicked the button to get the tower
        if (!mouseHasTower)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Instantiate(towers[towerNumber], mousePosition, Quaternion.identity);
            mouseHasTower = true;
        }
    }
}