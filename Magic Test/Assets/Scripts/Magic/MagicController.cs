using UnityEngine;

public class MagicController : MonoBehaviour
{

    float[] magicCooldown;
    float[] mcd = { 0, 0, 0, 0 };

    public GameObject MagicSymbols;

    public Magic[] selectedMagics;
    MagicSymbol[] symbolsImage;

    void Start()
    {
        symbolsImage = MagicSymbols.GetComponentsInChildren<MagicSymbol>();
    }

    void Update()
    {
        for (int i = 0; i < mcd.Length; i++)
        {
            mcd[i] -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && mcd[0] <= 0)
        {
            selectedMagics[0].Activate();
            mcd[0] = selectedMagics[0].GetCooldown();
            symbolsImage[0].StartCooldown(mcd[0]);
        }

        if (Input.GetKeyDown(KeyCode.Q) && mcd[1] <= 0)
        {
            selectedMagics[1].Activate();
            mcd[1] = selectedMagics[1].GetCooldown();
            symbolsImage[1].StartCooldown(mcd[1]);
        }

        if (Input.GetKeyDown(KeyCode.V) && mcd[2] <= 0)
        {
            selectedMagics[2].Activate();
            mcd[2] = selectedMagics[2].GetCooldown();
            symbolsImage[2].StartCooldown(mcd[2]);
        }

        if (Input.GetKeyDown(KeyCode.F) && mcd[3] <= 0)
        {
            selectedMagics[3].Activate();
            mcd[3] = selectedMagics[3].GetCooldown();
            symbolsImage[3].StartCooldown(mcd[3]);
        }
    }

    public Magic[] GetMagics()
    {
        return selectedMagics;
    }

    public void updateMagics(Magic[] magics)
    {
        selectedMagics = magics;
    }
    
}
