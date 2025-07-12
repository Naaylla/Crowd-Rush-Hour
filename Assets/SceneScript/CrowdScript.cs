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
    [SerializeField] Transform[] spawnPoints;

    [Tooltip("Valeur maximale de la jauge.")]
    public float maxSatisfaction = 100f;

    [Header("Données dynamiques")]
    [Range(0, 100)]
    [Tooltip("Jauge courante de satisfaction.")]
    public float currentSatisfaction;


    [Header("Génération de la rangée")]
    [Tooltip("Nombre de spectateurs maximum")]
    public int spectatorCount = 12;

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

        // Defintion du Hobbie aimer et detester
        int lovdHobbie = Random.Range(0, 3);
        int hatdHobbie = Random.Range(0,3);
        while (lovdHobbie == hatdHobbie) {
            hatdHobbie = Random.Range(0, 3);
        }

        
        lovedHobbie = GameManager.instance.Hobbies[lovdHobbie];
        hatedHobbie = GameManager.instance.Hobbies[hatdHobbie];

        int randomNum;
        
        
        for (int i = 0; i < spectatorCount; i++)
        {
            Vector3 pos;
            randomNum = Random.Range(0, 3);

            pos = spawnPoints[i].position;
            // Calcul de la position : start + (i * spacing) vers la droite

            specPrefRendrer[randomNum].sortingOrder = spectatorCount - i;

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
        /*if (diverted)
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
                currentSatisfaction += divertissement - (divertissement/3);
                Debug.Log("i guess its okey ");
            }


            Debug.Log("le public a etais divertie");
            Debug.Log(currentSatisfaction);
            diverted = false;

        }
        */
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
