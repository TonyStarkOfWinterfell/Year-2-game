using UnityEngine;
using UnityEditor;
using System.Text;

[CreateAssetMenu(menuName = "Items/Item")]
public class Item : ScriptableObject
{
    [SerializeField] string id;
    public string ID { get { return id; } }
    public string ItemName;
    [Range(1,999)]
    public int MaximumStacks = 1;
    public Sprite Icon;

    private void OnValidate()    // if unity editor - why have/nothave
    {
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);
    }

    public virtual Item GetCopy()
    {
        return this;
    }

    public virtual void Destroy()
    {
        
    }

    //get item type
}
