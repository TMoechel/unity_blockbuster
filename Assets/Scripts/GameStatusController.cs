using UnityEngine;
using TMPro;

public class GameStatusController : MonoBehaviour
{
    [Range(0.1f, 10)] [SerializeField] float speed = 1;
    [SerializeField] int numberOfPointsPerBlock = 10;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;


    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatusController>().Length;

        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        Time.timeScale = speed;
        scoreText.text = score.ToString();
    }

    public void ScoreCalculator()
    {
        // numberOfPointPerBlock
        // score = numberOfPointsPerBlock + score;
        score += numberOfPointsPerBlock;
        speed = speed + 0.1f;
    }


}
