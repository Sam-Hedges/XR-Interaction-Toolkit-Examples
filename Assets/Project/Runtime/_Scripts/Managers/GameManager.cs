using System.Collections;
using TMPro;
using UnityEngine;
public class GameManager : MonoBehaviour
{

    [SerializeField] private bool gameActive = true;
    [SerializeField] private int gameTimeInSeconds = 300;
    [SerializeField] private float timeRemaining;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private MeshRenderer[] planetMeshes;
    [SerializeField] private GameObject[] planetParticles;
    [SerializeField] private Puzzle[] puzzles;


        // Start is called before the first frame update
    void Start()
    {
        timeRemaining = gameTimeInSeconds;
        StartCoroutine(UpdateTimeRemaining());
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameActive)
        {
            foreach (var planetMesh in planetMeshes)
            {
                planetMesh.enabled = false;
            }
            foreach (var particle in planetParticles)
            {
                particle.GetComponent<ParticleSystem>().Play();
                
                ParticleSystem[] children = particle.GetComponentsInChildren<ParticleSystem>();

                foreach (var childParticle in children)
                {
                    childParticle.Play();
                }
            }
            gameActive = true;
        }
        
        if (gameActive)
        {
            
        }
    }
    
    private IEnumerator UpdateTimeRemaining()
    {
        while (gameActive)
        {
            timeRemaining -= 1;
            timerText.text = DisplayTime(timeRemaining);
            yield return new WaitForSeconds(1);
        
        
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                gameActive = false;
            }
        }
    }
    
    string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        return minutes + ":" + seconds;
    }
}
