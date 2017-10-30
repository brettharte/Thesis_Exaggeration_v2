using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A simple extension to allow shuffling lists
/// </summary>
public static class IListExtensions
{
    private static System.Random rng = new System.Random();

    /// <summary>
    /// Shuffles the element order of the specified list using Fisher-Yates shuffle.
    /// </summary>
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1) {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}


public class Randomized_Order_Loading : MonoBehaviour {
    // the possible scenes to be loaded in randomized order:
    private static IList<int> sceneOrder = new List<int>() { 2, 3, 4 };
    private static bool not_yet_randomized = true;
    private static IEnumerator<int> sceneIterator;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (not_yet_randomized) {
                not_yet_randomized = false;
                // determine a random order for the following scenes
                sceneOrder.Shuffle();
                // get an iterator that can be used later
                sceneIterator = sceneOrder.GetEnumerator();
                // and for now switch to the 0% scene
                SceneManager.LoadScene("softbody_O");
            } else {
                // switch to the next scene in the randomized order
                if (sceneIterator.MoveNext()) {
                    SceneManager.LoadScene(sceneIterator.Current);
                } else {
                    // end of scenes! TODO
                }
            }
        }
    }
}
