using System.Threading.Tasks;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;
using UnityEngine.UI;

public class LoadAsset : MonoBehaviour
{
    private DatabaseReference dbRef;
    public DataSnapshot firebaseData;
    
    public GameObject logoPrefab;
    public GameObject messagePrefab;

    public GameObject message;
    public GameObject logo;

    public Canvas canvas;

    void Start()
    {
        dbRef = FirebaseDatabase.GetInstance("https://fir-testing-79f84-default-rtdb.europe-west1.firebasedatabase.app/").RootReference;
        Test();
    }

    public async Task Test()
    {
        firebaseData = await dbRef.GetValueAsync();
        Debug.Log(firebaseData.GetRawJsonValue());
    }

    public void LoadLogo()
    {
        if (logo != null)
            Destroy(logo);

        logo = Instantiate(logoPrefab);
        logo.name = "Logo";
    }

    public void LoadMessage()
    {
        if (message != null)
            Destroy(message);

        message = Instantiate(messagePrefab);
        message.transform.SetParent(canvas.transform, false);
        message.name = "Message";
    }

}
