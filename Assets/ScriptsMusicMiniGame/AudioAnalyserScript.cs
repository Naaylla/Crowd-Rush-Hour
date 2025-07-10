using UnityEngine;

public class AudioPitchAnalyser : MonoBehaviour
{
    const float maxHeight = 4.0f;

    public AudioSource audioSource;
    public GameObject notePrefab;
    public int numberOfNotes = 10;
    public float noteSpacing = 0.5f;

    private float[] spectrum = new float[1024];
    private int currentNoteIndex = 0;
    private float timer = 0f;
    private float lastYPos = 0f;

    // Plage de fréquences et hauteur d'écran
    private float minFreq = 80f;
    private float minY = -maxHeight; 
    private float maxY;

    
    void Start()
    {
        // Calcule la hauteur d'écran (pour caméra orthographique)
        maxY = maxHeight;
    }

    void Update()
    {
        if (currentNoteIndex >= numberOfNotes) return;

        timer += Time.deltaTime;
        if (timer >= noteSpacing)
        {
            timer = 0f;
            SpawnNoteBasedOnPitch();
            currentNoteIndex++;
        }
    }
    

    void SpawnNoteBasedOnPitch()
    {
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        // Trouve la fréquence dominante
        float maxFreq = 0f;
        int maxIndex = 0;
        for (int i = 0; i < spectrum.Length; i++)
        {
            if (spectrum[i] > maxFreq)
            {
                maxFreq = spectrum[i];
                maxIndex = i;
            }
        }
        float dominantFreq = maxIndex * AudioSettings.outputSampleRate / 2 / spectrum.Length;

        // Normalise et map vers la position Y
        float clampedFreq = Mathf.Clamp(dominantFreq, minFreq, maxFreq);
        float normalizedPitch = (clampedFreq - minFreq) / (maxFreq - minFreq);
        float yPos = Mathf.Lerp(minY, maxY, normalizedPitch);

        // Lissage (optionnel)
        yPos = Mathf.Lerp(lastYPos, yPos, 0.3f);
        lastYPos = yPos;

        // Spawn la note
        Vector3 notePos = new Vector3(currentNoteIndex * 1.5f, yPos, 0);
        Instantiate(notePrefab, notePos, Quaternion.identity);
    }

    public void DeleteObject()
    {
        Destroy(gameObject);
    }
}