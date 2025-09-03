using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stagecnt : MonoBehaviour
{
   public int stagecnt = 1;
   public int Maxstage = 10;
   public TMP_Text stageText;

   void Start()
   {
         stageText.text = stagecnt.ToString();
         
    }

    public void UpdateStage()
    { 
        stagecnt++;
        stageText.text = stagecnt.ToString();
        if(stagecnt > Maxstage)
        {
            stagecnt = 1;
        }
    }
}
