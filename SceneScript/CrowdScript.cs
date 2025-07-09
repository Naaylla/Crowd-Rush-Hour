using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CrowdScript : MonoBehaviour
{
    private int divertissement;
    private bool diverted;
    public float timeImpactMultiplication;

    [Header("Réglages")]
    [Tooltip("Prefab du spectateur.")]
    public GameObject[] spectatorPrefab;
    public SpriteRenderer[] specPrefRendrer;
    [Tooltip("Positions où peuvent apparaître les spectateurs.")]
    public Transform[] spawnPoints;

    [Tooltip("Valeur maximale de la jauge.")]
    public float maxSatisfaction = 100f;

    [Header("Données dynamiques")]
    [Range(0, 100)]
    [Tooltip("Jauge courante de satisfaction.")]
    public float currentSatisfaction;


    [Header("Génération de la rangée")]
    [Tooltip("Nombre de spectateurs maximum")]
    public int spectatorCount = 12;
    [Tooltip("Position du premier spectateur (coin gauche)")]

    [SerializeField] Vector2 startPosition = new Vector2(-8f, 4f);
    [SerializeField] Vector2 startPosition2 = new Vector2(-20f, 2.6f);

    [Tooltip("Distance entre chaque spectateur sur X")]
    public float spacingX = 1f;

    private List<GameObject> spectators = new List<GameObject>();

    string lovedHobbie;
    string hatedHobbie;
    const float decRandX = 0.4f;
    void Start()
    {
        currentSatisfaction = GameManager.instance.currentGameSatisfaction;
        divertissement = GameManager.instance.scoreMiniGame;
        diverted = GameManager.instance.hadBeenDiverted;
        Debug.Log(diverted);

        // pour l'instant c'est moi qui decide la quelle est choisis
        lovedHobbie = GameManager.instance.Hobbies[0];
        hatedHobbie = GameManager.instance.Hobbies[1];

        int randomNum;
        float decalageX;
        
        
        for (int i = 0; i < spectatorCount; i++)
        {
            randomNum = Random.Range(0, 3);

            decalageX = Random.Range(-decRandX, decRandX);
            startPosition.x += decalageX;
            decalageX = Random.Range(-decRandX, decRandX);
            startPosition2.x += decalageX;
            // Calcul de la position : start + (i * spacing) vers la droite
            Vector2 pos;
            if (i < 6)
            {   
                pos = startPosition + Vector2.right * (i * spacingX);
                specPrefRendrer[randomNum].sortingOrder = 0;
            }
            // Par exemple, les spectateurs de la première rangée ont un ordre plus élevé}
            else
            {
                pos = startPosition2 + Vector2.right * (i * spacingX);
                specPrefRendrer[randomNum].sortingOrder = 10;
            }

            GameObject go = Instantiate(spectatorPrefab[randomNum], pos, Quaternion.identity, transform);

            // On stocke pour gérer l'activation ultérieurement
            go.SetActive(false);
            spectators.Add(go);
        }
    }



    void Update()
    {

  
        // Ici tu baisses/augmentes currentSatisfaction selon ta logique de jeu...
        // Ex : currentSatisfaction -= Time.deltaTime * 5f;

        // Clamp entre 0 et max
        currentSatisfaction -= Time.deltaTime * timeImpactMultiplication;
        

        currentSatisfaction = Mathf.Clamp(currentSatisfaction, 0f, maxSatisfaction);

        UpdateSpectators();
        GameManager.instance.currentGameSatisfaction = currentSatisfaction;
    }

    void UpdateSpectators()
    {
        // Calcule combien doit y avoir de spectateurs actifs
        if (diverted)
        {
            Debug.Log(currentSatisfaction);
            if (lovedHobbie == GameManager.instance.playedActivite)
            {
                currentSatisfaction += divertissement; Debug.Log("Ohh i like it");
            }
            if (hatedHobbie == GameManager.instance.playedActivite)
            {
                currentSatisfaction += divertissement / 3; Debug.Log("Ahh i hate it");
            }
            else
            {
                currentSatisfaction += divertissement / 2;
                Debug.Log("i guess its okey ");
            }


                Debug.Log("le public a etais divertie");
            Debug.Log(currentSatisfaction);
            diverted = false;

        }
        int total = spectators.Count;
        float ratio = currentSatisfaction / maxSatisfaction;      // entre 0 et 1
        int toShow = Mathf.RoundToInt(ratio * total);

        // Active les premiers “toShow” spectateurs, désactive les autres
        for (int i = 0; i < total; i++)
        {
            spectators[i].SetActive(i < toShow);
        }
    }
}
