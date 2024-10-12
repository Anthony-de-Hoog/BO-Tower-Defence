using UnityEngine;

public class TowerButton : MonoBehaviour
{
    [SerializeField] private GameObject[] towers;
    private bool MouseHasTower = false;

    public bool mouseHasTower
    {
        get { return MouseHasTower; }
        set { MouseHasTower = value; }
    }


    private void Tower(int towerNumber)
    {
        if (!mouseHasTower)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Instantiate(towers[towerNumber], mousePosition, Quaternion.identity);
            mouseHasTower = true;
        }
    }
}