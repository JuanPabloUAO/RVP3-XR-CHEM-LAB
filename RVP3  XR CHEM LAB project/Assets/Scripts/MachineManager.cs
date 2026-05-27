using UnityEngine;


public class MachineManager : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socketA;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socketB;

    public void ProcessChemicals()
    {
        if (!socketA.hasSelection || !socketB.hasSelection)
        {
            Debug.Log("Faltan químicos");
            return;
        }

        Chemical chemicalA =
            socketA.firstInteractableSelected.transform.GetComponent<Chemical>();

        Chemical chemicalB =
            socketB.firstInteractableSelected.transform.GetComponent<Chemical>();

        if (chemicalA == null || chemicalB == null)
        {
            Debug.Log("Objeto inválido");
            return;
        }

        CheckCombination(chemicalA, chemicalB);
    }

    private void CheckCombination(Chemical a, Chemical b)
    {
        if (
            (a.chemicalType == ChemicalType.Red &&
             b.chemicalType == ChemicalType.Blue)

            ||

            (a.chemicalType == ChemicalType.Blue &&
             b.chemicalType == ChemicalType.Red)
        )
        {
            Debug.Log("Combinación correcta");

            ScoreManager.Instance.AddScore(100);
            GameEvents.OnCorrectReaction?.Invoke();
        }
        else
        {
            Debug.Log("Combinación incorrecta");

            ScoreManager.Instance.RemoveScore(25);
            GameEvents.OnCorrectReaction?.Invoke();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ProcessChemicals();
        }
    }
}