using UnityEngine;
using UnityEngine.UI;

public class MagicManager : MonoBehaviour
{
    Magic[] selectedMagics = { null, null, null, null };

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

    public void SwapMagic(int position, Sprite magic)
    {
        foreach (Magic m in allMagics)
        {
            if(m.getSprite().Equals(magic))
            {
                selectedMagics[position].setSelected(false);
                m.setSelected(true);
                selectedMagics[position] = m;
                break;
            }
        }
    }

    void Start()
    {
        int c = 0;
        foreach (Magic magic in allMagics)
        {
            if(magic.getSelected())
            {
                selectedMagics[c] = magic;
                c++;
            }
        }
    }
}
