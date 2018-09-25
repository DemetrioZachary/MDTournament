using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabContainer : MonoBehaviour {
    [Space]
    public FundCard fundCardPrefab;
    public MeleeWeaponCard meleeWeaponCardPrefab;
    public RangedWeaponCard rangedWeaponCardPrefab;
    public HighlightCard highlightCardPrefab;
    public CrewMemberCard crewMemberCardPrefab;
    public AmmoCard ammoCardPrefab;


    private static PrefabContainer s_Instance = null;

    public static PrefabContainer instance {
        get {
            if (s_Instance == null) {
                Debug.LogError("Missing prefab container");
            }
            return s_Instance;
        }
    }

    private void Awake() {
        s_Instance = FindObjectOfType<PrefabContainer>();
    }

    public Card GetCardPrefabByType(CardType type) {
        switch (type) {
            case CardType.Fund:
                return fundCardPrefab;
            case CardType.MeleeWeapon:
                return meleeWeaponCardPrefab;
            case CardType.RangedWeapon:
                return rangedWeaponCardPrefab;
            case CardType.Highlight:
                return highlightCardPrefab;
            case CardType.CrewMember:
                return crewMemberCardPrefab;
            case CardType.Ammo:
                return ammoCardPrefab;
            default:
                return null;
        }
    }
}
