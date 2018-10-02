using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stash : MonoBehaviour {

    private List<string> stash = new List<string>();

    public void Initialize() {

    }

    public void AddToStash(string code) {
        stash.Add(code);
    }

    public List<string> GetStashList() {
        return stash;
    }

    public void ClearStash() {
        stash.Clear();
    }
}
