using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trash_Generator : MonoBehaviour
{
    public RectTransform Spawn_Position;
    public Transform Canvas_Position;
    public Sprite[] Trashes;
    public GameObject TrashPrefab;
    public void CreateTrash()
    {
             Sprite randomeSprites = Trashes[Random.Range(0, Trashes.Length)];
             GameObject trashObject = Instantiate(TrashPrefab, Spawn_Position.transform);
             trashObject.transform.SetParent(Canvas_Position);
             Image take_GameObject = trashObject.GetComponent<Image>();            
             take_GameObject.sprite = randomeSprites;
           

    }
}
