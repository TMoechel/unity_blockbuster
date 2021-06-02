using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] int totalBlocks = 0;
    SceneLoader sceneLoader;

    public void CountBreakableBlocks()
    {
        //die Anzahl der totalBlocks soll bei jedem Aufruf dieser Methode um 1 erhöht werden !
        // totalBlocks = totalBlocks + 1;
        // kurzschreibweise für totalBlocks = totalBlocks + 1 !!!!!!!
        totalBlocks++;
    }
    
    public void DestroyBlock()
    {
        totalBlocks--;
        if (totalBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }



    
}
