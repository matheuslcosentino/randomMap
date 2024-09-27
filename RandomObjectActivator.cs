using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class RandomObjectActivator : MonoBehaviour
{
    public List<GameObject> objectsToActivate; // Lista de objetos configuráveis no Inspector
    public int numberOfObjectsToActivate = 3; // Número de objetos a serem ativados

    void Start()
    {
        // Garante que não tentamos ativar mais objetos do que existem na lista
        numberOfObjectsToActivate = Mathf.Clamp(numberOfObjectsToActivate, 0, objectsToActivate.Count);
        
        // Desativa todos os objetos no início
        DeactivateAllObjects();
        
        // Ativa uma quantidade aleatória de objetos
        ActivateRandomObjects();
    }

    // Função para desativar todos os objetos da lista
    void DeactivateAllObjects()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(false); // Desativa o objeto
        }
    }

    // Função para ativar um número aleatório de objetos
    void ActivateRandomObjects()
    {
        // Cria uma lista temporária para armazenar os índices dos objetos já ativados
        List<int> activatedIndices = new List<int>();

        // Ativa o número de objetos definido
        for (int i = 0; i < numberOfObjectsToActivate; i++)
        {
            int randomIndex;
            
            // Garante que não ativaremos o mesmo objeto duas vezes
            do
            {
                randomIndex = Random.Range(0, objectsToActivate.Count);
            } while (activatedIndices.Contains(randomIndex));
            
            activatedIndices.Add(randomIndex);
            
            // Ativa o objeto correspondente
            objectsToActivate[randomIndex].SetActive(true);
        }
    }
}
