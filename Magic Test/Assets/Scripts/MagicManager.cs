using UnityEngine;

public class MagicManager : MonoBehaviour
{
    Magic[] selectedMagics = { null, null, null, null };
    MagicController mc;

    [SerializeField]
    Magic[] allMagics;

    public Magic[] getSelectedMagics()
    {
        return selectedMagics;
    }

    public Magic[] getAllMagics()
    {
        return allMagics;
    }

    void SwapMagic(int position, Magic magic)
    {
        selectedMagics[position] = magic;
    }

    void Start()
    {
        mc = GameObject.Find("Player").GetComponent<MagicController>();


        int c = 0;
        foreach (Magic magic in allMagics)
        {
            if(magic.getSelected())
            {
                selectedMagics[c] = magic;
                
                c++;
            }
        }
        
        //mc.updateMagics(selectedMagics);
    }

    void Update()
    {
        
    }
}
