using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CrowdScript : MonoBehaviour
{
    private int divertissement;
    private bool diverted;
    public float timeImpactMultiplication;

    private string[] Hobbies = {"music","cooking","painting"};

    [Header("Réglages")]
    [Tooltip("Prefab du spectateur.")]
    public GameObject spectatorPrefab;
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
    public int spectatorCount = 18;
    [Tooltip("Position du premier spectateur (coin gauche)")]
    public Vector2 startPosition = new Vector2(-8f, -3.5f);
    public Vector2 startPosition2 = new Vector2(-26f, -2.2f);
    [Tooltip("Distance entre chaque spectateur sur X")]
    public float spacingX = 1f;

    private List<GameObject> spectators = new List<GameObject>();

    string lovedHobbie;
    string hatedHobbie;
    void Start()
    {
        currentSatisfaction = GameManager.instance.currentGameSatisfaction;
        divertissement = GameManager.instance.scoreMiniGame;
        diverted = GameManager.instance.hadBeenDiverted;
        Debug.Log(diverted);

        // pour l'instant c'est moi qui decide la quelle est choisis
        lovedHobbie = Hobbies[0];
        hatedHobbie = Hobbies[1];

        // Instancier tous les spectateurs en file
        for (int i = 0; i < spectatorCount; i++)
        {
            // Calcul de la position : start + (i * spacing) vers la droite
            Vector2 pos;
            if (i < 9) 
            {   pos = startPosition + Vector2.right * (i * spacingX); }
            else
            {
                pos = startPosition2 + Vector2.right * (i * spacingX);
            }

                GameObject go = Instantiate(spectatorPrefab, pos, Quaternion.identity, transform);

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
