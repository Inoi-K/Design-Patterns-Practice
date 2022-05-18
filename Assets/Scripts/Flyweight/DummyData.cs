using UnityEngine;

[CreateAssetMenu(fileName = "New Dummy", menuName = "Flyweight Patter/DummyData")]
public class DummyData : ScriptableObject {
    public float speed;
    public int damage;
    public int maxHealth;
    public string description;
}
