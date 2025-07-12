using UnityEngine;

public class AudioPitchAnalyser : MonoBehaviour
{

    public AudioSource[] audioSources;
    private AudioSource aS;
    public GameObject notePrefab;
    public int numberOfNotes = 10;
    public float noteSpacing = 0.5f;

    private int currentNoteIndex = 0;
    private float timer = 10f;


    // Plage de fréquences et hauteur d'écran


    
    void Start()
    {
        // Calcule la hauteur d'écran (pour caméra orthographique)
        int num = 0;
        if (GameManager.instance.selectedType == "jazz") num = 0;
        if (GameManager.instance.selectedType == "rock") num = 1;
        if (GameManager.instance.selectedType == "classic") num = 2;

        aS = audioSources[num];
        aS.Play();
    }

    void Update()
    {
        if (currentNoteIndex < numberOfNotes)
        {
            timer += Time.deltaTime;
            if (timer >= noteSpacing)
            {
                timer = 0f;
                SpawnNoteBasedOnPitch();
                currentNoteIndex++;
            }
        }


    }
    

    void SpawnNoteBasedOnPitch()
    {

        float yPos = Random.Range(-4.13f,4.13f);
        // Spawn la note
        Vector3 notePos = new Vector3(currentNoteIndex * 1.5f, yPos, 0);
        Instantiate(notePrefab, notePos, Quaternion.identity);
    }

    public void DeleteObject()
    {
        Destroy(gameObject);
    }
}