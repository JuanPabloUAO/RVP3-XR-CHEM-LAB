
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class MachineManager : MonoBehaviour
{
    [Header("Sockets")]
    public XRSocketInteractor socketA;
    public XRSocketInteractor socketB;

    [Header("Settings")]
    public bool hasReacted = false;

    private void Update()
    {
        if (GameManager.Instance.CurrentState != GameState.Playing)
            return;

        if (hasReacted)
            return;

        if (socketA.hasSelection && socketB.hasSelection)
        {
            Chemical chemicalA =
                socketA.GetOldestInteractableSelected()
                .transform.GetComponent<Chemical>();

            Chemical chemicalB =
                socketB.GetOldestInteractableSelected()
                .transform.GetComponent<Chemical>();

            if (chemicalA == null || chemicalB == null)
                return;

            EvaluateReaction(chemicalA, chemicalB);

            hasReacted = true;

            Invoke(nameof(ResetMachine), 2f);
        }
    }

    void EvaluateReaction(Chemical a, Chemical b)
    {
        Debug.Log(a.chemicalType + " + " + b.chemicalType);

        // CORRECT REACTION
        if (
            (a.chemicalType == ChemicalType.Red &&
             b.chemicalType == ChemicalType.Blue)
            ||
            (a.chemicalType == ChemicalType.Blue &&
             b.chemicalType == ChemicalType.Red)
        )
        {
            Debug.Log("CORRECT REACTION");

            ScoreManager.Instance.AddScore(100);

            GameEvents.OnCorrectReaction?.Invoke();
        }

        // TOXIC REACTION
        else if (
            (a.chemicalType == ChemicalType.Green &&
             b.chemicalType == ChemicalType.Blue)
            ||
            (a.chemicalType == ChemicalType.Blue &&
             b.chemicalType == ChemicalType.Green)
        )
        {
            Debug.Log("TOXIC GAS");

            ScoreManager.Instance.RemoveScore(25);

            GameEvents.OnBadReaction?.Invoke();
        }

        // FAIL REACTION
        else
        {
            Debug.Log("FAILED REACTION");

            ScoreManager.Instance.RemoveScore(10);

            GameEvents.OnBadReaction?.Invoke();
        }
    }

    void ResetMachine()
    {
        hasReacted = false;
    }
}
