using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    
    // Update is called once per frame
    void Update()
    {
        // eine variable wird deklariert mit dem Typ und dem Namen der Variablen
        var mousePosx = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        
        // erstellt ein 2 dimensionales Vector object mit einer X und einer Y Koordinate
        // X: mousePosx
        // Y: mousePosy
        Vector2 mouseVector = new Vector2(transform.position.x, transform.position.y);
        mouseVector.x = Mathf.Clamp(mousePosx, minX, maxX);
        
        // setzt die position des Transform Objekts auf den mouseVector
        transform.position = mouseVector;
    }
}
