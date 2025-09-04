using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stagecnt : MonoBehaviour
{
    public int stagecnt = 1;
    public int Maxstage = 10;
    public int dungeonstagecnt = 1;
    public int Maxdungeonstage = 10;
    public TMP_Text stageText;
    public TMP_Text dungeonstage;

   void Start()
   {
         stageText.text = stagecnt.ToString();
         
    }

    public void UpdateStage()
    {
        if (stagecnt >= Maxstage)
        {
            stagecnt = 0;
            dungeonstagecnt = 0;
        }
        stagecnt++;        
        dungeonstagecnt++;
        dungeonstage.text = dungeonstagecnt.ToString();
        stageText.text = stagecnt.ToString();
       
    }
}
