using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private static IList<int> sceneOrder = new List<int>() { 1, 6 };
    private static IList<int> scenesOneOrder = new List<int>() { 2, 3, 4, 5 };
    private static IList<int> scenesTwoOrder = new List<int>() { 7, 8, 9, 10 };
    private static bool not_yet_randomized = true;
    private static IEnumerator<int> sceneIterator;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (not_yet_randomized)
            {
                not_yet_randomized = false;
                // determine a random order for the following scenes
                sceneOrder.Shuffle();
                scenesOneOrder.Shuffle();
                scenesTwoOrder.Shuffle();
                foreach (int scene in scenesOneOrder)
                {
                    sceneOrder.Insert(sceneOrder.IndexOf(1) + 1, scene);
                }
                foreach (int scene in scenesTwoOrder)
                {
                    sceneOrder.Insert(sceneOrder.IndexOf(6) + 1, scene);
                }
                // write the scene order we decided into a file:
                Debug.Log("Scene Order will be: " + string.Join(", ", sceneOrder.Select(x => x.ToString()).ToArray()));
                // add the special notification scenes:
                sceneOrder.Add(11); // add a scene at the end
                sceneOrder.Insert(5, 12); // insert scene number 12 at position 6, i.e. after the first five scenes
                Debug.Log("Scene Order (with special scenes) will be: " + string.Join(", ", sceneOrder.Select(x => x.ToString()).ToArray()));
                // get an iterator that can be used later
                sceneIterator = sceneOrder.GetEnumerator();
            }
            // switch to the next scene in the randomized order
            if (sceneIterator.MoveNext()) {
                SceneManager.LoadScene(sceneIterator.Current);
            } else {
                // end of scenes! TODO
            }
        }
    }
}
