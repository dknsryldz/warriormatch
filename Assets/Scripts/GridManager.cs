using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Izgara (Grid) Ayarları")]
    public int width = 6;
    public int height = 8;
    public float spacing = 1.2f;

    [Header("Referanslar")]
    public GameObject tilePrefab; // Zemin (Beyaz Kare)
    public GameObject itemPrefab; // Üzerindeki Sembol Şablonu
    public Sprite[] itemSprites;  // 5 muhteşem görselimizi tutacağımız liste

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        float offsetX = (width - 1) * spacing / 2f;
        float offsetY = (height - 1) * spacing / 2f;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // 1. Zemin Karesini Oluştur
                Vector2 position = new Vector2((x * spacing) - offsetX, (y * spacing) - offsetY);
                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity);
                tile.transform.parent = this.transform;
                tile.name = $"Tile {x},{y}";

                // 2. Sembolü Oluştur ve Karenin Çocuğu Yap
                GameObject item = Instantiate(itemPrefab, position, Quaternion.identity);
                item.transform.parent = tile.transform; 
                item.name = $"Item {x},{y}";

                // 3. Sembole Rastgele Bir Görsel Ata
                int randomIndex = Random.Range(0, itemSprites.Length);
                item.GetComponent<SpriteRenderer>().sprite = itemSprites[randomIndex];

                // 4. Görsellerin Boyutunu Ayarla (Karenin içine tam oturması için hafif küçültüyoruz)
                item.transform.localScale = new Vector3(0.8f, 0.8f, 1f); 
            }
        }
    }
}